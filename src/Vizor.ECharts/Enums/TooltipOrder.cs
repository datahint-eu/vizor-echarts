using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// 'seriesAsc': Base on series declaration, ascending order tooltip.
/// 'seriesDesc': Base on series declaration, descending order tooltip.
/// 'valueAsc': Base on value, ascending order tooltip, only for numberic value.
/// 'valueDesc': Base on value, descending order tooltip, only for numberic value.
/// </summary>
[JsonConverter(typeof(CamelCaseEnumConverter<TooltipOrder>))]
public enum TooltipOrder
{
    SeriesAsc,
    SeriesDesc,
    ValueAsc,
    ValueDesc,
}
