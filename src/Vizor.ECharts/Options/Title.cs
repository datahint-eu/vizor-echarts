
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
	public BorderRadius? BorderRadius { get; set; } 

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
	/// 
	/// </summary>
	[JsonPropertyName("zoom")]
	[DefaultValue("area zooming")]
	public string? Zoom { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("back")]
	[DefaultValue("restore area zooming")]
	public string? Back { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("line")]
	[DefaultValue("Switch to Line Chart")]
	public string? Line { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("bar")]
	[DefaultValue("Switch to Bar Chart")]
	public string? Bar { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("stack")]
	[DefaultValue("Stack")]
	public string? Stack { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("tiled")]
	[DefaultValue("Tile")]
	public string? Tiled { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("rect")]
	[DefaultValue("Rectangle selection")]
	public string? Rect { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("polygon")]
	[DefaultValue("Polygon selection")]
	public string? Polygon { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("lineX")]
	[DefaultValue("Horizontal selection")]
	public string? LineX { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("lineY")]
	[DefaultValue("Vertical selection")]
	public string? LineY { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("keep")]
	[DefaultValue("Keep previous selection")]
	public string? Keep { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("clear")]
	[DefaultValue("Clear selection")]
	public string? Clear { get; set; }

	/// <summary>
	/// The offset position relative to the center of gauge chart.
	/// The first item of array is the horizontal offset; the second item of array is the vertical offset.
	/// It could be absolute value and also the percentage relative to the radius of gauge chart.
	/// </summary>
	[JsonPropertyName("offsetCenter")]
	[DefaultValue("0,20%")]
	public NumberOrStringArray? OffsetCenter { get; set; } 

	/// <summary>
	/// text color.
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("'#464646'")]
	public Color? Color { get; set; } 

	/// <summary>
	/// font style.
	///  
	/// Options are:   'normal'  'italic'  'oblique'
	/// </summary>
	[JsonPropertyName("fontStyle")]
	[DefaultValue("normal")]
	public FontStyle? FontStyle { get; set; } 

	/// <summary>
	/// font thick weight.
	///  
	/// Options are:   'normal'  'bold'  'bolder'  'lighter'  100 | 200 | 300 | 400...
	/// </summary>
	[JsonPropertyName("fontWeight")]
	[DefaultValue("normal")]
	public FontWeight? FontWeight { get; set; } 

	/// <summary>
	/// font family.
	///  
	/// Can also be 'serif' , 'monospace', ...
	/// </summary>
	[JsonPropertyName("fontFamily")]
	[DefaultValue("sans-serif")]
	public string? FontFamily { get; set; } 

	/// <summary>
	/// font size.
	/// </summary>
	[JsonPropertyName("fontSize")]
	[DefaultValue("16")]
	public double? FontSize { get; set; } 

	/// <summary>
	/// Line height of the text fragment.
	///  
	/// If lineHeight is not set in rich , lineHeight in parent level will be used.
	/// For example:  {
	///     lineHeight: 56,
	///     rich: {
	///         a: {
	///             // `lineHeight` is not set, then it will be 56
	///         }
	///     }
	/// }
	/// </summary>
	[JsonPropertyName("lineHeight")]
	[DefaultValue("12")]
	public double? LineHeight { get; set; } 

	/// <summary>
	/// the text fragment border type.
	///  
	/// Possible values are:   'solid'  'dashed'  'dotted'   
	/// Since v5.0.0 , it can also be a number or a number array to specify the dash array of the line.
	/// With borderDashOffset , we can make the line style more flexible.
	///  
	/// For example：  {
	/// 
	/// borderType: [5, 10],
	/// 
	/// borderDashOffset: 5
	/// }
	/// </summary>
	[JsonPropertyName("borderType")]
	[DefaultValue("solid")]
	public LineType? BorderType { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// To set the line dash offset.
	/// With borderType , we can make the line style more flexible.
	///  
	/// Refer to MDN lineDashOffset for more details.
	/// </summary>
	[JsonPropertyName("borderDashOffset")]
	[DefaultValue("0")]
	public double? BorderDashOffset { get; set; } 

	/// <summary>
	/// Width of text block.
	/// </summary>
	[JsonPropertyName("width")]
	[DefaultValue("100")]
	public double? Width { get; set; } 

	/// <summary>
	/// Height of text block.
	/// </summary>
	[JsonPropertyName("height")]
	[DefaultValue("50")]
	public double? Height { get; set; } 

	/// <summary>
	/// Stroke color of the text.
	/// </summary>
	[JsonPropertyName("textBorderColor")]
	public Color? TextBorderColor { get; set; } 

	/// <summary>
	/// Stroke line width of the text.
	/// </summary>
	[JsonPropertyName("textBorderWidth")]
	public double? TextBorderWidth { get; set; } 

	/// <summary>
	/// Stroke line type of the text.
	///  
	/// Possible values are:   'solid'  'dashed'  'dotted'   
	/// Since v5.0.0 , it can also be a number or a number array to specify the dash array of the line.
	/// With textBorderDashOffset , we can make the line style more flexible.
	///  
	/// For example：  {
	/// 
	/// textBorderType: [5, 10],
	/// 
	/// textBorderDashOffset: 5
	/// }
	/// </summary>
	[JsonPropertyName("textBorderType")]
	[DefaultValue("solid")]
	public LineType? TextBorderType { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// To set the line dash offset.
	/// With textBorderType , we can make the line style more flexible.
	///  
	/// Refer to MDN lineDashOffset for more details.
	/// </summary>
	[JsonPropertyName("textBorderDashOffset")]
	[DefaultValue("0")]
	public double? TextBorderDashOffset { get; set; } 

	/// <summary>
	/// Shadow color of the text itself.
	/// </summary>
	[JsonPropertyName("textShadowColor")]
	[DefaultValue("#000")]
	public Color? TextShadowColor { get; set; } 

	/// <summary>
	/// Shadow blue of the text itself.
	/// </summary>
	[JsonPropertyName("textShadowBlur")]
	[DefaultValue(0)]
	public double? TextShadowBlur { get; set; } 

	/// <summary>
	/// Shadow X offset of the text itself.
	/// </summary>
	[JsonPropertyName("textShadowOffsetX")]
	[DefaultValue(0)]
	public double? TextShadowOffsetX { get; set; } 

	/// <summary>
	/// Shadow Y offset of the text itself.
	/// </summary>
	[JsonPropertyName("textShadowOffsetY")]
	[DefaultValue(0)]
	public double? TextShadowOffsetY { get; set; } 

	/// <summary>
	/// Determine how to display the text when it's overflow.
	/// Available when width is set.
	///   'truncate' Truncate the text and trailing with ellipsis .
	///  'break' Break by word  'breakAll' Break by character.
	/// </summary>
	[JsonPropertyName("overflow")]
	[DefaultValue("none")]
	public Overflow? Overflow { get; set; } 

	/// <summary>
	/// Ellipsis to be displayed when overflow is set to truncate .
	///   'truncate' Truncate the overflow lines.
	/// </summary>
	[JsonPropertyName("ellipsis")]
	[DefaultValue("...")]
	public string? Ellipsis { get; set; } 

	/// <summary>
	/// "Rich text styles" can be defined in this rich property.
	/// For example:  label: {
	///     // Styles defined in 'rich' can be applied to some fragments
	///     // of text by adding some markers to those fragment, like
	///     // `{styleName|text content text content}`.
	///     // `'\n'` is the newline character.
	///     formatter: [
	///         '{a|Style "a" is applied to this snippet}'
	///         '{b|Style "b" is applied to this snippet}This snippet use default style{x|use style "x"}'
	///     ].join('\n'),
	/// 
	///     rich: {
	///         a: {
	///             color: 'red',
	///             lineHeight: 10
	///         },
	///         b: {
	///             backgroundColor: {
	///                 image: 'xxx/xxx.jpg'
	///             },
	///             height: 40
	///         },
	///         x: {
	///             fontSize: 18,
	///             fontFamily: 'Microsoft YaHei',
	///             borderColor: '#449933',
	///             borderRadius: 4
	///         },
	///         ...
	///     }
	/// }  
	/// For more details, see Rich Text please.
	/// </summary>
	[JsonPropertyName("rich")]
	public Rich? Rich { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Whether to enable text animation of value change.
	/// </summary>
	[JsonPropertyName("valueAnimation")]
	[DefaultValue(true)]
	public bool? ValueAnimation { get; set; } 

}
