// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Title
{
	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; } 

	/// <summary>
	/// Set this to false to prevent the title from showing
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("true")]
	public bool? Show { get; set; } 

	/// <summary>
	/// The main title text, supporting for \n for newlines.
	/// </summary>
	[JsonPropertyName("text")]
	[DefaultValue("")]
	public string? Text { get; set; } 

	/// <summary>
	/// The hyper link of main title text.
	/// </summary>
	[JsonPropertyName("link")]
	[DefaultValue("")]
	public string? Link { get; set; } 

	/// <summary>
	/// Open the hyper link of main title in specified tab.
	///  
	/// options:   
	/// 'self' opening it in current tab   
	/// 'blank' opening it in a new tab
	/// </summary>
	[JsonPropertyName("target")]
	[DefaultValue("blank")]
	public string? Target { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("textStyle")]
	public TextStyle? TextStyle { get; set; } 

	/// <summary>
	/// Subtitle text, supporting for \n for newlines.
	/// </summary>
	[JsonPropertyName("subtext")]
	[DefaultValue("")]
	public string? Subtext { get; set; } 

	/// <summary>
	/// The hyper link of subtitle text.
	/// </summary>
	[JsonPropertyName("sublink")]
	[DefaultValue("")]
	public string? Sublink { get; set; } 

	/// <summary>
	/// Open the hyper link of subtitle in specified tab, options:   
	/// 'self' opening it in current tab   
	/// 'blank' opening it in a new tab
	/// </summary>
	[JsonPropertyName("subtarget")]
	[DefaultValue("blank")]
	public string? Subtarget { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("subtextStyle")]
	public SubtextStyle? SubtextStyle { get; set; } 

	/// <summary>
	/// The horizontal align of the component (including "text" and "subtext").
	///  
	/// Optional values: 'auto' , 'left' , 'right' , 'center' .
	/// </summary>
	[JsonPropertyName("textAlign")]
	[DefaultValue("auto")]
	public HorizontalAlign? TextAlign { get; set; } 

	/// <summary>
	/// The vertical align of the component (including "text" and "subtext").
	///  
	/// Optional values: 'auto' , 'top' , 'bottom' , 'middle' .
	/// </summary>
	[JsonPropertyName("textVerticalAlign")]
	[DefaultValue("auto")]
	public VerticalAlign? TextVerticalAlign { get; set; } 

	/// <summary>
	/// Set this to true to enable triggering events
	/// </summary>
	[JsonPropertyName("triggerEvent")]
	[DefaultValue(false)]
	public bool? TriggerEvent { get; set; } 

	/// <summary>
	/// title space around content.
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
	/// The gap between the main title and subtitle.
	/// </summary>
	[JsonPropertyName("itemGap")]
	[DefaultValue("10")]
	public double? ItemGap { get; set; } 

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
	/// Distance between title  component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue("auto")]
	public NumberOrString? Left { get; set; } 

	/// <summary>
	/// Distance between title  component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue("auto")]
	public NumberOrString? Top { get; set; } 

	/// <summary>
	/// Distance between title  component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue("auto")]
	public NumberOrString? Right { get; set; } 

	/// <summary>
	/// Distance between title  component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue("auto")]
	public NumberOrString? Bottom { get; set; } 

	/// <summary>
	/// Background color of title, which is transparent by default.
	///   
	/// Color can be represented in RGB, for example 'rgb(128, 128, 128)' .
	/// RGBA can be used when you need alpha channel, for example 'rgba(128, 128, 128, 0.5)' .
	/// You may also use hexadecimal format, for example '#ccc' .
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	[DefaultValue("transparent")]
	public Color? BackgroundColor { get; set; } 

	/// <summary>
	/// Border color of title.
	/// Support the same color format as backgroundColor.
	/// </summary>
	[JsonPropertyName("borderColor")]
	[DefaultValue("#ccc")]
	public Color? BorderColor { get; set; } 

	/// <summary>
	/// Border width of title.
	/// </summary>
	[JsonPropertyName("borderWidth")]
	[DefaultValue("0")]
	public double? BorderWidth { get; set; } 

	/// <summary>
	/// The radius of rounded corner.
	/// Its unit is px.
	/// And it supports use array to respectively specify the 4 corner radiuses.
	///  
	/// For example:  borderRadius: 5, // consistently set the size of 4 rounded corners
	/// borderRadius: [5, 5, 0, 0] // (clockwise upper left, upper right, bottom right and bottom left)
	/// </summary>
	[JsonPropertyName("borderRadius")]
	[DefaultValue(0)]
	public Radius? BorderRadius { get; set; } 

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

}
