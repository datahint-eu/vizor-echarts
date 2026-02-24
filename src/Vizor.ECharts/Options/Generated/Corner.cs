// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Corner
{
    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Only specify some special cell definitions for Corner cells.
    ///  data: [
    ///     {
    ///         coord: [[3, 5], [1, 2]], // Required to locate the cell.
    ///                                  // See the rule below.
    ///         value: 'some_text',      // Optional.
    /// The text to display.
    ///         mergeCells: true,        // Optional.
    /// `false` by default.
    ///     },
    ///     {
    ///         // ...
    ///     },
    ///     // ...
    /// ]  
    /// Cell locating and reference: see the description in matrix.body.data
    /// ]]>
    /// </summary>
    [JsonPropertyName("data")]
    public List<CornerData>? Data { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// Text label of Corner cells, to explain some data information about graphic item like value, name and so on.
    /// label is placed under itemStyle in ECharts 2.x.
    /// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
    /// </summary>
    [JsonPropertyName("label")]
    public Label? Label { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// Graphic style of Corner cells, emphasis is the style when it is highlighted, like being hovered by mouse, or highlighted via legend connect.
    /// </summary>
    [JsonPropertyName("itemStyle")]
    public ItemStyle? ItemStyle { get; set; } 

    /// <summary>
    /// Whether to ignore mouse events.
    /// Default value is false, for triggering and responding to mouse events.
    /// </summary>
    [JsonPropertyName("silent")]
    [DefaultValue(false)]
    public bool? Silent { get; set; } 

    /// <summary>
    /// Mouse cursor when hovering on the cell.
    /// </summary>
    [JsonPropertyName("cursor")]
    public string? Cursor { get; set; } 

    /// <summary>
    /// Specify the z-index (z-order) of the cell.
    /// Used when style conflict - especially for thick border style.
    /// </summary>
    [JsonPropertyName("z2")]
    public double? Z2 { get; set; } 

}
