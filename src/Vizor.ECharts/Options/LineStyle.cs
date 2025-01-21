
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class LineStyle
{
	/// <summary>
	/// Line color.
	///   
	/// Supports setting as solid color using rgb(255,255,255) , rgba(255,255,255,1) , #fff , etc.
	/// Also supports setting as gradient color and pattern fill, see option.color for details
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("inherit")]
	public Color? Color { get; set; }

	/// <summary>
	/// line width.
	/// </summary>
	[JsonPropertyName("width")]
	[DefaultValue("auto")]
	public double? Width { get; set; }

	/// <summary>
	/// line type.
	///  
	/// Possible values are:   'solid'  'dashed'  'dotted'   
	/// Since v5.0.0 , it can also be a number or a number array to specify the dash array of the line.
	/// With dashOffset , we can make the line style more flexible.
	///  
	/// For example：  {
	/// 
	/// type: [5, 10],
	/// 
	/// dashOffset: 5
	/// }
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("solid")]
	public LineType? Type { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// To set the line dash offset.
	/// With type , we can make the line style more flexible.
	///  
	/// Refer to MDN lineDashOffset for more details.
	/// </summary>
	[JsonPropertyName("dashOffset")]
	[DefaultValue("0")]
	public double? DashOffset { get; set; }

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
	[JsonPropertyName("cap")]
	[DefaultValue("butt")]
	public LineCap? Cap { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// To determine the shape used to join two line segments where they meet.
	///  
	/// Possible values are:   'bevel' : Fills an additional triangular area between the common endpoint of connected segments, and the separate outside rectangular corners of each segment.
	///  'round' : Rounds off the corners of a shape by filling an additional sector of disc centered at the common endpoint of connected segments.
	/// The radius for these rounded corners is equal to the line width.
	///  'miter' : Connected segments are joined by extending their outside edges to connect at a single point, with the effect of filling an additional lozenge-shaped area.
	/// This setting is affected by the miterLimit property.
	///   
	/// Default value is 'bevel' .
	/// Refer to MDN lineJoin for more details.
	/// </summary>
	[JsonPropertyName("join")]
	[DefaultValue("bevel")]
	public LineJoin? Join { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// To set the miter limit ratio.
	/// Only works when join is set as miter .
	///  
	/// Default value is 10 .
	/// Negative、 0 、 Infinity and NaN values are ignored.
	///  
	/// Refer to MDN miterLimit for more details.
	/// </summary>
	[JsonPropertyName("miterLimit")]
	[DefaultValue("10")]
	public double? MiterLimit { get; set; }

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
	[DefaultValue("inherit")]
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
	[DefaultValue("inherit")]
	public double? Opacity { get; set; }

	/// <summary>
	/// Whether to show the axis.
	/// It can be set to be false to hide the axis line to make a different style.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("true")]
	public bool? Show { get; set; }

	/// <summary>
	/// Edge curvature, which supports value from 0 to 1.
	/// The larger the value, the greater the curvature.
	/// </summary>
	[JsonPropertyName("curveness")]
	[DefaultValue("0")]
	public double? Curveness { get; set; }

}
