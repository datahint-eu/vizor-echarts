namespace Vizor.ECharts;

/// <summary>
/// Manual extensions for GraphSeriesData to support convenient constructors.
/// </summary>
public partial class GraphSeriesData
{
    /// <summary>
    /// Constructor for creating graph node with name and position.
    /// </summary>
    public GraphSeriesData(string name, double x, double y)
    {
        Name = name;
        X = x;
        Y = y;
    }
}
