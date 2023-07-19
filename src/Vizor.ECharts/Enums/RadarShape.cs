using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<RadarShape>))]
public enum RadarShape
{
	Polygon,
	Circle
}