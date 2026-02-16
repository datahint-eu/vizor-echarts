namespace Vizor.ECharts;

/// <summary>
/// Manual extension for LegendData to support implicit conversions.
/// </summary>
public partial class LegendData
{
    /// <summary>
    /// Implicit conversion from string to LegendData for convenient initialization.
    /// </summary>
    public static implicit operator LegendData(string name) => new() { Name = name };
}
