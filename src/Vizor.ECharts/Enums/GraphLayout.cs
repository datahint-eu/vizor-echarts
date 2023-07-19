using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<GraphLayout>))]
public enum GraphLayout
{
	None,
	Force,
	Circular
}
