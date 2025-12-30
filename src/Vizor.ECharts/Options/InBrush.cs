
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Defines visual effects of items in selection.
/// See https://echarts.apache.org/en/option.html#brush.inBrush
/// </summary>
public partial class InBrush
{
	/// <summary>
	/// Type of symbol.
	/// </summary>
	[JsonPropertyName("symbol")]
	public Icon? Symbol { get; set; }

	/// <summary>
	/// Symbol size.
	/// </summary>
	[JsonPropertyName("symbolSize")]
	public NumberOrNumberArray? SymbolSize { get; set; }

	/// <summary>
	/// Symbol color.
	/// </summary>
	[JsonPropertyName("color")]
	public Color? Color { get; set; }

	/// <summary>
	/// Symbol alpha channel.
	/// </summary>
	[JsonPropertyName("colorAlpha")]
	public double? ColorAlpha { get; set; }

	/// <summary>
	/// Opacity of symbol and others (like labels).
	/// </summary>
	[JsonPropertyName("opacity")]
	public double? Opacity { get; set; }

	/// <summary>
	/// Lightness in HSL.
	/// </summary>
	[JsonPropertyName("colorLightness")]
	public double? ColorLightness { get; set; }

	/// <summary>
	/// Saturation in HSL.
	/// </summary>
	[JsonPropertyName("colorSaturation")]
	public double? ColorSaturation { get; set; }

	/// <summary>
	/// Hue in HSL.
	/// </summary>
	[JsonPropertyName("colorHue")]
	public double? ColorHue { get; set; }
}
