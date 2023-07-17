using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

/// <summary>
/// Line type
/// See https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineDashOffset
/// </summary>
[JsonConverter(typeof(LineTypeConverter))]
public class LineType
{
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
			writer.WriteStartArray();
			foreach (var val in value.Pattern)
			{
				writer.WriteNumberValue(val);
			}
			writer.WriteEndArray();
		}
	}
}