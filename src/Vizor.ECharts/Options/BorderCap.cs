using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(BorderCapConverter))]
public enum BorderCap
{
	Butt,
	Round,
	Square
}

public class BorderCapConverter : JsonConverter<BorderCap>
{
	public override BorderCap Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for BorderCap.");
	}

	public override void Write(Utf8JsonWriter writer, BorderCap value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}