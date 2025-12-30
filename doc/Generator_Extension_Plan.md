# Generator Extension Plan

This document outlines how to extend the BindingGenerator to automatically produce the manual implementations currently required.

## Implementation Status

- ✅ **Phase 1 Complete** (December 30, 2024) - New union type patterns (BoolOrString, NumberOrStringArray)
- ✅ **Phase 2 Complete** (December 30, 2024) - SingleOrArrayType for Grid/XAxis/YAxis automation
- ✅ **Phase 3 Complete** (December 30, 2024) - EnumOrFunctionType for Sort properties
- ⏳ **Phase 4 Pending** - Visual properties enrichment (optional)

## Current Generator Architecture

### Key Components

1. **Phases/BasePhase.cs**
   - `MapPropertyType()` - Main type mapping logic with switch statements for type patterns
   - Handles single types, 2-type unions, and 3-type unions
   - Falls back to `object?` with TypeWarning for unmapped patterns

2. **Generators/ObjectTypeClassGenerator.cs**
   - `Generate()` - Writes C# class files with properties
   - Currently generates: `[JsonPropertyName]`, `[DefaultValue]`, property with getter/setter
   - Does NOT generate: `[JsonIgnore]` typed accessors, additional wrapper properties

3. **Types/IPropertyType.cs** hierarchy
   - `SimpleType` - Basic types (string, double, bool, object)
   - `MappedCustomType` - Existing union types (NumberOrBool, etc.)
   - `MappedEnumType` - Enum types
   - `GenericListType` - List<T>
   - `ObjectType` - Complex objects

## Extension Strategy

### 1. Add New Union Type Patterns (Easy - 1-2 hours)

**Goal:** Add missing 2-type and 3-type patterns to `BasePhase.MapPropertyType()`

**Implementation in BasePhase.cs line ~240:**

```csharp
// Add to 2-type union section:
case ("boolean", "string"):
    return new MappedCustomType(typeof(BoolOrString));
case ("array", "enum"):
    // Need generic: return new MappedGenericType("EnumOrArray", enumType);
    return new SimpleType("object"); // fallback until generic support
case ("enum", "number"):
    // Need generic: return new MappedGenericType("EnumOrNumber", enumType);
    return new SimpleType("object"); // fallback until generic support

// Add to 3-type union section after line ~290:
else if (optProp.Types is ["array", "enum", "number"])
{
    return new SimpleType("object"); // Complex - keep as typed accessor pattern
}
else if (optProp.Types is ["array", "number", "string"])
{
    return new MappedCustomType(typeof(NumberOrStringArray));
}
```

**Required new Types/ files to create first:**
- `BoolOrString.cs` - Same pattern as `NumberOrString.cs`
- `NumberOrStringArray.cs` - Already exists but not registered

**Difficulty:** ⭐ Easy - Just add cases to switch statement

---

### 2. Generate Object + Typed Accessor Pattern (Medium - 4-6 hours)

**Goal:** Automatically generate properties like:

```csharp
[JsonPropertyName("grid")]
public object? GridObject { get; set; }

[JsonIgnore]
public Grid? Grid 
{ 
    get => GridObject as Grid; 
    set => GridObject = value; 
}

[JsonIgnore]
public List<Grid>? GridList 
{ 
    get => GridObject as List<Grid>; 
    set => GridObject = value; 
}
```

**Implementation Strategy:**

#### A. Detect Single-or-Array Pattern

In `BasePhase.MapPropertyType()`, detect when ECharts option.json specifies both object and array:

```csharp
// Special handling for single-or-array pattern
if (optProp.Types is ["array", "object"] || IsArrayOfSingleType(optProp))
{
    var innerType = DetectInnerObjectType(optProp, prop.Name);
    return new SingleOrArrayType(innerType);
}
```

#### B. Create New IPropertyType Implementation

Create `Types/SingleOrArrayType.cs`:

```csharp
internal class SingleOrArrayType : IPropertyType
{
    public string InnerTypeName { get; }
    
    public SingleOrArrayType(string innerTypeName)
    {
        InnerTypeName = innerTypeName;
    }
    
    public string DotNetType => "object"; // The backing field type
    public string? TypeWarning => null;
}
```

#### C. Modify ObjectTypeClassGenerator

Extend `ObjectTypeClassGenerator.Generate()` to detect `SingleOrArrayType` and generate three properties:

