// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Radar
{
    /// <summary>
    /// Component ID, not specified by default.
    /// If specified, it can be used to refer the component in option or API.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; } 

    /// <summary>
    /// zlevel value of all graphical elements in .
    ///  
    /// zlevel is used to make layers with Canvas.
    /// Graphical elements with different zlevel values will be placed in different Canvases, which is a common optimization technique.
    /// We can put those frequently changed elements (like those with animations) to a separate zlevel .
    /// Notice that too many Canvases will increase memory cost, and should be used carefully on mobile phones to avoid crash.
    ///  
    /// Canvases with bigger zlevel will be placed on Canvases with smaller zlevel .
    /// </summary>
    [JsonPropertyName("zlevel")]
    [DefaultValue(0)]
    public double? Zlevel { get; set; } 

    /// <summary>
    /// z value of all graphical elements in , which controls order of drawing graphical components.
    /// Components with smaller z values may be overwritten by those with larger z values.
    ///  
    /// z has a lower priority to zlevel , and will not create new Canvas.
    /// </summary>
    [JsonPropertyName("z")]
    [DefaultValue(2)]
    public double? Z { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Center position of , the first of which is the horizontal position, and the second is the vertical position.
    ///  
    /// Percentage is supported.
    /// When set in percentage, the item is relative to the container width, and the second item to the height.
    ///  
    /// Example:  // Set to absolute pixel values
    /// center: [400, 300]
    /// // Set to relative percent
    /// center: ['50%', '50%']
    /// ]]>
    /// </summary>
    [JsonPropertyName("center")]
    [DefaultValue("[50%, 50%]")]
    public NumberOrStringArray? Center { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Radius of .
    /// Value can be:   number : Specify outside radius directly.
    ///  string : For example, '20%' , means that the outside radius is 20% of the viewport size (the little one between width and height of the chart container).
    ///    Array.<number|string> : The first item specifies the inside radius, and the second item specifies the outside radius.
    /// Each item follows the definitions above.
    /// ]]>
    /// </summary>
    [JsonPropertyName("radius")]
    [DefaultValue("0%, 75%")]
    public CircleRadius? Radius { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specifies another coordinate system component on which this radar is laid out.
    ///  
    /// Options:   
    /// null / undefined / 'none'  
    /// Not laid out in any coordinate system; instead, laid out independently.
    ///     
    /// 'calendar'  
    /// Lay out based on a calendar coordinate system .
    /// When multiple calendar coordinate systems exist within an ECharts instance, the corresponding system should be specified using calendarIndex or calendarId .
    ///     
    /// 'matrix'  
    /// Lay out based on a matrix coordinate system .
    /// When multiple matrix coordinate systems exist within an ECharts instance, the corresponding system should be specified using matrixIndex or matrixId .
    ///    
    /// Support for series and component layout on coordinate systems:  
    /// The leftmost column lists the series and components that will be laid out (coordinate systems themselves are also components), and the topmost row lists the coordinate systems that can be laid out on.
    ///      no coord sys  grid (cartesian2d)  polar  geo  singleAxis  radar  parallel  calendar  matrix      grid (cartesian2d)  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    polar  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    geo  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    singleAxis  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    calendar  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ❌  ❌    matrix  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ❌  ❌    series-line  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-bar  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-pie  ✅  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-scatter  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-effectScatter  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-radar  ❌  ❌  ❌  ❌  ❌  ✅  ❌  ❌ (✅ if via radar coord sys)  ❌ (✅ if via radar coord sys)    series-tree  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-treemap  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-sunburst  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-boxplot  ❌  ✅  ❌  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-candlestick  ❌  ✅  ❌  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-heatmap  ❌  ✅  ❌  ✅  ❌  ❌  ❌  ✅  ✅    series-map  ✅ (create a geo coord sys exclusively)  ❌  ❌  ✅  ❌  ❌  ❌  ✅  ✅    series-parallel  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ❌ (✅ if via parallel coord sys)  ❌ (✅ if via parallel coord sys)    series-lines  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ❌ (✅ if via another coord sys like geo )  ❌ (✅ if via another coord sys like geo )    series-graph  ✅ (create a "view" coord sys exclusively)  ✅  ✅  ✅  ❌  ❌  ❌  ✅  ✅    series-sankey  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-funnel  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-gauge  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-pictorialBar  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-themeRiver  ❌  ❌  ❌  ❌  ✅  ❌  ❌  ❌ (✅ if via another coord sys like singleAxis )  ❌ (✅ if via another coord sys like singleAxis )    series-chord  ✅  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    title  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    legend  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    dataZoom  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    visualMap  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    toolbox  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    timeline  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    thumbnail  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅     
    /// See also radar.coordinateSystemUsage .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coordinateSystem")]
    [DefaultValue("none")]
    public string? CoordinateSystem { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specify how to lay out this radar based on the specified coordinateSystem .
    ///  
    /// In most cases, there is no need to specify coordinateSystemUsage , unless the default behavior is unexpected.
    ///  
    /// Options:   
    /// 'data' : (Not applicable in radar )  
    /// Each data item of a series (e.g., each series.data[i] ) is laid out separately based on the specified coordinate system.
    /// Currently no non-series component supports coordinateSystemUsage: 'data' .
    ///   
    /// 'box' :  
    /// The entire series or component is laid out as a whole based on the specified coordinate system - that is, the overall bounding rect or basic anchor point is calculated relative to the system.
    ///   For example, a grid component can be laid out in a matrix coordinate system or a calendar coordinate system , where its layout rectangle is calculated by the specified radar.coords in that system.
    /// See example sparkline in matrix .
    ///  For example, a pie series or a chord series can be laid out in a geo coordinate system or a cartesian2d coordinate system , where the center is calculated by the specified series-pie.coords or series-pie.center in that system.
    /// See example pie in geo .
    ///     
    /// See also radar.coordinateSystem .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coordinateSystemUsage")]
    [DefaultValue("box")]
    public string? CoordinateSystemUsage { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// When coordinateSystemUsage is 'box' , coord is used as the input to the coordinate system and calculate the layout rectangle or anchor point.
    ///  
    /// Examples: sparkline in matrix , grpah in matrix .
    ///   
    /// Note: when coordinateSystemUsage is 'data' , the input of coordinate system is series.data[i] rather than this coord .
    ///   
    /// The format this coord is defined by each coordinate system, and it's the same as the second parameter of chart.convertToPixel .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coord")]
    public NumberOrStringArray? Coord { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// The index of the calendar coordinate system to base on.
    /// When mutiple calendar exist within an ECharts instance, use this to specify the corresponding calendar .
    /// </summary>
    [JsonPropertyName("calendarIndex")]
    [DefaultValue(0)]
    public int? CalendarIndex { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// The id of the calendar coordinate system to base on.
    /// When mutiple calendar exist within an ECharts instance, use this to specify the corresponding calendar .
    /// </summary>
    [JsonPropertyName("calendarId")]
    [DefaultValue("undefined")]
    public double? CalendarId { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// The index of the matrix coordinate system to base on.
    /// When mutiple matrix exist within an ECharts instance, use this to specify the corresponding matrix .
    /// </summary>
    [JsonPropertyName("matrixIndex")]
    [DefaultValue(0)]
    public int? MatrixIndex { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// The id of the matrix coordinate system to base on.
    /// When mutiple matrix exist within an ECharts instance, use this to specify the corresponding matrix .
    /// </summary>
    [JsonPropertyName("matrixId")]
    [DefaultValue("undefined")]
    public double? MatrixId { get; set; } 

    /// <summary>
    /// The start angle of coordinate, which is the angle of the first indicator axis.
    /// </summary>
    [JsonPropertyName("startAngle")]
    [DefaultValue(90)]
    public double? StartAngle { get; set; } 

    /// <summary>
    /// Name options for radar indicators.
    /// </summary>
    [JsonPropertyName("axisName")]
    public AxisName? AxisName { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between the indicator's name and axis.
    /// ]]>
    /// </summary>
    [JsonPropertyName("axisNameGap")]
    [DefaultValue("15")]
    public double? AxisNameGap { get; set; } 

    /// <summary>
    /// Segments of indicator axis.
    /// </summary>
    [JsonPropertyName("splitNumber")]
    [DefaultValue("15")]
    public double? SplitNumber { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Radar render type, in which 'polygon' and 'circle' are supported.
    /// ]]>
    /// </summary>
    [JsonPropertyName("shape")]
    [DefaultValue("polygon")]
    public RadarShape? Shape { get; set; } 

    /// <summary>
    /// Whether to prevent calculating the scaling relative to zero.
    /// If it is set to be true , the coordinate tick would not compulsorily contain zero value, which is usually useful in scatter diagram of double numerical values axis.
    /// </summary>
    [JsonPropertyName("scale")]
    [DefaultValue(false)]
    public bool? Scale { get; set; } 

    /// <summary>
    /// Set this to true , to prevent interaction with the axis.
    /// </summary>
    [JsonPropertyName("silent")]
    [DefaultValue(false)]
    public bool? Silent { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Set this to true to enable triggering events.
    ///  
    /// Parameters of the event include:  {
    ///     // Component type: xAxis, yAxis, radiusAxis, angleAxis
    ///     // Each of which has an attribute for index, e.g., xAxisIndex for xAxis
    ///     componentType: string,
    ///     // Value on axis before being formatted.
    ///     // Click on value label to trigger event.
    ///     value: '',
    ///     // Name of axis.
    ///     // Click on label name to trigger event.
    ///     name: ''
    /// }
    /// ]]>
    /// </summary>
    [JsonPropertyName("triggerEvent")]
    [DefaultValue(false)]
    public bool? TriggerEvent { get; set; } 

    /// <summary>
    /// Settings related to axis line.
    /// </summary>
    [JsonPropertyName("axisLine")]
    public AxisLine? AxisLine { get; set; } 

    /// <summary>
    /// Settings related to axis tick.
    /// </summary>
    [JsonPropertyName("axisTick")]
    public AxisTick? AxisTick { get; set; } 

    /// <summary>
    /// Settings related to axis label.
    /// </summary>
    [JsonPropertyName("axisLabel")]
    public AxisLabel? AxisLabel { get; set; } 

    /// <summary>
    /// Split line of axis in grid area.
    /// </summary>
    [JsonPropertyName("splitLine")]
    public SplitLine? SplitLine { get; set; } 

    /// <summary>
    /// Split area of axis in grid area, not shown by default.
    /// </summary>
    [JsonPropertyName("splitArea")]
    public SplitArea? SplitArea { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Indicator of radar chart, which is used to assign multiple variables(dimensions) in radar chart.
    /// Here is the example.
    ///  indicator: [
    ///    { name: 'Sales (sales) ', max: 6500},
    ///    { name: 'Administration (Administration) ', max: 16000, color: 'red'}, // Set the indicator as 'red'
    ///    { name: 'Information Technology (Information Technology) ', max: 30000},
    ///    { name: 'Customer Support (Customer Support) ', max: 38000},
    ///    { name: 'Development (Development) ', max: 52000},
    ///    { name: 'Marketing (Marketing) ', max: 25000}
    /// ]
    /// ]]>
    /// </summary>
    [JsonPropertyName("indicator")]
    public List<RadarIndicator>? Indicator { get; set; } 

}
