// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 5.6.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class GaugeAxisLine
{
    /// <summary>
    /// Whether to show the axis line of gauge chart.
    /// </summary>
    [JsonPropertyName("show")]
    [DefaultValue("true")]
    public bool? Show { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// Whether to add round caps at the end.
    /// </summary>
    [JsonPropertyName("roundCap")]
    [DefaultValue(false)]
    public bool? RoundCap { get; set; } 

    /// <summary>
    /// The style of the axis line of gauge chart.
    /// </summary>
    [JsonPropertyName("lineStyle")]
    public GaugeAxisLineStyle? LineStyle { get; set; } 

}
