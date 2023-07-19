using Vizor.ECharts.Enums;
using Vizor.ECharts.Types;

namespace Vizor.ECharts.Options;

public class TextStyle
	: ITextBorderOption
	, ITextShadowOption
	, IWidthHeightOption
{
	/// <summary>
	/// Color, default #333
	/// </summary>
	public Color? Color { get; set; }

	/// <summary>
	/// See FontStyles class. Default = normal
	/// </summary>
	public FontStyle? FontStyle { get; set; }

	/// <summary>
	/// See FontWeights class. Default = normal
	/// Other options: 100, 200, 300, 400, ...
	/// </summary>
	public FontWeight? FontWeight { get; set; }

	/// <summary>
	/// Default 'sans-serif'. Can also be 'serif' , 'monospace', ...
	/// </summary>
	public string? FontFamily { get; set; }

	/// <summary>
	/// Default font size 18 for titles, 12 for other components.
	/// </summary>
	public double? FontSize { get; set; }

	/// <summary>
	/// Line height of the text fragment.
	/// </summary>
	public double? LineHeight { get; set; }

	/// <inheritdoc />
	public string? Width { get; set; }

	/// <inheritdoc />
	public string? Height { get; set; }

	/// <inheritdoc />
	public Color? TextBorderColor { get; set; }

	/// <inheritdoc />
	public double? TextBorderWidth { get; set; }

	/// <inheritdoc />
	public LineType? TextBorderType { get; set; }

	/// <inheritdoc />
	public double? TextBorderDashOffset { get; set; }

	/// <inheritdoc />
	public Color? TextShadowColor { get; set; }

	/// <inheritdoc />
	public double? TextShadowBlur { get; set; }

	/// <inheritdoc />
	public double? TextShadowOffsetX { get; set; }

	/// <inheritdoc />
	public double? TextShadowOffsetY { get; set; }

	/// <summary>
	/// Determine how to display the text when it's overflow. Available when width is set.
	/// </summary>
	public Overflow? Overflow { get; set; }

	/// <summary>
	/// Ellipsis to be displayed when overflow is set to truncate.
	/// Default '...'
	/// - 'truncate' Truncate the overflow lines.
	/// </summary>
	public string? Ellipsis { get; set; }

	//TODO: Rich style


}
