using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Visual encoding properties for values outside the brush selection.
/// Supports visual channels: symbol, symbolSize, color, colorAlpha, opacity, 
/// colorLightness, colorSaturation, colorHue.
/// </summary>
public partial class OutOfBrush
{
    /// <summary>
    /// Symbol type. Can be 'circle', 'rect', 'roundRect', 'triangle', 'diamond', 'pin', 'arrow', 'none',
    /// or 'image://url' for images, or 'path://' for SVG paths.
    /// </summary>
    [JsonPropertyName("symbol")]
    public StringArray? Symbol { get; set; }

    /// <summary>
    /// Symbol size. Can be a number, an array of numbers for [width, height], or an array for mapping range.
    /// </summary>
    [JsonPropertyName("symbolSize")]
    public NumberOrNumberArray? SymbolSize { get; set; }

    /// <summary>
    /// Color mapping. Can be a single color, an array of colors for gradient, or an object for category mapping.
    /// </summary>
    [JsonPropertyName("color")]
    public ColorArray? Color { get; set; }

    /// <summary>
    /// Color alpha channel opacity (0-1).
    /// </summary>
    [JsonPropertyName("colorAlpha")]
    public NumberOrNumberArray? ColorAlpha { get; set; }

    /// <summary>
    /// Overall opacity of symbol and labels (0-1).
    /// </summary>
    [JsonPropertyName("opacity")]
    public NumberOrNumberArray? Opacity { get; set; }

    /// <summary>
    /// Color lightness in HSL (0-1).
    /// </summary>
    [JsonPropertyName("colorLightness")]
    public NumberOrNumberArray? ColorLightness { get; set; }

    /// <summary>
    /// Color saturation in HSL (0-1).
    /// </summary>
    [JsonPropertyName("colorSaturation")]
    public NumberOrNumberArray? ColorSaturation { get; set; }

    /// <summary>
    /// Color hue in HSL (0-360).
    /// </summary>
    [JsonPropertyName("colorHue")]
    public NumberOrNumberArray? ColorHue { get; set; }
}
