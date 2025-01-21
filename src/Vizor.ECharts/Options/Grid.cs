
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Grid
{
	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Whether to show the grid in rectangular coordinate.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("false")]
	public bool? Show { get; set; }

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
	/// Distance between grid  component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue("10%")]
	public NumberOrString? Left { get; set; }

	/// <summary>
	/// Distance between grid  component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue(60)]
	public NumberOrString? Top { get; set; }

	/// <summary>
	/// Distance between grid  component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue("10%")]
	public NumberOrString? Right { get; set; }

	/// <summary>
	/// Distance between grid  component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue(60)]
	public NumberOrString? Bottom { get; set; }

	/// <summary>
	/// Width of grid  component.
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("width")]
	[DefaultValue("auto")]
	public NumberOrString? Width { get; set; }

	/// <summary>
	/// Height of grid  component.
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("height")]
	[DefaultValue("auto")]
	public NumberOrString? Height { get; set; }

	/// <summary>
	/// Whether the grid region contains axis tick label of axis.
	///   When containLabel is false :  grid.left  grid.right  grid.top  grid.bottom  grid.width  grid.height decide the location and size of the rectangle that is made of by xAxis and yAxis.
	///  Setting to false will help when multiple grids need to be aligned at their axes.
	///    When containLabel is true :  grid.left  grid.right  grid.top  grid.bottom  grid.width  grid.height decide the location and size of the rectangle that contains the axes and the labels of the axes.
	///  Setting to true will help when the length of axis labels is dynamic and is hard to approximate.
	/// This will avoid labels from overflowing the container or overlapping other components.
	/// </summary>
	[JsonPropertyName("containLabel")]
	[DefaultValue("false")]
	public bool? ContainLabel { get; set; }

	/// <summary>
	/// Background color of grid, which is transparent by default.
	///   
	/// Color can be represented in RGB, for example 'rgb(128, 128, 128)' .
	/// RGBA can be used when you need alpha channel, for example 'rgba(128, 128, 128, 0.5)' .
	/// You may also use hexadecimal format, for example '#ccc' .
	///   
	/// Attention : Works only if show: true is set.
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	[DefaultValue("transparent")]
	public Color? BackgroundColor { get; set; }

	/// <summary>
	/// Border color of grid.
	/// Support the same color format as backgroundColor.
	///  
	/// Attention : Works only if show: true is set.
	/// </summary>
	[JsonPropertyName("borderColor")]
	[DefaultValue("#ccc")]
	public Color? BorderColor { get; set; }

	/// <summary>
	/// Border width of grid.
	///  
	/// Attention : Works only if show: true is set.
	/// </summary>
	[JsonPropertyName("borderWidth")]
	[DefaultValue("1")]
	public double? BorderWidth { get; set; }

	/// <summary>
	/// Size of shadow blur.
	/// This attribute should be used along with shadowColor , shadowOffsetX , shadowOffsetY to set shadow to component.
	///  
	/// For example:  {
	///     shadowColor: 'rgba(0, 0, 0, 0.5)',
	///     shadowBlur: 10
	/// }  
	/// Attention : This property works only if show: true is configured and backgroundColor is defined other than transparent .
	/// </summary>
	[JsonPropertyName("shadowBlur")]
	[DefaultValue("")]
	public double? ShadowBlur { get; set; }

	/// <summary>
	/// Shadow color.
	/// Support same format as color .
	///  
	/// Attention : This property works only if show: true configured.
	/// </summary>
	[JsonPropertyName("shadowColor")]
	[DefaultValue("")]
	public Color? ShadowColor { get; set; }

	/// <summary>
	/// Offset distance on the horizontal direction of shadow.
	///  
	/// Attention : This property works only if show: true configured.
	/// </summary>
	[JsonPropertyName("shadowOffsetX")]
	[DefaultValue("0")]
	public double? ShadowOffsetX { get; set; }

	/// <summary>
	/// Offset distance on the vertical direction of shadow.
	///  
	/// Attention : This property works only if show: true configured.
	/// </summary>
	[JsonPropertyName("shadowOffsetY")]
	[DefaultValue("0")]
	public double? ShadowOffsetY { get; set; }

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
