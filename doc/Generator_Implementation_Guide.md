# Generator Improvement: Code Examples & Implementation Guide

## Part 1: Diagnostic Infrastructure (Phase 1)

### Step 1: Create TypeMappingDiagnostic.cs

```csharp
// src/Vizor.ECharts.BindingGenerator/Diagnostics/TypeMappingDiagnostic.cs

namespace Vizor.ECharts.BindingGenerator.Diagnostics;

internal enum DiagnosticLevel
{
    /// <summary>Fully supported with strong type</summary>
    Supported,
    
    /// <summary>Falls back to object? with typed accessors</summary>
    PartiallySupported,
    
    /// <summary>Falls back to object or downgraded type</summary>
    Unsupported,
    
    /// <summary>New pattern - needs investigation</summary>
    RequiresInvestigation
}

internal class TypeMappingDiagnostic
{
    /// <summary>e.g., "CrossStyle.type" or "FunnelSeries.sort"</summary>
    public string PropertyPath { get; set; } = string.Empty;
    
    /// <summary>e.g., ["enum", "number", "array"]</summary>
    public List<string> Types { get; set; } = new();
    
    /// <summary>What was generated</summary>
    public DiagnosticLevel Level { get; set; }
    
    /// <summary>Descriptive message</summary>
    public string Message { get; set; } = string.Empty;
    
    /// <summary>How to fix/improve it</summary>
    public string? Suggestion { get; set; }
    
    /// <summary>Additional context (enum options, examples, etc.)</summary>
    public Dictionary<string, string> Context { get; set; } = new();
    
    public override string ToString()
    {
        var typeStr = string.Join(",", Types);
        return $"[{Level}] {PropertyPath}: {typeStr} → {Message}";
    }
}
```

### Step 2: Create DiagnosticCollector.cs

```csharp
// src/Vizor.ECharts.BindingGenerator/Diagnostics/DiagnosticCollector.cs

namespace Vizor.ECharts.BindingGenerator.Diagnostics;

internal class DiagnosticCollector
{
    private readonly List<TypeMappingDiagnostic> diagnostics = new();
    
    public void RecordSupported(string propertyPath, List<string> types, string mappedType)
    {
        diagnostics.Add(new TypeMappingDiagnostic
        {
            PropertyPath = propertyPath,
            Types = types,
            Level = DiagnosticLevel.Supported,
            Message = $"Mapped to {mappedType}"
        });
    }
    
    public void RecordPartiallySupported(
        string propertyPath, 
        List<string> types, 
        string fallback,
        string suggestion)
    {
        diagnostics.Add(new TypeMappingDiagnostic
        {
            PropertyPath = propertyPath,
            Types = types,
            Level = DiagnosticLevel.PartiallySupported,
            Message = $"Falls back to {fallback} with typed accessors",
            Suggestion = suggestion
        });
    }
    
    public void RecordUnsupported(
        string propertyPath,
        List<string> types,
        string fallback = "object",
        string? suggestion = null)
    {
        diagnostics.Add(new TypeMappingDiagnostic
        {
            PropertyPath = propertyPath,
            Types = types,
            Level = DiagnosticLevel.Unsupported,
            Message = $"Falls back to {fallback}",
            Suggestion = suggestion ?? "Investigate if a custom type is needed"
        });
    }
    
    public void RecordRequiresInvestigation(
        string propertyPath,
        List<string> types,
        string reason)
    {
        diagnostics.Add(new TypeMappingDiagnostic
        {
            PropertyPath = propertyPath,
            Types = types,
            Level = DiagnosticLevel.RequiresInvestigation,
            Message = reason
        });
    }
    
    public DiagnosticReport GenerateReport()
    {
        return new DiagnosticReport(diagnostics);
    }
    
    public IReadOnlyList<TypeMappingDiagnostic> AllDiagnostics => diagnostics.AsReadOnly();
}

internal class DiagnosticReport
{
    private readonly IReadOnlyList<TypeMappingDiagnostic> diagnostics;
    
    public DiagnosticReport(IReadOnlyList<TypeMappingDiagnostic> diagnostics)
    {
        this.diagnostics = diagnostics;
    }
    
    public int SupportedCount => diagnostics.Count(d => d.Level == DiagnosticLevel.Supported);
    public int PartiallyCount => diagnostics.Count(d => d.Level == DiagnosticLevel.PartiallySupported);
    public int UnsupportedCount => diagnostics.Count(d => d.Level == DiagnosticLevel.Unsupported);
    public int InvestigateCount => diagnostics.Count(d => d.Level == DiagnosticLevel.RequiresInvestigation);
    public int TotalCount => diagnostics.Count;
    
    public IEnumerable<IGrouping<string, TypeMappingDiagnostic>> GroupByPattern()
    {
        return diagnostics
            .GroupBy(d => string.Join(",", d.Types.OrderBy(t => t)))
            .OrderByDescending(g => g.Count());
    }
    
    public string ToMarkdown()
    {
        var sb = new StringBuilder();
        sb.AppendLine("# Type Pattern Analysis Report");
        sb.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm}");
        sb.AppendLine();
        sb.AppendLine("## Summary");
        sb.AppendLine($"- Total properties: {TotalCount}");
        sb.AppendLine($"- Fully supported: {SupportedCount} ({100.0 * SupportedCount / TotalCount:F1}%)");
        sb.AppendLine($"- Partially supported: {PartiallyCount} ({100.0 * PartiallyCount / TotalCount:F1}%)");
        sb.AppendLine($"- Unsupported: {UnsupportedCount} ({100.0 * UnsupportedCount / TotalCount:F1}%)");
        sb.AppendLine($"- Requires investigation: {InvestigateCount} ({100.0 * InvestigateCount / TotalCount:F1}%)");
        sb.AppendLine();
        
        // Unsupported patterns section
        var unsupported = diagnostics.Where(d => d.Level == DiagnosticLevel.Unsupported).ToList();
        if (unsupported.Any())
        {
            sb.AppendLine("## Unsupported Patterns");
            foreach (var group in GroupByPattern().Where(g => g.Any(d => d.Level == DiagnosticLevel.Unsupported)))
            {
                var typeStr = group.Key;
                var examples = group.Where(d => d.Level == DiagnosticLevel.Unsupported).Take(3);
                
                sb.AppendLine($"### {typeStr} ({group.Count(d => d.Level == DiagnosticLevel.Unsupported)} occurrences)");
                sb.AppendLine($"Examples: {string.Join(", ", examples.Select(e => e.PropertyPath))}");
                
                var suggestion = examples.FirstOrDefault()?.Suggestion;
                if (suggestion != null)
                    sb.AppendLine($"Action: {suggestion}");
                
                sb.AppendLine();
            }
        }
        
        return sb.ToString();
    }
}
```

