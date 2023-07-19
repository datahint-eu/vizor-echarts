// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Parallel
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
	/// Distance between parallel  component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue(80)]
	public NumberOrString? Left { get; set; } 

	/// <summary>
	/// Distance between parallel  component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue(60)]
	public NumberOrString? Top { get; set; } 

	/// <summary>
	/// Distance between parallel  component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue(80)]
	public NumberOrString? Right { get; set; } 

	/// <summary>
	/// Distance between parallel  component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue(60)]
	public NumberOrString? Bottom { get; set; } 

	/// <summary>
	/// Width of parallel  component.
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("width")]
	[DefaultValue("auto")]
	public NumberOrString? Width { get; set; } 

	/// <summary>
	/// Height of parallel  component.
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("height")]
	[DefaultValue("auto")]
	public NumberOrString? Height { get; set; } 

	/// <summary>
	/// Layout modes, whose optional values are:   
	/// 'horizontal' : place each axis horizontally.
	///   
	/// 'vertical' : place each axis vertically.
	/// </summary>
	[JsonPropertyName("layout")]
	[DefaultValue("horizontal")]
	public HorizontalOrVertical? Layout { get; set; } 

	/// <summary>
	/// When dimension number is extremely large, say, more than 50 dimensions, there will be more than 50 axes, which may hardly display in a page.
	///  
	/// In this case, you may use parallel.axisExpandable to improve the display.
	/// See this example:   
	/// Whether to enable toggling axis on clicking.
	/// </summary>
	[JsonPropertyName("axisExpandable")]
	[DefaultValue(false)]
	public bool? AxisExpandable { get; set; } 

	/// <summary>
	/// Index of the axis which is used as the center of expanding initially.
	/// It doesn't have a default value, and needs to be assigned manually.
	///  
	/// Please refer to parallel.axisExpandable for more information.
	/// </summary>
	[JsonPropertyName("axisExpandCenter")]
	public double? AxisExpandCenter { get; set; } 

	/// <summary>
	/// Defines how many axes are at expanding state initially.
	/// We'd suggest you assign this value manually according to dimensions.
	///  
	/// Please refer to parallel.axisExpandCenter and parallel.axisExpandable .
	/// </summary>
	[JsonPropertyName("axisExpandCount")]
	[DefaultValue(0)]
	public double? AxisExpandCount { get; set; } 

	/// <summary>
	/// Distance between two axes when at expanding state, in pixels.
	///  
	/// Please refer to parallel.axisExpandable for more information.
	/// </summary>
	[JsonPropertyName("axisExpandWidth")]
	[DefaultValue(50)]
	public double? AxisExpandWidth { get; set; } 

	/// <summary>
	/// Optional values:   'click' : Trigger expanding when mouse clicking.
	///  'mousemove' : Trigger expanding when mouse hovering.
	/// </summary>
	[JsonPropertyName("axisExpandTriggerOn")]
	[DefaultValue("click")]
	public TriggerOn? AxisExpandTriggerOn { get; set; } 

	/// <summary>
	/// When configuring multiple parallelAxis , there might be some common attributes in each axis configuration.
	/// To avoid writing them repeatly, they can be put under parallel.parallelAxisDefault .
	/// Before initializing axis, configurations in parallel.parallelAxisDefault will be merged into parallelAxis to generate the final axis configuration.
	///  
	/// See the sample .
	/// </summary>
	[JsonPropertyName("parallelAxisDefault")]
	public ParallelAxisDefault? ParallelAxisDefault { get; set; } 

}
