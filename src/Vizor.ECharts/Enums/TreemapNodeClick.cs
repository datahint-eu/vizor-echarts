using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverterWithBoolean<TreemapNodeClick>))]
public enum TreemapNodeClick
{
	True,
	False,
	ZoomToNode,
	Link
}