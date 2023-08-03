using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverterWithBoolean<SunburstNodeClick>))]
public enum SunburstNodeClick
{
	True,
	False,
	RootToNode,
	Link
}