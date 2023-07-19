using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<AxisPointer>))]
public enum AxisPointer
{
	Line,
	Shadow,
	None
}
