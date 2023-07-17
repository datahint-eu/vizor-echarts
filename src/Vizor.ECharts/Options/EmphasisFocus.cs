using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(EmphasisFocusConverter))]
public enum EmphasisFocus
{
	None,
	Self,
	Series
}

public class EmphasisFocusConverter : JsonConverter<EmphasisFocus>
{
	public override EmphasisFocus Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for EmphasisFocus.");
	}

	public override void Write(Utf8JsonWriter writer, EmphasisFocus value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}