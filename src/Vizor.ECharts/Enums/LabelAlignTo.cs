using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<LabelAlignTo>))]
public enum LabelAlignTo
{
	LabelLine,
	Edge
}
