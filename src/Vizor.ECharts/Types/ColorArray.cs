using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(ColorArrayConverter))]
public class ColorArray
{
	public ColorArray(Color color)
	{
		Colors = new Color[] { color };
	}

	public ColorArray(Color[] colors)
	{
		Colors = colors;
	}

	public Color[]? Colors { get; }

	public static implicit operator ColorArray(Color color)
	{
		return new ColorArray(color);
	}

	public static implicit operator ColorArray(Color[] colors)
	{
		return new ColorArray(colors);
	}
}

public class ColorArrayConverter : JsonConverter<ColorArray>
{
	public override ColorArray Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for ColorArray.");
	}

	public override void Write(Utf8JsonWriter writer, ColorArray value, JsonSerializerOptions options)
	{
		if (value.Colors != null)
		{
			if (value.Colors.Length == 1)
			{
				writer.WriteStringValue(value.Colors[0].ToString());
			}
			else
			{
				writer.WriteStartArray();
				foreach (var val in value.Colors)
				{
					writer.WriteStringValue(val.ToString());
				}
				writer.WriteEndArray();
			}
		}
	}
}