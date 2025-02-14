using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class OutOfBrush
{
	[JsonPropertyName("symbol")]
	public Icon? Symbol { get; set; }

	[JsonPropertyName("symbolSize")]
	public NumberOrNumberArray? SymbolSize { get; set; }

	/// <summary>
	/// Default '#ddd'
	/// </summary>
	[JsonPropertyName("color")]
	public Color? Color { get; set; }

	[JsonPropertyName("colorAlpha")]
    public double? ColorAlpha { get; set; }

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
