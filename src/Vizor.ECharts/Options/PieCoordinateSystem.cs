using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

/// <summary>
/// see https://echarts.apache.org/en/option.html#series-pie.coordinateSystem
/// </summary>
[JsonConverter(typeof(PieCoordinateSystemConverter))]
public enum PieCoordinateSystem
{
	None,
	Geo,
	Calendar
}

public class PieCoordinateSystemConverter : JsonConverter<PieCoordinateSystem>
{
	public override PieCoordinateSystem Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for PieCoordinateSystem.");
	}

	public override void Write(Utf8JsonWriter writer, PieCoordinateSystem value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}