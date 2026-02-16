# Manual Implementation Analysis

This document analyzes manual implementations in Vizor.ECharts that were added outside of the Generator, and evaluates whether they could be automated.

## Executive Summary

**Key Findings:**
- **17 out of 22 unmapped properties** have manual implementations in the codebase
- **13 custom union types** exist in `Types/` folder to handle complex type patterns
- **11 out of 12 unmapped patterns** are potentially automatable with Generator improvements
- **18 type combination patterns** are currently automated by the Generator

## Manual Implementation Patterns

### 1. Union Types (Types/ Folder)

The project has **13 manually-implemented union types** to handle complex ECharts type combinations:

**Already in Generator's pattern matching:**
- `NumberOrBool` - handles `boolean,number`
- `NumberOrString` - handles `number,string`
- `NumberOrNumberArray` - handles `array,number`
- `StringOrFunction` - handles `function,string`
- `NumberOrFunction` - handles `function,number`
- `ObjectOrFunction` - handles `function,object`
- `ColorOrFunction` - handles `color,function`
- `NumberOrStringOrFunction` - handles `function,number,string`
- `NumberArrayOrFunction` - handles `array,function,number`
- `NumberArray` - handles `array,number,vector`
- `ColorArray` - handles `array,color`

**NOT in Generator's pattern matching** (could be added):
- `StringArray` - could automate `array,string` pattern
- `NumberOrStringArray` - could automate `array,number,string` pattern

### 2. Object with Typed Accessors Pattern

Found **10 properties** using the `object? XyzObject` + `[JsonIgnore]` typed accessor pattern:

| File | Property | Purpose |
|------|----------|---------|
| `Options/CrossStyle.cs` | `TypeObject` | Union of `LineType` enum OR `number[]` |
| `Options/ChartOptions.cs` | `GridObject` | Single `Grid` OR `List<Grid>` |
| `Options/ChartOptions.cs` | `XAxisObject` | Single `XAxis` OR `List<XAxis>` |
| `Options/ChartOptions.cs` | `VisualMapObject` | Various visual map types |
| `Options/ChartOptions.cs` | `CalendarObject` | Single OR array of calendars |
| `Options/Dataset.cs` | `TransformObject` | Transform configuration |
| `Options/EmptyCircleStyle.cs` | `BorderTypeObject` | Line type OR number array |
| `Series/Parallel/ParallelSeriesData.cs` | `TypeObject` | Line type variants |
| `Series/Sunburst/SunburstSeries.cs` | `SortObject` | Enum OR `JavascriptFunction` |
| `Series/Funnel/FunnelSeries.cs` | `SortObject` | Enum OR `JavascriptFunction` |

**Pattern:**
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

This pattern is necessary when:
- The union includes both an enum and a function
- The union includes both a single object and array of objects
- Complex type combinations that can't be handled by simple union types

## Generator Coverage Analysis

### Currently Automated Patterns (18)

The Generator's `BasePhase.cs` already handles these type combinations:

```
array,color              → ColorArray
array,function,number    → NumberArrayOrFunction
array,number             → NumberOrNumberArray
array,number,vector      → NumberArray
array,percentvector      → double[]
array,string             → MappedEnumType (Icon)
array,vector             → double[]
boolean,number           → NumberOrBool
color,function           → ColorOrFunction
color,number             → double
date,number,string       → NumberOrString
function,icon,string     → StringOrFunction
function,number          → NumberOrFunction
function,number,string   → NumberOrStringOrFunction
function,object          → ObjectOrFunction
function,string          → StringOrFunction
icon,string              → MappedEnumType (Icon)
number,string            → NumberOrString
```

### Unmapped Patterns (12)

These patterns currently fall back to `object?` and require manual implementation:

