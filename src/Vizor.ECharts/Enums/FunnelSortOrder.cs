using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<FunnelSortOrder>))]
public enum FunnelSortOrder
{
	Ascending,
	Descending,
	None
}
