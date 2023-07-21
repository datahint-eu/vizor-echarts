// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Polar
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
	/// Center position of Polar coordinate, the first of which is the horizontal position, and the second is the vertical position.
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
	/// Radius of Polar coordinate.
	/// Value can be:   number : Specify outside radius directly.
	///  string : For example, '20%' , means that the outside radius is 20% of the viewport size (the little one between width and height of the chart container).
	///    Array.<number|string> : The first item specifies the inside radius, and the second item specifies the outside radius.
	/// Each item follows the definitions above.
	/// </summary>
	[JsonPropertyName("radius")]
	[DefaultValue("0%, 75%")]
	public Radius? Radius { get; set; } 

	/// <summary>
	/// tooltip settings in the coordinate system component.
	///  
	/// General Introduction:  
	/// tooltip can be configured on different places:   
	/// Configured on global: tooltip   
	/// Configured in a coordinate system: grid.tooltip , polar.tooltip , single.tooltip   
	/// Configured in a series: series.tooltip   
	/// Configured in each item of series.data : series.data.tooltip
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

}
