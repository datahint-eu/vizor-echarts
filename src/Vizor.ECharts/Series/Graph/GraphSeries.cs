
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class GraphSeries : ISeries
{
	[JsonPropertyName("type")]
	public string Type => "graph";

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
	/// Whether to enable highlighting chart when legend is being hovered.
	/// </summary>
	[JsonPropertyName("legendHoverLink")]
	[DefaultValue("true")]
	public bool? LegendHoverLink { get; set; } 

	/// <summary>
	/// The coordinate used in the series, whose options are:   
	/// null or 'none'  
	/// No coordinate.
	///     
	/// 'cartesian2d'  
	/// Use a two-dimensional rectangular coordinate (also known as Cartesian coordinate), with xAxisIndex and yAxisIndex to assign the corresponding axis component.
	///     
	/// 'polar'  
	/// Use polar coordinates, with polarIndex to assign the corresponding polar coordinate component.
	///     
	/// 'geo'  
	/// Use geographic coordinate, with geoIndex to assign the corresponding geographic coordinate components.
	///     
	/// 'calendar'  
	/// Use calendar coordinates, with calendarIndex to assign the corresponding calendar coordinate components.
	///     
	/// 'none'  
	/// Do not use coordinate system.
	/// </summary>
	[JsonPropertyName("coordinateSystem")]
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
	/// Index of polar coordinate to combine with, which is useful for multiple polar axes in one chart.
	/// </summary>
	[JsonPropertyName("polarIndex")]
	[DefaultValue(0)]
	public int? PolarIndex { get; set; } 

	/// <summary>
	/// Index of geographic coordinate to combine with, which is useful for multiple geographic axes in one chart.
	/// </summary>
	[JsonPropertyName("geoIndex")]
	[DefaultValue(0)]
	public int? GeoIndex { get; set; } 

	/// <summary>
	/// Index of calendar coordinates to combine with, which is useful for multiple calendar coordinates in one chart.
	/// </summary>
	[JsonPropertyName("calendarIndex")]
	[DefaultValue(0)]
	public int? CalendarIndex { get; set; } 

	/// <summary>
	/// Center of current view-port.
	/// It can be an arrary containing two number s in pixels or string s in percentage relative to the container width/height.
	/// string is supported from version 5.3.3 .
	///  
	/// Example:  center: [115.97, '30%']
	/// </summary>
	[JsonPropertyName("center")]
	[DefaultValue("0,0")]
	public double[]? Center { get; set; } 

	/// <summary>
	/// Zoom rate of current view-port.
	/// </summary>
	[JsonPropertyName("zoom")]
	[DefaultValue("1")]
	public double? Zoom { get; set; } 

	/// <summary>
	/// Graph layout.
	///  
	/// Options:   
	/// 'none' No any layout, use x , y provided in node as the position of node.
	///   
	/// 'circular' Adopt circular layout, see the example Les Miserables .
	///   
	/// 'force' Adopt force-directed layout, see the example Force , the detail about configrations of layout are in graph.force
	/// </summary>
	[JsonPropertyName("layout")]
	[DefaultValue("none")]
	public GraphLayout? Layout { get; set; } 

	/// <summary>
	/// Configuration about circular layout.
	/// </summary>
	[JsonPropertyName("circular")]
	public Circular? Circular { get; set; } 

	/// <summary>
	/// Configuration items about force-directed layout.
	/// Force-directed layout simulates spring/charge model, which will add a repulsion between 2 nodes and add a attraction between 2 nodes of each edge.
	/// In each iteration nodes will move under the effect of repulsion and attraction.
	/// After several iterations, the nodes will be static in a balanced position.
	/// As a result, the energy local minimum of this whole model will be realized.
	///  
	/// The result of force-directed layout has a good symmetries and clustering, which is also aesthetically pleasing.
	/// </summary>
	[JsonPropertyName("force")]
	public Force? Force { get; set; } 

	/// <summary>
	/// Whether to enable mouse zooming and translating.
	/// false by default.
	/// If either zooming or translating is wanted, it can be set to 'scale' or 'move' .
	/// Otherwise, set it to be true to enable both.
	/// </summary>
	[JsonPropertyName("roam")]
	[DefaultValue(false)]
	public Roam? Roam { get; set; } 

	/// <summary>
	/// Limit of scaling, with min and max .
	/// 1 by default.
	/// </summary>
	[JsonPropertyName("scaleLimit")]
	public ScaleLimit? ScaleLimit { get; set; } 

	/// <summary>
	/// Related zooming ratio of nodes when mouse zooming in or out.
	/// When it is set as 0, the node will not zoom as the mouse zooms.
	/// </summary>
	[JsonPropertyName("nodeScaleRatio")]
	[DefaultValue("0.6")]
	public double? NodeScaleRatio { get; set; } 

	/// <summary>
	/// If node is draggable.
	///  
	/// Note that this option is only available when using force-directed layout before v5.4.1 .
	/// </summary>
	[JsonPropertyName("draggable")]
	[DefaultValue("false")]
	public bool? Draggable { get; set; } 

	/// <summary>
	/// Symbol of node.
	///  
	/// Icon types provided by ECharts includes  
	/// 'circle' , 'rect' , 'roundRect' , 'triangle' , 'diamond' , 'pin' , 'arrow' , 'none'  
	/// It can be set to an image with 'image://url' , in which URL is the link to an image, or dataURI of an image.
	///  
	/// An image URL example:  'image://http://example.website/a/b.png' 
	/// A dataURI example:  'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7' 
	/// Icons can be set to arbitrary vector path via 'path://' in ECharts.
	/// As compared with a raster image, vector paths prevent jagging and blurring when scaled, and have better control over changing colors.
	/// The size of the vector icon will be adapted automatically.
	/// Refer to SVG PathData for more information about the format of the path.
	/// You may export vector paths from tools like Adobe  
	/// For example:  'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
	/// </summary>
	[JsonPropertyName("symbol")]
	[DefaultValue("circle")]
	public Icon? Symbol { get; set; } 

	/// <summary>
	/// node symbol size.
	/// It can be set to single numbers like 10 , or use an array to represent width and height.
	/// For example, [20, 10] means symbol width is 20 , and height is 10 .
	/// </summary>
	[JsonPropertyName("symbolSize")]
	public NumberOrNumberArray? SymbolSize { get; set; } 

	/// <summary>
	/// Rotate degree of node symbol.
	/// The negative value represents clockwise.
	/// Note that when symbol is set to be 'arrow' in markLine , symbolRotate value will be ignored, and compulsively use tangent angle.
	/// </summary>
	[JsonPropertyName("symbolRotate")]
	public double? SymbolRotate { get; set; } 

	/// <summary>
	/// Whether to keep aspect for symbols in the form of path:// .
	/// </summary>
	[JsonPropertyName("symbolKeepAspect")]
	[DefaultValue(false)]
	public bool? SymbolKeepAspect { get; set; } 

	/// <summary>
	/// Offset of node symbol relative to original position.
	/// By default, symbol will be put in the center position of data.
	/// But if symbol is from user-defined vector path or image, you may not expect symbol to be in center.
	/// In this case, you may use this attribute to set offset to default position.
	/// It can be in absolute pixel value, or in relative percentage value.
	///  
	/// For example, [0, '-50%'] means to move upside side position of symbol height.
	/// It can be used to make the arrow in the bottom to be at data position when symbol is pin.
	/// </summary>
	[JsonPropertyName("symbolOffset")]
	[DefaultValue("[0, 0]")]
	public double[]? SymbolOffset { get; set; } 

	/// <summary>
	/// Symbol of two ends of edge line.
	///  
	/// For example:  edgeSymbol: ['circle', 'arrow']
	/// </summary>
	[JsonPropertyName("edgeSymbol")]
	[DefaultValue("[none, none]")]
	public Icon? EdgeSymbol { get; set; } 

	/// <summary>
	/// Size of symbol of two ends of edge line.
	/// Can be an array or a single number.
	///  
	/// For example:  // Start symbol has size 5 and end symbol has size 10
	/// edgeSymbolSize: [5, 10],
	/// // All has size 10
	/// edgeSymbolSize: 10
	/// </summary>
	[JsonPropertyName("edgeSymbolSize")]
	[DefaultValue("10")]
	public NumberArray? EdgeSymbolSize { get; set; } 

	/// <summary>
	/// The mouse style when mouse hovers on an element, the same as cursor property in CSS .
	/// </summary>
	[JsonPropertyName("cursor")]
	[DefaultValue("pointer")]
	public string? Cursor { get; set; } 

	/// <summary>
	/// Graphic style of , emphasis is the style when it is highlighted, like being hovered by mouse, or highlighted via legend connect.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// The style of edge line.
	/// lineStyle.color can be 'source' or 'target' , which will use the color of source node or target node.
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

	/// <summary>
	/// Text label of , to explain some data information about graphic item like value, name and so on.
	/// label is placed under itemStyle in ECharts 2.x.
	/// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("edgeLabel")]
	public EdgeLabel? EdgeLabel { get; set; } 

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
	/// The categories of node, which is optional.
	/// If there is a classification of nodes, the category of each node can be assigned through data[i].category .
	/// And the style of category will also be applied to the style of nodes.
	/// categories can also be used in legend .
	/// </summary>
	[JsonPropertyName("categories")]
	public List<GraphSeriesCategories>? Categories { get; set; } 

	/// <summary>
	/// For the situation where there are multiple links between nodes, the curveness of each link is automatically calculated, not enabled by default.
	///  
	/// When set true to enable automatic curvature calculation, the default edge curvenness array length is 20 , if the number of edges between two nodes is more than 20 , please use number or Array to set the edge curvenness array.
	///  
	/// When set to number , it indicates the length of the edge curvenness array between two nodes, and the calculation result is given by the internal algorithm.
	///  
	/// When set to Array , it means that the curveness array is directly specified, and the multilateral curveness is directly selected from the array.
	///  
	/// Notice： if lineStyle.curveness has been set, this property is invalid.
	/// </summary>
	[JsonPropertyName("autoCurveness")]
	[DefaultValue(false)]
	public AutoCurveness? AutoCurveness { get; set; }

	/// <summary>
	/// Nodes list of graph.
	/// Can be a list of GraphSeriesData.
	/// 
	///  data: [{
	///     name: '1',
	///     x: 10,
	///     y: 10,
	///     value: 10
	/// }, {
	///     name: '2',
	///     x: 100,
	///     y: 100,
	///     value: 20,
	///     symbolSize: 20,
	///     itemStyle: {
	///         color: 'red'
	///     }
	/// }]
	/// </summary>
	[JsonPropertyName("data")]
	public object? Data { get; set; } 

	/// <summary>
	/// Alias of data
	/// </summary>
	[JsonPropertyName("nodes")]
	public List<GraphSeriesData>? Nodes { get; set; } 

	/// <summary>
	/// Relational data between nodes.
	/// Example:  links: [{
	///     source: 'n1',
	///     target: 'n2'
	/// }, {
	///     source: 'n2',
	///     target: 'n3'
	/// }]
	/// </summary>
	[JsonPropertyName("links")]
	public List<GraphSeriesLinks>? Links { get; set; } 

	/// <summary>
	/// Alias of links
	/// </summary>
	[JsonPropertyName("edges")]
	public List<GraphSeriesLinks>? Edges { get; set; } 

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
	/// Distance between  component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue("center")]
	public NumberOrString? Left { get; set; } 

	/// <summary>
	/// Distance between  component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue("middle")]
	public NumberOrString? Top { get; set; } 

	/// <summary>
	/// Distance between  component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue("auto")]
	public NumberOrString? Right { get; set; } 

	/// <summary>
	/// Distance between  component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue("auto")]
	public NumberOrString? Bottom { get; set; } 

	/// <summary>
	/// Width of  component.
	/// </summary>
	[JsonPropertyName("width")]
	[DefaultValue("auto")]
	public NumberOrString? Width { get; set; } 

	/// <summary>
	/// Height of  component.
	/// </summary>
	[JsonPropertyName("height")]
	[DefaultValue("auto")]
	public NumberOrString? Height { get; set; } 

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
	/// tooltip settings in this series.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

}
