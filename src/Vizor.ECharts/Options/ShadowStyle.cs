
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class ShadowStyle
{
	/// <summary>
	/// Fill color.
	///   
	/// Supports setting as solid color using rgb(255,255,255) , rgba(255,255,255,1) , #fff , etc.
	/// Also supports setting as gradient color and pattern fill, see option.color for details
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("rgba(150,150,150,0.3)")]
	public Color? Color { get; set; }

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