### Step 3: Create TypePatternRegistry.cs

```csharp
// src/Vizor.ECharts.BindingGenerator/Types/TypePatternRegistry.cs

namespace Vizor.ECharts.BindingGenerator.Types;

internal class TypePatternRegistry
{
    private readonly TypeCollection typeCollection;
    
    /// <summary>Primitive types that map to simple C# types</summary>
    private static readonly Dictionary<string, string> PrimitiveTypes = new()
    {
        { "string", "string" },
        { "number", "double" },
        { "boolean", "bool" },
        { "object", "object" },
    };
    
    /// <summary>Fully supported 2-3 element union types</summary>
    private static readonly Dictionary<string, Type> SupportedPatterns = new()
    {
        { "boolean,number", typeof(NumberOrBool) },
        { "boolean,string", typeof(BoolOrString) },
        { "number,string", typeof(NumberOrString) },
        { "array,number", typeof(NumberOrNumberArray) },
        { "function,string", typeof(StringOrFunction) },
        { "function,number", typeof(NumberOrFunction) },
        { "function,object", typeof(ObjectOrFunction) },
        { "color,function", typeof(ColorOrFunction) },
        { "array,color", typeof(ColorArray) },
        { "array,number,string", typeof(NumberOrStringArray) },
        { "array,function,number", typeof(NumberArrayOrFunction) },
        { "function,number,string", typeof(NumberOrStringOrFunction) },
        // Add more as needed
    };
    
    /// <summary>Patterns that need typed accessor generation</summary>
    private static readonly HashSet<string> PartiaallySupportedPatterns = new()
    {
        "enum,function",      // FunnelSeries.sort - enum OR function
        // Add more as needed
    };
    
    /// <summary>Patterns too complex for automation - document but keep as object</summary>
    private static readonly HashSet<string> TrulyUnsupported = new()
    {
        "*,number",           // itemGap - ambiguous
        "date,object,number,string",  // Too many options
    };
    
    public TypePatternRegistry(TypeCollection typeCollection)
    {
        this.typeCollection = typeCollection;
    }
    
    /// <summary>Try to get a mapped type for a list of types</summary>
    public bool TryGetMappedType(
        List<string> types,
        string parentName,
        out IPropertyType? mappedType)
    {
        // Single type - primitive mapping
        if (types.Count == 1)
        {
            var type = types[0];
            if (PrimitiveTypes.TryGetValue(type, out var primitiveType))
            {
                mappedType = new SimpleType(primitiveType);
                return true;
            }
        }
        
        // Union type - check supported patterns
        if (types.Count >= 2)
        {
            var key = string.Join(",", types.OrderBy(t => t));
            
            if (SupportedPatterns.TryGetValue(key, out var customType))
            {
                mappedType = new MappedCustomType(customType);
                return true;
            }
        }
        
        mappedType = null;
        return false;
    }
    
    /// <summary>Check if pattern needs typed accessor generation</summary>
    public bool IsPartiallySupported(List<string> types)
    {
        var key = string.Join(",", types.OrderBy(t => t));
        return PartiaallySupportedPatterns.Contains(key);
    }
    
    /// <summary>Check if pattern is truly unsupported (no automation possible)</summary>
    public bool IsTrulyUnsupported(List<string> types, out string reason)
    {
        var key = string.Join(",", types.OrderBy(t => t));
        
        if (TrulyUnsupported.Contains(key))
        {
            reason = $"Pattern '{key}' is too ambiguous for strong typing";
            return true;
        }
        
        reason = string.Empty;
        return false;
    }
    
    /// <summary>Get all known patterns for documentation</summary>
    public IEnumerable<string> GetAllSupportedPatterns()
    {
        return SupportedPatterns.Keys.Concat(PartiaallySupportedPatterns);
    }
}
```

