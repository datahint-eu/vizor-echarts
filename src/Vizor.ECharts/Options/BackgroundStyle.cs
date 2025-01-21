
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class BackgroundStyle
{
	/// <summary>
	/// Bar color.
	///   
	/// Supports setting as solid color using rgb(255,255,255) , rgba(255,255,255,1) , #fff , etc.
	/// Also supports setting as gradient color and pattern fill, see option.color for details
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("rgba(180, 180, 180, 0.2)")]
	public Color? Color { get; set; }

	/// <summary>
	/// The border color of bar.
	/// </summary>
	[JsonPropertyName("borderColor")]
	[DefaultValue("#000")]
	public Color? BorderColor { get; set; }

	/// <summary>
	/// The border width of bar.
	/// defaults to have no border.
	/// </summary>
	[JsonPropertyName("borderWidth")]
	[DefaultValue(0)]
	public double? BorderWidth { get; set; }

	/// <summary>
	/// Border type.
	/// Can be 'dashed' , 'dotted' .
	/// </summary>
	[JsonPropertyName("borderType")]
	[DefaultValue("solid")]
	public LineType? BorderType { get; set; }

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
