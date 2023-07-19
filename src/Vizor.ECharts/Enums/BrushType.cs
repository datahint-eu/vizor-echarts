using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<BrushType>))]
public enum BrushType
{
	Stroke, 
	Fill
}