---

## Part 2: Refactored MapType() (Phase 2)

### Before: Large complex method (simplified example)

```csharp
protected virtual IPropertyType? MapType(ObjectType parent, OptionProperty optProp, JsonProperty prop)
{
    if (optProp.Types == null || optProp.Types.Count == 0)
        throw new ArgumentException($"JSON property '{prop.Name}' could not be mapped: no type info available");

    // First try mapping enum types by name
    if (typeCollection.TryGetMappedEnumType(prop.Name, parent.Name, out var mappedEnumType))
        return mappedEnumType;
    
    // Detect single-or-array pattern (Grid, XAxis, YAxis, etc.)
    if (IsArrayAndObject(optProp) && optProp.ItemType != null)
    {
        var innerType = optProp.ItemType;
        if (innerType is IObjectType objType)
        {
            return new SingleOrArrayType(objType.DotNetType);
        }
    }
    
    // Matching based on types: simple first
    if (optProp.Types.Count == 1)
    {
        switch (optProp.Types[0])
        {
            case "object":
                return ParseObjectType(optProp, prop.Name, prop.Value, dataPrefix: prop.Name, typeGroup: "Options");
            case "enum":
                if (prop.Name != "fontFamily" && prop.Name != "cursor")
                {
                    Console.WriteLine($"WARNING: enum type '{prop.Name}' in '{parent.Name}' ...");
                    return new SimpleType("string")
                    {
                        TypeWarning = $"enum type '{prop.Name}' in '{parent.Name}' ..."
                    };
                }
                return new SimpleType("string");
            case "string":
                return new SimpleType("string");
            case "number":
                if (prop.Name.Contains("index", StringComparison.InvariantCultureIgnoreCase))
                    return new SimpleType("int");
                else
                    return new SimpleType("double");
            case "boolean":
                return new SimpleType("bool");
            // ... 50+ more cases ...
        }
    }
    
    // ... complex matching section with nested if/else ...
    
    // Finally, catch-all fallback
    Console.WriteLine($"ERROR: Failed to map property '{prop.Name}' in type '{parent.Name}' ...");
    return new SimpleType("object")
    {
        TypeWarning = $"Failed to map property ..."
    };
}
```

### After: Clear decision tree

