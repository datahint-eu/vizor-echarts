using Vizor.ECharts;

namespace Vizor.ECharts.Options;

public interface ITextBorderOption
{
	/// <summary>
	/// Stroke color of the text. See Color class.
	/// </summary>
	Color? TextBorderColor { get; set; }

	/// <summary>
	/// Stroke line width of the text.
	/// </summary>
	double? TextBorderWidth { get; set; }

	/// <summary>
	/// Possible values: 'solid' [default], 'dashed', 'dotted'
	/// Or a number or a number array to specify the dash array of the line. e.g. [5, 10]
	/// With TextBorderDashOffset , we can make the line style more flexible.
	/// </summary>
	LineType? TextBorderType { get; set; }

	/// <summary>
	/// To set the line dash offset. With TextBorderType , we can make the line style more flexible.
	/// See https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineDashOffset
	/// </summary>
	double? TextBorderDashOffset { get; set; }
}
