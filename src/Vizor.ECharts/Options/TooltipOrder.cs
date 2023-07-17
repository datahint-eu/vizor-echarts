using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

/// <summary>
/// 'seriesAsc': Base on series declaration, ascending order tooltip.
/// 'seriesDesc': Base on series declaration, descending order tooltip.
/// 'valueAsc': Base on value, ascending order tooltip, only for numberic value.
/// 'valueDesc': Base on value, descending order tooltip, only for numberic value.
/// </summary>
[JsonConverter(typeof(TooltipOrderConverter))]
public enum TooltipOrder
{
	SeriesAsc,
	SeriesDesc,
	ValueAsc,
	ValueDesc,
}

public class TooltipOrderConverter : JsonConverter<TooltipOrder>
{
	public override TooltipOrder Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for TooltipOrder.");
	}

	public override void Write(Utf8JsonWriter writer, TooltipOrder value, JsonSerializerOptions options)
	{
		var str = value.ToString();
		writer.WriteStringValue(char.ToLower(str[0]) + str[1..]);
	}
}