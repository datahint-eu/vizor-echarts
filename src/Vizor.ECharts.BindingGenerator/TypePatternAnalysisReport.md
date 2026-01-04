# Type Pattern Analysis Report
Generated: 2026-01-03 22:15:54

## Summary
- Total properties analyzed: 37348
- ✅ Fully supported: 37330 (100%)
- ⚠️ Partially supported: 2 (0%)
- ❌ Unsupported: 16 (0%)
- 🔍 Requires investigation: 0 (0%)

## Unsupported Patterns (Sorted by Frequency)

### array,enum,number (4 occurrences)
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

