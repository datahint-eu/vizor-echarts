using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverterWithBoolean<AxisPointerStatus>))]
public enum AxisPointerStatus
{
	True,
	False,
	Show,
	Hide
}
