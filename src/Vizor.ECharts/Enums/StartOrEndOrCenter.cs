using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<StartOrEndOrCenter>))]
public enum StartOrEndOrCenter
{
	Start,
	End,
	Center
}
