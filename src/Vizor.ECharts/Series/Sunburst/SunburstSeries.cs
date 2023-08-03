
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class SunburstSeries : ISeries
{
	[JsonPropertyName("type")]
	public string Type => "sunburst";

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
	/// Center position of Sunburst chart, the first of which is the horizontal position, and the second is the vertical position.
	///  
	/// Percentage is supported.
	/// When set in percentage, the item is relative to the container width, and the second item to the height.
	///  
	/// Example:  // Set to absolute pixel values
	/// center: [400, 300]
	/// // Set to relative percent
	/// center: ['50%', '50%']
	/// </summary>
	[JsonPropertyName("center")]
	[DefaultValue("[50%, 50%]")]
	public double[]? Center { get; set; } 

	/// <summary>
	/// Radius of Sunburst chart.
	/// Value can be:   number : Specify outside radius directly.
	///  string : For example, '20%' , means that the outside radius is 20% of the viewport size (the little one between width and height of the chart container).
	///    Array.<number|string> : The first item specifies the inside radius, and the second item specifies the outside radius.
	/// Each item follows the definitions above.
	/// </summary>
	[JsonPropertyName("radius")]
	[DefaultValue("0%, 75%")]
	public CircleRadius? Radius { get; set; }

	/// <summary>
	/// The data structure of series-sunburst.data is like tree.
	/// 
	/// Can be List of SunburstSeriesData, an external data source, ...
	/// 
	/// For example:  [{
	///     name: 'parent1',
	///     value: 10,          // value of parent node can be left unset, and sum of
	///                         // children values will be used in this case.
	///                         // If is set, and is larger than sum of children nodes,
	///                         // the reset can be used for other parts in parent.
	///     children: [{
	///         value: 5,
	///         name: 'child1',
	///         children: [{
	///             value: 2,
	///             name: 'grandchild1',
	///             itemStyle: {
	///                 // every data can have its own itemStyle,
	///                 // which will overwrites series.itemStyle and level.itemStyle
	///             },
	///             label: {
	///                 // label style, the same to above
	///             }
	///         }]
	///     }, {
	///         value: 3,
	///         name: 'child2'
	///     }],
	///     itemStyle: {
	///         // itemStyle of parent1, which will not be inherited for children
	///     },
	///     label: {
	///         // label of parent1, which will not be inherited for children
	///     }
	/// }, {
	///     name: 'parent2',
	///     value: 4
	/// }]
	/// </summary>
	[JsonPropertyName("data")]
	public object? Data { get; set; } 

	/// <summary>
	/// The action of clicking a sector, which can be:   false : nothing happens.
	///  'rootToNode' : use the clicked sector as root.
	///  'link' ：if link is set, the page will redirect to it.
	/// </summary>
	[JsonPropertyName("nodeClick")]
	[DefaultValue("rootToNode")]
	public SunburstNodeClick? NodeClick { get; set; } 

	/// <summary>
	/// Sorting method that sectors use based on value , which is the sum of children when not set.
	/// The default value 'desc' states for descending order, while it can also be set to be 'asc' for ascending order, or null for not sorting
	/// Or callback function like:  function(nodeA, nodeB) {
	///     return nodeA.getValue() - nodeB.getValue();
	/// }
	/// </summary>
	[JsonPropertyName("sort")]
	[DefaultValue("desc")]
	public object? SortObject { get; set; }

	/// <summary>
	/// orting method that sectors use based on value , which is the sum of children when not set.
	/// The default value 'desc' states for descending order, while it can also be set to be 'asc' for ascending order, or null for not sorting
	/// </summary>
	[JsonIgnore]
	public SortOrder? Sort
	{
		get => (SortOrder?)SortObject;
		set => SortObject = value;
	}

	/// <summary>
	/// callback function like:  function(nodeA, nodeB) {
	///     return nodeA.getValue() - nodeB.getValue();
	/// }
	/// </summary>
	[JsonIgnore]
	public JavascriptFunction? SortFunction
	{
		get => SortObject as JavascriptFunction;
		set => SortObject = value;
	}

	/// <summary>
	/// If there is no name , whether need to render it.
	/// </summary>
	[JsonPropertyName("renderLabelForZeroData")]
	[DefaultValue(false)]
	public bool? RenderLabelForZeroData { get; set; } 

	/// <summary>
	/// Whether the layout of sectors of sunburst chart is clockwise.
	/// </summary>
	[JsonPropertyName("clockwise")]
	[DefaultValue("true")]
	public bool? Clockwise { get; set; } 

	/// <summary>
	/// The start angle, which range is [0, 360].
	/// </summary>
	[JsonPropertyName("startAngle")]
	[DefaultValue("90")]
	public double? StartAngle { get; set; } 

	/// <summary>
	/// To specify the style of the label of the sector.
	///  
	/// Priority： series.data.label > series.levels.label > series.label 。  
	/// Text label of sunburst chart, to explain some data information about graphic item like value, name and so on.
	/// label is placed under itemStyle in ECharts 2.x.
	/// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Configuration of label guide line.
	/// </summary>
	[JsonPropertyName("labelLine")]
	public LabelLine? LabelLine { get; set; } 

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
	/// To specify the style of the sector of the sunburst chart.
	///  
	/// You can specify the style of all sectors with series.itemStyle , or specify the style of each level of sectors with series.levels.itemStyle , or specify a specific style for each sector with series.data.itemStyle .
	/// The priority is from low to high, that is, if series.data.itemStyle is defined, it will override series.itemStyle and series.levels.itemStyle .
	///  
	/// Priority： series.data.itemStyle > series.levels.itemStyle > series.itemStyle 。
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// Configurations of emphasis state.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public object? Emphasis { get; set; } 

	/// <summary>
	/// Configurations of blur state.
	/// Available when emphasis.focus is set.
	/// </summary>
	[JsonPropertyName("blur")]
	public object? Blur { get; set; } 

	/// <summary>
	/// Configurations of select state.
	/// Available when selectedMode is set.
	/// </summary>
	[JsonPropertyName("select")]
	public object? Select { get; set; } 

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
	/// Multiple levels  
	/// Sunburst chart has a leveled structure.
	/// To make it convenient, we provide a levels option, which is an array.
	/// The first element of it is for returning to parent node when data mining.
	/// The following elements are for levels from center to outside.
	///  
	/// For example, if we don't want the data mining, and want to set the most inside sector to be red, and text to be blue, we can set the option like:  series: {
	///     // ...
	///     levels: [
	///         {
	///             // Blank setting for data mining
	///         },
	///         {
	///             // The most inside level
	///             itemStyle: {
	///                 color: 'red'
	///             },
	///             label: {
	///                 color: 'blue'
	///             }
	///         },
	///         {
	///             // The second level
	///         }
	///     ]
	/// }
	/// </summary>
	[JsonPropertyName("levels")]
	public List<SunburstSeriesLevels>? Levels { get; set; } 

	/// <summary>
	/// tooltip settings in this series.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

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

}
