namespace Vizor.ECharts.Options;

/// <summary>
/// Drawing grid in rectangular coordinate. In a single grid, at most two X and Y axes each is allowed.
/// Line chart, bar chart, and scatter chart (bubble chart) can be drawn in grid.
/// see https://echarts.apache.org/en/option.html#grid
/// </summary>
public class Grid
	: IOption
	, IZOption
	, IPositionOption
	, IWidthHeightOption
	, IBorderOption
	, IShadowOption
{
	/// <inheritdoc />
	public string? Id { get; set; }

	/// <summary>
	///  Whether to show the grid in rectangular coordinate.
	/// </summary>
	public bool? Show { get; set; }

	/// <inheritdoc />
	public double? ZLevel { get; set; }

	/// <inheritdoc />
	public double? Z { get; set; }

	/// <inheritdoc />
	public string? Left { get; set; }

	/// <inheritdoc />
	public string? Top { get; set; }

	/// <inheritdoc />
	public string? Right { get; set; }

	/// <inheritdoc />
	public string? Bottom { get; set; }

	/// <inheritdoc />
	public string? Width { get; set; }

	/// <inheritdoc />
	public string? Height { get; set; }


	/// <summary>
	/// Whether the grid region contains axis tick label of axis.
	/// When containLabel is false:
	///		grid.left grid.right grid.top grid.bottom grid.width grid.height decide the location and size of the rectangle that is made of by xAxis and yAxis.
	///		Setting to false will help when multiple grids need to be aligned at their axes.
	///	When containLabel is true:
	///		grid.left grid.right grid.top grid.bottom grid.width grid.height decide the location and size of the rectangle that contains the axes and the labels of the axes.
	///		Setting to true will help when the length of axis labels is dynamic and is hard to approximate.This will avoid labels from overflowing the container or overlapping other components.
	/// </summary>
	public bool ContainLabel { get; set; }

	/// <summary>
	/// Background color of grid, which is transparent by default.
	/// </summary>
	public Color? BackgroundColor { get; set; }

	/// <inheritdoc />
	public Color? BorderColor { get; set; }

	/// <inheritdoc />
	public double? BorderWidth { get; set; }

	/// <inheritdoc />
	public Radius? BorderRadius { get; set; }

	/// <inheritdoc />
	public double? ShadowBlur { get; set; }

	/// <inheritdoc />
	public Color? ShadowColor { get; set; }

	/// <inheritdoc />
	public double? ShadowOffsetX { get; set; }

	/// <inheritdoc />
	public double? ShadowOffsetY { get; set; }

	//TODO: tooltip
}
