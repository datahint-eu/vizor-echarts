
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Toolbox
{
	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Whether to show toolbox component.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue(true)]
	public bool? Show { get; set; }

	/// <summary>
	/// The layout orientation of toolbox's icon.
	///  
	/// Options:   'horizontal'  'vertical'
	/// </summary>
	[JsonPropertyName("orient")]
	[DefaultValue("horizontal")]
	public Orient? Orient { get; set; }

	/// <summary>
	/// The size of toolbox's icon.
	/// </summary>
	[JsonPropertyName("itemSize")]
	[DefaultValue("15")]
	public double? ItemSize { get; set; }

	/// <summary>
	/// The gap between each icon of toolbox.
	/// It is horizontal gap in horizontal layout, while vertical gap in vertical layout.
	/// </summary>
	[JsonPropertyName("itemGap")]
	[DefaultValue("8")]
	public double? ItemGap { get; set; }

	/// <summary>
	/// Whether to show the title of each tool icon when mouse hovers.
	/// </summary>
	[JsonPropertyName("showTitle")]
	[DefaultValue("true")]
	public bool? ShowTitle { get; set; }

	/// <summary>
	/// The configuration item for each tool.
	///  
	/// Besides the tools we provide, user-defined toolbox is also supported.
	///  
	/// Notes: User-defined tool name could only start with my , like myTool1 and myTool2 in the below example:  {
	///     toolbox: {
	///         feature: {
	///             myTool1: {
	///                 show: true,
	///                 title: 'custom extension method 1',
	///                 icon: 'path://M432.45,595.444c0,2.177-4.661,6.82-11.305,6.82c-6.475,0-11.306-4.567-11.306-6.82s4.852-6.812,11.306-6.812C427.841,588.632,432.452,593.191,432.45,595.444L432.45,595.444z M421.155,589.876c-3.009,0-5.448,2.495-5.448,5.572s2.439,5.572,5.448,5.572c3.01,0,5.449-2.495,5.449-5.572C426.604,592.371,424.165,589.876,421.155,589.876L421.155,589.876z M421.146,591.891c-1.916,0-3.47,1.589-3.47,3.549c0,1.959,1.554,3.548,3.47,3.548s3.469-1.589,3.469-3.548C424.614,593.479,423.062,591.891,421.146,591.891L421.146,591.891zM421.146,591.891',
	///                 onclick: function (){
	///                     alert('myToolHandler1')
	///                 }
	///             },
	///             myTool2: {
	///                 show: true,
	///                 title: 'custom extension method',
	///                 icon: 'image://https://echarts.apache.org/en/images/favicon.png',
	///                 onclick: function (){
	///                     alert('myToolHandler2')
	///                 }
	///             }
	///         }
	///     }
	/// }
	/// </summary>
	[JsonPropertyName("feature")]
	public Feature? Feature { get; set; }

	/// <summary>
	/// The style setting of Shared icon.
	/// Since icon label is displayed only when hovering on the icon, the label configuration options are available under emphasis .
	/// </summary>
	[JsonPropertyName("iconStyle")]
	public IconStyle? IconStyle { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; }

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
	/// Distance between toolbox component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue("auto")]
	public NumberOrString? Left { get; set; }

	/// <summary>
	/// Distance between toolbox component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue("auto")]
	public NumberOrString? Top { get; set; }

	/// <summary>
	/// Distance between toolbox component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue("auto")]
	public NumberOrString? Right { get; set; }

	/// <summary>
	/// Distance between toolbox component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue("auto")]
	public NumberOrString? Bottom { get; set; }

	/// <summary>
	/// Width of toolbox component.
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("width")]
	[DefaultValue("auto")]
	public NumberOrString? Width { get; set; }

	/// <summary>
	/// Height of toolbox component.
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("height")]
	[DefaultValue("auto")]
	public NumberOrString? Height { get; set; }

	/// <summary>
	/// Tooltip configuration for toolbox tooltip, which is similar to tooltip .
	/// It is not shown by default.
	/// If you wish to set special style for toolbox icon label (especially when using CSS to control text style), you may set as the following example:  option = {
	///     tooltip: {
	///         show: true // include tooltip component for the feature
	///     },
	///     toolbox: {
	///         show: true,
	///         showTitle: false, // hide the default text so they don't overlap each other
	///         feature: {
	///             saveAsImage: {
	///                 show: true,
	///                 title: 'Save As Image'
	///             },
	///             dataView: {
	///                 show: true,
	///                 title: 'Data View'
	///             },
	///         },
	///         tooltip: { // same as option.tooltip
	///             show: true,
	///             formatter: function (param) {
	///                 return return '<div>' + param.title + '</div>'; // user-defined DOM structure
	///             },
	///             backgroundColor: '#222',
	///             textStyle: {
	///                 fontSize: 12,
	///             },
	///             extraCssText: 'box-shadow: 0 0 3px rgba(0, 0, 0, 0.3);' // user-defined CSS styles
	///         }
	///     },
	///     ...
	/// }
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; }

}
