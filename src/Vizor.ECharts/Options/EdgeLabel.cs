
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class EdgeLabel
{
	/// <summary>
	/// If show label on edge.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue(false)]
	public bool? Show { get; set; }

	/// <summary>
	/// Label position, options：   'start'  'middle'  'end'
	/// </summary>
	[JsonPropertyName("position")]
	[DefaultValue("middle")]
	public string? Position { get; set; }

	/// <summary>
	/// Data label formatter, which supports string template and callback function.
	/// In either form, \n is supported to represent a new line.
	///  
	/// String template  
	/// Model variation includes:   {a} : series name.
	///  {b} : the name of a data item.
	///  {c} : the value of a data item.
	///  {@xxx} : the value of a dimension named 'xxx' , for example, {@product} refers the value of 'product' dimension.
	///  {@[n]} : the value of a dimension at the index of n , for example, {@[3]} refers the value at dimensions[3].
	///   
	/// example:  formatter: '{b}: {@score}'  
	/// Callback function  
	/// Callback function is in form of:  (params: Object|Array) => string  
	/// where params is the single dataset needed by formatter, which is formed as:  {
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
	///     dimensionNames: Array&lt;String&gt;,
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
	/// </summary>
	[JsonPropertyName("formatter")]
	public StringOrFunction? Formatter { get; set; }

	/// <summary>
	/// text color.
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("null")]
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

	/// <summary>
	/// Distance to the host graphic element.
	/// </summary>
	[JsonPropertyName("distance")]
	[DefaultValue("5")]
	public double? Distance { get; set; }

	/// <summary>
	/// Rotate label, from -90 degree to 90, positive value represents rotate anti-clockwise.
	///  
	/// See: label rotation .
	/// </summary>
	[JsonPropertyName("rotate")]
	[DefaultValue("0")]
	public double? Rotate { get; set; }

	/// <summary>
	/// Whether to move text slightly.
	/// For example: [30, 40] means move 30 horizontally and move 40 vertically.
	/// </summary>
	[JsonPropertyName("offset")]
	public double[]? Offset { get; set; }

}
