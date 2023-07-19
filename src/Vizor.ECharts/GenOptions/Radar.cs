// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Radar
{
	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; } 

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
	/// Center position of , the first of which is the horizontal position, and the second is the vertical position.
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
	/// Radius of .
	/// Value can be:   number : Specify outside radius directly.
	///  string : For example, '20%' , means that the outside radius is 20% of the viewport size (the little one between width and height of the chart container).
	///    Array.<number|string> : The first item specifies the inside radius, and the second item specifies the outside radius.
	/// Each item follows the definitions above.
	/// </summary>
	[JsonPropertyName("radius")]
	[DefaultValue("0%, 75%")]
	public Radius? Radius { get; set; } 

	/// <summary>
	/// The start angle of coordinate, which is the angle of the first indicator axis.
	/// </summary>
	[JsonPropertyName("startAngle")]
	[DefaultValue(90)]
	public double? StartAngle { get; set; } 

	/// <summary>
	/// Name options for radar indicators.
	/// </summary>
	[JsonPropertyName("axisName")]
	public AxisName? AxisName { get; set; } 

	/// <summary>
	/// Distance between the indicator's name and axis.
	/// </summary>
	[JsonPropertyName("nameGap")]
	[DefaultValue("15")]
	public double? NameGap { get; set; } 

	/// <summary>
	/// Segments of indicator axis.
	/// </summary>
	[JsonPropertyName("splitNumber")]
	[DefaultValue("15")]
	public double? SplitNumber { get; set; } 

	/// <summary>
	/// Radar render type, in which 'polygon' and 'circle' are supported.
	/// </summary>
	[JsonPropertyName("shape")]
	[DefaultValue("polygon")]
	public RadarShape? Shape { get; set; } 

	/// <summary>
	/// Whether to prevent calculating the scaling relative to zero.
	/// If it is set to be true , the coordinate tick would not compulsorily contain zero value, which is usually useful in scatter diagram of double numerical values axis.
	/// </summary>
	[JsonPropertyName("scale")]
	[DefaultValue(false)]
	public bool? Scale { get; set; } 

	/// <summary>
	/// Set this to true , to prevent interaction with the axis.
	/// </summary>
	[JsonPropertyName("silent")]
	[DefaultValue(false)]
	public bool? Silent { get; set; } 

	/// <summary>
	/// Set this to true to enable triggering events.
	///  
	/// Parameters of the event include:  {
	///     // Component type: xAxis, yAxis, radiusAxis, angleAxis
	///     // Each of which has an attribute for index, e.g., xAxisIndex for xAxis
	///     componentType: string,
	///     // Value on axis before being formatted.
	///     // Click on value label to trigger event.
	///     value: '',
	///     // Name of axis.
	///     // Click on laben name to trigger event.
	///     name: ''
	/// }
	/// </summary>
	[JsonPropertyName("triggerEvent")]
	[DefaultValue(false)]
	public bool? TriggerEvent { get; set; } 

	/// <summary>
	/// Settings related to axis line.
	/// </summary>
	[JsonPropertyName("axisLine")]
	public AxisLine? AxisLine { get; set; } 

	/// <summary>
	/// Settings related to axis tick.
	/// </summary>
	[JsonPropertyName("axisTick")]
	public AxisTick? AxisTick { get; set; } 

	/// <summary>
	/// Settings related to axis label.
	/// </summary>
	[JsonPropertyName("axisLabel")]
	public AxisLabel? AxisLabel { get; set; } 

	/// <summary>
	/// Split line of axis in grid area.
	/// </summary>
	[JsonPropertyName("splitLine")]
	public SplitLine? SplitLine { get; set; } 

	/// <summary>
	/// Split area of axis in grid area, not shown by default.
	/// </summary>
	[JsonPropertyName("splitArea")]
	public SplitArea? SplitArea { get; set; } 

	/// <summary>
	/// Indicator of radar chart, which is used to assign multiple variables(dimensions) in radar chart.
	/// Here is the example.
	///  indicator: [
	///    { name: 'Sales (sales) ', max: 6500},
	///    { name: 'Administration (Administration) ', max: 16000, color: 'red'}, // Set the indicator as 'red'
	///    { name: 'Information Technology (Information Technology) ', max: 30000},
	///    { name: 'Customer Support (Customer Support) ', max: 38000},
	///    { name: 'Development (Development) ', max: 52000},
	///    { name: 'Marketing (Marketing) ', max: 25000}
	/// ]
	/// </summary>
	[JsonPropertyName("indicator")]
	public List<RadarIndicator>? Indicator { get; set; } 

}
