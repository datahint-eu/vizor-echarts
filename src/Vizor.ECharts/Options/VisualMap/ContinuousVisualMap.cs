using System.Collections.Generic;

namespace Vizor.ECharts;

/// <summary>
/// Hand-tuned partial class adding implicit conversion operators for VisualMap.
/// Allows assigning a single ContinuousVisualMap to List&lt;object&gt; properties.
/// </summary>
public partial class ContinuousVisualMap
{
    /// <summary>
    /// Implicit conversion: ContinuousVisualMap → List&lt;object&gt;
    /// Allows: VisualMap = new ContinuousVisualMap() { ... }
    /// Instead of requiring: VisualMap = new List&lt;object&gt; { new ContinuousVisualMap() { ... } }
    /// </summary>
    public static implicit operator List<object>(ContinuousVisualMap visualMap)
    {
        return visualMap == null ? null : new List<object> { visualMap };
    }
}
