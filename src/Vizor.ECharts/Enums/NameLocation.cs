using System.Text.Json.Serialization;
using Vizor.ECharts;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<NameLocation>))]
public enum NameLocation
{
	Start,
	Middle,
	End
}