using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(AxisPositionConverter))]
public enum AxisPosition
{
	Top,
	Bottom
}

public class AxisPositionConverter : JsonConverter<AxisPosition>
{
	public override AxisPosition Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for AxisPosition.");
	}

	public override void Write(Utf8JsonWriter writer, AxisPosition value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}