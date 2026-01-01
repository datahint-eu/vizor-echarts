# Generator Improvement Plan: Comprehensive Type Mapping

## Goal
Generate strong types for **all** ECharts properties, eliminating `object` fallbacks (except truly dynamic cases) and providing clear diagnostics for unsupported type patterns.

---

## Current State Analysis

### Fallback Points (Need Fixing)
From [BasePhase.cs](../src/Vizor.ECharts.BindingGenerator/Phases/BasePhase.cs) `MapType()`:

1. **Line 295**: `case "*"` → returns `object` (wildcard types)
2. **Line 218-223**: Unmapped enums → downgrades to `string` with warning
3. **Line 318**: Unmapped arrays → returns `List<object>` with warning  
4. **Line 290-294**: Enum+Function pattern → falls to `object` when enum type unknown
5. **Line 333-338**: Final catch-all → returns `object` for unmapped patterns

### Known Issues
- **Warnings scattered in console** (not aggregated or tracked)
- **Type warnings embedded in generated code** as `//TODO:` comments (not discoverable)
- **No central registry** of what's supported vs. needs investigation
- **Enum type failures** silently downgrade to `string` (fontFamily/cursor exceptions hardcoded)
- **No diagnostic report** showing which patterns block full generation

### Existing Infrastructure to Leverage
- `IPropertyType.TypeWarning` property already present
- [ObjectTypeClassGenerator.cs](../src/Vizor.ECharts.BindingGenerator/Generators/ObjectTypeClassGenerator.cs) already writes warnings as comments
- [warnings.txt](../src/Vizor.ECharts.BindingGenerator/warnings.txt) collects some output
- Test analysis infrastructure in [ManualImplementationAnalysisTests.cs](../src/Vizor.ECharts.Tests/Unit/Generator/ManualImplementationAnalysisTests.cs)

---

## Phase 1: Type Categorization System

### 1.1 Create Diagnostic Infrastructure

**New file**: `src/Vizor.ECharts.BindingGenerator/Diagnostics/TypeMappingDiagnostic.cs`

```csharp
internal class TypeMappingDiagnostic
{
    public string PropertyPath { get; set; }  // "ParentType.PropertyName"
    public List<string> Types { get; set; }  // ["string", "number", "array"]
    public DiagnosticLevel Level { get; set; }
    public string Message { get; set; }
    public string? Suggestion { get; set; }  // "Use NumberOrString"
}

internal enum DiagnosticLevel
{
    Supported,              // Fully mapped
    PartiallySupported,     // Falls back to typed accessor
    Unsupported,            // Falls to object/string
    RequiresInvestigation   // New pattern not yet analyzed
}
```

**New file**: `src/Vizor.ECharts.BindingGenerator/Diagnostics/DiagnosticCollector.cs`

```csharp
internal class DiagnosticCollector
{
    private readonly List<TypeMappingDiagnostic> diagnostics = new();
    
    public void RecordSupported(string path, List<string> types) { }
    public void RecordPartiallySupported(string path, List<string> types, string fallback) { }
    public void RecordUnsupported(string path, List<string> types, string? suggestion = null) { }
    
    public DiagnosticReport GenerateReport() { }
}
```

### 1.2 Create Type Pattern Registry

**New file**: `src/Vizor.ECharts.BindingGenerator/Types/TypePatternRegistry.cs`

Centralize all type mapping knowledge:

