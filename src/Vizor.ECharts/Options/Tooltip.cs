// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Tooltip
{
	/// <summary>
	/// Whether to show the tooltip component.
	///  
	/// including tooltip floating layer and axisPointer .
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("true")]
	public bool? Show { get; set; } 

	/// <summary>
	/// Type of triggering.
	///  
	/// Options:   
	/// 'item'  
	/// Triggered by data item, which is mainly used for charts that don't have a category axis like scatter charts or pie charts.
	///   
	/// 'axis'  
	/// Triggered by axes, which is mainly used for charts that have category axes, like bar charts or line charts.
	///  
	/// ECharts 2.x only supports axis trigger for category axis.
	/// In ECharts 3, it is supported for all types of axes in grid or polar .
	/// Also, you may assign axis with axisPointer.axis .
	///   
	/// 'none'  
	/// Trigger nothing.
	/// </summary>
	[JsonPropertyName("trigger")]
	[DefaultValue("item")]
	public TooltipTrigger? Trigger { get; set; } 

	/// <summary>
	/// Configuration item for axisPointer.
	///  
	/// tooltip.axisPointer is like syntactic sugar of axisPointer settings on axes (for example, xAxis.axisPointer or angleAxis.axisPointer ).
	/// More detailed features can be configured on someAxis.axisPointer .
	/// But in common cases, using tooltip.axisPointer is more convenient.
	///   
	/// Notice: configurations of tooltip.axisPointer has lower priority than that of someAxis.axisPointer .
	///    
	/// axisPointer is a tool for displaying reference line and axis value under mouse pointer.
	///  
	/// For example:   
	/// In the demo above, axisPointer.link is used to link axisPointer from different coordinate systems.
	///  
	/// axisPointer can also be used on touch device, where user can drag the button to move the reference line and label.
	///   
	/// In the cases that more than one axis exist, axisPointer helps to look inside the data.
	///      
	/// Notice: Generally, axisPointers is configured in each axes who need them (for example xAxis.axisPointer ), or configured in tooltip (for example tooltip.axisPointer ).
	///    
	/// But these configurations can only be configured in global axisPointer: axisPointer.triggerOn , axisPointer.link .
	///     
	/// How to display axisPointer:  
	/// In cartesian (grid) and polar](~polar) and (single axis , each axis has its own axisPointer.
	///  
	/// Those axisPointer will not be displayed by default, utill configured as follows:   
	/// Set someAxis.axisPointer.show (like xAxis.axisPointer.show ) as true .
	/// Then axisPointer of this axis will be displayed.
	///   
	/// Set tooltip.trigger as 'axis' , or set tooltip.axisPointer.type as 'cross' .
	/// Then coordinate system will automatically chose the axes who will display their axisPointers.
	/// ( tooltip.axisPointer.axis can be used to change the choice.) Notice, axis.axisPointer will override tooltip.axisPointer settings.
	///     
	/// How to display the label of axisPointer:  
	/// The label of axisPointer will not be displayed by default(namely, only reference line will be displayed by default), utill configured as follows:   
	/// Set someAxis.axisPointer.label.show (for example xAxis.axisPointer.label.show ) as true .
	/// Then the label of the axisPointer will be displayed.
	///   
	/// Set tooltip.axisPointer.type as 'cross' .
	/// Then the label of the crossed axisPointers will be displayed.
	///     
	/// How to configure axisPointer on touch device:  
	/// Set someAxis.axisPointer.handle.show (for example xAxis.axisPointer.handle.show as true .
	/// Then the button for dragging will be displayed.
	/// (This feature is not supported on polar).
	///  
	/// Notice: If tooltip does not work well in this case, try to set tooltip.triggerOn as 'none' (for the effect: show tooltip when finger holding on the button, and hide tooltip after finger left the button), or set tooltip.alwaysShowContent as true (then tooltip will always be displayed).
	///  
	/// See the example .
	///   
	/// Snap to point  
	/// In value axis and time axis, if snap is set as true, axisPointer will snap to point automatically.
	/// </summary>
	[JsonPropertyName("axisPointer")]
	public AxisPointer? AxisPointer { get; set; } 

	/// <summary>
	/// The position of the tooltip's floating layer, which would follow the position of mouse by default.
	///  
	/// Options:   
	/// Array  
	/// Display the position of tooltip's floating layer through array, which supports absolute position and relative percentage.
	///  
	/// Example:  // absolute position, which is 10px to the left side and 10px to the top side of the container
	///   position: [10, 10]
	///   // relative position, in the exact center of the container
	///   position: ['50%', '50%']   
	/// Function  
	/// Callback function in the following form:  (point: Array, params: Object|Array.<Object>, dom: HTMLDomElement, rect: Object, size: Object) => Array  
	///  Parameters: 
	/// point: Mouse position.
	/// 
	/// param: The same as formatter.
	/// 
	/// dom: The DOM object of tooltip.
	/// 
	/// rect: It is valid only when mouse is on graphic elements, which stands for a bounding box with x , y , width , and height .
	/// 
	/// size: The size of dom echarts container.
	/// For example: {contentSize: [width, height], viewSize: [width, height]} .
	/// 
	///  
	///  Return: 
	/// Return value is an array standing for tooltip position, which can be absolute pixels, or relative percentage.
	/// 
	/// Or can be an object, like {left: 10, top: 30} , or {right: '20%', bottom: 40} .
	/// 
	///  
	/// For example:  position: function (point, params, dom, rect, size) {
	///       // fixed at top
	///       return [point[0], '10%'];
	///   }  
	/// Or:  position: function (pos, params, dom, rect, size) {
	///       // tooltip will be fixed on the right if mouse hovering on the left,
	///       // and on the left if hovering on the right.
	///       var obj = {top: 60};
	///       obj[['left', 'right'][+(pos[0] < size.viewSize[0] / 2)]] = 5;
	///       return obj;
	///   }   
	/// 'inside'  
	/// Center position of the graphic element where the mouse is in, which is only valid when trigger is 'item' .
	///   
	/// 'top'  
	/// Top position of the graphic element where the mouse is in, which is only valid when trigger is 'item' .
	///   
	/// 'left'  
	/// Left position of the graphic element where the mouse is in, which is only valid when trigger is 'item' .
	///   
	/// 'right'  
	/// Right position of the graphic element where the mouse is in, which is only valid when trigger is 'item' .
	///   
	/// 'bottom'  
	/// Bottom position of the graphic element where the mouse is in, which is only valid when trigger is 'item' .
	/// </summary>
	[JsonPropertyName("position")]
	public TooltipPosition? Position { get; set; } 

	/// <summary>
	/// The content formatter of tooltip's floating layer which supports string template and callback function.
	///  
	/// 1.
	/// String template  
	/// The template variables are {a} , {b} , {c} , {d} and {e} , which stands for series name, data name and data value and ect.
	/// When trigger is set to be 'axis' , there may be data from multiple series.
	/// In this time, series index can be refered as {a0} , {a1} , or {a2} .
	///  
	/// {a} , {b} , {c} , {d} have different meanings for different series types:   
	/// Line (area) charts, bar (column) charts, K charts: {a} for series name, {b} for category name, {c} for data value, {d} for none;   
	/// Scatter (bubble) charts: {a} for series name, {b} for data name, {c} for data value, {d} for none;   
	/// Map: {a} for series name, {b} for area name, {c} for merging data, {d} for none;   
	/// Pie charts, gauge charts, funnel charts: {a} for series name, {b} for data item name, {c} for data value, {d} for percentage.
	///    
	/// Example:  formatter: '{b0}: {c0}<br />{b1}: {c1}'  
	/// 2.
	/// Callback function  
	/// The format of callback function:  (params: Object|Array, ticket: string, callback: (ticket: string, html: string)) => string | HTMLElement | HTMLElement[]  
	/// The first parameter params is the data that the formatter needs.
	/// Its format is shown as follows:  {
	///     componentType: 'series',
	///     // Series type
	///     seriesType: string,
	///     // Series index in option.series
	///     seriesIndex: number,
	///     // Series name
	///     seriesName: string,
	///     // Data name, or category name
	///     name: string,
	///     // Data index in input data array
	///     dataIndex: number,
	///     // Original data as input
	///     data: Object,
	///     // Value of data.
	/// In most series it is the same as data.
	///     // But in some series it is some part of the data (e.g., in map, radar)
	///     value: number|Array|Object,
	///     // encoding info of coordinate system
	///     // Key: coord, like ('x' 'y' 'radius' 'angle')
	///     // value: Must be an array, not null/undefined.
	/// Contain dimension indices, like:
	///     // {
	///     //     x: [2] // values on dimension index 2 are mapped to x axis.
	///     //     y: [0] // values on dimension index 0 are mapped to y axis.
	///     // }
	///     encode: Object,
	///     // dimension names list
	///     dimensionNames: Array<String>,
	///     // data dimension index, for example 0 or 1 or 2 ...
	///     // Only work in `radar` series.
	///     dimensionIndex: number,
	///     // Color of data
	///     color: string,
	///     // The percentage of current data item in the pie/funnel series
	///     percent: number,
	///     // The ancestors of current node in the sunburst series (including self)
	///     treePathInfo: Array,
	///     // The ancestors of current node in the tree/treemap series (including self)
	///     treeAncestors: Array
	/// }  
	/// How to use encode and dimensionNames ?  
	/// When the dataset is like  dataset: {
	///     source: [
	///         ['Matcha Latte', 43.3, 85.8, 93.7],
	///         ['Milk Tea', 83.1, 73.4, 55.1],
	///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
	///         ['Walnut Brownie', 72.4, 53.9, 39.1]
	///     ]
	/// }  
	/// We can get the value of the y-axis via  params.value[params.encode.y[0]]  
	/// When the dataset is like  dataset: {
	///     dimensions: ['product', '2015', '2016', '2017'],
	///     source: [
	///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
	///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
	///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
	///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
	///     ]
	/// }  
	/// We can get the value of the y-axis via  params.value[params.dimensionNames[params.encode.y[0]]]  
	/// When trigger is 'axis' , or when tooltip is triggered by axisPointer , params is the data array of multiple series.
	/// The content of each item of the array is the same as above.
	/// Besides,  {
	///     componentType: 'series',
	///     // Series type
	///     seriesType: string,
	///     // Series index in option.series
	///     seriesIndex: number,
	///     // Series name
	///     seriesName: string,
	///     // Data name, or category name
	///     name: string,
	///     // Data index in input data array
	///     dataIndex: number,
	///     // Original data as input
	///     data: Object,
	///     // Value of data.
	/// In most series it is the same as data.
	///     // But in some series it is some part of the data (e.g., in map, radar)
	///     value: number|Array|Object,
	///     // encoding info of coordinate system
	///     // Key: coord, like ('x' 'y' 'radius' 'angle')
	///     // value: Must be an array, not null/undefined.
	/// Contain dimension indices, like:
	///     // {
	///     //     x: [2] // values on dimension index 2 are mapped to x axis.
	///     //     y: [0] // values on dimension index 0 are mapped to y axis.
	///     // }
	///     encode: Object,
	///     // dimension names list
	///     dimensionNames: Array<String>,
	///     // data dimension index, for example 0 or 1 or 2 ...
	///     // Only work in `radar` series.
	///     dimensionIndex: number,
	///     // Color of data
	///     color: string
	/// }  
	/// How to use encode and dimensionNames ?  
	/// When the dataset is like  dataset: {
	///     source: [
	///         ['Matcha Latte', 43.3, 85.8, 93.7],
	///         ['Milk Tea', 83.1, 73.4, 55.1],
	///         ['Cheese Cocoa', 86.4, 65.2, 82.5],
	///         ['Walnut Brownie', 72.4, 53.9, 39.1]
	///     ]
	/// }  
	/// We can get the value of the y-axis via  params.value[params.encode.y[0]]  
	/// When the dataset is like  dataset: {
	///     dimensions: ['product', '2015', '2016', '2017'],
	///     source: [
	///         {product: 'Matcha Latte', '2015': 43.3, '2016': 85.8, '2017': 93.7},
	///         {product: 'Milk Tea', '2015': 83.1, '2016': 73.4, '2017': 55.1},
	///         {product: 'Cheese Cocoa', '2015': 86.4, '2016': 65.2, '2017': 82.5},
	///         {product: 'Walnut Brownie', '2015': 72.4, '2016': 53.9, '2017': 39.1}
	///     ]
	/// }  
	/// We can get the value of the y-axis via  params.value[params.dimensionNames[params.encode.y[0]]]  
	/// Note: Using array to present all the parameters in ECharts 2.x is not supported anymore.
	///  
	/// The second parameter ticket is the asynchronous callback flag which should be used along with the third parameter callback when it is used.
	///  
	/// The third parameter callback is asynchronous callback.
	/// When the content of tooltip is acquired asynchronously, ticket and htm as introduced above can be used to update tooltip with callback.
	///  
	/// Example:  formatter: function (params, ticket, callback) {
	///     $.get('detail?name=' + params.name, function (content) {
	///         callback(ticket, toHTML(content));
	///     });
	///     return 'Loading';
	/// }
	/// </summary>
	[JsonPropertyName("formatter")]
	public StringOrFunction? Formatter { get; set; } 

	/// <summary>
	/// Since v5.3.0   
	/// Callback function for formatting the value section in tooltip.
	///  
	/// Interface:  (value: number | string) => string  
	/// Example:  // Add $ prefix
	/// valueFormatter: (value) => '$' + value.toFixed(2)
	/// </summary>
	[JsonPropertyName("valueFormatter")]
	public string? ValueFormatter { get; set; } 

	/// <summary>
	/// The background color of tooltip's floating layer.
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	[DefaultValue("rgba(50,50,50,0.7)")]
	public Color? BackgroundColor { get; set; } 

	/// <summary>
	/// The border color of tooltip's floating layer.
	/// </summary>
	[JsonPropertyName("borderColor")]
	[DefaultValue("#333")]
	public Color? BorderColor { get; set; } 

	/// <summary>
	/// The border width of tooltip's floating layer.
	/// </summary>
	[JsonPropertyName("borderWidth")]
	[DefaultValue("0")]
	public double? BorderWidth { get; set; } 

	/// <summary>
	/// The floating layer of tooltip space around content.
	/// The unit is px.
	/// Default values for each position are 5.
	/// And they can be set to different values with left, right, top, and bottom.
	///  
	/// Examples:  // Set padding to be 5
	/// padding: 5
	/// // Set the top and bottom paddings to be 5, and left and right paddings to be 10
	/// padding: [5, 10]
	/// // Set each of the four paddings seperately
	/// padding: [
	///     5,  // up
	///     10, // right
	///     5,  // down
	///     10, // left
	/// ]
	/// </summary>
	[JsonPropertyName("padding")]
	[DefaultValue(5)]
	public Padding? Padding { get; set; } 

	/// <summary>
	/// The text syle of tooltip's floating layer.
	/// </summary>
	[JsonPropertyName("textStyle")]
	public TextStyle? TextStyle { get; set; } 

	/// <summary>
	/// Extra CSS style for floating layer.
	/// The following is an example for adding shadow.
	///  extraCssText: 'box-shadow: 0 0 3px rgba(0, 0, 0, 0.3);'
	/// </summary>
	[JsonPropertyName("extraCssText")]
	public string? ExtraCssText { get; set; } 

	/// <summary>
	/// Whether to show the tooltip floating layer, whose default value is true.
	/// It should be configurated to be false , if you only need tooltip to trigger the event or show the axisPointer without content.
	/// </summary>
	[JsonPropertyName("showContent")]
	[DefaultValue("true")]
	public bool? ShowContent { get; set; } 

	/// <summary>
	/// Whether to show tooltip content all the time.
	/// By default, it will be hidden after some time .
	/// It can be set to be true to preserve displaying.
	///  
	/// This attribute is newly added to ECharts 3.0.
	/// </summary>
	[JsonPropertyName("alwaysShowContent")]
	[DefaultValue("false")]
	public bool? AlwaysShowContent { get; set; } 

	/// <summary>
	/// Conditions to trigger tooltip.
	/// Options:   
	/// 'mousemove'  
	/// Trigger when mouse moves.
	///   
	/// 'click'  
	/// Trigger when mouse clicks.
	///   
	/// 'mousemove|click'  
	/// Trigger when mouse clicks and moves.
	///   
	/// 'none'  
	/// Do not triggered by 'mousemove' and 'click' .
	/// Tooltip can be triggered and hidden manually by calling action.tooltip.showTip and action.tooltip.hideTip .
	/// It can also be triggered by axisPointer.handle in this case.
	///    
	/// This attribute is new to ECharts 3.0.
	/// </summary>
	[JsonPropertyName("triggerOn")]
	[DefaultValue("mousemove|click")]
	public TriggerOn? TriggerOn { get; set; } 

	/// <summary>
	/// Delay time for showing tooltip, in ms.
	/// No delay by default, and it is not recommended to set.
	/// Only valid when triggerOn is set to be 'mousemove' .
	/// </summary>
	[JsonPropertyName("showDelay")]
	[DefaultValue(0)]
	public double? ShowDelay { get; set; } 

	/// <summary>
	/// Delay time for hiding tooltip, in ms.
	/// It will be invalid when alwaysShowContent is true .
	/// </summary>
	[JsonPropertyName("hideDelay")]
	[DefaultValue("100")]
	public double? HideDelay { get; set; } 

	/// <summary>
	/// Whether mouse is allowed to enter the floating layer of tooltip, whose default value is false.
	/// If you need to interact in the tooltip like with links or buttons, it can be set as true .
	/// </summary>
	[JsonPropertyName("enterable")]
	[DefaultValue("false")]
	public bool? Enterable { get; set; } 

	/// <summary>
	/// Render mode for tooltip.
	/// By default, it is set to be 'html' so that extra DOM element is used for tooltip.
	/// It can also set to be 'richText' so that the tooltip will be rendered inside Canvas.
	/// This is very useful for environments that don't have DOM, such as Wechat applications.
	/// </summary>
	[JsonPropertyName("renderMode")]
	[DefaultValue("html")]
	public RenderMode? RenderMode { get; set; } 

	/// <summary>
	/// Whether confine tooltip content in the view rect of chart instance.
	///  
	/// Useful when tooltip is cut because of 'overflow: hidden' set on outer dom of chart instance, or because of narrow screen on mobile.
	/// </summary>
	[JsonPropertyName("confine")]
	[DefaultValue("false")]
	public bool? Confine { get; set; } 

	/// <summary>
	/// Since v4.7.0   
	/// Whether to append the tooltip DOM element as a child of the <body> of the HTML page, when using renderMode  'html' .
	///  
	/// By default false , means that the tooltip DOM element will be one of a descendant of its echarts DOM container.
	/// But that means that the tooltip might be cut when overflow the container if some of the ancestors DOM element of the echarts container are styled with overflow: hidden .
	/// This case could also be resolved by setting tooltip.confine , but it might not suitable for all scenarios.
	///  
	/// Here we provide appendToBody: true to auto append the tooltip element to <body> , which is a common way to resolve this kind of issue.
	/// But true is not set as a default value because to void to bring break change for some cases where tooltip is deeply customized and to void some unexpected bad cases.
	///  
	/// Note that it also works when CSS transform used.
	/// </summary>
	[JsonPropertyName("appendToBody")]
	[DefaultValue("false")]
	public bool? AppendToBody { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Specify the classes for the tooltip root DOM.
	/// (Only works in html render mode).
	///  
	/// Example:  className: 'echarts-tooltip echarts-tooltip-dark'
	/// </summary>
	[JsonPropertyName("className")]
	public string? ClassName { get; set; } 

	/// <summary>
	/// The transition duration of tooltip's animation, in seconds.
	/// When it is set to be 0, it would move closely with the mouse.
	/// </summary>
	[JsonPropertyName("transitionDuration")]
	[DefaultValue("0.4")]
	public double? TransitionDuration { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Tooltip order for multiple series.
	/// Defaults is 'seriesAsc' .
	///  
	/// Conditions to order tooltip.
	/// Options:   
	/// 'seriesAsc'  
	/// Base on series declaration, ascending order tooltip.
	///   
	/// 'seriesDesc'  
	/// Base on series declaration, descending order tooltip.
	///   
	/// 'valueAsc'  
	/// Base on value, ascending order tooltip, only for numberic value.
	///   
	/// 'valueDesc'  
	/// Base on value, descending order tooltip, only for numberic value.
	/// </summary>
	[JsonPropertyName("order")]
	[DefaultValue("seriesAsc")]
	public TooltipOrder? Order { get; set; } 

}
