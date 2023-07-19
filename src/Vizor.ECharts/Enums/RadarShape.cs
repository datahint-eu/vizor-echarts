using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<RadarShape>))]
public enum RadarShape
{
	Polygon,
	Circle
}