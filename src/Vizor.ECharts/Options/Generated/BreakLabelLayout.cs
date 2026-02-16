// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class BreakLabelLayout
{
    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// When axis break labels overlap, whether to move labels to avoid overlap.
    ///  
    /// 'auto' or true means moving labels to avoid overlap when overlapping occurs; false means not moving.
    /// ]]>
    /// </summary>
    [JsonPropertyName("moveOverlap")]
    [DefaultValue("auto")]
    public BoolOrString? MoveOverlap { get; set; } 

}
