// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Grid
{
    /// <summary>
    /// Component ID, not specified by default.
    /// If specified, it can be used to refer the component in option or API.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; } 

    /// <summary>
    /// Whether to show the grid in rectangular coordinate.
    /// </summary>
    [JsonPropertyName("show")]
    [DefaultValue("false")]
    public bool? Show { get; set; } 

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
    /// Distance between undefined component and the left side of the container.
    ///  
    /// left can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
    ///  
    /// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
    /// ]]>
    /// </summary>
    [JsonPropertyName("left")]
    [DefaultValue("10%")]
    public NumberOrString? Left { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between undefined component and the top side of the container.
    ///  
    /// top can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
    ///  
    /// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
    /// ]]>
    /// </summary>
    [JsonPropertyName("top")]
    [DefaultValue(60)]
    public NumberOrString? Top { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between undefined component and the right side of the container.
    ///  
    /// right can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("right")]
    [DefaultValue("10%")]
    public NumberOrString? Right { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between undefined component and the bottom side of the container.
    ///  
    /// bottom can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("bottom")]
    [DefaultValue(60)]
    public NumberOrString? Bottom { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Width of grid component.
    /// Adaptive by default.
    ///  
    /// width can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("width")]
    [DefaultValue("auto")]
    public NumberOrString? Width { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Height of grid component.
    /// Adaptive by default.
    ///  
    /// height can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("height")]
    [DefaultValue("auto")]
    public NumberOrString? Height { get; set; } 

    /// <summary>
    /// Deprecated since v6.0.0 .
    /// See grid.outerBoundsMode .
    ///  
    /// Whether the grid region contains axis tick label .
    ///   When containLabel is false :  grid.left  grid.right  grid.top  grid.bottom  grid.width  grid.height decide the location and size of the rectangle that is made of by xAxis and yAxis.
    ///  Setting to false will help when multiple grids need to be aligned at their axes.
    ///    When containLabel is true :  grid.left  grid.right  grid.top  grid.bottom  grid.width  grid.height decide the location and size of the rectangle that contains the axes, and the labels of the axes.
    ///  Setting to true will help when the length of axis labels is dynamic and is hard to approximate.
    /// This will avoid labels from overflowing the container or overlapping other components.
    /// </summary>
    [JsonPropertyName("containLabel")]
    [DefaultValue("false")]
    public bool? ContainLabel { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// The "outer bounds" is a constraint rectangle used to prevent axis labels and axis names from overflowing.
    /// outerBoundsMode defines the strategy for determining the "outer bounds".
    ///  
    /// In most cases, we do not need to specify grid.outerBoundsMode , grid.outerBounds , grid.outerBoundsContain and grid.containLabel , as the default settings can prevent axis labels and axis names from overflowing the canvas.
    ///  
    /// The grid component (Cartesian) layout strategy:   First, lay out axis lines based on the rect defined by grid.left / right / top / bottom / width / height .
    /// This can meet the requirement of aligning axis lines across multiple grids.
    ///  Then, if axis labels and/or axis names overflow the "outer bounds", shrink the rectangle to prevent that overflow.
    /// grid.outerBoundsContain determines whether axis label and axis name is confined by the "outer bounds".
    ///   
    /// Options of outerBoundsMode :   'auto' / null / undefined (default):  Behave the same as outerBoundsMode: 'same' when grid.containLabel: true .
    ///  Otherwise, the "outer bounds" is determined by grid.outerBounds if specified.
    ///  Otherwise, automatically determine the "outer bounds" - typically defaulting to the current canvas, or a assigned layout rectangle if this grid is laid out in another coordinate system (see grid.coordinateSystem ).
    ///    'none' : Force the "outer bounds" to be infinity (i.e., no constraint), regardless of the specified grid.outerBounds .
    ///  'same' : Force the "outer bounds" to be the same as the layout rectangle defined by grid.left / right / top / bottom / width / height , regardless of the specified grid.outerBounds .
    ///    
    /// The "outer bounds" encompasses the functionality of grid.containLabel ; therefore, grid.containLabel is deprecated.
    /// grid.containLabel: true is equivalent to grid: {outerBoundsMode: 'same', outerBoundsContain: 'axisLabel'} .
    /// The effect might be slightly different, but usually indiscernible.
    /// You can use the code below to enforce the previous effect, though it's unnecessary in most cases.
    ///  import {use} from 'echarts/core';
    /// import {LegacyGridContainLabel} from 'echarts/features';
    /// use([LegacyGridContainLabel]);   
    /// Demo : outerBounds example .
    /// ]]>
    /// </summary>
    [JsonPropertyName("outerBoundsMode")]
    [DefaultValue("auto")]
    public string? OuterBoundsMode { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// See details in grid.outerBoundsMode .
    ///  
    /// See also outerBounds example .
    /// </summary>
    [JsonPropertyName("outerBounds")]
    public OuterBounds? OuterBounds { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Options:   'auto' / null / undefined (default):  Behave the same as outerBoundsContain: 'axisLabel' if containLabel: true .
    ///  Otherwise, behave the same as outerBoundsContain: 'all' .
    ///    'all' : The "outer bounds" constrain the grid (Cartesian) rectangle (determined by the x-axis and y-axis lines) and axis labels and axis names.
    ///  'axisLabel' : The "outer bounds" constrain the grid (Cartesian) rectangle (determined by the x-axis and y-axis lines) and axis labels, but exclude axis names.
    ///   
    /// For more details, see grid.outerBoundsMode .
    ///  
    /// See also outerBounds example .
    /// ]]>
    /// </summary>
    [JsonPropertyName("outerBoundsContain")]
    [DefaultValue("auto")]
    public bool? OuterBoundsContain { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Background color of grid, which is transparent by default.
    ///   
    /// Color can be represented in RGB, for example 'rgb(128, 128, 128)' .
    /// RGBA can be used when you need alpha channel, for example 'rgba(128, 128, 128, 0.5)' .
    /// You may also use hexadecimal format, for example '#ccc' .
    ///   
    /// Attention : Works only if show: true is set.
    /// ]]>
    /// </summary>
    [JsonPropertyName("backgroundColor")]
    [DefaultValue("transparent")]
    public Color? BackgroundColor { get; set; } 

    /// <summary>
    /// Border color of grid.
    /// Support the same color format as backgroundColor.
    ///  
    /// Attention : Works only if show: true is set.
    /// </summary>
    [JsonPropertyName("borderColor")]
    [DefaultValue("#ccc")]
    public Color? BorderColor { get; set; } 

    /// <summary>
    /// Border width of grid.
    ///  
    /// Attention : Works only if show: true is set.
    /// </summary>
    [JsonPropertyName("borderWidth")]
    [DefaultValue("1")]
    public double? BorderWidth { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Size of shadow blur.
    /// This attribute should be used along with shadowColor , shadowOffsetX , shadowOffsetY to set shadow to component.
    ///  
    /// For example:  {
    ///     shadowColor: 'rgba(0, 0, 0, 0.5)',
    ///     shadowBlur: 10
    /// }  
    /// Attention : This property works only if show: true is configured and backgroundColor is defined other than transparent .
    /// ]]>
    /// </summary>
    [JsonPropertyName("shadowBlur")]
    [DefaultValue("")]
    public double? ShadowBlur { get; set; } 

    /// <summary>
    /// Shadow color.
    /// Support same format as color .
    ///  
    /// Attention : This property works only if show: true configured.
    /// </summary>
    [JsonPropertyName("shadowColor")]
    [DefaultValue("")]
    public Color? ShadowColor { get; set; } 

    /// <summary>
    /// Offset distance on the horizontal direction of shadow.
    ///  
    /// Attention : This property works only if show: true configured.
    /// </summary>
    [JsonPropertyName("shadowOffsetX")]
    [DefaultValue("0")]
    public double? ShadowOffsetX { get; set; } 

    /// <summary>
    /// Offset distance on the vertical direction of shadow.
    ///  
    /// Attention : This property works only if show: true configured.
    /// </summary>
    [JsonPropertyName("shadowOffsetY")]
    [DefaultValue("0")]
    public double? ShadowOffsetY { get; set; } 

    /// <summary>
    /// tooltip settings in the coordinate system component.
    ///  
    /// General Introduction:  
    /// tooltip can be configured on different places:   
    /// Configured on global: tooltip   
    /// Configured in a coordinate system: grid.tooltip , polar.tooltip , single.tooltip   
    /// Configured in a series: series.tooltip   
    /// Configured in each item of series.data : series.data.tooltip
    /// </summary>
    [JsonPropertyName("tooltip")]
    public Tooltip? Tooltip { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specifies another coordinate system component on which this grid is laid out.
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
    /// See example sparkline in matrix .
    ///    
    /// Support for series and component layout on coordinate systems:  
    /// The leftmost column lists the series and components that will be laid out (coordinate systems themselves are also components), and the topmost row lists the coordinate systems that can be laid out on.
    ///      no coord sys  grid (cartesian2d)  polar  geo  singleAxis  radar  parallel  calendar  matrix      grid (cartesian2d)  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    polar  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    geo  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    singleAxis  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    calendar  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ❌  ❌    matrix  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ❌  ❌    series-line  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-bar  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-pie  ✅  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-scatter  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-effectScatter  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-radar  ❌  ❌  ❌  ❌  ❌  ✅  ❌  ❌ (✅ if via radar coord sys)  ❌ (✅ if via radar coord sys)    series-tree  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-treemap  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-sunburst  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-boxplot  ❌  ✅  ❌  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-candlestick  ❌  ✅  ❌  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-heatmap  ❌  ✅  ❌  ✅  ❌  ❌  ❌  ✅  ✅    series-map  ✅ (create a geo coord sys exclusively)  ❌  ❌  ✅  ❌  ❌  ❌  ✅  ✅    series-parallel  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ❌ (✅ if via parallel coord sys)  ❌ (✅ if via parallel coord sys)    series-lines  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ❌ (✅ if via another coord sys like geo )  ❌ (✅ if via another coord sys like geo )    series-graph  ✅ (create a "view" coord sys exclusively)  ✅  ✅  ✅  ❌  ❌  ❌  ✅  ✅    series-sankey  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-funnel  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-gauge  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-pictorialBar  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-themeRiver  ❌  ❌  ❌  ❌  ✅  ❌  ❌  ❌ (✅ if via another coord sys like singleAxis )  ❌ (✅ if via another coord sys like singleAxis )    series-chord  ✅  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    title  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    legend  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    dataZoom  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    visualMap  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    toolbox  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    timeline  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    thumbnail  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅     
    /// See also grid.coordinateSystemUsage .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coordinateSystem")]
    [DefaultValue("none")]
    public string? CoordinateSystem { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specify how to lay out this grid based on the specified coordinateSystem .
    ///  
    /// In most cases, there is no need to specify coordinateSystemUsage , unless the default behavior is unexpected.
    ///  
    /// Options:   
    /// 'data' : (Not applicable in grid )  
    /// Each data item of a series (e.g., each series.data[i] ) is laid out separately based on the specified coordinate system.
    /// Currently no non-series component supports coordinateSystemUsage: 'data' .
    ///   
    /// 'box' :  
    /// The entire series or component is laid out as a whole based on the specified coordinate system - that is, the overall bounding rect or basic anchor point is calculated relative to the system.
    ///   For example, a grid component can be laid out in a matrix coordinate system or a calendar coordinate system , where its layout rectangle is calculated by the specified grid.coords in that system.
    /// See example sparkline in matrix .
    ///  For example, a pie series or a chord series can be laid out in a geo coordinate system or a cartesian2d coordinate system , where the center is calculated by the specified series-pie.coords or series-pie.center in that system.
    /// See example pie in geo .
    ///     
    /// See also grid.coordinateSystem .
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

}
