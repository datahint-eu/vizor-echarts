using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

/// <summary>
/// see https://echarts.apache.org/en/option.html#series-line.coordinateSystem
/// </summary>
[JsonConverter(typeof(LineCoordinateSystemConverter))]
public enum LineCoordinateSystem
{
	Cartesian2D,
	Polar
}

public class LineCoordinateSystemConverter : JsonConverter<LineCoordinateSystem>
{
	public override LineCoordinateSystem Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for LineCoordinateSystem.");
	}

	public override void Write(Utf8JsonWriter writer, LineCoordinateSystem value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}