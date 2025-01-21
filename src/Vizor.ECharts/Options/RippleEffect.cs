
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class RippleEffect
{
	/// <summary>
	/// Since v4.4.0   
	/// Color of the ripple rings.
	/// The default value is the color of scatter.
	/// </summary>
	[JsonPropertyName("color")]
	public Color? Color { get; set; }

	/// <summary>
	/// Since v5.2.0   
	/// The number of ripples.
	/// </summary>
	[JsonPropertyName("number")]
	[DefaultValue("3")]
	public double? Number { get; set; }

	/// <summary>
	/// The period duration of animation, in seconds.
	/// </summary>
	[JsonPropertyName("period")]
	[DefaultValue("4")]
	public double? Period { get; set; }

	/// <summary>
	/// The maximum zooming scale of ripples in animation.
	/// </summary>
	[JsonPropertyName("scale")]
	[DefaultValue("2.5")]
	public double? Scale { get; set; }

	/// <summary>
	/// The brush type for ripples.
	/// options: 'stroke' and 'fill' .
	/// </summary>
	[JsonPropertyName("brushType")]
	[DefaultValue("fill")]
	public BrushType? BrushType { get; set; }

}
