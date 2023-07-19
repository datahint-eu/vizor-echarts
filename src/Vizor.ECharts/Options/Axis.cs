using Vizor.ECharts.Enums;
using Vizor.ECharts.Types;

namespace Vizor.ECharts.Options;

/// <summary>
/// see https://echarts.apache.org/en/option.html#xAxis
/// </summary>
public class Axis
	: IOption
	, IAnimationOption
	, IZOption
{
	/// <inheritdoc />
	public string? Id { get; set; }

	/// <inheritdoc />
	public bool? Show { get; set; }

	/// <summary>
	/// The index of grid which the x axis belongs to. Defaults to be in the first grid.
	/// </summary>
	public int? GridIndex { get; set; }

	/// <summary>
	/// alignTicks turned on to automatically align ticks when multiple numeric x axes. Only available for axes of type 'value' and 'log'.
	/// </summary>
	public bool? AlignTicks { get; set; }


	/// <summary>
	/// The position of x axis.
	/// options: 'top', 'bottom'
	/// The first x axis in grid defaults to be on the bottom of the grid, and the second x axis is on the other side against the first x axis.
	/// Notice: Set xAxis.axisLine.onZero to false to activate this option.
	/// </summary>
	public TopOrBottom? Position { get; set; }

	/// <summary>
	/// Offset of x axis relative to default position. Useful when multiple x axis has same position value.
	/// Notice: Set xAxis.axisLine.onZero to false to activate this option.
	/// </summary>
	public int? Offset { get; set; }

	/// <summary>
	/// See AxisType
	/// </summary>
	public AxisType? Type { get; set; }

	public string? Name { get; set; }

	//TODO: NameLocation

	/// <summary>
	/// Text style of axis name.
	/// </summary>
	public TextStyle? NameTextStyle { get; set; }

	/// <summary>
	/// Gap between axis name and axis line. Default = 15
	/// </summary>
	public double? NameGap { get; set; }

	/// <summary>
	/// Rotation of axis name.
	/// </summary>
	public double? NameRotate { get; set; }

	/// <summary>
	/// Set this to true to invert the axis. 
	/// </summary>
	public bool? Inverse { get; set; }


	//TODO: boundary gap, min, max

	/// <summary>
	/// It is available only in numerical axis, i.e., type: 'value'.
	/// It specifies whether not to contain zero position of axis compulsively.
	/// When it is set to be true, the axis may not contain zero position, which is useful in the scatter chart for both value axes.
	/// This configuration item is unavailable when the min and max are set.
	/// </summary>
	public bool? Scale { get; set; }

	/// <summary>
	/// Number of segments that the axis is split into. Note that this number serves only as a recommendation, and the true segments may be adjusted based on readability.
	/// This is unavailable for category axis.
	/// Default = 5
	/// </summary>
	public double? SplitNumber { get; set; }

	/// <summary>
	/// Minimum gap between split lines.
	/// For example, it can be set to be 1 to make sure axis label is show as integer.
	/// It is available only for axis of type 'value' or 'time'.
	/// </summary>
	public double? MinInterval { get; set; }

	/// <summary>
	/// Maximum gap between split lines.
	/// For example, in time axis(type is 'time'), it can be set to be 3600 * 24 * 1000 to make sure that the gap between axis labels is less than or equal to one day.
	/// It is available only for axis of type 'value' or 'time'.
	/// </summary>
	public double? MaxInterval { get; set; }


	/// <summary>
	/// Compulsively set segmentation interval for axis.
	/// As splitNumber is a recommendation value, the calculated tick may not be the same as expected.In this case, interval should be used along with min and max to compulsively set tickings.But in most cases, we do not suggest using this, our automatic calculation is enough for most situations.
	/// This is unavailable for category axis. Timestamp should be passed for type: 'time' axis.Logged value should be passed for type: 'log' axis.
	/// </summary>
	public double? Interval { get; set; }

	/// <summary>
	/// Base of logarithm, which is valid only for numeric axes with type: 'log'.
	/// Default = 10
	/// </summary>
	public double? LogBase { get; set; }

	/// <summary>
	/// Set this to true, to prevent interaction with the axis.
	/// </summary>
	public bool? Silent { get; set; }

	/// <summary>
	/// Set this to true to enable triggering events
	/// </summary>
	public bool TriggerEvent { get; set; }

	/// <summary>
	/// Settings related to axis line.
	/// </summary>
	public AxisLine? AxisLine { get; set; }

	/// <summary>
	/// Settings related to axis tick.
	/// </summary>
	public AxisTick? AxisTick { get; set; }

	/// <summary>
	/// Settings related minor ticks.
	/// </summary>
	public AxisMinorTick? MinorTick { get; set; }

	/// <summary>
	/// Settings related to axis label.
	/// </summary>
	public AxisLabel? AxisLabel { get; set; }

	/// <summary>
	/// Split line of axis in grid area.
	/// </summary>
	public AxisSplitLine? SplitLine { get; set; }

	/// <summary>
	/// Minor split lines of axis in the grid area。It will align to the minorTick
	/// </summary>
	public AxisMinorSplitLine? MinorSplitLine { get; set; }

	/// <summary>
	/// Split area of axis in grid area, not shown by default.
	/// </summary>
	public AxisSplitArea? SplitArea { get; set; }

	//TODO: Data

	//TODO: AxisPointer

	/// <inheritdoc />
	public bool? Animation { get; set; }

	/// <inheritdoc />
	public int? AnimationThreshold { get; set; }

	/// <inheritdoc />
	public NumberOrFunction? AnimationDuration { get; set; }

	/// <inheritdoc />
	public AnimationEasing? AnimationEasing { get; set; }

	/// <inheritdoc />
	public NumberOrFunction? AnimationDelay { get; set; }

	/// <inheritdoc />
	public NumberOrFunction? AnimationDurationUpdate { get; set; }

	/// <inheritdoc />
	public AnimationEasing? AnimationEasingUpdate { get; set; }

	/// <inheritdoc />
	public NumberOrFunction? AnimationDelayUpdate { get; set; }

	/// <inheritdoc />
	public double? ZLevel { get; set; }

	/// <inheritdoc />
	public double? Z { get; set; }
}
