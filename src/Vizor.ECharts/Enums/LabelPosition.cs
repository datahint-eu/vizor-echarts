using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<LabelPosition>))]
public enum LabelPosition
{
	Top,
	Left,
	Right,
	Bottom,
	Inside,
	InsideLeft,
	InsideRight,
	InsideTop,
	InsideBottom,
	InsideTopLeft,
	InsideBottomLeft,
	InsideTopRight,
	InsideBottomRight,
	Outside
}
