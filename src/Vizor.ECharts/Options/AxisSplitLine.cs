namespace Vizor.ECharts.Options;

/// <summary>
/// See https://echarts.apache.org/en/option.html#xAxis.splitLine
/// </summary>
public class AxisSplitLine
{
	/// <summary>
	/// Set this to false to prevent the splitLine from showing. value type axes are shown by default, while category type axes are hidden.
	/// </summary>
	public bool? Show { get; set; }

	//TODO: interval

	/// <summary>
	/// Line style
	/// </summary>
	public LineStyle? LineStyle { get; set; }
}
