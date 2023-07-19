using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Vizor.ECharts;

/// <summary>
/// See https://echarts.apache.org/en/option.html#grid.tooltip.axisPointer.label.overflow
/// Determine how to display the text when it's overflow. Available when width is set.
/// 'truncate' Truncate the text and trailing with ellipsis.
/// 'break' Break by word
/// 'breakAll' Break by character.
/// </summary>
[JsonConverter(typeof(CamelCaseEnumConverter<Overflow>))]
public enum Overflow
{
    Truncate,
    Break,
    BreakAll
}