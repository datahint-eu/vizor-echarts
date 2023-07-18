using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.Mime.MediaTypeNames;

namespace Vizor.ECharts.Options;

/// <summary>
/// See https://echarts.apache.org/en/option.html#grid.tooltip.axisPointer.label.overflow
/// Determine how to display the text when it's overflow. Available when width is set.
/// 'truncate' Truncate the text and trailing with ellipsis.
/// 'break' Break by word
/// 'breakAll' Break by character.
/// </summary>
[JsonConverter(typeof(OverflowConverter))]
public enum Overflow
{
	Truncate,
	Break,
	BreakAll
}

public class OverflowConverter : JsonConverter<Overflow>
{
	public override Overflow Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for Overflow.");
	}

	public override void Write(Utf8JsonWriter writer, Overflow value, JsonSerializerOptions options)
	{
		var str = value.ToString();
		writer.WriteStringValue(char.ToLower(str[0]) + str[1..]);
	}
}