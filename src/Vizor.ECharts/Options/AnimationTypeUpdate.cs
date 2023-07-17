using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(AnimationTypeUpdateConverter))]
public enum AnimationTypeUpdate
{
	Transition,
	Expansion
}

public class AnimationTypeUpdateConverter : JsonConverter<AnimationTypeUpdate>
{
	public override AnimationTypeUpdate Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for AnimationTypeUpdate.");
	}

	public override void Write(Utf8JsonWriter writer, AnimationTypeUpdate value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}