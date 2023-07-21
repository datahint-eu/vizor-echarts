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

	[JsonPropertyName("symbol")]
	public Icon? Symbol { get; set; } //TODO: is Icon the correct type ?

	[JsonPropertyName("color")]
	public Color? Color { get; set; }

	//TODO: colorAlpha: Symbol alpha channel.
	//TODO: opacity: Opacity of symbol and others(like labels).
	//TODO: colorLightness: Lightness in HSL.
	//TODO: colorSaturation: Saturation in HSL.
	//TODO: colorHue: Hue in HSL.
}
