using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(ColorByConverter))]
public enum ColorBy
{
	Series,
	Data
}

public class ColorByConverter : JsonConverter<ColorBy>
{
	public override ColorBy Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for ColorBy.");
	}

	public override void Write(Utf8JsonWriter writer, ColorBy value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}