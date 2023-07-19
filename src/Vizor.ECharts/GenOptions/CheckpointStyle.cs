// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class CheckpointStyle
{
	/// <summary>
	/// Symbol of timeline.checkpointStyle .
	///  
	/// Icon types provided by ECharts includes  
	/// 'circle' , 'rect' , 'roundRect' , 'triangle' , 'diamond' , 'pin' , 'arrow' , 'none'  
	/// It can be set to an image with 'image://url' , in which URL is the link to an image, or dataURI of an image.
	///  
	/// An image URL example:  'image://http://example.website/a/b.png' 
	/// A dataURI example:  'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7' 
	/// Icons can be set to arbitrary vector path via 'path://' in ECharts.
	/// As compared with a raster image, vector paths prevent jagging and blurring when scaled, and have better control over changing colors.
	/// The size of the vector icon will be adapted automatically.
	/// Refer to SVG PathData for more information about the format of the path.
	/// You may export vector paths from tools like Adobe  
	/// For example:  'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
	/// </summary>
	[JsonPropertyName("symbol")]
	[DefaultValue("circle")]
	public Icon? Symbol { get; set; } 

	/// <summary>
	/// timeline.checkpointStyle  symbol size.
	/// It can be set to single numbers like 10 , or use an array to represent width and height.
	/// For example, [20, 10] means symbol width is 20 , and height is 10 .
	/// </summary>
	[JsonPropertyName("symbolSize")]
	[DefaultValue(13)]
	public NumberOrNumberArray? SymbolSize { get; set; } 

	/// <summary>
	/// Rotate degree of timeline.checkpointStyle  symbol.
	/// The negative value represents clockwise.
	/// Note that when symbol is set to be 'arrow' in markLine , symbolRotate value will be ignored, and compulsively use tangent angle.
	/// </summary>
	[JsonPropertyName("symbolRotate")]
	public double? SymbolRotate { get; set; } 

	/// <summary>
	/// Whether to keep aspect for symbols in the form of path:// .
	/// </summary>
	[JsonPropertyName("symbolKeepAspect")]
	[DefaultValue(false)]
	public bool? SymbolKeepAspect { get; set; } 

	/// <summary>
	/// Offset of timeline.checkpointStyle  symbol relative to original position.
	/// By default, symbol will be put in the center position of data.
	/// But if symbol is from user-defined vector path or image, you may not expect symbol to be in center.
	/// In this case, you may use this attribute to set offset to default position.
	/// It can be in absolute pixel value, or in relative percentage value.
	///  
	/// For example, [0, '-50%'] means to move upside side position of symbol height.
	/// It can be used to make the arrow in the bottom to be at data position when symbol is pin.
	/// </summary>
	[JsonPropertyName("symbolOffset")]
	[DefaultValue("[0, 0]")]
	public double[]? SymbolOffset { get; set; } 

	/// <summary>
	/// color.
	///   
	/// Supports setting as solid color using rgb(255,255,255) , rgba(255,255,255,1) , #fff , etc.
	/// Also supports setting as gradient color and pattern fill, see option.color for details
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("#316bf3")]
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
	[DefaultValue("&#39;rgba(0, 0, 0, 0.3)&#39;")]
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

	/// <summary>
	/// In timeline component, whether there is animation in checkpoint moving during the process of timeline playing and switching.
	/// </summary>
	[JsonPropertyName("animation")]
	[DefaultValue("true")]
	public bool? Animation { get; set; } 

	/// <summary>
	/// The animation duration of checkpoint in timeline component.
	/// </summary>
	[JsonPropertyName("animationDuration")]
	[DefaultValue("300")]
	public double? AnimationDuration { get; set; } 

	/// <summary>
	/// The easing effect of animation of checkpoint in timeline component.
	/// Refers to easing sample for different easing effects.
	/// </summary>
	[JsonPropertyName("animationEasing")]
	[DefaultValue("quinticInOut")]
	public AnimationEasing? AnimationEasing { get; set; } 

}
