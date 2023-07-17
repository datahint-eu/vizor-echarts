using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

/// <summary>
/// Type of axis.
/// 'value' Numerical axis, suitable for continuous data.
/// 'category' Category axis, suitable for discrete category data.Category data can be auto retrieved from series.data or dataset.source, or can be specified via xAxis.data.
/// 'time' Time axis, suitable for continuous time series data. As compared to value axis, it has a better formatting for time and a different tick calculation method.For example, it decides to use month, week, day or hour for tick based on the range of span.
/// 'log' Log axis, suitable for log data.
/// </summary>
[JsonConverter(typeof(AxisTypeConverter))]
public enum AxisType
{
	Category,
	Value,
	Time,
	Log
}

public class AxisTypeConverter : JsonConverter<AxisType>
{
	public override AxisType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for AxisType.");
	}
	public override void Write(Utf8JsonWriter writer, AxisType value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}