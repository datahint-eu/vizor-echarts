using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Line type
/// See https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineDashOffset
/// </summary>
[JsonConverter(typeof(LineTypeConverter))]
public class LineType
{
	public LineType(double number)
	{
		Pattern = new double[] { number };
	}

	public LineType(double[] pattern)
	{
		Pattern = pattern;
	}

	public LineType(LineTypeStyle style)
	{
		Style = style;
	}

	public double[]? Pattern { get; }
	public LineTypeStyle? Style { get; }


	public static implicit operator LineType(double number)
	{
		return new LineType(number);
	}

	public static implicit operator LineType(double[] numbers)
	{
		return new LineType(numbers);
	}

	public static implicit operator LineType(LineTypeStyle type)
	{
		return new LineType(type);
	}
}

public enum LineTypeStyle
{
	Solid,
	Dashed,
	Dotted
}


public class LineTypeConverter : JsonConverter<LineType>
{
	public override LineType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for LineType.");
	}

	public override void Write(Utf8JsonWriter writer, LineType value, JsonSerializerOptions options)
	{
		if (value.Style != null)
		{
			writer.WriteStringValue(value.Style!.ToString()!.ToLower());
		}
		else if (value.Pattern != null)
		{
			if (value.Pattern.Length == 1)
			{
				writer.WriteNumberValue(value.Pattern[0]);
			}
			else
			{
				writer.WriteStartArray();
				foreach (var val in value.Pattern)
				{
					writer.WriteNumberValue(val);
				}
				writer.WriteEndArray();
			}
		}
	}
}