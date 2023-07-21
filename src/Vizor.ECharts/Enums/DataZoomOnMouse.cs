using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<DataZoomOnMouse>))]
public enum DataZoomOnMouse
{
	True,
	False,
	Shift,
	Ctrl,
	Alt
}