```csharp
internal class TypePatternRegistry
{
    // Fully supported patterns (1-element types)
    private readonly HashSet<string> primitiveTypes = new() { "string", "number", "boolean", "object", "color", "function", "array", "*" };
    
    // Enum mappings (already in TypeCollection)
    public bool TryGetEnumMapping(string propName, string parentName, out MappedEnumType enumType) { }
    
    // Custom union types (2+ elements)
    private readonly Dictionary<string, Type> supportedPatterns = new()
    {
        { "boolean,number", typeof(NumberOrBool) },
        { "boolean,string", typeof(BoolOrString) },
        { "number,string", typeof(NumberOrString) },
        // ... all existing patterns
    };
    
    // Partially supported (typed accessor needed)
    private readonly HashSet<string> needsTypedAccessor = new()
    {
        { "enum,function" },     // FunnelSeries.sort - has typed accessors
        // ... others
    };
    
    // Not yet supported
    private readonly HashSet<string> unsupported = new();
    
    public bool IsSupported(List<string> types, out IPropertyType mappedType) { }
    public bool IsPartiallySupported(List<string> types, string parentName) { }
    public bool IsUnsupported(List<string> types, out string reason) { }
}
```

---

## Phase 2: Refactor MapType() for Clarity

### 2.1 Restructure Decision Logic

Replace the large `MapType()` method with decision branches:

```csharp
protected virtual IPropertyType? MapType(ObjectType parent, OptionProperty optProp, JsonProperty prop)
{
    var types = optProp.Types ?? new();
    
    // 1. Single type → simple mapping
    if (types.Count == 1)
        return MapSingleType(parent, optProp, prop);
    
    // 2. Known union pattern → custom type
    if (typePatternRegistry.TryGetPattern(types, out var customType))
        return customType;
    
    // 3. Partially supported → typed accessor
    if (typePatternRegistry.IsPartiallySupported(types, parent.Name))
        return MapPartiallySupported(parent, optProp, prop);
    
    // 4. Unknown pattern → diagnostic + decision
    diagnosticCollector.RecordUnsupported(
        $"{parent.Name}.{prop.Name}", 
        types,
        suggestion: SuggestMapping(types, optProp));
    
    return GetFallbackType(types, parent, prop);  // object or specific typed accessor
}
```

### 2.2 Extract Single-Type Mapping

```csharp
protected virtual IPropertyType? MapSingleType(ObjectType parent, OptionProperty optProp, JsonProperty prop)
{
    var type = optProp.Types![0];
    
    switch (type)
    {
        case "string": return new SimpleType("string");
        case "number": return new SimpleType(IsIndexProperty(prop.Name) ? "int" : "double");
        case "boolean": return new SimpleType("bool");
        case "color": return new MappedCustomType(typeof(Color));
        case "function": return new MappedCustomType(typeof(JavascriptFunction));
        case "enum": return MapEnumType(parent, optProp, prop);
        case "array": return typeCollection.MapArrayType(parent, optProp, prop);
        case "*": 
            diagnosticCollector.RecordUnsupported($"{parent.Name}.{prop.Name}", new() { "*" });
            return new SimpleType("object");
    }
    
    throw new ArgumentException($"Unknown single type: {type}");
}
```

### 2.3 Dedicated Enum Mapping

```csharp
protected virtual IPropertyType? MapEnumType(ObjectType parent, OptionProperty optProp, JsonProperty prop)
{
    if (typeCollection.TryGetMappedEnumType(prop.Name, parent.Name, out var enumType))
        return enumType;
    
    // Known exceptions (safe to downgrade)
    if (prop.Name == "fontFamily" || prop.Name == "cursor")
        return new SimpleType("string");
    
    // Unknown enum → diagnostic + fallback
    diagnosticCollector.RecordUnsupported(
        $"{parent.Name}.{prop.Name}",
        new() { "enum" },
        suggestion: $"Add enum mapping: AddMappedEnumType(new(\"{prop.Name}\", typeof(???)), \"{parent.Name}\");");
    
    return new SimpleType("string");
}
```

---

## Phase 3: Pattern Discovery & Documentation

### 3.1 Build Pattern Analysis Test

**New test**: `src/Vizor.ECharts.Tests/Unit/Generator/TypePatternAnalysisTests.cs`

