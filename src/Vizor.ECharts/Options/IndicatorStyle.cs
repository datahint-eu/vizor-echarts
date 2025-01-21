
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class IndicatorStyle
{
	/// <summary>
	/// color.
	///   
	/// Supports setting as solid color using rgb(255,255,255) , rgba(255,255,255,1) , #fff , etc.
	/// Also supports setting as gradient color and pattern fill, see option.color for details
	/// </summary>
	[JsonPropertyName("color")]
	public Color? Color { get; set; }

	/// <summary>
	/// border color, whose format is similar to that of color .
	/// </summary>
	[JsonPropertyName("borderColor")]
	[DefaultValue("#fff")]
	public Color? BorderColor { get; set; }

	/// <summary>
	/// border width.
	/// No border when it is set to be 0.
	///  
	/// border width.
	/// No border when it is set to be 0.
	/// </summary>
	[JsonPropertyName("borderWidth")]
	[DefaultValue(2)]
	public double? BorderWidth { get; set; }

	/// <summary>
	/// border type.
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
	/// To determine the shape used to join two line segments where they meet.
	///  
	/// Possible values are:   'bevel' : Fills an additional triangular area between the common endpoint of connected segments, and the separate outside rectangular corners of each segment.
	///  'round' : Rounds off the corners of a shape by filling an additional sector of disc centered at the common endpoint of connected segments.
	/// The radius for these rounded corners is equal to the line width.
	///  'miter' : Connected segments are joined by extending their outside edges to connect at a single point, with the effect of filling an additional lozenge-shaped area.
	/// This setting is affected by the borderMiterLimit property.
	///   
	/// Default value is 'bevel' .
	/// Refer to MDN lineJoin for more details.
	/// </summary>
	[JsonPropertyName("borderJoin")]
	[DefaultValue("bevel")]
	public LineJoin? BorderJoin { get; set; }

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
	[DefaultValue("2")]
	public double? ShadowBlur { get; set; }

	/// <summary>
	/// Shadow color.
	/// Support same format as color .
	/// </summary>
	[JsonPropertyName("shadowColor")]
	[DefaultValue("rgba(0,0,0,0.2)")]
	public Color? ShadowColor { get; set; }

	/// <summary>
	/// Offset distance on the horizontal direction of shadow.
	/// </summary>
	[JsonPropertyName("shadowOffsetX")]
	[DefaultValue("1")]
	public double? ShadowOffsetX { get; set; }

	/// <summary>
	/// Offset distance on the vertical direction of shadow.
	/// </summary>
	[JsonPropertyName("shadowOffsetY")]
	[DefaultValue("1")]
	public double? ShadowOffsetY { get; set; }

	/// <summary>
	/// Opacity of the component.
	/// Supports value from 0 to 1, and the component will not be drawn when set to 0.
	/// </summary>
	[JsonPropertyName("opacity")]
	[DefaultValue("1")]
	public double? Opacity { get; set; }

}
