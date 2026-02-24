// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class AxisTick
{
    /// <summary>
    /// <![CDATA[
    /// Set this to false to prevent the axis tick from showing.
    ///   
    /// The value axis doesn't show the axis ticks by default since v5.0.0 , you need to explicitly set axisTick.show as true to enable it.
    /// ]]>
    /// </summary>
    [JsonPropertyName("show")]
    [DefaultValue("true")]
    public bool? Show { get; set; } 

    /// <summary>
    /// Align axis tick with label, which is available only when boundaryGap is set to be true in category axis.
    /// See the following picture:
    /// </summary>
    [JsonPropertyName("alignWithLabel")]
    [DefaultValue("false")]
    public bool? AlignWithLabel { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Interval of axisTick, which is available in category axis.
    ///  is set to be the same as axisLabel.interval by default.
    ///  
    /// It uses a strategy that labels do not overlap by default.
    ///  
    /// You may set it to be 0 to display all labels compulsively.
    ///  
    /// If it is set to be 1, it means that labels are shown once after one label.
    /// And if it is set to be 2, it means labels are shown once after two labels, and so on.
    ///  
    /// On the other hand, you can control by callback function, whose format is shown below:  (index:number, value: string) => boolean  
    /// The first parameter is index of category, and the second parameter is the name of category.
    /// The return values decides whether to display label.
    /// ]]>
    /// </summary>
    [JsonPropertyName("interval")]
    [DefaultValue("auto")]
    public NumberOrFunction? Interval { get; set; } 

    /// <summary>
    /// Set this to true so the axis labels face the inside direction.
    /// </summary>
    [JsonPropertyName("inside")]
    [DefaultValue(false)]
    public bool? Inside { get; set; } 

    /// <summary>
    /// The length of the axis tick.
    /// </summary>
    [JsonPropertyName("length")]
    [DefaultValue("5")]
    public double? Length { get; set; } 

    /// <summary>
    /// Line style of axis ticks.
    /// </summary>
    [JsonPropertyName("lineStyle")]
    public LineStyle? LineStyle { get; set; } 

    /// <summary>
    /// Since v5.5.1   
    /// To customize tick positions.
    /// For example,  axisTick: {
    ///     alignWithLabel: true,
    ///     customValues: [0, 0.5, 1, 1.5, 2, 8, 9]
    /// }
    /// </summary>
    [JsonPropertyName("customValues")]
    //TODO: Type Warning: array type 'customValues' in 'axisTick' will be mapped to List<object>
    public List<object>? CustomValues { get; set; } 

    /// <summary>
    /// The split scale number between split line.
    /// </summary>
    [JsonPropertyName("splitNumber")]
    [DefaultValue("5")]
    public double? SplitNumber { get; set; } 

    /// <summary>
    /// Since v5.0   
    /// The distance between the tick line and axis line.
    /// </summary>
    [JsonPropertyName("distance")]
    [DefaultValue("10")]
    public double? Distance { get; set; } 

}
