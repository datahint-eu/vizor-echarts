using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<SortOrder>))]
public enum SortOrder
{
	Asc,
	Desc,
	None
}