```csharp
if (prop.MappedType is SingleOrArrayType singleOrArray)
{
    // Generate backing field
    writer.WriteDocumentation(prop.Description);
    writer.WriteLine($"[JsonPropertyName(\"{prop.Name}\")]");
    writer.WriteLine($"public object? {prop.PropertyName}Object {{ get; set; }}");
    writer.EmptyLine();
    
    // Generate single accessor
    writer.WriteDocumentation(prop.Description);
    writer.WriteLine($"[JsonIgnore]");
    writer.WriteLine($"public {singleOrArray.InnerTypeName}? {prop.PropertyName}");
    writer.WriteLine($"{{");
    writer.WriteLine($"\tget => {prop.PropertyName}Object as {singleOrArray.InnerTypeName};");
    writer.WriteLine($"\tset => {prop.PropertyName}Object = value;");
    writer.WriteLine($"}}");
    writer.EmptyLine();
    
    // Generate list accessor
    writer.WriteDocumentation(prop.Description);
    writer.WriteLine($"[JsonIgnore]");
    writer.WriteLine($"public List<{singleOrArray.InnerTypeName}>? {prop.PropertyName}List");
    writer.WriteLine($"{{");
    writer.WriteLine($"\tget => {prop.PropertyName}Object as List<{singleOrArray.InnerTypeName}>;");
    writer.WriteLine($"\tset => {prop.PropertyName}Object = value;");
    writer.WriteLine($"}}");
    writer.EmptyLine();
}
else
{
    // Existing property generation logic...
}
```

**Files to modify:**
1. `Types/SingleOrArrayType.cs` (new)
2. `Phases/BasePhase.cs` - Add detection logic
3. `Generators/ObjectTypeClassGenerator.cs` - Modify `Generate()` method

**Difficulty:** ⭐⭐⭐ Medium - Requires new type class and generator logic changes

**Implementation Complete (December 30, 2024):**

✅ Created `Types/SingleOrArrayType.cs` with InnerTypeName property  
✅ Added `IsArrayAndObject()` helper method to BasePhase.cs  
✅ Added detection logic in `MapType()` to identify array+object patterns with ItemType  
✅ Modified ObjectTypeClassGenerator.cs to generate three properties when encountering SingleOrArrayType  
✅ Created 8 unit tests in Phase2SingleOrArrayTests.cs (all passing)  
✅ Verified existing manual implementations (Grid, XAxis, YAxis, Calendar, Dataset) match generated pattern  

**Test Results:** 49/49 tests passing (41 original + 8 Phase 2)

**Properties Now Automatable:**
- `ChartOptions.Grid` / `GridList` / `GridObject`
- `ChartOptions.XAxis` / `XAxisList` / `XAxisObject`
- `ChartOptions.YAxis` / `YAxisList` / `YAxisObject`
- `ChartOptions.Calendar` / `CalendarList` / `CalendarObject`
- `ChartOptions.Dataset` / `DatasetList` / `DatasetObject`

**Note:** The generator now automatically creates the three-property pattern (Object backing field + single accessor + list accessor) for any property with `types: ["array", "object"]` and an ItemType defined in option.json.

---

### 3. Generate Enum + Function Typed Accessor Pattern (Medium - 3-4 hours)

**Goal:** Automatically generate properties like:

```csharp
[JsonPropertyName("sort")]
[DefaultValue("descending")]
public object? SortObject { get; set; }

[JsonIgnore]
public FunnelSortOrder? Sort
{
    get => (FunnelSortOrder?)SortObject;
    set => SortObject = value;
}

[JsonIgnore]
public JavascriptFunction? SortFunction
{
    get => SortObject as JavascriptFunction;
    set => SortObject = value;
}
```

**Implementation Strategy:**

Similar to SingleOrArrayType but simpler:

#### A. Detect Enum + Function Pattern

```csharp
if (optProp.Types is ["enum", "function"])
{
    var enumType = DetectEnumType(optProp.EnumOptions, prop.Name);
    return new EnumOrFunctionType(enumType);
}
```

#### B. Create EnumOrFunctionType

```csharp
internal class EnumOrFunctionType : IPropertyType
{
    public string EnumTypeName { get; }
    
    public EnumOrFunctionType(string enumTypeName)
    {
        EnumTypeName = enumTypeName;
    }
    
    public string DotNetType => "object";
    public string? TypeWarning => null;
}
```

#### C. Modify Generator

In `ObjectTypeClassGenerator.Generate()`:

