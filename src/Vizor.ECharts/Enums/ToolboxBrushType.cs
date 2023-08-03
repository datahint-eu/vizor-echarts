using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://echarts.apache.org/en/option.html#toolbox.feature.brush.type
/// </summary>
[JsonConverter(typeof(CamelCaseEnumConverter<ToolboxBrushType>))]
public enum ToolboxBrushType
{
	Rect,
	Polygon,
	LineX,
	LineY,
	Keep,
	Clear
}