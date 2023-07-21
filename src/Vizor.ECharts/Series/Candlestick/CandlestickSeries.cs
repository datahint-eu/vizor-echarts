// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class CandlestickSeries
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("candlestick")]
	public string? Type { get; set; }  = "candlestick";

	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; } 

	/// <summary>
	/// The coordinate used in the series, whose options are:   
	/// 'cartesian2d'  
	/// Use a two-dimensional rectangular coordinate (also known as Cartesian coordinate), with xAxisIndex and yAxisIndex to assign the corresponding axis component.
	/// </summary>
	[JsonPropertyName("coordinateSystem")]
	[DefaultValue("cartesian2d")]
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
	/// Whether to enable highlighting chart when legend is being hovered.
	/// </summary>
	[JsonPropertyName("legendHoverLink")]
	[DefaultValue("true")]
	public bool? LegendHoverLink { get; set; } 

	/// <summary>
	/// Whether to enable animation when hovering on box.
	/// </summary>
	[JsonPropertyName("hoverAnimation")]
	[DefaultValue(true)]
	public bool? HoverAnimation { get; set; } 

	/// <summary>
	/// Layout method, whose values may be:   
	/// 'horizontal' : horizontally layout all boxs.
	///   
	/// 'vertical' : vertically layout all boxs.
	///    
	/// The default value is decided by:   if there is a category axis:  if it is horizontal, use 'horizontal' ;  otherwise use 'vertical' ;    otherwise use 'horizontal' .
	/// </summary>
	[JsonPropertyName("layout")]
	public string? Layout { get; set; } 

	/// <summary>
	/// Specify bar width.
	/// Absolute value (like 10 ) or percentage (like '20%' , according to band width) can be used.
	/// Auto adapt by default.
	/// </summary>
	[JsonPropertyName("barWidth")]
	[DefaultValue("70%")]
	public double? BarWidth { get; set; } 

	/// <summary>
	/// Specify bar min width.
	/// Absolute value (like 10 ) or percentage (like '20%' , according to band width) can be used.
	/// Auto adapt by default.
	/// </summary>
	[JsonPropertyName("barMinWidth")]
	public NumberOrString? BarMinWidth { get; set; } 

	/// <summary>
	/// Specify bar max width.
	/// Absolute value (like 10 ) or percentage (like '20%' , according to band width) can be used.
	/// Auto adapt by default.
	/// </summary>
	[JsonPropertyName("barMaxWidth")]
	public NumberOrString? BarMaxWidth { get; set; } 

	/// <summary>
	/// Item style of candlestick.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// Emphasis style of candlestick.
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
	/// Whether to enable the optimization of large-scale data.
	/// It could be set when large data causes performance problem.
	///  
	/// After being enabled, largeThreshold can be used to indicate the minimum number for turning on the optimization.
	///  
	/// But when the optimization enabled, the style of single data item can't be customized any more.
	/// </summary>
	[JsonPropertyName("large")]
	[DefaultValue(true)]
	public bool? Large { get; set; } 

	/// <summary>
	/// The threshold enabling the drawing optimization.
	/// </summary>
	[JsonPropertyName("largeThreshold")]
	[DefaultValue("600")]
	public double? LargeThreshold { get; set; } 

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
	[DefaultValue(3000)]
	public double? Progressive { get; set; } 

	/// <summary>
	/// If current data amount is over the threshold, "progressive rendering" is enabled.
	/// </summary>
	[JsonPropertyName("progressiveThreshold")]
	[DefaultValue(10000)]
	public double? ProgressiveThreshold { get; set; } 

	/// <summary>
	/// Chunk approach, optional values:   'sequential' : slice data by data index.
	///  'mod' : slice data by mod, which make the data items of each chunk coming from all over the data, bringing better visual effect while progressive rendering.
	/// </summary>
	[JsonPropertyName("progressiveChunkMode")]
	[DefaultValue("mod")]
	public string? ProgressiveChunkMode { get; set; } 

	/// <summary>
	/// dimensions can be used to define dimension info for series.data or dataset.source .
	///  
	/// Notice: if dataset is used, we can definite dimensions in dataset.dimensions , or provide dimension names in the first column/row of dataset.source , and not need to specify dimensions here.
	/// But if dimensions is specified here, it will be used despite the dimension definitions in dataset.
	///  
	/// For example:  option = {
	///     dataset: {
	///         source: [
	///             // 'date', 'open', 'close', 'highest', 'lowest'
	///             [12, 44, 55, 66, 2],
	///             [23, 6, 16, 23, 1],
	///             ...
	///         ]
	///     },
	///     series: {
	///         type: 'xxx',
	///         // Specify name for each dimesions, which will be displayed in tooltip.
	///         dimensions: ['date', 'open', 'close', 'highest', 'lowest']
	///     }
	/// }  series: {
	///     type: 'xxx',
	///     dimensions: [
	///         null,                // If you do not intent to defined this dimension, use null is fine.
	///         {type: 'ordinal'},   // Specify type of this dimension.
	///                              // 'ordinal' is always used in string.
	///                              // If type is not specified, echarts will guess type by data.
	///         {name: 'good', type: 'number'},
	///         'bad'                // Equals to {name: 'bad'}.
	///     ]
	/// }  
	/// Each data item of dimensions can be:   string , for example, 'someName' , which equals to {name: 'someName'} .
	///  Object , where the attributes can be:  name: string .
	///  type: string , supports:  number  float , that is, Float64Array  int , that is, Int32Array  ordinal , discrete value, which represents string generally.
	///  time , time value, see data to check the format of time value.
	///    displayName: string , generally used in tooltip for dimension display.
	/// If not specified, use name by default.
	///     
	/// When dimensions is specified, the default tooltip will be displayed vertically, which is better to show diemsion names.
	/// Otherwise, tooltip will displayed only value horizontally.
	/// </summary>
	[JsonPropertyName("dimensions")]
	public List<object>? Dimensions { get; set; } 

	/// <summary>
	/// Define what is encoded to for each dimension of data .
	/// For example:  option = {
	///     dataset: {
	///         source: [
	///             // Each column is called a dimension.
	///             // There are five dimensions: 0, 1, 2, 3, 4.
	///             [12, 44, 55, 66, 2],
	///             [23, 6, 16, 23, 1],
	///             ...
	///         ]
	///     },
	///     series: {
	///         type: 'xxx',
	///         encode: {
	///             x: [3, 1, 5],      // Dimension 3, 1, 5 is mapped to x axis.
	///             y: 2,              // Dimension 2 is mapped to y axis.
	///             tooltip: [3, 2, 4] // Dimension 3, 2, 4 will be displayed in tooltip.
	///         }
	///     }
	/// }  
	/// When dimensions is used to defined name for a certain dimension, encode can refer the name directly.
	/// For example:  series: {
	///     type: 'xxx',
	///     dimensions: ['date', 'open', 'close', 'highest', 'lowest'],
	///     encode: {
	///         x: 'date',
	///         y: ['open', 'close', 'highest', 'lowest']
	///     }
	/// }  
	/// The basic structure of encode is illustrated as follows, where the left part of colon is the name of axis like 'x' , 'y' , 'radius' , 'angle' or some special reserved names like "tooltip", "itemName" etc., and the right part of the colon is the dimension names or dimension indices (based on 0).
	/// One or more dimensions can be specified.
	/// Usually not all of mappings need to be specified, only specify needed ones.
	///  
	/// The properties available in encode listed as follows:  // In any of the series and coordinate systems,
	/// // these properties are available:
	/// encode: {
	///     // Display dimension "product" and "score" in the tooltip.
	///     tooltip: ['product', 'score']
	///     // Set the series name as the concat of the names of dimensions[1] and dimensions[3].
	///     // (sometimes the dimension names are too long to type in series.name manually).
	///     seriesName: [1, 3],
	///     // Using dimensions[2] as the id of each data item.
	/// This is useful when dynamically
	///     // update data by `chart.setOption()`, where the new and old data item can be
	///     // corresponded by id, by which the appropriate animation can be performed when updating.
	///     itemId: 2,
	///     // Using dimensions[3] as the name of each data item.
	/// This is useful in charts like
	///     // 'pie', 'funnel', where data item name can be displayed in legend.
	///     itemName: 3,
	///     // Using dimensions[4] as the groupId of each data item.
	/// groupId will be used to categorize the data.
	/// And to determine
	///     // How the merge and split animation are performed in the universal transition.
	/// See universalTransition option for detail.
	///     itemGroupId: 4
	/// }
	/// 
	/// // These properties only work in cartesian(grid) coordinate system:
	/// encode: {
	///     // Map dimensions[1], dimensions[5] and dimension "score" to the X axis.
	///     x: [1, 5, 'score'],
	///     // Map dimensions[0] to the Y axis.
	///     y: 0
	/// }
	/// 
	/// // These properties only work in polar coordinate system:
	/// encode: {
	///     radius: 3,
	///     angle: 2,
	///     ...
	/// }
	/// 
	/// // These properties only work in geo coordinate system:
	/// encode: {
	///     lng: 3,
	///     lat: 2
	/// }
	/// 
	/// // For some type of series that are not in any coordinate system,
	/// // like 'pie', 'funnel' etc.:
	/// encode: {
	///     value: 3
	/// }  
	/// This is an example for encode .
	///  
	/// Specially, in [custom series(~series-custom), some property in encode , corresponding to axis, can be set as null to make the series not controlled by the axis, that is, the series data will not be count in the extent of the axis, and the dataZoom on the axis will not filter the series.
	///  var option = {
	///     xAxis: {},
	///     yAxis: {},
	///     dataZoom: [{
	///         xAxisIndex: 0
	///     }, {
	///         yAxisIndex: 0
	///     }],
	///     series: {
	///         type: 'custom',
	///         renderItem: function (params, api) {
	///             return {
	///                 type: 'circle',
	///                 shape: {
	///                     cx: 100, // x position is always 100
	///                     cy: api.coord([0, api.value(0)])[1],
	///                     r: 30
	///                 },
	///                 style: {
	///                     fill: 'blue'
	///                 }
	///             };
	///         },
	///         encode: {
	///             // Then the series will not be controlled
	///             // by x axis and corresponding dataZoom.
	///             x: -1,
	///             y: 1
	///         },
	///         data: [ ...
	/// ]
	///     }
	/// };
	/// </summary>
	[JsonPropertyName("encode")]
	public Encode? Encode { get; set; } 

	/// <summary>
	/// A groupID common to all data in the series.
	/// the groupID will be used to classify the data and determine how merge and split animations are performed in the universal transition animation.
	///  
	/// If you are using the dataset component to represent the data, it is recommended to use encode.itemGroupID to specify which dimension is encoded as the groupID.
	/// </summary>
	[JsonPropertyName("dataGroupId")]
	public string? DataGroupId { get; set; } 

	/// <summary>
	/// Data should be the two-dimensional array shown as follows.
	///  [
	///     [2320.26, 2320.26, 2287.3,  2362.94],
	///     [2300,    2291.3,  2288.26, 2308.38],
	///     { // the data item could also be an Object, so that it could contains special settings for this data item.
	///         value: [2300,    2291.3,  2288.26, 2308.38],
	///         itemStyle: {...}
	///     },
	///     ...
	/// ]  
	/// Every data item (each line in the example above) represents a box, which contains 4 values.
	/// They are:  [open, close, lowest, highest]  (namely: [opening value, closing value, lowest value, highest value])
	/// </summary>
	[JsonPropertyName("data")]
	public List<CandlestickSeriesData>? Data { get; set; } 

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
	/// Since v4.5.0   
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
	/// zlevel value of all graphical elements in Candlestick .
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
	/// z value of all graphical elements in Candlestick , which controls order of drawing graphical components.
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
	/// Duration of the first animation, which supports callback function for different data to have different animation effect:  animationDuration: function (idx) {
	///     // delay for later data is larger
	///     return idx * 100;
	/// }
	/// </summary>
	[JsonPropertyName("animationDuration")]
	[DefaultValue("300")]
	public NumberOrFunction? AnimationDuration { get; set; } 

	/// <summary>
	/// Easing method used for the first animation.
	/// Varied easing effects can be found at easing effect example .
	/// </summary>
	[JsonPropertyName("animationEasing")]
	[DefaultValue("linear")]
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
