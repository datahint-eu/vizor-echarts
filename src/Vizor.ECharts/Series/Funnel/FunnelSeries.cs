// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class FunnelSeries
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("funnel")]
	public string? Type { get; set; }  = "funnel";

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
	[DefaultValue("data")]
	public ColorBy? ColorBy { get; set; } 

	/// <summary>
	/// The specified minimum value.
	/// </summary>
	[JsonPropertyName("min")]
	[DefaultValue("0")]
	public double? Min { get; set; } 

	/// <summary>
	/// The specified maximum value.
	/// </summary>
	[JsonPropertyName("max")]
	[DefaultValue("100")]
	public double? Max { get; set; } 

	/// <summary>
	/// The mapped width from minimum data value min .
	///  
	/// It can be absolute pixel and also the percentage of layout width .
	/// If you don't want the graph of minimum value to be a triangle, you can set up this property larger than 0.
	/// </summary>
	[JsonPropertyName("minSize")]
	[DefaultValue("0%")]
	public NumberOrString? MinSize { get; set; } 

	/// <summary>
	/// The mapped width from maximum data value max .
	///  
	/// It can be absolute pixel and also the percentage of layout width .
	/// </summary>
	[JsonPropertyName("maxSize")]
	[DefaultValue("100%")]
	public NumberOrString? MaxSize { get; set; } 

	/// <summary>
	/// Orient of funnel，Can be 'vertical' or 'horizontal' .
	///   
	/// Since v4.9.0
	/// </summary>
	[JsonPropertyName("orient")]
	[DefaultValue("vertical")]
	public Orient? Orient { get; set; } 

	/// <summary>
	/// Data sorting, which can be whether 'ascending' , 'descending' , 'none' (in data order) or a function, which is the same as Array.prototype.sort(function (a, b) { ...
	/// }) ;
	/// </summary>
	[JsonPropertyName("sort")]
	[DefaultValue("descending")]
	public object? Sort { get; set; } 

	/// <summary>
	/// Gap between each trapezoid.
	/// </summary>
	[JsonPropertyName("gap")]
	[DefaultValue("0")]
	public double? Gap { get; set; } 

	/// <summary>
	/// Whether to enable highlighting chart when legend is being hovered.
	/// </summary>
	[JsonPropertyName("legendHoverLink")]
	[DefaultValue("true")]
	public bool? LegendHoverLink { get; set; } 

	/// <summary>
	/// Horizontal align.
	/// Defaults to align center.
	/// Can be 'left', 'right', 'center'.
	/// </summary>
	[JsonPropertyName("funnelAlign")]
	[DefaultValue("center")]
	public FunnelAlign? FunnelAlign { get; set; } 

	/// <summary>
	/// Text label of funnel chart, to explain some data information about graphic item like value, name and so on.
	/// label is placed under itemStyle in ECharts 2.x.
	/// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// The visual guide line style of label.
	/// When label position is set as 'left' or 'right' , the visual guide line will show.
	/// </summary>
	[JsonPropertyName("labelLine")]
	public LabelLine? LabelLine { get; set; } 

	/// <summary>
	/// Graphic style of , emphasis is the style when it is highlighted, like being hovered by mouse, or highlighted via legend connect.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

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
	/// Configurations of emphasis state.
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
	/// zlevel value of all graphical elements in .
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
	/// z value of all graphical elements in , which controls order of drawing graphical components.
	/// Components with smaller z values may be overwritten by those with larger z values.
	///  
	/// z has a lower priority to zlevel , and will not create new Canvas.
	/// </summary>
	[JsonPropertyName("z")]
	[DefaultValue(2)]
	public double? Z { get; set; } 

	/// <summary>
	/// Distance between Funnel component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue(80)]
	public NumberOrString? Left { get; set; } 

	/// <summary>
	/// Distance between Funnel component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue(60)]
	public NumberOrString? Top { get; set; } 

	/// <summary>
	/// Distance between Funnel component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue(80)]
	public NumberOrString? Right { get; set; } 

	/// <summary>
	/// Distance between Funnel component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue(60)]
	public NumberOrString? Bottom { get; set; } 

	/// <summary>
	/// Width of Funnel component.
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("width")]
	[DefaultValue("auto")]
	public NumberOrString? Width { get; set; } 

	/// <summary>
	/// Height of Funnel component.
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("height")]
	[DefaultValue("auto")]
	public NumberOrString? Height { get; set; } 

	/// <summary>
	/// When dataset is used, seriesLayoutBy specifies whether the column or the row of dataset is mapped to the series, namely, the series is "layout" on columns or rows.
	/// Optional values:   'column': by default, the columns of dataset are mapped the series.
	/// In this case, each column represents a dimension.
	///  'row'：the rows of dataset are mapped to the series.
	/// In this case, each row represents a dimension.
	///   
	/// Check this example .
	/// </summary>
	[JsonPropertyName("seriesLayoutBy")]
	[DefaultValue("column")]
	public SeriesLayoutBy? SeriesLayoutBy { get; set; } 

	/// <summary>
	/// If series.data is not specified, and dataset exists, the series will use dataset .
	/// datasetIndex specifies which dataset will be used.
	/// </summary>
	[JsonPropertyName("datasetIndex")]
	[DefaultValue(0)]
	public int? DatasetIndex { get; set; } 

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
	/// Data array of  series, which can be a single data value, like:  [12, 34, 56, 10, 23]  
	/// Or, if need extra dimensions for components like visualMap to map to graphic attributes like color, it can also be in the form of array.
	/// For example:  [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]  
	/// In this case, we can assgin the second value in each array item to visualMap component.
	///  
	/// More likely, we need to assign name to each data item, in which case each item should be an object:  [{
	///     // name of date item
	///     name: 'data1',
	///     // value of date item is 8
	///     value: 10
	/// }, {
	///     name: 'data2',
	///     value: 20
	/// }]  
	/// Each data item can be further customized:  [{
	///     name: 'data1',
	///     value: 10
	/// }, {
	///     // name of data item
	///     name: 'data2',
	///     value : 56,
	///     // user-defined label format that only useful for this data item
	///     label: {},
	///     // user-defined special itemStyle that only useful for this data item
	///     itemStyle:{}
	/// }]
	/// </summary>
	[JsonPropertyName("data")]
	public List<FunnelSeriesData>? Data { get; set; } 

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
