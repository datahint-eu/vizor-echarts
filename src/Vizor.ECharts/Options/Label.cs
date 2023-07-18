namespace Vizor.ECharts.Options;

/// <summary>
/// See https://echarts.apache.org/en/option.html#grid.tooltip.axisPointer.label
/// </summary>
public class Label
	: IBorderOption
	, IWidthHeightOption
	, IShadowOption
	, ITextBorderOption
{
	public bool? Show { get; set; }

	/// <summary>
	/// The precision of value in label. It is auto determined by default.
	/// You can also set it as '2', which indicates that two decimal fractions are reserved.
	/// </summary>
	public NumberOrString? Precision { get; set; }

	//TODO: formatter

	/// <summary>
	/// Distance between label and axis. Default = 3
	/// </summary>
	public double? Margin { get; set; }

	/// <summary>
	/// Text Color, default #fff
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
	/// Default font size 12
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

	public Padding? Padding { get; set; }

	/// <summary>
	/// Background color of label, the same as axis.axisLine.lineStyle.color by default.
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

}