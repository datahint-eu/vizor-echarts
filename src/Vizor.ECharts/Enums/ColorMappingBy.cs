using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<ColorMappingBy>))]
public enum ColorMappingBy
{
	Index,
	Value,
	Id
}
