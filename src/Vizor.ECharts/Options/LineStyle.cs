using Vizor.ECharts;

namespace Vizor.ECharts.Options;

/// <summary>
/// See https://echarts.apache.org/en/option.html#legend.lineStyle
/// </summary>
public class LineStyle
	: IShadowOption
{
	public Color? Color { get; set; }

	/// <summary>
	/// Line width, default = auto
	/// </summary>
	public double? Width { get; set; }

	/// <summary>
	/// Possible values: 'solid' [default], 'dashed', 'dotted'
	/// Or a number or a number array to specify the dash array of the line. e.g. [5, 10]
	/// With TextBorderDashOffset , we can make the line style more flexible.
	/// </summary>
	public LineType? Type { get; set; }

	/// <summary>
	/// To set the line dash offset.
	/// See https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineDashOffset
	/// </summary>
	public double? DashOffset { get; set; }

	/// <summary>
	/// Specify how to draw the end points of the line. Possible values are:
	/// 'butt': The ends of lines are squared off at the endpoints.
	/// 'round': The ends of lines are rounded.
	/// 'square': The ends of lines are squared off by adding a box with an equal width and half the height of the line's thickness.
	/// Default value is 'butt'.
	/// Refer to MDN https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineCap for more details.
	/// </summary>
	public LineCap? Cap { get; set; }

	/// <summary>
	/// To determine the shape used to join two line segments where they meet.
	/// Possible values are:
	/// 'bevel': Fills an additional triangular area between the common endpoint of connected segments, and the separate outside rectangular corners of each segment.
	/// 'round': Rounds off the corners of a shape by filling an additional sector of disc centered at the common endpoint of connected segments. The radius for these rounded corners is equal to the line width.
	/// 'miter': Connected segments are joined by extending their outside edges to connect at a single point, with the effect of filling an additional lozenge-shaped area. This setting is affected by the borderMiterLimit property.
	/// Default value is 'bevel'.
	/// Refer to MDN https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineJoin for more details.
	/// </summary>
	public LineJoin? Join { get; set; }

	/// <summary>
	/// To set the miter limit ratio. Only works when borderJoin is set as miter.
	/// Default value is 10. Negative、0、Infinity and NaN values are ignored.
	/// Refer to MDN https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/miterLimit for more details.
	/// </summary>
	public double? MiterLimit { get; set; }

	/// <inheritdoc />
	public double? ShadowBlur { get; set; }

	/// <inheritdoc />
	public Color? ShadowColor { get; set; }

	/// <inheritdoc />
	public double? ShadowOffsetX { get; set; }

	/// <inheritdoc />
	public double? ShadowOffsetY { get; set; }

	/// <summary>
	/// Opacity of the component. Supports value from 0 to 1, and the component will not be drawn when set to 0.
	/// Default = inherit
	/// </summary>
	public double? Opacity { get; set; }
}
