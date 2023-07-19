using System.Globalization;
using System.Text.Json.Serialization;
using Vizor.ECharts;
using Vizor.ECharts.Options.Series;

namespace Vizor.ECharts.Options;

public class ChartOptions<TData>
	: IAnimationOption
{
	public Title? Title { get; set; }

	public Legend? Legend { get; set; }

	public Grid? Grid { get; set; }

	[JsonPropertyName("xAxis")]
	public Axis? XAxis { get; set; }

	[JsonPropertyName("yAxis")]
	public Axis? YAxis { get; set; }

	public Polar? Polar { get; set; }

	public RadiusAxis? RadiusAxis { get; set; }

	public AngleAxis? AngleAxis { get; set; }

	public Radar? Radar { get; set; }

	public DataZoom? DataZoom { get; set; }

	public VisualMap? VisualMap { get; set; }

	public Tooltip? Tooltip { get; set; }

	public AxisPointer? AxisPointer { get; set; }

	public Toolbox? Toolbox { get; set; }

	public Brush? Brush { get; set; }

	public Geo? Geo { get; set; }

	public Parallel? Parallel { get; set; }

	public ParallelAxis? ParallelAxis { get; set; }

	public SingleAxis? SingleAxis { get; set; }

	public Timeline? Timeline { get; set; }

	public Graphic? Graphic { get; set; }

	public Calendar? Calendar { get; set; }

	public Dataset? Dataset { get; set; }

	public Aria? Aria { get; set; }

	[JsonConverter(typeof(ChartSeriesConverterFactory))]
	public List<IChartSeries<TData>> Series { get; set; } = new();

	/// <summary>
	/// Background color. No background by default.
	/// Dark mode is detected using the background color.
	/// </summary>
	public Color? BackgroundColor { get; set; }

	/// <summary>
	/// Global text style.
	/// </summary>
	public TextStyle? TextStyle { get; set; }

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

	public StateAnimation? StateAnimation { get; set; }

	/// <summary>
	/// Sets the type of compositing operation to apply when drawing a new shape.
	/// See the different type: https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/globalCompositeOperation.
	/// The default is 'source-over'. Support settings for each series.
	/// 'lighter' is also a common type of compositing operation.In this mode, the area where the number of graphics is concentrated is superimposed into a high-brightness color (white). It often used to highlight the effect of the area. See example Global airline
	/// </summary>
	public BlendMode? BlendMode { get; set; }


	/// <summary>
	/// When the number of element of the whole chart is larger than hoverLayerThreshold, a seperate hover layer is used to render hovered elements.
	/// The seperate hover layer is used to avoid re-painting the whole canvas when hovering on elements.Instead, the hovered elements are rendered in a seperate layer so that other elements don't have to be rendered again.
	/// Default = 3000
	/// </summary>
	public double? HoverLayerThreshold { get; set; }

	/// <summary>
	/// Whether to use UTC in display.
	///		true: When axis.type is 'time', ticks is determined according to UTC, and axisLabel and tooltip use UTC by default.
	///	 false: When axis.type is 'time', ticks is determined according to local time, and axisLabel and tooltip use local time by default.
	/// The default value of useUTC is false, for sake of considering:
	///		In many cases, labels should be displayed in local time (whether the time is stored in server in local time or UTC)
	///		If user uses time string (like '2012-01-02') in data, it usually means local time if time zone is not specified.Time should be displayed in its original time zone by default.
	///	Notice: the setting only affects "display time", not "parse time". For how time value (like 1491339540396, '2013-01-04', ...) is parsed in echarts, see the time part in date.
	/// </summary>
	public bool? UseUTC { get; set; }

	//TODO: Options

	//TODO: Media --> ECUnitOption = ChartOptions ??
}
