using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<AxisPointerStatus>))]
public enum AxisPointerStatus
{
	True,
	False,
	Show,
	Hide
}
