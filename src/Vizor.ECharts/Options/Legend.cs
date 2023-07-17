namespace Vizor.ECharts.Options;

/// <summary>
/// See https://echarts.apache.org/en/option.html#legend
/// </summary>
public class Legend
	: IOption
	, IZOption
	, IPositionOption
	, IWidthHeightOption
	, IPaddingOption
	, IBorderOption
	, IShadowOption

{
	/// <summary>
	/// Type of legend. Optional values:
	/// 'plain': Simple legend. [default]
	/// 'scroll': Scrollable legend.It helps when too many legend items needed to be shown.
	/// </summary>
	public LegendType? LegendType { get; set; }

	/// <inheritdoc />
	public string? Id { get; set; }

	/// <inheritdoc />
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
	/// The layout orientation of legend.
	/// </summary>
	public Orient? Orient { get; set; }

	/// <summary>
	/// Legend marker and text aligning.
	/// By default, it automatically calculates from component location and orientation.
	/// When left value of this component is 'right', and the vertical layout (orient is 'vertical'), it would be aligned to 'right'.
	/// Default = auto
	/// </summary>
	public HAlign Align { get; set; } //TODO: prevent center

	/// <inheritdoc />
	public Padding? Padding { get; set; }

	/// <summary>
	/// The distance between each legend, horizontal distance in horizontal layout, and vertical distance in vertical layout.
	/// Default=10
	/// </summary>
	public double? ItemGap { get; set; }

	/// <summary>
	/// Image width of legend symbol.
	/// Default=25
	/// </summary>
	public double? ItemWidth { get; set; }

	/// <summary>
	/// Image height of legend symbol.
	/// Default=14
	/// </summary>
	public double? ItemHeight { get; set; }

	public ItemStyle? ItemStyle { get; set; }

	public LineStyle? LineStyle { get; set; }

	/// <summary>
	/// Rotation of the symbol, which can be number | 'inherit'.
	/// If it's 'inherit', symbolRotate of the series will be used.
	/// Default = inherit
	/// </summary>
	public string? SymbolRotate { get; set; }

	//TODO: formatter

	/// <summary>
	/// Selected mode of legend, which controls whether series can be toggled displaying by clicking legends. It is enabled by default, and you may set it to be false to disable it.
	/// Besides, it can be set to 'single' or 'multiple', for single selection and multiple selection.
	/// </summary>
	public SelectionMode? SelectedMode { get; set; }

	/// <summary>
	/// Legend color when not selected.
	/// Default = #ccc
	/// </summary>
	public Color? InactiveColor { get; set; }

	/// <summary>
	/// Legend border color when not selected.
	/// Default = #ccc
	/// </summary>
	public Color? InactiveBorderColor { get; set; }

	/// <summary>
	/// Legend border width when not selected.
	/// If it is 'auto', the border width is set to be 2 if there is border width in the series, 0 elsewise.
	/// If it is 'inherit', it always takes the border width of the series.
	/// </summary>
	public string? InactiveBorderWidth { get; set; }

	//TODO: selected

	/// <summary>
	/// Legend text style.
	/// </summary>
	public TextStyle? TextStyle { get; set; }

	//TODO: tooltip (Tooltip class)

	/// <summary>
	/// Icon of the legend items.
	/// </summary>
	public Icon? Icon { get; set; }

	//TODO: data array

	/// <summary>
	/// Background color of title, which is transparent by default.
	/// See Color class.
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

	/// <summary>
	/// It works when legend.type is 'scroll'.
	/// dataIndex of the left top most displayed item.
	/// </summary>
	public double? ScrollDataIndex { get; set; }

	//TODO: pageXXX properties

	/// <summary>
	/// Whether to use animation when page scrolls.
	/// </summary>
	public bool? Animation { get; set; }

	/// <summary>
	/// Duration in ms of the page scroll animation.
	/// Default=800
	/// </summary>
	public double? AnimationDurationUpdate { get; set; }

	//TODO: emphasis object

	/// <summary>
	/// The selector button in the legend component. Currently, there are two types of button:
	/// all: Select All
	/// inverse: Inverse Selection
	/// </summary>
	public Selector? Selector { get; set; }

	//TODO: SelectorLabel

	/// <summary>
	/// The position of the selector button, which can be placed at the end or start of the legend component, the corresponding values are 'end' and 'start'.
	/// By default, when the legend is laid out horizontally, the selector is placed at the end of it, and when the legend is laid out vertically, the selector is placed at the start of it.
	/// Default = auto
	/// </summary>
	public string? SelectorPosition { get; set; }

	/// <summary>
	/// The gap between the selector button. Default = 7
	/// </summary>
	public double? SelectorItemGap { get; set; }

	/// <summary>
	/// The gap between selector button and legend component. Default = 10
	/// </summary>
	public double? SelectorButtonGap { get; set; }
}
