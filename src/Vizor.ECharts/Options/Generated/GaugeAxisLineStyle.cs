// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 5.6.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class GaugeAxisLineStyle
{
    /// <summary>
    /// <![CDATA[
    /// The axis line of gauge chart can be divided to several segments in different colors.
    /// The end position and color of each segment can be expressed by an array.
    ///  
    /// Default value:  [[1, '#E6EBF8']]  
    /// Note: The value of color[i][0] means the percentage of the axis line of the gauge chart's segments, which should be between 0 and 1, and color[i][1] is the corresponding color.
    ///  color: [
    ///     [0.1, 'red'], // 0~10% is red
    ///     [0.2, 'green'], // 10~20% is green
    ///     [0.3, 'blue'], // 20~30% is blue
    ///     // ...
    /// ]
    /// ]]>
    /// </summary>
    [JsonPropertyName("color")]
    public GaugeAxisLineColor? Color { get; set; } 

    /// <summary>
    /// The width of axis line.
    /// </summary>
    [JsonPropertyName("width")]
    [DefaultValue(10)]
    public double? Width { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Size of shadow blur.
    /// This attribute should be used along with shadowColor , shadowOffsetX , shadowOffsetY to set shadow to component.
    ///  
    /// For example:  {
    ///     shadowColor: 'rgba(0, 0, 0, 0.5)',
    ///     shadowBlur: 10
    /// }
    /// ]]>
    /// </summary>
    [JsonPropertyName("shadowBlur")]
    [DefaultValue("")]
    public double? ShadowBlur { get; set; } 

    /// <summary>
    /// Shadow color.
    /// Support same format as color .
    /// </summary>
    [JsonPropertyName("shadowColor")]
    [DefaultValue("")]
    public Color? ShadowColor { get; set; } 

    /// <summary>
    /// Offset distance on the horizontal direction of shadow.
    /// </summary>
    [JsonPropertyName("shadowOffsetX")]
    [DefaultValue("0")]
    public double? ShadowOffsetX { get; set; } 

    /// <summary>
    /// Offset distance on the vertical direction of shadow.
    /// </summary>
    [JsonPropertyName("shadowOffsetY")]
    [DefaultValue("0")]
    public double? ShadowOffsetY { get; set; } 

    /// <summary>
    /// Opacity of the component.
    /// Supports value from 0 to 1, and the component will not be drawn when set to 0.
    /// </summary>
    [JsonPropertyName("opacity")]
    [DefaultValue("1")]
    public double? Opacity { get; set; } 

}
