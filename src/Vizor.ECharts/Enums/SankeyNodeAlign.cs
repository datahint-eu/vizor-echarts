using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<SankeyNodeAlign>))]
public enum SankeyNodeAlign
{
	Justify,
	Left,
	Right
}
