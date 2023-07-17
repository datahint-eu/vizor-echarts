namespace Vizor.ECharts.Options;

/// <summary>
/// See https://echarts.apache.org/en/option.html#xAxis.minorSplitLine
/// </summary>
public class AxisMinorSplitLine
{
	/// <summary>
	/// Show minor split lines.
	/// </summary>
	public bool? Show { get; set; }

	/// <summary>
	/// Line style
	/// </summary>
	public LineStyle? LineStyle { get; set; }
}