| Pattern | Occurrences | Examples | Automation Recommendation |
|---------|-------------|----------|---------------------------|
| `array,enum,number` | 5 | `crossStyle.type` | ✅ Create `EnumOrNumberOrArray<T>` |
| `boolean,string` | 2 | `SliderDataZoom.showDataShadow`, `TreemapSeries.nodeClick` | ✅ Create `BoolOrString` |
| `array,enum` | 2 | `dayLabel.nameMap`, `monthLabel.nameMap` | ✅ Create `EnumOrArray<T>` |
| `enum,function` | 2 | `SunburstSeries.sort`, `FunnelSeries.sort` | ⚠️ Keep as `object?` (enum + function requires typed accessors) |
| `prefix` | 3 | `label.rotate` | ⚠️ Special type, may require custom handling |
| `*,number` | 1 | `PiecewiseVisualMap.itemGap` | ❌ Wildcard type, keep as `object?` |
| `array,number,string` | 1 | `calendar.range` | ✅ Could add to Generator (3-type union) |
| `array,object` | 1 | `dataset.source` | ❌ Too generic, keep as `object?` |
| `enum,number` | 1 | `areaStyle.origin` | ✅ Create `EnumOrNumber<T>` |
| `boolean,object` | 1 | `PieSeries.emptyCircleStyle` | ⚠️ Use typed accessor pattern |
| `array,boolean,number` | 1 | `GraphSeries.autoCurveness` | ✅ Existing: `AutoCurveness` class |
| `number,percentvector,string` | 1 | `PictorialBarSeries.symbolMargin` | ❌ Complex 3-type union, keep as `object?` |

**Legend:**
- ✅ Can be automated in Generator
- ⚠️ Requires special handling (typed accessor pattern)
- ❌ Too complex or rare, manual implementation recommended

## Recommendations for Generator Improvements

### High Priority (Automatable)

1. **Add `BoolOrString` type** (2 occurrences)
   ```csharp
   public class BoolOrString
   {
       public bool? Bool { get; }
       public string? String { get; }
       // ... implicit operators
   }
   ```
   Map to: `("boolean", "string")`

2. **Add `EnumOrArray<T>` generic type** (2 occurrences)
   - Handles `array,enum` pattern
   - Similar to existing `ColorArray` but for enum types

3. **Add mapping for `array,enum,number`** (5 occurrences)
   - Most common unmapped pattern
   - Could create `EnumOrNumberOrArray<T>` generic type

### Medium Priority

4. **Register `StringArray` in Generator** (already implemented in Types/)
   - Map `array,string` → `StringArray` when not used as enum

5. **Register `NumberOrStringArray` in Generator** (already implemented)
   - Map `array,number,string` → `NumberOrStringArray`

6. **Add `EnumOrNumber<T>` generic** (1 occurrence)
   - Map `enum,number` → `EnumOrNumber<T>`

### Low Priority (Keep Manual)

7. **`enum,function` pattern** - Keep using `object?` with typed accessors
   - Requires both enum property and `JavascriptFunction` property
   - Current manual implementation is appropriate

8. **Wildcard and complex unions** - Keep as `object?`
   - `*,number` (wildcard)
   - `array,object` (too generic)
   - `number,percentvector,string` (rare complex union)

## Implementation Status

✅ **17/22 unmapped properties have manual implementations**
- All 22 properties appear in generated code as fallback types (`object?`, `string`)
- 17 have additional manual implementations (typed accessors, custom types)
- 0 properties are completely missing (skipped)

This demonstrates that the Generator successfully produces compilable code even for unmapped patterns, falling back to safe types like `object?` and `string`.

## Next Steps

1. **Test before ECharts 6 upgrade**
   - Current test suite (35 tests) provides baseline
   - Manual implementations are documented

2. **Consider Generator improvements**
   - Add `BoolOrString`, `EnumOrArray<T>`, `EnumOrNumberOrArray<T>`
   - Register existing `StringArray` and `NumberOrStringArray` types
   - Update `BasePhase.cs` pattern matching

3. **Monitor warnings.txt**
   - Track new unmapped patterns in ECharts 6
   - Evaluate if they follow existing patterns

## Files Changed for Analysis

- `src/Vizor.ECharts.Tests/Unit/Generator/ManualImplementationAnalysisTests.cs`
  - `FindUnionTypePropertiesWithObject` - Finds object + accessor pattern
  - `AnalyzeCustomTypesInTypesFolder` - Lists all union types
  - `MapWarningsToManualImplementations` - Cross-references warnings with code
  - `AnalyzeGeneratorMappingPatterns` - Lists current Generator capabilities
  - `RecommendGeneratorImprovements` - Provides actionable recommendations
