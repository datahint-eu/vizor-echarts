using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Category data for axis (used by XAxis, YAxis, AngleAxis, RadiusAxis, ParallelAxis, SingleAxis).
/// Each data item represents a category name and optional text styling.
/// </summary>
public partial class AxisData
{
    /// <summary>
    /// Name of a category.
    /// </summary>
    [JsonPropertyName("value")]
    public string? Value { get; set; }

    /// <summary>
    /// Text style of the category.
    /// </summary>
    [JsonPropertyName("textStyle")]
    public TextStyle? TextStyle { get; set; }

    /// <summary>
    /// Implicit conversion from string to AxisData for convenient initialization.
    /// </summary>
    public static implicit operator AxisData(string value) => new() { Value = value };
}
