// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Label
{
	/// <summary>
	/// Whether show label.
	/// Label will not show by default.
	/// But if tooltip.axisPointer.type is set as 'cross' , label will be displayed automatically.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue(false)]
	public bool? Show { get; set; } 

	/// <summary>
	/// The precision of value in label.
	/// It is auto determined by default.
	/// You can also set it as '2' , which indicates that two decimal fractions are reserved.
	/// </summary>
	[JsonPropertyName("precision")]
	[DefaultValue("auto")]
	public NumberOrString? Precision { get; set; } 

	/// <summary>
	/// The formatter of label.
	///  
	/// If set as string , for example it can be: formatter: 'some text {value} some text , where {value} will be replaced by axis value automatically.
	///  
	/// If set as function :  
	/// Parameters:  
	/// {Object} params: Including fields as follows:  
	/// {Object} params.value: current value of this axis.
	/// If axis.type is 'category' , it is one of the value in axis.data .
	/// If axis.type is 'time' , it is a timestamp.
	///  
	/// {Array.<Object>} params.seriesData: An array, containing info of nearest points.
	/// Each item is:  
	/// {string} params.axisDimension: The dimension name of the axis.
	/// For example, in catesian it will be 'x' , 'y' , and in polar it will be 'radius' , 'angle' .
	///  
	/// {number} params.axisIndex: The index of the axis, for example, 0 , 1 , 2 , ...
	///  {
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
	///     dimensionNames: Array<String>,
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
	/// Each item also includes axis infomation:  {
	///     axisDim: 'x', // 'x', 'y', 'angle', 'radius', 'single'
	///     axisId: 'xxx',
	///     axisName: 'xxx',
	///     axisIndex: 3,
	///     axisValue: 121, // The current value of axisPointer
	///     axisValueLabel: 'text of value'
	/// }  
	/// Return:  
	/// The string to be displayed.
	///  
	/// For example:  formatter: function (params) {
	///     // If axis.type is 'time'
	///     return 'some text' + echarts.format.formatTime(params.value);
	/// }
	/// </summary>
	[JsonPropertyName("formatter")]
	public StringOrFunction? Formatter { get; set; } 

	/// <summary>
	/// Distance between label and axis.
	/// </summary>
	[JsonPropertyName("margin")]
	[DefaultValue(3)]
	public double? Margin { get; set; } 

	/// <summary>
	/// text color.
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("'#fff'")]
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
	/// axisPointer space around content.
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
	[DefaultValue("[5, 7, 5, 7]")]
	public Padding? Padding { get; set; } 

	/// <summary>
	/// Background color of label, the same as axis.axisLine.lineStyle.color by default.
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	[DefaultValue("auto")]
	public string? BackgroundColor { get; set; } 

	/// <summary>
	/// Border color of label.
	/// </summary>
	[JsonPropertyName("borderColor")]
	public string? BorderColor { get; set; } 

	/// <summary>
	/// Border width of label.
	/// </summary>
	[JsonPropertyName("borderWidth")]
	[DefaultValue(0)]
	public string? BorderWidth { get; set; } 

	/// <summary>
	/// Size of shadow blur.
	/// This attribute should be used along with shadowColor , shadowOffsetX , shadowOffsetY to set shadow to component.
	///  
	/// For example:  {
	///     shadowColor: 'rgba(0, 0, 0, 0.5)',
	///     shadowBlur: 10
	/// }
	/// </summary>
	[JsonPropertyName("shadowBlur")]
	[DefaultValue("3")]
	public double? ShadowBlur { get; set; } 

	/// <summary>
	/// Shadow color.
	/// Support same format as color .
	/// </summary>
	[JsonPropertyName("shadowColor")]
	[DefaultValue("#aaa")]
	public Color? ShadowColor { get; set; } 

	/// <summary>
	/// Offset distance on the horizontal direction of shadow.
	/// </summary>
	[JsonPropertyName("shadowOffsetX")]
	[DefaultValue("0")]
	public double? ShadowOffsetX { get; set; } 

	/// <summary>
	/// Offset distance on the vertical direction of shadow.
	/// </summary>
	[JsonPropertyName("shadowOffsetY")]
	[DefaultValue("0")]
	public double? ShadowOffsetY { get; set; } 

	/// <summary>
	/// Label position.
	///  
	/// Followings are the options:   
	/// [x, y]  
	/// Use relative percentage, or absolute pixel values to represent position of label relative to top-left corner of bounding box.
	///   For example:  // Absolute pixel values
	///   position: [10, 10],
	///   // Relative percentage
	///   position: ['50%', '50%']   
	/// 'top'   'left'  'right'  'bottom'  'inside'  'insideLeft'  'insideRight'  'insideTop'  'insideBottom'  'insideTopLeft'  'insideBottomLeft'  'insideTopRight'  'insideBottomRight'   
	/// See: label position .
	/// </summary>
	[JsonPropertyName("position")]
	public LabelPosition? Position { get; set; } 

	/// <summary>
	/// Distance to the host graphic element.
	///  
	/// It is valid only when position is string value (like 'top' 、 'insideRight' ).
	///  
	/// See: label position .
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
	public NumberOrString? Rotate { get; set; } 

	/// <summary>
	/// Whether to move text slightly.
	/// For example: [30, 40] means move 30 horizontally and move 40 vertically.
	/// </summary>
	[JsonPropertyName("offset")]
	public double[]? Offset { get; set; } 

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
	/// Interval of label .
	/// When it is assigned with a numerical value, such as 2 , a label would show every 2 items.
	/// </summary>
	[JsonPropertyName("interval")]
	[DefaultValue("auto")]
	public NumberOrString? Interval { get; set; } 

	/// <summary>
	/// Label aligning policy.
	/// Valid only when position is 'outer' .
	///  
	/// Since ECharts v4.6.0, we provide 'labelLine' and 'edge' two extra valid alignTo values.
	///   'none' (default): label lines have fixed length as labelLine.length and labelLine.length2 .
	///  'labelLine' : aligning to the end of label lines and the length of the shortest horizontal label lines is configured by labelLine.length2 .
	///  'edge' : aligning to text and the distance between the edges of text and the viewport is configured by label.edgeDistance .
	/// </summary>
	[JsonPropertyName("alignTo")]
	[DefaultValue("none")]
	public LabelAlignTo? AlignTo { get; set; } 

	/// <summary>
	/// The horizontal distance between text edges and viewport when label.position is 'outer' and label.alignTo is 'edge' .
	///   
	/// In most cases, you need a small edgeDistance value like 10 for mobile devices to make sure more text can be shown instead of being ...
	/// .
	/// But on larger resolutions, a percentage value should be applied so that the label lines won't be too long.
	/// If your chart is used in varied resolutions, it is advised to set responsive design for different resolutions.
	/// </summary>
	[JsonPropertyName("edgeDistance")]
	[DefaultValue("20%")]
	public NumberOrString? EdgeDistance { get; set; } 

	/// <summary>
	/// The horizontal distance between text and viewport when label.position is 'outer' and label.alignTo is 'none' or 'labelLine' .
	/// Longer text will be truncated into '...' .
	/// </summary>
	[JsonPropertyName("bleedMargin")]
	[DefaultValue("10")]
	public double? BleedMargin { get; set; } 

	/// <summary>
	/// Distance between label line and text.
	/// </summary>
	[JsonPropertyName("distanceToLabelLine")]
	[DefaultValue("5")]
	public double? DistanceToLabelLine { get; set; } 

	/// <summary>
	/// If angle of data piece is smaller than this value (in degrees), then text is not displayed.
	/// This is used for hiding text for small piece of data.
	/// </summary>
	[JsonPropertyName("minAngle")]
	public double? MinAngle { get; set; } 

}
