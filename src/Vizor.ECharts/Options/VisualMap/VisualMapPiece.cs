using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://echarts.apache.org/en/option.html#visualMap-piecewise.pieces
/// </summary>
public class VisualMapPiece
{
	/// <summary>
	/// Set to -Infinity if ignored
	/// </summary>
	[JsonPropertyName("min")]
	public double? Min { get; set; }

	/// <summary>
	/// Set to Infinity if ignored
	/// </summary>
	[JsonPropertyName("max")]
	public double? Max { get; set; }

	[JsonPropertyName("value")]
	public double? Value { get; set; }

	[JsonPropertyName("label")]
	public string? Label { get; set; }

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
	public ColorArray? Color { get; set; }

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
