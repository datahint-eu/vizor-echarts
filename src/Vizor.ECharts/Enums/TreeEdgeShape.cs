using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<TreeEdgeShape>))]
public enum TreeEdgeShape
{
	Orthogonal,
	Radial
}