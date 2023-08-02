using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://echarts.apache.org/en/option.html#visualMap-continuous.inRange
/// </summary>
public class VisualMapRange
{
	/// <summary>
	/// For example: [30, 100]
	/// </summary>
	[JsonPropertyName("symbolSize")]
	public double[]? SymbolSize { get; set; }

	/// <summary>
	/// Icon types provided by ECharts includes
	/// 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none'
	/// 
	/// Can also be an image URL ('image://url')
	/// </summary>
	[JsonPropertyName("symbol")]
	public Icon? Symbol { get; set; }

	/// <summary>
	/// Symbol color
	/// </summary>
	[JsonPropertyName("color")]
	public Color[]? Color { get; set; }

	/// <summary>
	/// Range [0, 1]
	/// </summary>
	[JsonPropertyName("colorAlpha")]
	public double? ColorAlpha { get; set; }

	/// <summary>
	/// Range [0, 1]
	/// </summary>
	[JsonPropertyName("opacity")]
	public double? Opacity { get; set; }

	/// <summary>
	/// Lightness in HSL. Range [0, 1]
	/// </summary>
	[JsonPropertyName("colorLightness")]
	public double? ColorLightness { get; set; }

	/// <summary>
	/// Saturation in HSL. Range [0, 1]
	/// </summary>
	[JsonPropertyName("colorSaturation")]
	public double? ColorSaturation { get; set; }

	/// <summary>
	/// Hue in HSL. Range [0, 360]
	/// </summary>
	[JsonPropertyName("colorHue")]
	public double? ColorHue { get; set; }
}