```csharp
[TestMethod]
public void AnalyzeAllTypePatterns()
{
    // Run generator on option.json
    // Collect diagnostics
    // Group by pattern
    // Report on:
    //   - Fully supported: 85 patterns
    //   - Partially supported: 5 patterns (need typed accessor)
    //   - Unsupported: 12 patterns (need custom types)
    //   - Requires investigation: 3 patterns (edge cases)
    
    var report = diagnosticCollector.GenerateReport();
    File.WriteAllText("TypePatternAnalysisReport.md", report.ToMarkdown());
}
```

### 3.2 Pattern Suggestion Engine

```csharp
private string SuggestMapping(List<string> types, OptionProperty optProp)
{
    var typeStr = string.Join(",", types);
    
    if (types.Count == 2)
    {
        var key = string.Join(",", types.OrderBy(t => t));
        
        // Check if custom type should exist
        if (!ShouldBeObject(key))
            return $"Create custom type 'Union{key.Replace(",", "Or")}' (see pattern examples in doc/Manual_Implementation_Analysis.md)";
    }
    
    if (types.Contains("enum") && optProp.EnumOptions?.Length > 0)
        return $"Auto-generate enum: {{{string.Join(", ", optProp.EnumOptions)}}}";
    
    return "Too complex for automation - requires manual implementation or typed accessor";
}

private bool ShouldBeObject(string pattern)
{
    // Patterns that are legitimately too complex
    var reallyComplex = new[] { "enum,function", "*,number", "date,object,string" };
    return reallyComplex.Contains(pattern);
}
```

---

## Phase 4: Implementation Strategy

### 4.1 Execution Order

**Week 1**: Diagnostics foundation
- [ ] Create `DiagnosticCollector` and `TypeMappingDiagnostic`
- [ ] Create `TypePatternRegistry` with all known patterns
- [ ] Add diagnostics calls to `MapType()` (minimal changes)

**Week 2**: Refactor MapType()
- [ ] Extract `MapSingleType()`
- [ ] Extract `MapEnumType()`
- [ ] Extract `MapPartiallySupported()`
- [ ] Reorganize with clear decision tree

**Week 3**: Analysis & reporting
- [ ] Build pattern discovery test
- [ ] Generate report of all patterns
- [ ] Document patterns by category
- [ ] Suggest concrete next patterns to implement

**Week 4**: Close gaps
- [ ] Implement highest-priority custom types
- [ ] Add enum mappings for missing patterns
- [ ] Update TypeCollection with new patterns

### 4.2 Success Criteria

- [ ] All types categorized (Supported / Partially Supported / Unsupported / Investigation)
- [ ] Zero console output (all diagnostics collected, not printed)
- [ ] Generated code has no `//TODO: Type Warning` comments
- [ ] Report shows improvement: `Unsupported: 0` (or near-zero with documented rationale)
- [ ] New developers can follow: "If property isn't supported, see TypePatternAnalysisReport.md"

---

## Phase 5: Handling Truly Unsupported Cases

### 5.1 Categories That Must Remain `object`

```csharp
/// <summary>
/// Patterns too complex for strong typing (requires manual accessor pattern).
/// Keep as 'object?' in generated code; provide typed accessors manually.
/// </summary>
private readonly HashSet<string> mustRemainObject = new()
{
    "enum,function",           // FunnelSeries.sort - needs both enum AND function
    "*,number",               // itemGap - truly ambiguous
    "date,object,number,string" // Too many variations
};
```

For these, generate:
```csharp
/// <summary>
/// [UNSUPPORTED PATTERN: enum,function]
/// Cannot be strongly typed. Use typed accessor pattern:
/// public MyEnum? TypeAsEnum { get; set; }
/// public JavascriptFunction? TypeAsFunction { get; set; }
/// </summary>
[JsonPropertyName("type")]
public object? Type { get; set; }

[JsonIgnore]
public MyEnum? TypeAsEnum 
{ 
    get => Type as MyEnum; 
    set => Type = value; 
}

[JsonIgnore]
public JavascriptFunction? TypeAsFunction 
{ 
    get => Type as JavascriptFunction; 
    set => Type = value; 
}
```

