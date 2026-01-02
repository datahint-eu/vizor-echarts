namespace Vizor.ECharts;

/// <summary>
/// Hand-tuned override for FunnelSeriesData to provide convenience constructors.
/// Complements the auto-generated partial class in Series/Generated/Funnel/FunnelSeriesData.cs
/// </summary>
public partial class FunnelSeriesData
{
    /// <summary>
    /// Parameterless constructor for property initialization.
    /// </summary>
    public FunnelSeriesData()
    {
    }

    /// <summary>
    /// Convenience constructor to initialize funnel data with name and value.
    /// </summary>
    /// <param name="name">The name of the data item.</param>
    /// <param name="value">The numeric value of the data item.</param>
    public FunnelSeriesData(string name, double value)
    {
        Name = name;
        Value = value;
    }
}