```csharp
// src/Vizor.ECharts.BindingGenerator/Phases/BasePhase.cs (snippet)

private DiagnosticCollector diagnosticCollector = new();
private TypePatternRegistry typePatternRegistry;

protected virtual IPropertyType? MapType(ObjectType parent, OptionProperty optProp, JsonProperty prop)
{
    if (optProp.Types == null || optProp.Types.Count == 0)
        throw new ArgumentException($"JSON property '{prop.Name}' could not be mapped");

    var types = optProp.Types;
    var path = $"{parent.Name}.{prop.Name}";
    
    // ═════════════════════════════════════════════════════════════
    // Step 1: Primitive types (enum, string, number, boolean, etc.)
    // ═════════════════════════════════════════════════════════════
    if (types.Count == 1)
    {
        var result = MapSingleType(parent, optProp, prop);
        if (result != null)
        {
            diagnosticCollector.RecordSupported(path, types, result.DotNetType);
            return result;
        }
    }
    
    // ═════════════════════════════════════════════════════════════
    // Step 2: Known union patterns (boolean,string → BoolOrString)
    // ═════════════════════════════════════════════════════════════
    if (typePatternRegistry.TryGetMappedType(types, parent.Name, out var customType))
    {
        diagnosticCollector.RecordSupported(path, types, customType!.DotNetType);
        return customType;
    }
    
    // ═════════════════════════════════════════════════════════════
    // Step 3: Partially supported (enum,function → object + typed accessors)
    // ═════════════════════════════════════════════════════════════
    if (typePatternRegistry.IsPartiallySupported(types))
    {
        var result = MapPartiallySupported(parent, optProp, prop);
        diagnosticCollector.RecordPartiallySupported(
            path,
            types,
            "object",
            suggestion: "Use typed accessor pattern (see ObjectOrFunction)");
        return result;
    }
    
    // ═════════════════════════════════════════════════════════════
    // Step 4: Special cases (array+object → SingleOrArrayType<T>)
    // ═════════════════════════════════════════════════════════════
    if (IsArrayAndObject(optProp) && optProp.ItemType != null)
    {
        var result = MapArrayAndObject(parent, optProp, prop);
        if (result != null)
        {
            diagnosticCollector.RecordSupported(path, types, result.DotNetType);
            return result;
        }
    }
    
    // ═════════════════════════════════════════════════════════════
    // Step 5: Fallback (unsupported pattern)
    // ═════════════════════════════════════════════════════════════
    
    // Check if pattern is known to be complex
    if (typePatternRegistry.IsTrulyUnsupported(types, out var reason))
    {
        diagnosticCollector.RecordUnsupported(
            path,
            types,
            fallback: "object",
            suggestion: reason);
        return new SimpleType("object")
        {
            TypeWarning = reason
        };
    }
    
    // Unknown pattern - flag for investigation
    var suggestion = SuggestMapping(types, optProp);
    diagnosticCollector.RecordUnsupported(
        path,
        types,
        fallback: "object",
        suggestion: suggestion);
    
    return new SimpleType("object")
    {
        TypeWarning = $"Pattern '{string.Join(",", types)}' not yet mapped. Suggestion: {suggestion}"
    };
}

/// <summary>Map single type (string, number, boolean, etc.)</summary>
protected virtual IPropertyType? MapSingleType(ObjectType parent, OptionProperty optProp, JsonProperty prop)
{
    var type = optProp.Types![0];
    
    // Try enum first
    if (type == "enum")
        return MapEnumType(parent, optProp, prop);
    
    // Primitives
    return type switch
    {
        "string" => new SimpleType("string"),
        "number" => new SimpleType(IsIndexProperty(prop.Name) ? "int" : "double"),
        "boolean" => new SimpleType("bool"),
        "color" => new MappedCustomType(typeof(Color)),
        "function" => new MappedCustomType(typeof(JavascriptFunction)),
        "object" => ParseObjectType(optProp, prop.Name, prop.Value, dataPrefix: prop.Name, typeGroup: "Options"),
        "array" => typeCollection.MapArrayType(parent, optProp, prop),
        "*" => null,  // Handled by fallback
        _ => throw new ArgumentException($"Unknown single type: {type}")
    };
}

/// <summary>Map enum type with fallback handling</summary>
protected virtual IPropertyType? MapEnumType(ObjectType parent, OptionProperty optProp, JsonProperty prop)
{
    // Check TypeCollection for known enum mappings
    if (typeCollection.TryGetMappedEnumType(prop.Name, parent.Name, out var mappedType))
        return mappedType;
    
    // Hardcoded exceptions (safe to downgrade to string)
    if (prop.Name == "fontFamily" || prop.Name == "cursor")
        return new SimpleType("string");
    
    // Unknown enum - record diagnostic with actionable suggestion
    var suggestion = $"Add enum mapping to TypeCollection:\n" +
        $"  AddMappedEnumType(new MappedEnumType(\"{prop.Name}\", typeof(???)), \"{parent.Name}\");";
    
    diagnosticCollector.RecordUnsupported(
        $"{parent.Name}.{prop.Name}",
        new() { "enum" },
        fallback: "string",
        suggestion: suggestion);
    
    return new SimpleType("string")
    {
        TypeWarning = suggestion
    };
}

/// <summary>Generate typed accessor pattern for partially supported types</summary>
protected virtual IPropertyType? MapPartiallySupported(ObjectType parent, OptionProperty optProp, JsonProperty prop)
{
    // For enum,function pattern: return object but mark for typed accessor generation
    if (optProp.Types.OrderBy(t => t).SequenceEqual(new[] { "enum", "function" }))
    {
        return new EnumOrFunctionType(GetEnumTypeForPartial(parent, optProp, prop));
    }
    
    // Default fallback
    return new SimpleType("object")
    {
        TypeWarning = $"Partially supported pattern: {string.Join(",", optProp.Types)}"
    };
}

/// <summary>Suggest what custom type should be created</summary>
private string SuggestMapping(List<string> types, OptionProperty optProp)
{
    var typeStr = string.Join(",", types.OrderBy(t => t));
    
    if (types.Count == 2 && !types.Contains("*"))
    {
        return $"Create custom type: 'Union{string.Join("Or", types.OrderBy(t => t).Select(Capitalize))}'";
    }
    
    if (types.Contains("enum") && optProp.EnumOptions?.Length > 0)
    {
        return $"Auto-generate enum type for values: {{{string.Join(", ", optProp.EnumOptions)}}}";
    }
    
    return $"Pattern '{typeStr}' is too complex - may require manual implementation";
}

private bool IsIndexProperty(string name) 
    => name.Contains("index", StringComparison.InvariantCultureIgnoreCase);

private string Capitalize(string s) 
    => s.Length > 0 ? char.ToUpper(s[0]) + s.Substring(1) : s;
```

