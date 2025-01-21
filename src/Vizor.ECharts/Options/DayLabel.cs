
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class DayLabel
{
	/// <summary>
	/// Set this to false to prevent dayLabel from showing.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("true")]
	public bool? Show { get; set; }

	/// <summary>
	/// A week from the beginning of the week, the default starting on Sunday.
	///  
	/// Examples:  calendar: [{
	///     dayLabel: {
	///         firstDay: 1 // start on Monday
	///     }
	/// }]
	/// </summary>
	[JsonPropertyName("firstDay")]
	[DefaultValue(0)]
	public double? FirstDay { get; set; }

	/// <summary>
	/// The margin between the day label and the axis line.
	/// </summary>
	[JsonPropertyName("margin")]
	[DefaultValue(0)]
	public double? Margin { get; set; }

	/// <summary>
	/// Position of week, at the beginning or end of the range.
	///  
	/// Options:   'start'  'end'
	/// </summary>
	[JsonPropertyName("position")]
	[DefaultValue("start")]
	public StartOrEnd? Position { get; set; }

	/// <summary>
	/// Week text content, defaults to 'en'.
	/// Since v5.2.2 , it defaults to the specified locale name when initializing charts .
	/// If not specified, it defaults to the auto-detected locale by the browser language.
	///  
	/// It supports Chinese( cn ), English( en ), and customized array.
	/// Since v5.2.2 , it also supports any built-in( EN / ZH ) or other registered locale names (case-sensitive).
	///  
	/// The index 0 always means Sunday .
	///  
	/// Examples:  // Before v5.2.2
	/// 
	/// // shortcut to English  ['S', 'M', 'T', 'W', 'T', 'F', 'S'],
	/// nameMap: 'en',
	/// // shortcut to Chinese ['日', '一', '二', '三', '四', '五', '六']
	/// nameMap: 'cn',
	/// 
	/// // Since v5.2.2
	/// 
	/// // shortcut to English  ['S', 'M', 'T', 'W', 'T', 'F', 'S'],
	/// nameMap: 'EN',
	/// // shortcut to Chinese ['日', '一', '二', '三', '四', '五', '六']
	/// nameMap: 'ZH',
	/// 
	/// // Customized: mixed in English and Chinese or not displayed
	/// nameMap: ['S', '一', 'T', '三', '', '五', 'S'],
	/// 
	/// calendar: [{
	///     dayLabel: {
	///         // nameMap: 'en' // Before v5.2.2
	///         nameMap: 'EN'    // Since v5.2.2
	///     }
	/// }]
	/// </summary>
	[JsonPropertyName("nameMap")]
	[DefaultValue("EN")]
	public StringArray? NameMap { get; set; }

	/// <summary>
	/// text color.
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("#000")]
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
	[DefaultValue("12")]
	public double? FontSize { get; set; }

	/// <summary>
	/// Horizontal alignment of text, automatic by default.
	///  
	/// Options are:   'left'  'center'  'right'   
	/// If align is not set in rich , align in parent level will be used.
	/// For example:  {
	///     align: right,
	///     rich: {
	///         a: {
	///             // `align` is not set, then it will be right
	///         }
	///     }
	/// }
	/// </summary>
	[JsonPropertyName("align")]
	public HorizontalAlign? Align { get; set; }

	/// <summary>
	/// Vertical alignment of text, automatic by default.
	///  
	/// Options are:   'top'  'middle'  'bottom'   
	/// If verticalAlign is not set in rich , verticalAlign in parent level will be used.
	/// For example:  {
	///     verticalAlign: bottom,
	///     rich: {
	///         a: {
	///             // `verticalAlign` is not set, then it will be bottom
	///         }
	///     }
	/// }
	/// </summary>
	[JsonPropertyName("verticalAlign")]
	public VerticalAlign? VerticalAlign { get; set; }

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
	/// Background color of the text fragment.
	///  
	/// Can be color string, like '#123234' , 'red' , 'rgba(0,23,11,0.3)' .
	///  
	/// Or image can be used, for example:  backgroundColor: {
	///     image: 'xxx/xxx.png'
	///     // It can be URL of a image,
	///     // or dataURI,
	///     // or HTMLImageElement,
	///     // or HTMLCanvasElement.
	/// }  
	/// width or height can be specified when using background image, or
	/// auto adapted by default.
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	[DefaultValue("#fff")]
	public Color? BackgroundColor { get; set; }

	/// <summary>
	/// Border color of the text fragment.
	/// </summary>
	[JsonPropertyName("borderColor")]
	[DefaultValue("#fff")]
	public Color? BorderColor { get; set; }

	/// <summary>
	/// Border width of the text fragment.
	/// </summary>
	[JsonPropertyName("borderWidth")]
	[DefaultValue(0)]
	public double? BorderWidth { get; set; }

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
	/// Border radius of the text fragment.
	/// </summary>
	[JsonPropertyName("borderRadius")]
	[DefaultValue(0)]
	public BorderRadius? BorderRadius { get; set; }

	/// <summary>
	/// Padding of the text fragment, for example:   padding: [3, 4, 5, 6] : represents padding of [top, right, bottom, left] .
	///  padding: 4 : represents padding: [4, 4, 4, 4] .
	///  padding: [3, 4] : represents padding: [3, 4, 3, 4] .
	///   
	/// Notice, width and height specifies the width and height of the content, without padding .
	/// </summary>
	[JsonPropertyName("padding")]
	[DefaultValue(0)]
	public Padding? Padding { get; set; }

	/// <summary>
	/// Shadow color of the text block.
	/// </summary>
	[JsonPropertyName("shadowColor")]
	[DefaultValue("transparent")]
	public Color? ShadowColor { get; set; }

	/// <summary>
	/// Show blur of the text block.
	/// </summary>
	[JsonPropertyName("shadowBlur")]
	[DefaultValue(0)]
	public double? ShadowBlur { get; set; }

	/// <summary>
	/// Shadow X offset of the text block.
	/// </summary>
	[JsonPropertyName("shadowOffsetX")]
	[DefaultValue(0)]
	public double? ShadowOffsetX { get; set; }

	/// <summary>
	/// Shadow Y offset of the text block.
	/// </summary>
	[JsonPropertyName("shadowOffsetY")]
	[DefaultValue(0)]
	public double? ShadowOffsetY { get; set; }

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

}
