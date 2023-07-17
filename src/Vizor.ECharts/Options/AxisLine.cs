namespace Vizor.ECharts.Options;

/// <summary>
/// See https://echarts.apache.org/en/option.html#xAxis.axisLine
/// </summary>
public class AxisLine
{
	/// <summary>
	/// Set this to false to prevent the axis line from showing.
	/// </summary>
	public bool? Show { get; set; }

	/// <summary>
	/// Specifies whether X or Y axis lies on the other's origin position, where value is 0 on axis. Valid only if the other axis is of value type, and contains 0 value.
	/// Default = true
	/// </summary>
	public bool? OnZero { get; set; }

	/// <summary>
	/// When mutiple axes exists, this option can be used to specify which axis can be "onZero" to.
	/// </summary>
	public double? OnZeroAxisIndex { get; set; }

	/// <summary>
	/// Symbol of the two ends of the axis.
	/// It could be a string, representing the same symbol for two ends; or an array with two string elements, representing the two ends separately.
	/// It's set to be 'none' by default, meaning no arrow for either end. If it is set to be 'arrow', there shall be two arrows. If there should only one arrow at the end, it should set to be ['none', 'arrow'].
	/// </summary>
	public AxisSymbol? AxisSymbol { get; set; }

	/// <summary>
	/// Size of the arrows at two ends. The first is the width perpendicular to the axis, the next is the width parallel to the axis.
	/// Default = [10, 15]
	/// </summary>
	public double[]? SymbolSize { get; set; }

	/// <summary>
	/// Arrow offset of axis. If is array, the first number is the offset of the arrow at the beginning, and the second number is the offset of the arrow at the end. If is number, it means the arrows have the same offset.
	/// Default = [0, 0]
	/// </summary>
	public double[]? SymbolOffset { get; set; }

	public LineStyle? LineStyle { get; set; }
}
