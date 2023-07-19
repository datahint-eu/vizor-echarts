using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Type of axis.
/// 'value' Numerical axis, suitable for continuous data.
/// 'category' Category axis, suitable for discrete category data.Category data can be auto retrieved from series.data or dataset.source, or can be specified via xAxis.data.
/// 'time' Time axis, suitable for continuous time series data. As compared to value axis, it has a better formatting for time and a different tick calculation method.For example, it decides to use month, week, day or hour for tick based on the range of span.
/// 'log' Log axis, suitable for log data.
/// </summary>
[JsonConverter(typeof(CamelCaseEnumConverter<AxisType>))]
public enum AxisType
{
    Category,
    Value,
    Time,
    Log
}
