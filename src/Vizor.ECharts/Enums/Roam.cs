using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverterWithBoolean<Roam>))]
public enum Roam
{
	True,
	False,
	Scale,
	Move
}