```csharp
if (prop.MappedType is EnumOrFunctionType enumOrFunc)
{
    // Generate object backing field
    writer.WriteDocumentation(prop.Description);
    writer.WriteLine($"[JsonPropertyName(\"{prop.Name}\")]");
    writer.WriteDefaultValueAttribute(prop.Default);
    writer.WriteLine($"public object? {prop.PropertyName}Object {{ get; set; }}");
    writer.EmptyLine();
    
    // Generate enum accessor
    writer.WriteDocumentation($"{prop.Description}");
    writer.WriteLine($"[JsonIgnore]");
    writer.WriteLine($"public {enumOrFunc.EnumTypeName}? {prop.PropertyName}");
    writer.WriteLine($"{{");
    writer.WriteLine($"\tget => ({enumOrFunc.EnumTypeName}?){prop.PropertyName}Object;");
    writer.WriteLine($"\tset => {prop.PropertyName}Object = value;");
    writer.WriteLine($"}}");
    writer.EmptyLine();
    
    // Generate function accessor
    writer.WriteDocumentation($"A {prop.Name} function.");
    writer.WriteLine($"[JsonIgnore]");
    writer.WriteLine($"public JavascriptFunction? {prop.PropertyName}Function");
    writer.WriteLine($"{{");
    writer.WriteLine($"\tget => {prop.PropertyName}Object as JavascriptFunction;");
    writer.WriteLine($"\tset => {prop.PropertyName}Object = value;");
    writer.WriteLine($"}}");
    writer.EmptyLine();
}
```

**Difficulty:** ⭐⭐⭐ Medium

**Implementation Complete (December 30, 2024):**

✅ Created `Types/EnumOrFunctionType.cs` with EnumTypeName property  
✅ Added detection logic in BasePhase.cs for `["enum", "function"]` pattern  
✅ Used `TryGetMappedEnumType` to resolve enum type dynamically  
✅ Modified ObjectTypeClassGenerator.cs to generate three properties when encountering EnumOrFunctionType  
✅ Created 8 unit tests in Phase3EnumOrFunctionTests.cs (all passing)  
✅ Verified existing manual implementations (FunnelSeries.Sort, SunburstSeries.Sort) match generated pattern  

**Test Results:** 57/57 tests passing (41 original + 8 Phase 2 + 8 Phase 3)

**Properties Now Automatable:**
- `FunnelSeries.Sort` / `SortFunction` / `SortObject` (enum: FunnelSortOrder)
- `SunburstSeries.Sort` / `SortFunction` / `SortObject` (enum: SortOrder)

**How It Works:**
When the generator encounters a property with `types: ["enum", "function"]` in option.json, it:
1. Looks up the enum type using the existing `TryGetMappedEnumType` method
2. Creates an EnumOrFunctionType with the resolved enum name
3. Generates three properties:
   - `{PropertyName}Object` - object backing field with [JsonPropertyName]
   - `{PropertyName}` - enum accessor with cast: `(EnumType?){PropertyName}Object`
   - `{PropertyName}Function` - JavascriptFunction accessor with `as` cast

**Note:** This pattern automatically handles any property where ECharts accepts either an enum value OR a custom JavaScript function, enabling type-safe access while maintaining flexibility.

---

### 4. Handle Visual Properties Pattern (Medium-Hard - 6-8 hours)

**Goal:** Detect properties like InBrush/OutOfBrush that follow a standard visual encoding pattern

**Challenge:** option.json might not fully describe these properties, requiring:
- Manual configuration file listing known visual property patterns
- Heuristic detection based on property names

**Implementation Strategy:**

#### A. Create Configuration File

Create `BindingGenerator/VisualPropertyPatterns.json`:

```json
{
  "visualPropertyTypes": [
    {
      "typeName": "InBrush",
      "properties": [
        { "name": "symbol", "type": "Icon" },
        { "name": "symbolSize", "type": "NumberOrNumberArray" },
        { "name": "color", "type": "Color" },
        { "name": "colorAlpha", "type": "double" },
        { "name": "opacity", "type": "double" },
        { "name": "colorLightness", "type": "double" },
        { "name": "colorSaturation", "type": "double" },
        { "name": "colorHue", "type": "double" }
      ]
    },
    {
      "typeName": "OutOfBrush",
      "properties": "sameAs:InBrush"
    }
  ]
}
```

#### B. Post-Processing Phase

Create `Phases/EnrichVisualPropertiesPhase.cs`:

