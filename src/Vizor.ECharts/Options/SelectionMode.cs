using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(SelectionModeConverter))]
public enum SelectionMode
{
	True,
	False,
	Single,
	Multiple
}

public class SelectionModeConverter : JsonConverter<SelectionMode>
{
	public override SelectionMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for SelectionMode.");
	}

	public override void Write(Utf8JsonWriter writer, SelectionMode value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}