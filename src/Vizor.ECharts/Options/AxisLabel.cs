
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class AxisLabel
{
	/// <summary>
	/// Set this to false to prevent the axis label from appearing.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("true")]
	public bool? Show { get; set; } 

	/// <summary>
	/// Interval of Axis label, which is available in category axis.
	///  
	/// It uses a strategy that labels do not overlap by default.
	///  
	/// You may set it to be 0 to display all labels compulsively.
	///  
	/// If it is set to be 1, it means that labels are shown once after one label.
	/// And if it is set to be 2, it means labels are shown once after two labels, and so on.
	///  
	/// On the other hand, you can control by callback function, whose format is shown below:  (index:number, value: string) => boolean  
	/// The first parameter is index of category, and the second parameter is the name of category.
	/// The return values decides whether to display label.
	/// </summary>
	[JsonPropertyName("interval")]
	[DefaultValue("auto")]
	public NumberOrFunction? Interval { get; set; } 

	/// <summary>
	/// Set this to true so the axis labels face the inside direction.
	/// </summary>
	[JsonPropertyName("inside")]
	[DefaultValue(false)]
	public bool? Inside { get; set; } 

	/// <summary>
	/// Rotation degree of axis label, which is especially useful when there is no enough space for category axis.
	///  
	/// Rotation degree is from -90 to 90.
	/// </summary>
	[JsonPropertyName("rotate")]
	[DefaultValue(0)]
	public double? Rotate { get; set; } 

	/// <summary>
	/// The margin between the axis label and the axis line.
	/// </summary>
	[JsonPropertyName("margin")]
	[DefaultValue("8")]
	public double? Margin { get; set; } 

	/// <summary>
	/// Formatter of axis label, which supports string template and callback function.
	///  
	/// Example:  // Use string template; template variable is the default label of axis {value}
	/// formatter: '{value} kg'
	/// // Use callback.
	/// formatter: function (value, index) {
	///     return value + 'kg';
	/// }   
	/// For axes of time type : 'time' , formatter supports the following forms:   String Templates : an easy and fast way to make frequently used date/time template, formed in string  Callback Functions : customized formatter to make complex format, formed in Function  Cascading Templates : to adopt different formatters for different time granularity, formed in object   
	/// Next, we are going to introduce these three forms one by one.
	///  
	/// String Templates  
	/// Using string templates is an easy way to format date/time with frequently used formats.
	/// If it can be used to make what you want, you are advised to do so.
	/// If not, you could then consider the others.
	/// Supported formats are:     Group  Template  Value (EN)  Value (ZH)      Year  {yyyy}  e.g., 2020, 2021, ...
	///  例：2020, 2021, ...
	///     {yy}  00-99  00-99    Quarter  {Q}  1, 2, 3, 4  1, 2, 3, 4    Month  {MMMM}  e.g., January, February, ...
	///  一月、二月、……     {MMM}  e.g., Jan, Feb, ...
	///  1月、2月、……     {MM}  01-12  01-12     {M}  1-12  1-12    Day of Month  {dd}  01-31  01-31     {d}  1-31  1-31    Day of Week  {eeee}  Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, Saturday  星期日、星期一、星期二、星期三、星期四、星期五、星期六     {ee}  Sun, Mon, Tues, Wed, Thu, Fri, Sat  日、一、二、三、四、五、六     {e}  1-54  1-54    Hour  {HH}  00-23  00-23     {H}  0-23  0-23     {hh}  01-12  01-12     {h}  1-12  1-12    Minute  {mm}  00-59  00-59     {m}  0-59  0-59    Second  {ss}  00-59  00-59     {s}  0-59  0-59    Millisecond  {SSS}  000-999  000-999     {S}  0-999  0-999      
	/// Templates of other languages can be found in the language package .
	/// Please refer to echarts.registerLocale to register a language.
	///   
	/// Example:  formatter: '{yyyy}-{MM}-{dd}' // gets labels like '2020-12-02'
	/// formatter: 'Day {d}' // gets labels like 'Day 2'  
	/// Callback Functions  
	/// Callback functions can be used to get different formats for different axis tick values.
	/// Sometimes, if you have complex date/time formatting requirement, third-party libraries like Moment.js or date-fns can be used to return formatted labels.
	///  
	/// Example:  // Use callback function; function parameters are axis index
	/// formatter: function (value, index) {
	///     // Formatted to be month/day; display year only in the first label
	///     var date = new Date(value);
	///     var texts = [(date.getMonth() + 1), date.getDate()];
	///     if (index === 0) {
	///         texts.unshift(date.getYear());
	///     }
	///     return texts.join('/');
	/// }  
	/// Cascading Templates  
	/// Sometimes, we wish to use different formats for different time granularity.
	/// For example, in a quarter-year chart, we may wish to see the month name with the first date of the month, while see the date name with others.
	/// This can be made with:  
	/// Example:  formatter: {
	///     month: '{MMMM}', // Jan, Feb, ...
	///     day: '{d}' // 1, 2, ...
	/// }  
	/// Supported levels and their default formatters are:  {
	///     year: '{yyyy}',
	///     month: '{MMM}',
	///     day: '{d}',
	///     hour: '{HH}:{mm}',
	///     minute: '{HH}:{mm}',
	///     second: '{HH}:{mm}:{ss}',
	///     millisecond: '{hh}:{mm}:{ss} {SSS}',
	///     none: '{yyyy}-{MM}-{dd} {hh}:{mm}:{ss} {SSS}'
	/// }  
	/// Let's take day for example.
	/// When a tick value is 0 for its hour, minute, second, and millisecond, day level will be used to make formatter.
	/// none is used when no other level fulfills, which is for tick values with millisecond values other than 0 .
	///  
	/// Rich Text  
	/// The above three forms all support rich text, so it can be used to make some complex effects.
	///  
	/// Example:  xAxis: {
	///     type: 'time',
	///     axisLabel: {
	///         formatter: {
	///             // Display year and month information on the first data of a year
	///             year: '{yearStyle|{yyyy}}\n{monthStyle|{MMM}}',
	///             month: '{monthStyle|{MMM}}'
	///         },
	///         rich: {
	///             yearStyle: {
	///                 // Make yearly text more standing out
	///                 color: '#000',
	///                 fontWeight: 'bold'
	///             },
	///             monthStyle: {
	///                 color: '#999'
	///             }
	///         }
	///     }
	/// },  
	/// The above example can also be made with a callback function:  
	/// Example:  xAxis: {
	///     type: 'time',
	///     axisLabel: {
	///         formatter: function (value) {
	///             const date = new Date(value);
	///             const yearStart = new Date(value);
	///             yearStart.setMonth(0);
	///             yearStart.setDate(1);
	///             yearStart.setHours(0);
	///             yearStart.setMinutes(0);
	///             yearStart.setSeconds(0);
	///             yearStart.setMilliseconds(0);
	///             // Whether a tick value is the start of a year
	///             if (date.getTime() === yearStart.getTime()) {
	///                 return '{year|' + date.getFullYear() + '}\n'
	///                     + '{month|' + (date.getMonth() + 1) + '月}';
	///             }
	///             else {
	///                 return '{month|' + (date.getMonth() + 1) + '月}'
	///             }
	///         },
	///         rich: {
	///             year: {
	///                 color: '#000',
	///                 fontWeight: 'bold'
	///             },
	///             month: {
	///                 color: '#999'
	///             }
	///         }
	///     }
	/// },
	/// </summary>
	[JsonPropertyName("formatter")]
	public StringOrFunction? Formatter { get; set; } 

	/// <summary>
	/// Whether to show the label of the min tick.
	/// Optional values: true , false , null .
	/// It is auto determined by default, that is, if labels are overlapped, the label of the min tick will not be displayed.
	/// </summary>
	[JsonPropertyName("showMinLabel")]
	public bool? ShowMinLabel { get; set; } 

	/// <summary>
	/// Whether to show the label of the max tick.
	/// Optional values: true , false , null .
	/// It is auto determined by default, that is, if labels are overlapped, the label of the max tick will not be displayed.
	/// </summary>
	[JsonPropertyName("showMaxLabel")]
	public bool? ShowMaxLabel { get; set; } 

	/// <summary>
	/// Since v5.2.0   
	/// Whether to hide overlapped labels.
	/// </summary>
	[JsonPropertyName("hideOverlap")]
	public bool? HideOverlap { get; set; } 

	/// <summary>
	/// Color of axis label is set to be axisLine.lineStyle.color by default.
	/// Callback function is supported, in the following format:  (val: string) => Color  
	/// Parameter is the text of label, and return value is the color.
	/// See the following example:  textStyle: {
	///     color: function (value, index) {
	///         return value >= 0 ? 'green' : 'red';
	///     }
	/// }
	/// </summary>
	[JsonPropertyName("color")]
	public ColorOrFunction? Color { get; set; } 

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

	/// <summary>
	/// The distance between the label and tick line.
	/// </summary>
	[JsonPropertyName("distance")]
	[DefaultValue("15")]
	public double? Distance { get; set; } 

}