---

## Part 3: Using the Improved System

### Adding a New Pattern to TypePatternRegistry

```csharp
// Before: Manually add case to MapType()
// (time-consuming, error-prone)

// After: 1. Create custom type in Vizor.ECharts/Types/
// src/Vizor.ECharts/Types/EnumOrNumberArray.cs
public class EnumOrNumberArray<T> where T : Enum
{
    public T? EnumValue { get; set; }
    public double[]? NumberArray { get; set; }
    public double? SingleNumber { get; set; }
    // ... JsonConverter implementation ...
}

// 2. Register in TypePatternRegistry
var SupportedPatterns = new Dictionary<string, Type>
{
    // ... existing patterns ...
    { "array,enum,number", typeof(EnumOrNumberArray<>) },  // ← Add 1 line
};

// Done! Generator will now use it automatically.
```

### Reading the Diagnostic Report

```markdown
# Type Pattern Analysis Report

## Unsupported Patterns

### array,enum,number (5 occurrences)
Examples: CrossStyle.type, ParallelSeriesData.type, ...
**Action**: Create custom type: 'UnionArrayEnumNumber<T>'

### boolean,object (3 occurrences)
Examples: ScatterSeries.symbolKeepAspect, ...
**Action**: Too complex - keep as object? with typed accessors

## Summary
- Total properties: 1,247
- Fully supported: 1,195 (95.8%)
- **Action items**: 15 patterns (1.2%)
```

---

## Part 4: Test Examples

### TypePatternAnalysisTests.cs

```csharp
[TestClass]
public class TypePatternAnalysisTests
{
    [TestMethod]
    public void GenerateTypePatternAnalysisReport()
    {
        // Load option.json
        var json = File.ReadAllText("option.json");
        var doc = JsonDocument.Parse(json);
        
        // Run generator phases
        var typeCollection = new TypeCollection();
        var diagnosticCollector = new DiagnosticCollector();
        var phase1 = new Phase1Generator(typeCollection, diagnosticCollector);
        
        phase1.Run(doc.RootElement);
        
        // Generate report
        var report = diagnosticCollector.GenerateReport();
        
        // Assertions
        Assert.IsTrue(report.SupportedCount > 0);
        Assert.IsTrue(report.UnsupportedCount < 50);  // Less than 4% unsupported
        
        // Save report
        File.WriteAllText(
            "TypePatternAnalysisReport.md",
            report.ToMarkdown());
        
        Console.WriteLine($"✓ Report generated: {report.SupportedCount} supported, {report.UnsupportedCount} unsupported");
    }
}
```

---

## Summary of Changes

| File | Change | Impact |
|------|--------|--------|
| `TypeMappingDiagnostic.cs` | NEW | Structured diagnostic data |
| `DiagnosticCollector.cs` | NEW | Collects all mapping decisions |
| `TypePatternRegistry.cs` | NEW | Centralizes pattern knowledge |
| `BasePhase.cs` | REFACTOR | Clear decision tree, calls diagnostics |
| `MapType()` | SIMPLIFY | From 100+ lines → 60 with clear steps |
| Generated code | IMPROVE | No `//TODO` comments (or minimal) |
| Reports | NEW | Analysis-driven improvement planning |

**Total new infrastructure**: ~600 lines
**Benefits**: 10x clearer code, 100% diagnoistic coverage, extensible pattern system
