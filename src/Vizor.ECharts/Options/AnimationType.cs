using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(AnimationTypeConverter))]
public enum AnimationType
{
	Expansion,
	Scale
}

public class AnimationTypeConverter : JsonConverter<AnimationType>
{
	public override AnimationType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for AnimationType.");
	}

	public override void Write(Utf8JsonWriter writer, AnimationType value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}