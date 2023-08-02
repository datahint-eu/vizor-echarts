using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(TooltipPositionConverter))]
public class TooltipPosition
{
	public TooltipPosition(TooltipPositionType type)
	{
		Type = type;
	}

	public TooltipPosition(JavascriptFunction function)
	{
		Function = function;
	}

	public TooltipPosition(params NumberOrString[] position)
	{
		Position = position;
	}

	public TooltipPositionType? Type { get; }

	public JavascriptFunction? Function { get; }

	public NumberOrString[]? Position { get; }

	public static implicit operator TooltipPosition(TooltipPositionType type)
	{
		return new TooltipPosition(type);
	}

	public static implicit operator TooltipPosition(JavascriptFunction function)
	{
		return new TooltipPosition(function);
	}

	public static implicit operator TooltipPosition(NumberOrString[] position)
	{
		return new TooltipPosition(position);
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
		else if (value.Position != null)
		{
			writer.WriteStartArray();

			foreach (var val in value.Position)
			{
				NumberOrStringConverter.Instance.Write(writer, val, options);
			}

			writer.WriteEndArray();
		}
		else if (value.Function != null)
		{
			JavascriptFunctionConverter.Instance.Write(writer, value.Function, options);
		}
	}
}