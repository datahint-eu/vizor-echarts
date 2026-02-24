// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class ChordSeriesData
{
    /// <summary>
    /// Name of the data item.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; } 

    /// <summary>
    /// Value of the data item.
    /// </summary>
    [JsonPropertyName("value")]
    public NumberOrNumberArray? Value { get; set; } 

    /// <summary>
    /// Style of this node.
    /// </summary>
    [JsonPropertyName("itemStyle")]
    public ItemStyle? ItemStyle { get; set; } 

    /// <summary>
    /// Label style for this node.
    /// </summary>
    [JsonPropertyName("label")]
    public Label? Label { get; set; } 

    /// <summary>
    /// Style when the node is emphasized.
    /// </summary>
    [JsonPropertyName("emphasis")]
    public Emphasis? Emphasis { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// The blur (faded) state of the node.
    /// </summary>
    [JsonPropertyName("blur")]
    public Blur? Blur { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// The selected state of the node.
    /// </summary>
    [JsonPropertyName("select")]
    public Select? Select { get; set; } 

    /// <summary>
    /// tooltip settings in this series data.
    /// </summary>
    [JsonPropertyName("tooltip")]
    public Tooltip? Tooltip { get; set; } 

}
