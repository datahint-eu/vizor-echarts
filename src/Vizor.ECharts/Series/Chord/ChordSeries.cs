using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class ChordSeries
{
    [JsonPropertyName("label")]
    public Label? Label { get; set; } 

}