// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class ChordSeriesLink
{
    /// <summary>
    /// The source node name ( data.name ) as a string, or the index of the source node as a number.
    /// </summary>
    [JsonPropertyName("source")]
    public NumberOrString? Source { get; set; } 

    /// <summary>
    /// The target node name ( data.name ) as a string, or the index of the target node as a number.
    /// </summary>
    [JsonPropertyName("target")]
    public NumberOrString? Target { get; set; } 

    /// <summary>
    /// Value of the edge.
    /// </summary>
    [JsonPropertyName("value")]
    public double? Value { get; set; } 

}
