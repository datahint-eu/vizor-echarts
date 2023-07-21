using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(TooltipPositionConverter))]
public class TooltipPosition
{
	//TODO: must also accept arrays of string/number, see https://echarts.apache.org/en/option.html#tooltip.position

	public TooltipPosition(TooltipPositionType type)
	{
		Type = type;
	}

	public TooltipPositionType? Type { get; }

	public static implicit operator TooltipPosition(TooltipPositionType type)
	{
		return new TooltipPosition(type);
	}
}

public enum TooltipPositionType
{
	Inside,
	Top,
	Left,
	Right,
	Bottom
}


public class TooltipPositionConverter : JsonConverter<TooltipPosition>
{
	public override TooltipPosition Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for TooltipPosition.");
	}

	public override void Write(Utf8JsonWriter writer, TooltipPosition value, JsonSerializerOptions options)
	{
		if (value.Type != null)
		{
			writer.WriteStringValue(value.Type!.ToString()!.ToLower());
		}
	}
}