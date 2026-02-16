namespace Vizor.ECharts;

/// <summary>
/// Manual extensions for PictorialBarSeriesData to support convenient constructors.
/// </summary>
public partial class PictorialBarSeriesData
{
    /// <summary>
    /// Constructor for creating data with symbol/name and value.
    /// </summary>
    public PictorialBarSeriesData(string symbol, double value)
    {
        Symbol = symbol;
        Value = value;
    }
}
