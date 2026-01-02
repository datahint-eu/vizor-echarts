using System.Collections.Generic;

namespace Vizor.ECharts;

/// <summary>
/// Hand-tuned partial class adding implicit conversion operators for VisualMap.
/// Allows assigning a single PiecewiseVisualMap to List&lt;object&gt; properties.
/// </summary>
public partial class PiecewiseVisualMap
{
    /// <summary>
    /// Implicit conversion: PiecewiseVisualMap → List&lt;object&gt;
    /// Allows: VisualMap = new PiecewiseVisualMap() { ... }
    /// Instead of requiring: VisualMap = new List&lt;object&gt; { new PiecewiseVisualMap() { ... } }
    /// </summary>
    public static implicit operator List<object>(PiecewiseVisualMap visualMap)
    {
        return visualMap == null ? null : new List<object> { visualMap };
    }
}
