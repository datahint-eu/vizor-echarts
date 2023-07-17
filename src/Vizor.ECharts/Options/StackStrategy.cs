using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(StackStrategyConverter))]
public enum StackStrategy
{
	SameSign,
	All,
	Positive,
	Negative
}

public class StackStrategyConverter : JsonConverter<StackStrategy>
{
	public override StackStrategy Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for StackStrategy.");
	}

	public override void Write(Utf8JsonWriter writer, StackStrategy value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}