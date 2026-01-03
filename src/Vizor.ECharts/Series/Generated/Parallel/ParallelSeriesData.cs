// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 5.6.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class ParallelSeriesData
{
    /// <summary>
    /// The name of a data item.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; } 

    /// <summary>
    /// The value of a data item.
    /// </summary>
    [JsonPropertyName("value")]
    //TODO: Type Warning: array type 'value' in 'ParallelSeriesData' will be mapped to List<object>
    public List<object>? Value { get; set; } 

    /// <summary>
    /// Line style.
    /// </summary>
    [JsonPropertyName("lineStyle")]
    public LineStyle? LineStyle { get; set; } 

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("emphasis")]
    public Emphasis? Emphasis { get; set; } 

}
