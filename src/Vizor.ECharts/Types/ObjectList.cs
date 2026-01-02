using System.Collections.Generic;

namespace Vizor.ECharts;

/// <summary>
/// Implicit conversion wrapper for List&lt;object&gt; assignments.
/// Provides convenient implicit conversions for common array-to-List&lt;object&gt; scenarios.
/// </summary>
public class ObjectList : List<object>
{
    /// <summary>
    /// Implicit conversion: string[] → ObjectList
    /// </summary>
    public static implicit operator ObjectList(string[] source)
    {
        var list = new ObjectList();
        if (source != null)
        {
            foreach (var item in source)
            {
                list.Add(item);
            }
        }
        return list;
    }

    /// <summary>
    /// Implicit conversion: int[] → ObjectList
    /// </summary>
    public static implicit operator ObjectList(int[] source)
    {
        var list = new ObjectList();
        if (source != null)
        {
            foreach (var item in source)
            {
                list.Add(item);
            }
        }
        return list;
    }

    /// <summary>
    /// Implicit conversion: double[] → ObjectList
    /// </summary>
    public static implicit operator ObjectList(double[] source)
    {
        var list = new ObjectList();
        if (source != null)
        {
            foreach (var item in source)
            {
                list.Add(item);
            }
        }
        return list;
    }

    /// <summary>
    /// Gets the list as List&lt;object&gt; for property assignments.
    /// </summary>
    public List<object> ToList()
    {
        return new List<object>(this);
    }
}
