using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<AxisPointerType>))]
public enum AxisPointerType
{
	Line,
	Shadow,
	None,
	Cross
}
