// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class TreeSeries
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("tree")]
	public string? Type { get; set; }  = "tree";

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
	/// Distance between tree component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue("12%")]
	public NumberOrString? Left { get; set; } 

	/// <summary>
	/// Distance between tree component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue("12%")]
	public NumberOrString? Top { get; set; } 

	/// <summary>
	/// Distance between tree component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue("12%")]
	public NumberOrString? Right { get; set; } 

	/// <summary>
	/// Distance between tree component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue("12%")]
	public NumberOrString? Bottom { get; set; } 

	/// <summary>
	/// Width of tree component.
	/// </summary>
	[JsonPropertyName("width")]
	public NumberOrString? Width { get; set; } 

	/// <summary>
	/// Height of tree component.
	/// </summary>
	[JsonPropertyName("height")]
	public NumberOrString? Height { get; set; } 

	/// <summary>
	/// Center of current view-port.
	/// It can be an arrary containing two number s in pixels or string s in percentage relative to the container width/height.
	/// string is supported from version 5.3.3 .
	///  
	/// Example:  center: [115.97, '30%']
	/// </summary>
	[JsonPropertyName("center")]
	//TODO: Type Warning: array type 'center' in 'TreeSeries' will be mapped to List<object>
	public List<object>? Center { get; set; } 

	/// <summary>
	/// Zoom rate of current view-port.
	/// </summary>
	[JsonPropertyName("zoom")]
	[DefaultValue(1)]
	public double? Zoom { get; set; } 

	/// <summary>
	/// The layout of the tree, which can be orthogonal and radial .
	/// Here the orthogonal layout is what we usually refer to the horizontal and vertical direction, the corresponding parameter value is orthogonal .
	/// The radial layout refers to the view that the root node as the center and each layer of nodes as the ring, the corresponding parameter value is radial .
	///  
	/// Orthogonal Example：   
	/// Radial Example：
	/// </summary>
	[JsonPropertyName("layout")]
	[DefaultValue("orthogonal")]
	public TreeLayout? Layout { get; set; } 

	/// <summary>
	/// The direction of the orthogonal layout in the tree diagram.
	/// That means this configuration takes effect only if layout = 'orthogonal' .
	/// The corresponding directions are from left to right , from right to left , from top to bottom , from bottom to top , with shorthand values 'LR' , 'RL' , 'TB' , 'BT' .
	/// Note: The previous configuration value 'horizontal' is equivalent to 'LR' , 'vertical' is equivalent to 'TB' .
	/// </summary>
	[JsonPropertyName("orient")]
	[DefaultValue("LR")]
	public Orient? Orient { get; set; } 

	/// <summary>
	/// Symbol of .
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
	/// If symbols needs to be different, you can set with callback function in the following format:  (value: Array|number, params: Object) => string  
	/// The first parameter value is the value in data , and the second parameter params is the rest parameters of data item.
	/// </summary>
	[JsonPropertyName("symbol")]
	[DefaultValue("circle")]
	public StringOrFunction? Symbol { get; set; } 

	/// <summary>
	/// symbol size.
	/// It can be set to single numbers like 10 , or use an array to represent width and height.
	/// For example, [20, 10] means symbol width is 20 , and height is 10 .
	///  
	/// If size of symbols needs to be different, you can set with callback function in the following format:  (value: Array|number, params: Object) => number|Array  
	/// The first parameter value is the value in data , and the second parameter params is the rest parameters of data item.
	/// </summary>
	[JsonPropertyName("symbolSize")]
	[DefaultValue(7)]
	public NumberArrayOrFunction? SymbolSize { get; set; } 

	/// <summary>
	/// Rotate degree of  symbol.
	/// The negative value represents clockwise.
	/// Note that when symbol is set to be 'arrow' in markLine , symbolRotate value will be ignored, and compulsively use tangent angle.
	///  
	/// If rotation of symbols needs to be different, you can set with callback function in the following format:  (value: Array|number, params: Object) => number  
	/// The first parameter value is the value in data , and the second parameter params is the rest parameters of data item.
	///   
	/// Callback is supported since 4.8.0 .
	/// </summary>
	[JsonPropertyName("symbolRotate")]
	public NumberOrFunction? SymbolRotate { get; set; } 

	/// <summary>
	/// Whether to keep aspect for symbols in the form of path:// .
	/// </summary>
	[JsonPropertyName("symbolKeepAspect")]
	[DefaultValue(false)]
	public bool? SymbolKeepAspect { get; set; } 

	/// <summary>
	/// Offset of  symbol relative to original position.
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
	/// Since v4.7.0   
	/// The shape of the edge which is under the tree orthogonal layout .
	/// There are two types of shape, curve and polyline, the corresponding values are 'curve' and 'polyline' .
	///  
	/// Note: This configuration item is only valid under the orthogonal layout .
	/// Errors will be reported in the development environment under the radial layout .
	/// </summary>
	[JsonPropertyName("edgeShape")]
	[DefaultValue("curve")]
	public TreeEdgeShape? EdgeShape { get; set; } 

	/// <summary>
	/// This is the position where the polyline branches in the subtree when the shape of the edge is a polyline in the orthogonal layout .
	/// The position here refers to the percentage of the distance between the bifurcation point and the parent node of the subtree to the height of the entire subtree.
	/// The default value is '50%' , which can be between ['0', '100%'].
	///  
	/// Note: This configuration item is only valid when edgeShape = 'polyline' .
	/// </summary>
	[JsonPropertyName("edgeForkPosition")]
	[DefaultValue("50%")]
	public string? EdgeForkPosition { get; set; } 

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
	/// Subtree collapses and expands interaction, default true .
	/// As the drawing area is limited, and usually the nodes of a tree may be more, so there will be hidden between the nodes.
	/// In order to avoid this problem, you can put a temporary unrelated subtree folded away, until you need to start when necessary.
	/// Such as the above radial layout tree example, the center of the node is filled with blue is the folded away subtree, you can click to expand it.
	///  
	/// Note: If you configure a custom image as the tag for a node, it is not possible to distinguish whether the current node has a collapsed subtree by the fill color.
	/// And currently do not support, upload two pictures, respectively represent the collapsing and expansion state of the node.
	/// So, if you want to explicitly show the two states of the node, it is recommended to use ECharts regular tag types, such as emptyCircle .
	/// </summary>
	[JsonPropertyName("expandAndCollapse")]
	[DefaultValue("true")]
	public bool? ExpandAndCollapse { get; set; } 

	/// <summary>
	/// The initial level (depth) of the tree.
	/// The root node is the 0th layer, then the first layer, the second layer, ...
	/// , until the leaf node.
	/// This configuration item is primarily used in conjunction with collapsing and expansion interactions.
	/// The purpose is to prevent the nodes from obscuring each other.
	/// If set as -1 or null or undefined , all nodes are expanded.
	/// </summary>
	[JsonPropertyName("initialTreeDepth")]
	[DefaultValue("2")]
	public double? InitialTreeDepth { get; set; } 

	/// <summary>
	/// The style of each node in the tree, where itemStyle.color represents the fill color of the node, to distinguish the state of the subtree corresponding to collapsing or expansion .
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// label describes the style of the text corresponding to each node.
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
	/// Defines the style of the tree edge.
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
	/// Leaf node special configuration, such as the above tree diagram example, the leaf node and non-leaf node label location is different.
	/// </summary>
	[JsonPropertyName("leaves")]
	public Leaves? Leaves { get; set; } 

	/// <summary>
	/// series-tree.data the data format is a tree structure, for example：  { // note that the outermost layer is an object that represents the root node of the tree.
	///     name: "flare",    // the name of the node, the text corresponding to the current node label.
	///     label: {          // the special label configuration (if necessary).
	///         ...
	///           // the format of the label is shown in the series-tree.label.
	///     },
	///     itemStyle: {      // the special itemStyle configuration (if necessary).
	///         ...
	///           // the format of the itemstyle is shown in the series-tree.itemStyle.
	///     },
	///     children: [
	///         {
	///             name: "flex",
	///             value: 4116,    // value, which only displayed in tooltip.
	///             label: {
	///                 ...
	///             },
	///             itemStyle: {
	///                 ...
	///             },
	///             collapsed: null, // If set as `true`, the node is collapsed in the initialization.
	///             children: [...]  // leaf nodes do not have children, can not write.
	///         },
	///         ...
	///     ]
	/// };
	/// </summary>
	[JsonPropertyName("data")]
	public DataData? Data { get; set; } 

	/// <summary>
	/// tooltip settings in this series.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

}
