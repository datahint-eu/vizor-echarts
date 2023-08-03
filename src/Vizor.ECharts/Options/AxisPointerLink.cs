using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// axisPointers can be linked to each other. The term "link" represents that axes are synchronized and move together. Axes are linked according to the value of axisPointer.
/// See https://echarts.apache.org/en/option.html#axisPointer.link
/// </summary>
public class AxisPointerLink
{

	[JsonPropertyName("xAxisIndex")]
	public MultiIndex? XAxisIndex { get; set; }

	[JsonPropertyName("xAxisName")]
	public string[]? XAxisName { get; set; }

	[JsonPropertyName("xAxisId")]
	public string[]? XAxisId { get; set; }

	[JsonPropertyName("yAxisIndex")]
	public MultiIndex? YAxisIndex { get; set; }

	[JsonPropertyName("yAxisName")]
	public string[]? YAxisName { get; set; }

	[JsonPropertyName("yAxisId")]
	public string[]? YAxisId { get; set; }

	[JsonPropertyName("angleAxis")]
	public string[]? AngleAxis { get; set; }

	[JsonPropertyName("mapper")]
	public JavascriptFunction? Mapper { get; set; }
}
