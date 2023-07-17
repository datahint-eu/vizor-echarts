using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(StepConverter))]
public enum Step
{
	True,
	False,
	Start,
	Middle,
	End
}

public class StepConverter : JsonConverter<Step>
{
	public override Step Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for Step.");
	}

	public override void Write(Utf8JsonWriter writer, Step value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}