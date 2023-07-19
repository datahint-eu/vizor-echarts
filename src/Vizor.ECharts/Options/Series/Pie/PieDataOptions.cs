using Vizor.ECharts.Enums;
using Vizor.ECharts.Types;

namespace Vizor.ECharts.Options.Series.Pie;

public class PieDataOptions
	: IZOption
	, IPositionOption
	, IWidthHeightOption
	, IAnimationOption
{
	/// <summary>
	/// The policy to take color from option.color. Default = data
	/// </summary>
	public ColorBy? ColorBy { get; set; }

	/// <summary>
	/// Whether to enable highlighting chart when legend is being hovered.
	/// Default = true
	/// </summary>
	public bool? LegendHoverLink { get; set; }

	/// <summary>
	/// The coordinate used in the series
	/// </summary>
	public PieCoordinateSystem? CoordinateSystem { get; set; }

	/// <summary>
	/// Index of geographic coordinate to combine with, which is useful for multiple geographic axes in one chart.
	/// </summary>
	public int? GeoIndex { get; set; }

	/// <summary>
	/// Index of calendar coordinates to combine with, which is useful for multiple calendar coordinates in one chart.
	/// </summary>
	public int? CalendarIndex { get; set; }

	/// <summary>
	/// Selected mode. It is enabled by default, and you may set it to be false to disable it.
	/// </summary>
	public SelectionMode? SelectedMode { get; set; }

	/// <summary>
	/// The offset distance of selected sector.
	/// Default = 10
	/// </summary>
	public double? SelectedOffset { get; set; }

	/// <summary>
	/// Whether the layout of sectors of pie chart is clockwise.
	/// Default = true
	/// </summary>
	public bool? Clockwise { get; set; }

	/// <summary>
	/// The start angle, which range is [0, 360].
	/// Default = 90
	/// </summary>
	public double? StartAngle { get; set; }

	/// <summary>
	/// The minimum angle of sector (0 ~ 360).
	/// It prevents some sector from being too small when value is small, which will affect user interaction.
	/// </summary>
	public double? MinAngle { get; set; }

	/// <summary>
	///If a sector is less than this angle (0 ~ 360), label and labelLine will not be displayed.
	/// </summary>
	public double? MinShowLabelAngle { get; set; }

	//TODO: RoseType

	/// <summary>
	/// Whether to enable the strategy to avoid labels overlap.
	/// Defaults to be enabled, which will move the label positions in the case of labels overlapping
	/// </summary>
	public bool? AvoidLabelOverlap { get; set; }

	/// <summary>
	/// Whether to show sector when all data are zero. Default = true
	/// </summary>
	public bool? StillShowZeroSum { get; set; }

	/// <summary>
	/// The precision of the percentage value. The default value is 2.
	/// </summary>
	public double? PercentPrecision { get; set; }

	/// <summary>
	/// The mouse style when mouse hovers on an element, the same as cursor property in CSS.
	/// </summary>
	public string? Cursor { get; set; }

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
	/// If display an placeholder circle when there is no data.
	/// Default = true
	/// </summary>
	public bool? ShowEmptyCircle { get; set; }

	//TODO: emptyCircleStyle

	/// <summary>
	/// Text label of pie chart, to explain some data information about graphic item like value, name and so on. 
	/// </summary>
	public Label? Label { get; set; }

	/// <summary>
	/// The style of visual guide line. Will show when label position is set as 'outside'.
	/// </summary>
	public LabelLine? LabelLine { get; set; }

	/// <summary>
	/// Unified layout configuration of labels.
	/// It provide a chance to adjust the labels' (x, y) position, alignment based on the original layout each series provides.
	/// </summary>
	public LabelLayout? LabelLayout { get; set; }

	/// <summary>
	/// Graphic style of , emphasis is the style when it is highlighted, like being hovered by mouse, or highlighted via legend connect.
	/// </summary>
	public ItemStyle? ItemStyle { get; set; }

	/// <summary>
	/// Configurations of emphasis state.
	/// </summary>
	public Emphasis? Emphasis { get; set; }

	/// <summary>
	/// Configurations of blur state. Available when emphasis.focus is set.
	/// </summary>
	public Blur? Blur { get; set; }

	/// <summary>
	/// Configurations of select state. Available when selectedMode is set.
	/// </summary>
	public Select? Select { get; set; }

	/// <summary>
	/// Center position of Pie chart, the first of which is the horizontal position, and the second is the vertical position.
	/// Percentage is supported. When set in percentage, the item is relative to the container width, and the second item to the height.
	/// </summary>
	public PieCenter? Center { get; set; }

	/// <summary>
	/// Radius of Pie chart.
	/// </summary>
	public PieRadius? Radius { get; set; }

	/// <summary>
	/// When dataset is used, seriesLayoutBy specifies whether the column or the row of dataset is mapped to the series, namely, the series is "layout" on columns or rows
	/// </summary>
	public SeriesLayoutBy? SeriesLayoutBy { get; set; }

	/// <summary>
	/// f series.data is not specified, and dataset exists, the series will use dataset. datasetIndex specifies which dataset will be used.
	/// </summary>
	public int? DatasetIndex { get; set; }


	//TODO: dimensions, encode

	/// <summary>
	/// A groupID common to all data in the series. the groupID will be used to classify the data and determine how merge and split animations are performed in the universal transition animation.
	/// If you are using the dataset component to represent the data, it is recommended to use encode.itemGroupID to specify which dimension is encoded as the groupID.
	/// </summary>
	public string? DataGroupId { get; set; }

	//TODO: Data

	/// <summary>
	/// Mark point in a chart.
	/// </summary>
	public MarkPoint? MarkPoint { get; set; }

	/// <summary>
	/// Use a line in the chart to illustrate.
	/// </summary>
	public MarkLine? MarkLine { get; set; }

	/// <summary>
	/// Used to mark an area in chart. For example, mark a time interval.
	/// </summary>
	public MarkArea? MarkArea { get; set; }

	/// <summary>
	/// Whether to ignore mouse events. Default value is false, for triggering and responding to mouse events.
	/// </summary>
	public bool? Silent { get; set; }

	/// <summary>
	/// Initial animation type. Default = expansion
	/// </summary>
	public AnimationType? AnimationType { get; set; }

	/// <summary>
	/// Initial animation type. Default = transition
	/// </summary>
	public AnimationTypeUpdate? AnimationTypeUpdate { get; set; }

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

	//TODO: universalTransition

	/// <summary>
	/// Tooltip settings in this series.
	/// </summary>
	public Tooltip? Tooltip { get; set; }
}
