using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(SeriesLayoutByConverter))]
public enum SeriesLayoutBy
{
	Column,
	Row
}

public class SeriesLayoutByConverter : JsonConverter<SeriesLayoutBy>
{
	public override SeriesLayoutBy Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for SeriesLayoutBy.");
	}

	public override void Write(Utf8JsonWriter writer, SeriesLayoutBy value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}