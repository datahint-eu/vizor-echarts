using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<ScatterEffectType>))]
public enum ScatterEffectType
{
	Ripple
}
