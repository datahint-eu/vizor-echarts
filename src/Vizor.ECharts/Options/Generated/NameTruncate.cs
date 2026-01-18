// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class NameTruncate
{
    /// <summary>
    /// The maximum length for the truncated text.
    /// Any text exceeding this length will be truncated.
    /// </summary>
    [JsonPropertyName("maxWidth")]
    public double? MaxWidth { get; set; } 

    /// <summary>
    /// The content displayed at the end of the text after truncation.
    /// </summary>
    [JsonPropertyName("ellipsis")]
    [DefaultValue("...")]
    public string? Ellipsis { get; set; } 

}
