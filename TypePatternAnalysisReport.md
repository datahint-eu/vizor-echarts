# Type Pattern Analysis Report
Generated: 2026-01-18 19:10:10

## Summary
- Total properties analyzed: 39020
- ✅ Fully supported: 38990 (99,9%)
- ⚠️ Partially supported: 2 (0%)
- ❌ Unsupported: 28 (0,1%)
- 🔍 Requires investigation: 0 (0%)

## Unsupported Patterns (Sorted by Frequency)

### enum (10 occurrences)
**Examples**: geo.preserveAspectAlign, geo.preserveAspectVerticalAlign, dividerLineStyle.cap
**Suggestion**: Add enum type mapping: AddMappedEnumType(new MappedEnumType("{propName}", typeof(???)), "{parentName}");

### array,enum,number (6 occurrences)
**Examples**: crossStyle.type, crossStyle.type, crossStyle.type
**Suggestion**: Pattern 'array,enum,number' is complex - investigate if typed accessor pattern is appropriate

### color,number (3 occurrences)
**Examples**: itemStyle.borderColorSaturation, itemStyle.borderColorSaturation, itemStyle.borderColorSaturation
**Suggestion**: Create custom union type: ColorOrNumber<T> (see NumberOrString pattern for template)

### array,enum (2 occurrences)
**Examples**: dayLabel.nameMap, monthLabel.nameMap
**Suggestion**: Create custom union type: ArrayOrEnum<T> (see NumberOrString pattern for template)

### number,percentvector,string (2 occurrences)
**Examples**: PictorialBarSeries.symbolMargin, PictorialBarSeriesData.symbolMargin
**Suggestion**: Pattern 'number,percentvector,string' is complex - investigate if typed accessor pattern is appropriate

### *,number (1 occurrences)
**Examples**: PiecewiseVisualMap.itemGap
**Suggestion**: Investigate if a custom type is needed

### function,htmlelement,string (1 occurrences)
**Examples**: tooltip.appendTo
**Suggestion**: Pattern 'function,htmlelement,string' is complex - investigate if typed accessor pattern is appropriate

### array,object (1 occurrences)
**Examples**: dataset.source
**Suggestion**: Create custom union type: ArrayOrObject<T> (see NumberOrString pattern for template)

### enum,number (1 occurrences)
**Examples**: areaStyle.origin
**Suggestion**: Create custom union type: EnumOrNumber<T> (see NumberOrString pattern for template)

### boolean,object (1 occurrences)
**Examples**: PieSeries.emptyCircleStyle
**Suggestion**: Create custom union type: BooleanOrObject<T> (see NumberOrString pattern for template)

## Partially Supported Patterns (Typed Accessor Pattern)

### enum,function (2 occurrences)
**Pattern**: object? with typed accessors
**Examples**: SunburstSeries.sort, FunnelSeries.sort

