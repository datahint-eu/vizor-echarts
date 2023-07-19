using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<StartOrEnd>))]
public enum StartOrEnd
{
	Start,
	End
}
