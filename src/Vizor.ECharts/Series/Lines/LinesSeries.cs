
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class LinesSeries : ISeries
{
	[JsonPropertyName("type")]
	public string Type => "lines";

	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Series name used for displaying in tooltip and filtering with legend , or updating data and configuration with setOption .
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Since v5.2.0   
	/// The policy to take color from option.color .
	/// Valid values:   'series' : assigns the colors in the palette by series, so that all data in the same series are in the same color;  'data' : assigns colors in the palette according to data items, with each data item using a different color.
	/// </summary>
	[JsonPropertyName("colorBy")]
	[DefaultValue("series")]
	public ColorBy? ColorBy { get; set; }

	/// <summary>
	/// The coordinate used in the series, whose options are:   
	/// 'cartesian2d'  
	/// Use a two-dimensional rectangular coordinate (also known as Cartesian coordinate), with xAxisIndex and yAxisIndex to assign the corresponding axis component.
	///     
	/// 'geo'  
	/// Use geographic coordinate, with geoIndex to assign the corresponding geographic coordinate components.
	/// </summary>
	[JsonPropertyName("coordinateSystem")]
	[DefaultValue("geo")]
	public string? CoordinateSystem { get; set; }

	/// <summary>
	/// Index of x axis to combine with, which is  useful for multiple x axes in one chart.
	/// </summary>
	[JsonPropertyName("xAxisIndex")]
	[DefaultValue(0)]
	public int? XAxisIndex { get; set; }

	/// <summary>
	/// Index of y axis to combine with, which is  useful for multiple y axes in one chart.
	/// </summary>
	[JsonPropertyName("yAxisIndex")]
	[DefaultValue(0)]
	public int? YAxisIndex { get; set; }

	/// <summary>
	/// Index of geographic coordinate to combine with, which is useful for multiple geographic axes in one chart.
	/// </summary>
	[JsonPropertyName("geoIndex")]
	[DefaultValue(0)]
	public int? GeoIndex { get; set; }

	/// <summary>
	/// If draw as a polyline.
	///  
	/// Default to be false .
	/// Can only draw a two end straight line.
	///  
	/// If it is set true, data.coords can have more than two coord to draw a polyline.
	/// It is useful when visualizing GPS track data.
	/// See example lines-bus .
	/// </summary>
	[JsonPropertyName("polyline")]
	[DefaultValue(false)]
	public bool? Polyline { get; set; }

	/// <summary>
	/// The setting about the special effects of lines.
	///  
	/// Tips: All the graphs with trail effect should be put on a individual layer, which means that zlevel need to be different with others.
	/// And the animation ( animation : false)  of this layer is suggested to be turned off at the meanwhile.
	/// Otherwise, other graphic elements in other series and the label of animation would produce unnecessary ghosts.
	/// </summary>
	[JsonPropertyName("effect")]
	public Effect? Effect { get; set; }

	/// <summary>
	/// Whether to enable the optimization of large-scale lines graph.
	/// It could be enabled when there is a particularly large number of data(>=5k) .
	///  
	/// After being enabled, largeThreshold can be used to indicate the minimum number for turning on the optimization.
	///  
	/// The style of a single data item can't be customized
	/// </summary>
	[JsonPropertyName("large")]
	[DefaultValue(true)]
	public bool? Large { get; set; }

	/// <summary>
	/// The threshold enabling the drawing optimization.
	/// </summary>
	[JsonPropertyName("largeThreshold")]
	[DefaultValue(2000)]
	public double? LargeThreshold { get; set; }

	/// <summary>
	/// Symbol type at the two ends of the line.
	/// It can be an array for two ends, or assigned seperately.
	/// See data.symbol for more format information.
	/// </summary>
	[JsonPropertyName("symbol")]
	[DefaultValue("none")]
	public Icon? Symbol { get; set; }

	/// <summary>
	/// Symbol size at the two ends of the line.
	/// It can be an array for two ends, or assigned seperately.
	///  
	/// Attention: You cannot assgin width and height seperately as normal symbolSize .
	/// </summary>
	[JsonPropertyName("symbolSize")]
	[DefaultValue(10)]
	public NumberOrNumberArray? SymbolSize { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; }

	/// <summary>
	/// Label settings.
	/// Does not work when polyline is true .
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Unified layout configuration of labels.
	///  
	/// It provide a chance to adjust the labels' (x, y) position, alignment based on the original layout each series provides.
	///  
	/// This option can be a callback with following parameters.
	///  // corresponding index of data
	/// dataIndex: number
	/// // corresponding type of data.
	/// Only available in graph, in which it can be 'node' or 'edge'
	/// dataType?: string
	/// // corresponding index of series
	/// seriesIndex: number
	/// // Displayed text of label.
	/// text: string
	/// // Bounding rectangle of label.
	/// labelRect: {x: number, y: number, width: number, height: number}
	/// // Horizontal alignment of label.
	/// align: 'left' | 'center' | 'right'
	/// // Vertical alignment of label.
	/// verticalAlign: 'top' | 'middle' | 'bottom'
	/// // Bounding rectangle of the element corresponding to.
	/// rect: {x: number, y: number, width: number, height: number}
	/// // Default points array of labelLine.
	/// Currently only provided in pie and funnel series.
	/// // It's null in other series.
	/// labelLinePoints?: number[][]  
	/// Example:  
	/// Align the labels on the right.
	/// Left 10px margin to the edge.
	///  labelLayout(params) {
	///     return {
	///         x: params.rect.x + 10,
	///         y: params.rect.y + params.rect.height / 2,
	///         verticalAlign: 'middle',
	///         align: 'left'
	///     }
	/// }  
	/// Set the text size based on the size of element bounding rectangle.
	///  labelLayout(params) {
	///     return {
	///         fontSize: Math.max(params.rect.width / 10, 5)
	///     };
	/// }
	/// </summary>
	[JsonPropertyName("labelLayout")]
	public ObjectOrFunction? LabelLayout { get; set; }

	/// <summary>
	/// Emphasis state.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Configurations of blur state.
	/// Available when emphasis.focus is set.
	/// </summary>
	[JsonPropertyName("blur")]
	public Blur? Blur { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Configurations of select state.
	/// Available when selectedMode is set.
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Selected mode.
	/// It is enabled by default, and you may set it to be false to disable it.
	///  
	/// Besides, it can be set to 'single' , 'multiple' or 'series' , for single selection, multiple selections and whole series selection.
	///   
	/// 'series' is supported since v5.3.0
	/// </summary>
	[JsonPropertyName("selectedMode")]
	[DefaultValue(false)]
	public SelectionMode? SelectedMode { get; set; }

	/// <summary>
	/// progressive specifies the amount of graphic elements that can be rendered within a frame (about 16ms) if "progressive rendering" enabled.
	///  
	/// When data amount is from thousand to more than 10 million, it will take too long time to render all of the graphic elements.
	/// Since ECharts 4, "progressive rendering" is supported in its workflow, which processes and renders data chunk by chunk alone with each frame, avoiding to block the UI thread of the browser.
	///  
	/// Set progressive: 0 to disable progressive permanently.
	/// By default, progressive is auto-enabled when data amount is bigger than progressiveThreshold .
	/// </summary>
	[JsonPropertyName("progressive")]
	[DefaultValue(400)]
	public double? Progressive { get; set; }

	/// <summary>
	/// If current data amount is over the threshold, "progressive rendering" is enabled.
	/// </summary>
	[JsonPropertyName("progressiveThreshold")]
	[DefaultValue(3000)]
	public double? ProgressiveThreshold { get; set; }

	/// <summary>
	/// A groupID common to all data in the series.
	/// the groupID will be used to classify the data and determine how merge and split animations are performed in the universal transition animation.
	///  
	/// If you are using the dataset component to represent the data, it is recommended to use encode.itemGroupID to specify which dimension is encoded as the groupID.
	/// </summary>
	[JsonPropertyName("dataGroupId")]
	public string? DataGroupId { get; set; }

	/// <summary>
	/// The data set of lines.
	/// Can be list of LinesSeriesData
	/// </summary>
	[JsonPropertyName("data")]
	public object? Data { get; set; }

	/// <summary>
	/// Mark point in a chart.
	/// </summary>
	[JsonPropertyName("markPoint")]
	public MarkPoint? MarkPoint { get; set; }

	/// <summary>
	/// Use a line in the chart to illustrate.
	/// </summary>
	[JsonPropertyName("markLine")]
	public MarkLine? MarkLine { get; set; }

	/// <summary>
	/// Used to mark an area in chart.
	/// For example, mark a time interval.
	/// </summary>
	[JsonPropertyName("markArea")]
	public MarkArea? MarkArea { get; set; }

	/// <summary>
	/// Since v4.4.0   
	/// If clip the overflow on the coordinate system.
	/// Clip results varies between series:   Scatter/EffectScatter：Ignore the symbols exceeds the coordinate system.
	/// Not clip the elements.
	///  Bar：Clip all the overflowed.
	/// With bar width kept.
	///  Line：Clip the overflowed line.
	///  Lines: Clip all the overflowed.
	///  Candlestick: Ignore the elements exceeds the coordinate system.
	///  Custom: Clip all the olverflowed.
	///   
	/// All these series have default value true except custom series.
	/// Set it to false if you don't want to clip.
	/// </summary>
	[JsonPropertyName("clip")]
	[DefaultValue("true")]
	public bool? Clip { get; set; }

	/// <summary>
	/// zlevel value of all graphical elements in 路径图.
	///  
	/// zlevel is used to make layers with Canvas.
	/// Graphical elements with different zlevel values will be placed in different Canvases, which is a common optimization technique.
	/// We can put those frequently changed elements (like those with animations) to a separate zlevel .
	/// Notice that too many Canvases will increase memory cost, and should be used carefully on mobile phones to avoid crash.
	///  
	/// Canvases with bigger zlevel will be placed on Canvases with smaller zlevel .
	/// </summary>
	[JsonPropertyName("zlevel")]
	[DefaultValue(0)]
	public double? Zlevel { get; set; }

	/// <summary>
	/// z value of all graphical elements in 路径图, which controls order of drawing graphical components.
	/// Components with smaller z values may be overwritten by those with larger z values.
	///  
	/// z has a lower priority to zlevel , and will not create new Canvas.
	/// </summary>
	[JsonPropertyName("z")]
	[DefaultValue(2)]
	public double? Z { get; set; }

	/// <summary>
	/// Whether to ignore mouse events.
	/// Default value is false, for triggering and responding to mouse events.
	/// </summary>
	[JsonPropertyName("silent")]
	[DefaultValue(false)]
	public bool? Silent { get; set; }

	/// <summary>
	/// Whether to enable animation.
	/// </summary>
	[JsonPropertyName("animation")]
	[DefaultValue("true")]
	public bool? Animation { get; set; }

	/// <summary>
	/// Whether to set graphic number threshold to animation.
	/// Animation will be disabled when graphic number is larger than threshold.
	/// </summary>
	[JsonPropertyName("animationThreshold")]
	[DefaultValue(2000)]
	public double? AnimationThreshold { get; set; }

	/// <summary>
	/// Duration of the first animation, which supports callback function for different data to have different animation effect:  animationDuration: function (idx) {
	///     // delay for later data is larger
	///     return idx * 100;
	/// }
	/// </summary>
	[JsonPropertyName("animationDuration")]
	[DefaultValue("1000")]
	public NumberOrFunction? AnimationDuration { get; set; }

	/// <summary>
	/// Easing method used for the first animation.
	/// Varied easing effects can be found at easing effect example .
	/// </summary>
	[JsonPropertyName("animationEasing")]
	[DefaultValue("cubicOut")]
	public AnimationEasing? AnimationEasing { get; set; }

	/// <summary>
	/// Delay before updating the first animation, which supports callback function for different data to have different animation effect.
	///  
	/// For example:  animationDelay: function (idx) {
	///     // delay for later data is larger
	///     return idx * 100;
	/// }  
	/// See this example for more information.
	/// </summary>
	[JsonPropertyName("animationDelay")]
	[DefaultValue(0)]
	public NumberOrFunction? AnimationDelay { get; set; }

	/// <summary>
	/// Time for animation to complete, which supports callback function for different data to have different animation effect:  animationDurationUpdate: function (idx) {
	///     // delay for later data is larger
	///     return idx * 100;
	/// }
	/// </summary>
	[JsonPropertyName("animationDurationUpdate")]
	[DefaultValue("1000")]
	public NumberOrFunction? AnimationDurationUpdate { get; set; }

	/// <summary>
	/// Easing method used for animation.
	/// </summary>
	[JsonPropertyName("animationEasingUpdate")]
	[DefaultValue("cubicOut")]
	public AnimationEasing? AnimationEasingUpdate { get; set; }

	/// <summary>
	/// Delay before updating animation, which supports callback function for different data to have different animation effects.
	///  
	/// For example:  animationDelayUpdate: function (idx) {
	///     // delay for later data is larger
	///     return idx * 100;
	/// }  
	/// See this example for more information.
	/// </summary>
	[JsonPropertyName("animationDelayUpdate")]
	[DefaultValue(0)]
	public NumberOrFunction? AnimationDelayUpdate { get; set; }

	/// <summary>
	/// Since v5.2.0   
	/// Configuration related to universal transition animation.
	///  
	/// Universal Transition provides the ability to morph between any series.
	/// With this feature enabled, each time setOption , transitions between series with the same id will be automatically associated with each other.
	///  
	/// One-to-many or many-to-one animations such as drill-down, aggregation, etc.
	/// can also be achieved by specifying groups of data such as encode.itemGroupId or dataGroupId .
	///  
	/// This can be enabled directly by configuring universalTransition: true in the series.
	/// It is also possible to provide an object for more detailed configuration.
	/// </summary>
	[JsonPropertyName("universalTransition")]
	public UniversalTransition? UniversalTransition { get; set; }

	/// <summary>
	/// tooltip settings in this series.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; }

}
