namespace Vizor.ECharts.Options;

/// <summary>
/// See https://echarts.apache.org/en/option.html#xAxis.axisTick
/// </summary>
public class AxisTick
{
	/// <summary>
	/// Set this to false to prevent the axis tick from showing.
	/// </summary>
	public bool? Show { get; set; }

	/// <summary>
	/// Align axis tick with label, which is available only when boundaryGap is set to be true in category axis
	/// </summary>
	public bool? AlignWithLabel { get; set; }

	//TODO: interval

	/// <summary>
	/// Set this to true so the axis labels face the inside direction.
	/// </summary>
	public bool? Inside { get; set; }

	/// <summary>
	/// The length of the axis tick. Default = 5
	/// </summary>
	public double? Length { get; set; }

	/// <summary>
	/// Line style of axis ticks.
	/// </summary>
	public LineStyle? LineStyle { get; set; }
}
