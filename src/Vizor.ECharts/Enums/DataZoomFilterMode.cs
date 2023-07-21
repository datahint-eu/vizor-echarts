using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<DataZoomFilterMode>))]
public enum DataZoomFilterMode
{
	Filter,
	WeakFilter,
	Empty,
	None
}
