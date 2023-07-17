using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

/// <summary>
/// see https://echarts.apache.org/en/option.html#series-line.coordinateSystem
/// </summary>
[JsonConverter(typeof(CoordinateSystemConverter))]
public enum CoordinateSystem
{
	Cartesian2D,
	Polar
}

public class CoordinateSystemConverter : JsonConverter<CoordinateSystem>
{
	public override CoordinateSystem Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for CoordinateSystem.");
	}

	public override void Write(Utf8JsonWriter writer, CoordinateSystem value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString().ToLower());
	}
}