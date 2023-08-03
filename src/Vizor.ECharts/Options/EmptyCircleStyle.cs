using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Style of circle placeholder.
/// See https://echarts.apache.org/en/option.html#series-pie.emptyCircleStyle.color
/// </summary>
public class EmptyCircleStyle
{
	[JsonPropertyName("color")]
	[DefaultValue("lightgray")]
	public Color? Color { get; set; }

	[JsonPropertyName("borderColor")]
	[DefaultValue("#000")]
	public Color? BorderColor { get; set; }

	/// <summary>
	/// border width. No border when it is set to be 0.
	/// </summary>
	[JsonPropertyName("borderWidth")]
	public double? BorderWidth { get; set; }

	/// <summary>
	/// line type. Possible values are:   'solid'  'dashed'  'dotted'
	/// Since v5.0.0 , it can also be a number or a number array to specify the dash array of the line.
	/// With borderDashOffset , we can make the line style more flexible.
	///  
	/// For example：  {
	/// 
	/// type: [5, 10],
	/// 
	/// dashOffset: 5
	/// }
	/// </summary>
	[JsonPropertyName("borderType")]
	[DefaultValue("solid")]
	public object? BorderTypeObject { get; set; }

	/// <summary>
	/// line type. Possible values are:   'solid'  'dashed'  'dotted'
	/// </summary>
	[JsonIgnore]
	public LineStyle? BorderType
	{
		get => BorderTypeObject as LineStyle;
		set => BorderTypeObject = value;
	}

	/// <summary>
	/// Since v5.0.0, it can also be a number or a number array to specify the dash array of the line. 
	/// For example: [5, 10]
	/// Use in combination with DashOffset
	/// </summary>
	[JsonIgnore]
	public NumberArray? BorderTypeDashArray
	{
		get => BorderTypeObject as NumberArray;
		set => BorderTypeObject = value;
	}

	/// <summary>
	/// Since v5.0.0   
	/// To set the line dash offset.
	/// Use in combination with TypeDashArray
	///  
	/// Refer to MDN lineDashOffset for more details.
	/// </summary>
	[JsonPropertyName("borderDashOffset")]
	[DefaultValue("0")]
	public double? BorderDashOffset { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// To specify how to draw the end points of the line.
	/// Possible values are:   'butt' : The ends of lines are squared off at the endpoints.
	///  'round' : The ends of lines are rounded.
	///  'square' : The ends of lines are squared off by adding a box with an equal width and half the height of the line's thickness.
	///   
	/// Default value is 'butt' .
	/// Refer to MDN lineCap for more details.
	/// </summary>
	[JsonPropertyName("borderCap")]
	[DefaultValue("butt")]
	public LineCap? BorderCap { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// To set the miter limit ratio.
	/// Only works when borderJoin is set as miter .
	///  
	/// Default value is 10 .
	/// Negative、 0 、 Infinity and NaN values are ignored.
	///  
	/// Refer to MDN miterLimit for more details.
	/// </summary>
	[JsonPropertyName("borderMiterLimit")]
	[DefaultValue("10")]
	public double? BorderMiterLimit { get; set; }

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
	[DefaultValue("")]
	public double? ShadowBlur { get; set; }

	/// <summary>
	/// Shadow color.
	/// Support same format as color .
	/// </summary>
	[JsonPropertyName("shadowColor")]
	[DefaultValue("")]
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
	/// Opacity of the component.
	/// Supports value from 0 to 1, and the component will not be drawn when set to 0.
	/// </summary>
	[JsonPropertyName("opacity")]
	[DefaultValue("1")]
	public double? Opacity { get; set; }
}
