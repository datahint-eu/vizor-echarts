// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class XAxisBreak
{
    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// The start value for the axis break area, specified in data domain defined by series.data , rather than in pixels.
    ///   
    /// If axis.type is 'value' or 'log' , use number type values.
    ///   
    /// If axis.type is 'category' : not supported yet.
    ///   
    /// If axis.type is 'time' , the value can be:   string type represents any time format that can be parsed by method parseDate in echarts/src/util/number.ts , e.g., '2024-04-09 13:00:00' .
    ///  number type represents a timestamp, e.g., 1712667600000 .
    ///  Date type time objects, e.g., new Date('2024-04-09T13:00:00Z') .
    ///     
    /// Note: xAxis.breaks.start and xAxis.breaks.end are the unique identifiers for each break item.
    /// When calling chart.setOption to modify xAxis.breaks.gap or xAxis.breaks.isExpanded , start and end must be specified.
    /// Update animations will only occur if start and end are not modified; no animation will occur if they are changed.
    /// ]]>
    /// </summary>
    [JsonPropertyName("start")]
    public DateOrNumberOrString? Start { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// The end value for the axis break area, specified in data domain defined by series.data , rather than in pixels.
    ///   
    /// If axis.type is 'value' or 'log' , use number type values.
    ///   
    /// If axis.type is 'category' : not supported yet.
    ///   
    /// If axis.type is 'time' , the value can be:   string type represents any time format that can be parsed by method parseDate in echarts/src/util/number.ts , e.g., '2024-04-09 13:00:00' .
    ///  number type represents a timestamp, e.g., 1712667600000 .
    ///  Date type time objects, e.g., new Date('2024-04-09T13:00:00Z') .
    ///     
    /// Note: xAxis.breaks.start and xAxis.breaks.end are the unique identifiers for each break item.
    /// When calling chart.setOption to modify xAxis.breaks.gap or xAxis.breaks.isExpanded , start and end must be specified.
    /// Update animations will only occur if start and end are not modified; no animation will occur if they are changed.
    /// ]]>
    /// </summary>
    [JsonPropertyName("end")]
    public DateOrNumberOrString? End { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// It determines the visual size of the axis break area.
    ///   
    /// Percentage (string):  
    /// Specifies the proportion relative to the axis.
    /// For example, '5%' means that the final size of the axis break area will always be '5%' of the axis length.
    /// Using a percentage ensures that the pixel size of the axis break area remains stable, and does not change when xAxis.min , xAxis.max , or dataZoom are modified.
    /// For this reason, using a percentage is recommended in most scenarios.
    ///   
    /// Absolute value:  
    /// Its unit is the same as start and end , referring to a value in the data domain defined by the business data ( series.data ), rather than pixels.
    /// It represents mapping (replacing) the [start, end] interval with [start, start + gap] .
    /// Therefore, if set as an absolute value, the pixel size of the axis break area will change when xAxis.min , xAxis.max , or dataZoom are modified.
    ///    
    /// Notice: Within a xAxis.breaks array, gap must be specified either entirely in percentages or entirely in absolute values.
    /// Mixing the two is not allowed, as it may lead to unexpected results.
    ///  
    /// Note: xAxis.breaks.start and xAxis.breaks.end are the unique identifiers for each break item.
    /// When calling chart.setOption to modify xAxis.breaks.gap or xAxis.breaks.isExpanded , start and end must be specified.
    /// Update animations will only occur if start and end are not modified; no animation will occur if they are changed.
    /// ]]>
    /// </summary>
    [JsonPropertyName("gap")]
    public NumberOrString? Gap { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// Whether this axis break area is expanded, default is false .
    ///  
    /// Note: xAxis.breaks.start and xAxis.breaks.end are the unique identifiers for each break item.
    /// When calling chart.setOption to modify xAxis.breaks.gap or xAxis.breaks.isExpanded , start and end must be specified.
    /// Update animations will only occur if start and end are not modified; no animation will occur if they are changed.
    /// </summary>
    [JsonPropertyName("isExpanded")]
    [DefaultValue(false)]
    public bool? IsExpanded { get; set; } 

}
