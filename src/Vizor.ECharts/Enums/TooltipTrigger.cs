using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

/// <summary>
/// 'item': Triggered by data item, which is mainly used for charts that don't have a category axis like scatter charts or pie charts.
/// 'axis': Triggered by axes, which is mainly used for charts that have category axes, like bar charts or line charts.
/// 'none': Trigger nothing.
/// </summary>
[JsonConverter(typeof(CamelCaseEnumConverter<TooltipTrigger>))]
public enum TooltipTrigger
{
    Item,
    Axis,
    None
}