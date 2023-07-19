using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<FunnelAlign>))]
public enum FunnelAlign
{
	Left,
	Center,
	Right
}
