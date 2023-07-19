using System.Text.Json.Serialization;
using Vizor.ECharts.Enums;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<NameLocation>))]
public enum NameLocation
{
	Start,
	Middle,
	End
}