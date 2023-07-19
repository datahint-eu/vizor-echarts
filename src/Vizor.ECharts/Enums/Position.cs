using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<Position>))]
public enum Position
{
	Left,
	Right,
	Top,
	Bottom
}
