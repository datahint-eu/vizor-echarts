
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class ItemStyle
{
	/// <summary>
	/// color.
	///   
	/// Supports setting as solid color using rgb(255,255,255) , rgba(255,255,255,1) , #fff , etc.
	/// Also supports setting as gradient color and pattern fill, see option.color for details
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("inherit")]
	public Color? Color { get; set; } 

	/// <summary>
	/// border color, whose format is similar to that of color .
	/// </summary>
	[JsonPropertyName("borderColor")]
	[DefaultValue("inherit")]
	public Color? BorderColor { get; set; } 

	/// <summary>
	/// border width.
	/// No border when it is set to be 0.
	///  
	/// When its value is "auto" , if there is borderWidth in series, then it is set to be 2, otherwise, it is set to be 0.
	/// If its value is "inherit" , then the borderWidth of the series are always used
	/// </summary>
	[JsonPropertyName("borderWidth")]
	[DefaultValue("auto")]
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
	[DefaultValue("0")]
	public double? ShadowBlur { get; set; } 

	/// <summary>
	/// Shadow color.
	/// Support same format as color .
	/// </summary>
	[JsonPropertyName("shadowColor")]
	[DefaultValue("null")]
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
	/// The style of the decal pattern.
	/// It works only if aria.enabled and aria.decal.show are both set to be true .
	///  
	/// If it is set to be 'none' , no decal will be used.
	/// </summary>
	[JsonPropertyName("decal")]
	[DefaultValue("inherit")]
	public Decal? Decal { get; set; } 

	/// <summary>
	/// Area filling color.
	///   
	/// Supports setting as solid color using rgb(255,255,255) , rgba(255,255,255,1) , #fff , etc.
	/// Also supports setting as gradient color and pattern fill, see option.color for details
	/// </summary>
	[JsonPropertyName("areaColor")]
	[DefaultValue("#eee")]
	public Color? AreaColor { get; set; } 

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
	/// Gaps between child nodes.
	/// </summary>
	[JsonPropertyName("gapWidth")]
	[DefaultValue(0)]
	public double? GapWidth { get; set; } 

	/// <summary>
	/// The color saturation of a border or gap.
	/// The value range is between 0 ~ 1.
	///  
	/// Tips:  
	/// When borderColorSaturation is set, the borderColor is disabled, and, instead, the final border color is calculated based on the color of this node (this color could be sepcified explicitly or inherited from its parent node) and mixing with borderColorSaturation .
	///  
	/// In this way, a effect can be implemented: different sections have different hue of gap color repectively, which makes users easy to distinguish both sections and levels.
	///  
	/// How to avoid confusion by setting border/gap of node  
	/// If all of the border/gaps are set with the same color, confusion might occur when rectangulars in different levels display at the same time.
	///  
	/// See the example .
	/// Notice that the child rectangles in the red area are in the deeper level than rectangles that are saparated by white gap.
	/// So in the red area, basically we set gap color with red, and use borderColorSaturation to lift the saturation.
	/// </summary>
	[JsonPropertyName("borderColorSaturation")]
	[DefaultValue("0.5")]
	public double? BorderColorSaturation { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("textStyle")]
	public TextStyle? TextStyle { get; set; } 

	/// <summary>
	/// Fill color of bearish candle stick.
	///   
	/// Supports setting as solid color using rgb(255,255,255) , rgba(255,255,255,1) , #fff , etc.
	/// Also supports setting as gradient color and pattern fill, see option.color for details
	/// </summary>
	[JsonPropertyName("color0")]
	[DefaultValue("#314656")]
	public Color? Color0 { get; set; } 

	/// <summary>
	/// Border color of bearish candle stick.
	///   
	/// Supports setting as solid color using rgb(255,255,255) , rgba(255,255,255,1) , #fff , etc.
	/// Also supports setting as gradient color and pattern fill, see option.color for details
	/// </summary>
	[JsonPropertyName("borderColor0")]
	[DefaultValue("#314656")]
	public Color? BorderColor0 { get; set; } 

	/// <summary>
	/// Since v5.4.1   
	/// Border color of doji (when the open price is the same as the close price).
	///   
	/// Supports setting as solid color using rgb(255,255,255) , rgba(255,255,255,1) , #fff , etc.
	/// Also supports setting as gradient color and pattern fill, see option.color for details
	/// </summary>
	[JsonPropertyName("borderColorDoji")]
	public Color? BorderColorDoji { get; set; } 

	/// <summary>
	/// Height of this data item.
	/// By default, the height is evenly divided for all data items.
	/// The height can be set to percentage (e.g.: '10%') or pixel value (e.g.: 20).
	/// Please make sure that the total height of all data items is 100%.
	/// </summary>
	[JsonPropertyName("height")]
	public NumberOrString? Height { get; set; } 

}
