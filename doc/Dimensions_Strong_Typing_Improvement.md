# Dimensions Strong Typing Improvement Plan

## Current State
- `Dataset.Dimensions` is typed as `List<object>?` with a generator warning
- `Series.Dimensions` is also `List<object>?`
- This is due to the ECharts spec allowing dimensions to be union types: `string | object | null`
- Generator lacks support for this union pattern and falls back to `List<object>`

## Specification (ECharts)
According to the ECharts option.json and documentation, each dimension can be:
- **String**: dimension name only (e.g., `"date"`)
- **Object**: dimension with metadata:
  - `name`: string (dimension name)
  - `type`: enum (`"number"` | `"ordinal"` | `"time"` | `"float"` | `"int"`)
  - `displayName`: string (optional, for tooltip display)
- **Null**: skip this dimension (used as placeholder)

## Current Workaround
Temporarily using `string[]?` for simplicity:
- Pros: Simple, avoids runtime `List<object>` casting
- Cons: Loses ability to specify dimension metadata (type, displayName) and null placeholders

## Planned Improvement (Future)

### Step 1: Create DimensionDefinition Union Type
Create a new class `DimensionDefinition` that represents the union:
```csharp
public partial class DimensionDefinition
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    
    [JsonPropertyName("type")]
    public DimensionType? Type { get; set; }
    
    [JsonPropertyName("displayName")]
    public string? DisplayName { get; set; }
}

public enum DimensionType
{
    Number,
    Ordinal,
    Time,
    Float,
    Int
}
```

### Step 2: Create Custom JsonConverter
Implement `DimensionDefinitionConverter` that handles:
- String input → `{name: value}`
- Object input → parse to DimensionDefinition
- Null input → null

### Step 3: Update Generator
1. Add mapping in `TypeCollection.AddMappedType()` or similar:
   ```csharp
   // For dataset.dimensions and series.dimensions patterns
   MappedTypes["dataset"]["dimensions"] = typeof(List<DimensionDefinition?>);
   ```
2. Ensure generator emits `List<DimensionDefinition?>` instead of `List<object>`

### Step 4: Apply to All Occurrences
- `Dataset.Dimensions`
- `Series.Dimensions`
- Any other properties with the same union pattern

### Benefits
- ✅ Full type safety
- ✅ IntelliSense support for dimension properties
- ✅ Preserves ECharts spec compliance
- ✅ No runtime casting needed

## References
- ECharts Option.json: `dataset.dimensions` type definition
- ECharts Handbook: Dataset tutorial
- Generator: `TypeCollection.cs`, `BasePhase.cs`
- Issue: Generator "unmapped patterns" - currently has `array,object,null` as unhandled

## Timeline
- Phase 1 (Current): String-only workaround for immediate usability
- Phase 2 (Future): Implement full union type support as above