```csharp
internal class EnrichVisualPropertiesPhase : BasePhase
{
    private Dictionary<string, List<VisualProperty>> visualPatterns;
    
    public EnrichVisualPropertiesPhase(TypeCollection typeCollection) 
        : base(typeCollection)
    {
        visualPatterns = LoadVisualPatterns("VisualPropertyPatterns.json");
    }
    
    internal override void Run(JsonElement root)
    {
        foreach (var objType in typeCollection.ObjectTypes)
        {
            if (visualPatterns.TryGetValue(objType.Name, out var props))
            {
                EnrichWithVisualProperties(objType, props);
            }
        }
    }
    
    private void EnrichWithVisualProperties(ObjectType objType, List<VisualProperty> props)
    {
        foreach (var visualProp in props)
        {
            if (!objType.Properties.Any(p => p.Name == visualProp.Name))
            {
                objType.Properties.Add(CreateVisualProperty(visualProp));
            }
        }
    }
}
```

#### C. Register Phase

In `GenerateOptionBindingTool.cs`:

```csharp
var phases = new BasePhase[]
{
    new GenerateObjectTypesPhase(typeCollection),
    new EnrichVisualPropertiesPhase(typeCollection) // NEW
};

foreach (var phase in phases)
{
    phase.Run(root);
}
```

**Difficulty:** ⭐⭐⭐⭐ Medium-Hard - Requires new phase infrastructure

---

## Implementation Priority

### Phase 1: Quick Wins (1-2 hours)
✅ Add `BoolOrString` type mapping
✅ Register `NumberOrStringArray` type mapping

**Impact:** Eliminates 4-5 manual implementations
**Files to change:** `BasePhase.cs` (add 2 cases)

### Phase 2: Core Infrastructure (4-6 hours)
✅ Implement `SingleOrArrayType` for Grid/XAxis/YAxis/etc.
✅ Modify `ObjectTypeClassGenerator` to generate typed accessors

**Impact:** Eliminates Grid, XAxis, YAxis, VisualMap, Calendar manual implementations (5 properties)
**Files to change:** 
- `Types/SingleOrArrayType.cs` (new)
- `Phases/BasePhase.cs` (detection logic)
- `Generators/ObjectTypeClassGenerator.cs` (generation logic)

### Phase 3: Advanced Patterns (3-4 hours)
✅ Implement `EnumOrFunctionType` for Sort properties
✅ Modify generator for enum + function accessors

**Impact:** Eliminates FunnelSeries.Sort, SunburstSeries.Sort (2 properties)
**Files to change:**
- `Types/EnumOrFunctionType.cs` (new)
- `Phases/BasePhase.cs` (detection)
- `Generators/ObjectTypeClassGenerator.cs` (generation)

### Phase 4: Visual Properties Enrichment (6-8 hours) [OPTIONAL]
⚠️ Create visual property configuration system
⚠️ Implement post-processing phase

**Impact:** Eliminates InBrush/OutOfBrush manual implementations (16 properties)
**Files to change:**
- `VisualPropertyPatterns.json` (new)
- `Phases/EnrichVisualPropertiesPhase.cs` (new)
- `GenerateOptionBindingTool.cs` (register phase)

---

## Testing Strategy

After each phase, verify:

1. **Regenerate bindings:**
   ```bash
   cd src/Vizor.ECharts.BindingGenerator
   dotnet run -- option-binding --input path/to/option.json --output ../Vizor.ECharts
   ```

2. **Build library:**
   ```bash
   cd ../Vizor.ECharts
   dotnet build
   ```

3. **Run existing tests:**
   ```bash
   cd ../Vizor.ECharts.Tests
   dotnet test
   ```

4. **Check warnings.txt:**
   - Should see reduction in unmapped properties
   - Compare before/after counts

5. **Manual verification:**
   - Open generated files (Grid, XAxis, InBrush, etc.)
   - Verify typed accessor pattern is correct
   - Check JSON serialization attributes

---

## Benefits of Generator Extension

1. **Consistency** - All similar patterns handled uniformly
2. **Maintainability** - ECharts 6 upgrade will be smoother
3. **Documentation** - Generated code is self-documenting
4. **Coverage** - Reduces manual implementation burden from ~17 to ~2-3 edge cases
5. **Type Safety** - Typed accessors provide better IntelliSense

## Estimated Total Effort

- **Phase 1 (Quick Wins):** 1-2 hours → 25% reduction in manual work
- **Phase 2 (Core):** 4-6 hours → 50% reduction in manual work
- **Phase 3 (Advanced):** 3-4 hours → 65% reduction in manual work
- **Phase 4 (Optional):** 6-8 hours → 85% reduction in manual work

**Total: 14-20 hours for complete automation**

## Alternative: Hybrid Approach

If full automation is too time-consuming:

1. Implement Phase 1 & 2 (5-8 hours) → Cover 75% of cases
2. Keep Phase 3 & 4 as manual implementations
3. Revisit automation when upgrading to ECharts 7+

This gives maximum ROI for minimum investment.
