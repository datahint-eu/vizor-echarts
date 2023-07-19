using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<LeftOrRight>))]
public enum LeftOrRight
{
	Left,
	Right
}