---

## Deliverables

### Generated Files
1. `TypeMappingDiagnostic.cs` - Diagnostic type
2. `DiagnosticCollector.cs` - Collection & reporting
3. `TypePatternRegistry.cs` - Central pattern knowledge
4. `TypePatternAnalysisReport.md` - Pattern categorization
5. Refactored `BasePhase.cs` - Clear decision logic

### Documentation
- **doc/Generator_Improvement_Plan.md** (this file)
- **doc/TypePatternAnalysisReport.md** (auto-generated from test)
- **doc/TypePatternsGuide.md** - How to add new patterns
- Updated `IMPROVEMENTS.md` with generator progress

### Test Coverage
- `TypePatternAnalysisTests.cs` - Pattern discovery
- `DiagnosticCollectorTests.cs` - Diagnostic collection
- Generator regression tests (ensure existing patterns still work)

---

## Quick Reference: Existing Custom Types

**Already Supported** (in `src/Vizor.ECharts/Types/`):
- `NumberOrBool`
- `BoolOrString` 
- `NumberOrString`
- `NumberOrNumberArray`
- `StringOrFunction`
- `NumberOrFunction`
- `ObjectOrFunction`
- `ColorOrFunction`
- `NumberOrStringOrFunction`
- `NumberArrayOrFunction`
- `NumberArray`
- `ColorArray`
- `NumberOrStringArray`
- `SingleOrArrayType<T>` (Grid, XAxis, YAxis pattern)
- `EnumOrFunctionType` (exists but incomplete)

**Need Implementation**:
- `EnumOrArray<T>` (array + enum)
- `EnumOrNumber<T>` (enum + number)
- More as discovered in analysis phase

---

## Integration Points

- **Enum mappings** feed from `TypeCollection.AddMappedEnumType()` calls
- **Custom types** discovered in `src/Vizor.ECharts/Types/` via reflection
- **Generated code** uses diagnostics to add helpful comments
- **Test infrastructure** already exists in `ManualImplementationAnalysisTests.cs`

---

## Risk Mitigation

| Risk | Mitigation |
|------|-----------|
| Refactoring breaks generation | Add comprehensive tests before refactor; keep old logic as fallback |
| Report overwhelms with noise | Filter diagnostics by level; focus on "Unsupported" only |
| Missed patterns | Automated pattern discovery; test against all real options |
| Backward compatibility | New system is additive; old warnings still work |

---

## Future Improvements

### Use Arrays for Static Configuration Data

**Rationale**: Many ECharts properties contain static configuration data that is set once during initialization and rarely modified. Using arrays instead of Lists would:
- Reduce memory overhead (no List capacity management)
- Improve cache locality and serialization performance
- Better convey immutability intent
- More idiomatic for read-only configuration

**Affected Properties**:
- `Legend.Data` → change `List<LegendData>?` to `LegendData[]?`
- All axis `Data` properties → change `List<AxisData>?` to `AxisData[]?` in:
  - `XAxis.Data`
  - `YAxis.Data`
  - `AngleAxis.Data`
  - `RadiusAxis.Data`
  - `ParallelAxis.Data`
  - `SingleAxis.Data`
- Consider other static data collections (series data arrays, radar indicators, etc.)

**Implementation**:
- Add logic in generator to detect "data" properties and emit arrays instead of Lists
- Alternatively, add explicit property mappings in BasePhase for known static data types
- Breaking change - requires updates to all sample/test code

**Priority**: Medium (quality-of-life improvement, not blocking functionality)

---

## Next Steps

1. **Review & validate** this plan with team
2. **Start Phase 1** (Diagnostics foundation)
3. **Weekly sync** on analysis results
4. **Prioritize** custom type implementations based on usage frequency
