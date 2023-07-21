// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class SankeySeries
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("sankey")]
	public string? Type { get; set; }  = "sankey";

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
	/// Distance between sankey component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue("5%")]
	public NumberOrString? Left { get; set; } 

	/// <summary>
	/// Distance between sankey component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue("5%")]
	public NumberOrString? Top { get; set; } 

	/// <summary>
	/// Distance between sankey component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue("20%")]
	public NumberOrString? Right { get; set; } 

	/// <summary>
	/// Distance between sankey component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue("5%")]
	public NumberOrString? Bottom { get; set; } 

	/// <summary>
	/// Width of sankey component.
	/// </summary>
	[JsonPropertyName("width")]
	public NumberOrString? Width { get; set; } 

	/// <summary>
	/// Height of sankey component.
	/// </summary>
	[JsonPropertyName("height")]
	public NumberOrString? Height { get; set; } 

	/// <summary>
	/// The node width of rectangle in Sankey diagram.
	/// </summary>
	[JsonPropertyName("nodeWidth")]
	[DefaultValue("20")]
	public double? NodeWidth { get; set; } 

	/// <summary>
	/// The gap between any two rectangles in each column of the Sankey diagram.
	/// </summary>
	[JsonPropertyName("nodeGap")]
	[DefaultValue("8")]
	public double? NodeGap { get; set; } 

	/// <summary>
	/// Controls the horizontal alignment of nodes in the diagram.
	///  
	/// May be:   
	/// left : initial nodes (those with no incoming links) are aligned to the left of the diagram.
	///   
	/// right : terminal nodes (those with no outgoing links) are aligned to the right of the diagram.
	///   
	/// justify : initial and terminal nodes are aligned on the left and right edges.
	///    
	/// Note when orient is vertical , nodeAlign controls vertical alignment.
	/// </summary>
	[JsonPropertyName("nodeAlign")]
	[DefaultValue("justify")]
	public SankeyNodeAlign? NodeAlign { get; set; } 

	/// <summary>
	/// The iterations of layout, which is used to iteratively optimize the position of the nodes and edges in the Sankey diagram to reduce the overlapping between nodes and edges.
	/// The default value is 32 .
	/// If you want the order of the nodes in the chart to be the same with the order in the original data , you can set the value to be 0 .
	/// </summary>
	[JsonPropertyName("layoutIterations")]
	[DefaultValue("32")]
	public double? LayoutIterations { get; set; } 

	/// <summary>
	/// The layout direction of the nodes in the Sankey diagram, which can be horizontal from left to right or vertical from top to bottom.
	/// The corresponding parameter values ​​are horizontal or vertical .
	/// </summary>
	[JsonPropertyName("orient")]
	[DefaultValue("horizontal")]
	public Orient? Orient { get; set; } 

	/// <summary>
	/// The drag-and-drop interaction of the node, which is enabled by default.
	/// After opening, the user can drag any node in the Sankey diagram to any position.
	/// To turn this interaction off, simply set the value to false .
	/// </summary>
	[JsonPropertyName("draggable")]
	[DefaultValue("true")]
	public bool? Draggable { get; set; } 

	/// <summary>
	/// Since v5.4.1   
	/// The label style of each edge/link.
	/// </summary>
	[JsonPropertyName("edgeLabel")]
	public EdgeLabel? EdgeLabel { get; set; } 

	/// <summary>
	/// The setting of each layer of Sankey diagram.
	/// Can be set layer by layer, as follows:  levels: [{
	///     depth: 0,
	///     itemStyle: {
	///         color: '#fbb4ae'
	///     },
	///     lineStyle: {
	///         color: 'source',
	///         opacity: 0.6
	///     }
	/// }, {
	///     depth: 1,
	///     itemStyle: {
	///         color: '#b3cde3'
	///     },
	///     lineStyle: {
	///         color: 'source',
	///         opacity: 0.6
	///     }
	/// }]  
	/// You can also only set a certain layer:  levels: [{
	///     depth: 3,
	///     itemStyle: {
	///         color: '#fbb4ae'
	///     },
	///     lineStyle: {
	///         color: 'source',
	///         opacity: 0.6
	///     }
	/// }]
	/// </summary>
	[JsonPropertyName("levels")]
	public List<SankeySeriesLevels>? Levels { get; set; } 

	/// <summary>
	/// label describes the text label style in each rectangular node.
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
	/// The style of node rectangle in Sankey diagram.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// The edge style of Sankey diagram
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

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
	/// Configurations of selected state.
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
	/// The nodes list of the sankey diagram.
	///  data: [{
	///     name: 'node1',
	///     // This attribute decides the layer of the current node.
	///     depth: 0
	/// }, {
	///     name: 'node2',
	///     depth: 1
	/// }]  
	/// Notice: The name of the node cannot be repeated.
	/// </summary>
	[JsonPropertyName("data")]
	public List<SankeySeriesData>? Data { get; set; } 

	/// <summary>
	/// Equals to data
	/// </summary>
	[JsonPropertyName("nodes")]
	public List<SankeySeriesData>? Nodes { get; set; } 

	/// <summary>
	/// The links between nodes.
	/// Notes: The Sankey diagram theoretically only supports Directed Acyclic Graph(DAG), so please make sure that there is no cycle in the links.
	/// For instance:  links: [{
	///     source: 'n1',
	///     target: 'n2'
	/// }, {
	///     source: 'n2',
	///     target: 'n3'
	/// }]
	/// </summary>
	[JsonPropertyName("links")]
	public List<SankeySeriesLinks>? Links { get; set; } 

	/// <summary>
	/// Equals to links
	/// </summary>
	[JsonPropertyName("edges")]
	public List<SankeySeriesLinks>? Edges { get; set; } 

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
