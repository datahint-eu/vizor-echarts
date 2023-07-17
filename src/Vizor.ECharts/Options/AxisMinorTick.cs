namespace Vizor.ECharts.Options;

/// <summary>
/// See https://echarts.apache.org/en/option.html#xAxis.minorTick
/// </summary>
public class AxisMinorTick
{
	/// <summary>
	/// Set this to false to prevent the axis tick from showing.
	/// </summary>
	public bool? Show { get; set; }

	/// <summary>
	/// Number of interval splited by minor ticks. Default = 5
	/// </summary>
	public double? SplitNumber { get; set; }

	/// <summary>
	/// The length of the axis tick. Default = 5
	/// </summary>
	public double? Length { get; set; }

	/// <summary>
	/// Line style
	/// </summary>
	public LineStyle? LineStyle { get; set; }
}
