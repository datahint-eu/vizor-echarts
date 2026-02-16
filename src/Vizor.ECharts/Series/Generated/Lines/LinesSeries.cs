// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class LinesSeries : ISeries
{
    /// <summary>
    /// Component ID, not specified by default.
    /// If specified, it can be used to refer the component in option or API.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; } 

    /// <summary>
    /// Series name used for displaying in tooltip and filtering with legend , or updating data and configuration with setOption .
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v5.2.0   
    /// The policy to take color from option.color .
    /// Valid values:   'series' : assigns the colors in the palette by series, so that all data in the same series are in the same color;  'data' : assigns colors in the palette according to data items, with each data item using a different color.
    /// ]]>
    /// </summary>
    [JsonPropertyName("colorBy")]
    [DefaultValue("series")]
    public ColorBy? ColorBy { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Specifies another coordinate system component on which this series-lines is laid out.
    ///  
    /// Options:   
    /// 'cartesian2d'  
    /// Lay out based on a two-dimensional rectangular coordinate system (also known as Cartesian coordinate system) .
    /// When multiple xAxis or multiple yAxis exist within an ECharts instance, the corresponding axes should be specified using xAxisIndex and yAxisIndex or xAxisId and yAxisId .
    ///  
    /// Note: some commonly used series, such as series-line , series-bar , etc., can not be laid out directly based on matrix coordinate system or calendar coordinate system , but they can be laid out on a grid(Cartesian) , and that grid can be laid out on a matrix or calendar .
    ///     
    /// 'geo'  
    /// Lay out based on a geographic coordinate system .
    /// When multiple geographic coordinate systems exist within an ECharts instance, the corresponding system should be specified using geoIndex or geoId .
    ///     
    /// 'singleAxis'  
    /// Lay out based on a singleAxis coordinate system .
    /// When multiple singleAxis coordinate systems exist within an ECharts instance, the corresponding system should be specified using singleAxisIndex or singleAxisId .
    ///    
    /// Support for series and component layout on coordinate systems:  
    /// The leftmost column lists the series and components that will be laid out (coordinate systems themselves are also components), and the topmost row lists the coordinate systems that can be laid out on.
    ///      no coord sys  grid (cartesian2d)  polar  geo  singleAxis  radar  parallel  calendar  matrix      grid (cartesian2d)  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    polar  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    geo  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    singleAxis  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    calendar  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ❌  ❌    matrix  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ❌  ❌    series-line  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-bar  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-pie  ✅  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-scatter  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-effectScatter  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-radar  ❌  ❌  ❌  ❌  ❌  ✅  ❌  ❌ (✅ if via radar coord sys)  ❌ (✅ if via radar coord sys)    series-tree  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-treemap  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-sunburst  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-boxplot  ❌  ✅  ❌  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-candlestick  ❌  ✅  ❌  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-heatmap  ❌  ✅  ❌  ✅  ❌  ❌  ❌  ✅  ✅    series-map  ✅ (create a geo coord sys exclusively)  ❌  ❌  ✅  ❌  ❌  ❌  ✅  ✅    series-parallel  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ❌ (✅ if via parallel coord sys)  ❌ (✅ if via parallel coord sys)    series-lines  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ❌ (✅ if via another coord sys like geo )  ❌ (✅ if via another coord sys like geo )    series-graph  ✅ (create a "view" coord sys exclusively)  ✅  ✅  ✅  ❌  ❌  ❌  ✅  ✅    series-sankey  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-funnel  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-gauge  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-pictorialBar  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-themeRiver  ❌  ❌  ❌  ❌  ✅  ❌  ❌  ❌ (✅ if via another coord sys like singleAxis )  ❌ (✅ if via another coord sys like singleAxis )    series-chord  ✅  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    title  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    legend  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    dataZoom  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    visualMap  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    toolbox  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    timeline  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    thumbnail  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅     
    /// See also series-lines.coordinateSystemUsage .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coordinateSystem")]
    [DefaultValue("geo")]
    public string? CoordinateSystem { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specify how to lay out this series-lines based on the specified coordinateSystem .
    ///  
    /// In most cases, there is no need to specify coordinateSystemUsage , unless the default behavior is unexpected.
    ///  
    /// Options:   
    /// 'data' :  
    /// Each data item of a series (e.g., each series.data[i] ) is laid out separately based on the specified coordinate system.
    /// Currently no non-series component supports coordinateSystemUsage: 'data' .
    ///   
    /// 'box' : (Not applicable in series-lines )  
    /// The entire series or component is laid out as a whole based on the specified coordinate system - that is, the overall bounding rect or basic anchor point is calculated relative to the system.
    ///   For example, a grid component can be laid out in a matrix coordinate system or a calendar coordinate system , where its layout rectangle is calculated by the specified series-lines.coords in that system.
    /// See example sparkline in matrix .
    ///  For example, a pie series or a chord series can be laid out in a geo coordinate system or a cartesian2d coordinate system , where the center is calculated by the specified series-pie.coords or series-pie.center in that system.
    /// See example pie in geo .
    ///     
    /// Only a few series support both coordinateSystemUsage: 'data' and coordinateSystemUsage: 'box' , such as series-graph , series-map .
    /// For examle, in this example (coordinateSystemUsage: 'data') , each node of a graph series is laid out on a matrix coordinate system, while in this example (coordinateSystemUsage: 'box') , the entire graph series is laid out within a matrix cell.
    ///  
    /// Most series only support coordinateSystemUsage: 'data' - such as series-line , series-bar , series-scatter , etc.
    /// Meanwhile, some series only support coordinateSystemUsage: 'box' - such as series-pie ( example: pie in geo ), series-tree , series-treemap , series-sankey , etc.
    ///  
    /// See also series-lines.coordinateSystem .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coordinateSystemUsage")]
    [DefaultValue("data")]
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
    /// The index of the xAxis to base on.
    /// When mutiple xAxis components exist within an ECharts instance, use this to specify the corresponding xAxis .
    /// </summary>
    [JsonPropertyName("xAxisIndex")]
    [DefaultValue(0)]
    public int? XAxisIndex { get; set; } 

    /// <summary>
    /// The id of the xAxis to base on.
    /// When mutiple xAxis components exist within an ECharts instance, use this to specify the corresponding xAxis .
    /// </summary>
    [JsonPropertyName("xAxisId")]
    [DefaultValue("undefined")]
    public double? XAxisId { get; set; } 

    /// <summary>
    /// The index of the yAxis to base on.
    /// When mutiple yAxis components exist within an ECharts instance, use this to specify the corresponding yAxis .
    /// </summary>
    [JsonPropertyName("yAxisIndex")]
    [DefaultValue(0)]
    public int? YAxisIndex { get; set; } 

    /// <summary>
    /// The index of the yAxis to base on.
    /// When mutiple yAxis components exist within an ECharts instance, use this to specify the corresponding yAxis .
    /// </summary>
    [JsonPropertyName("yAxisId")]
    [DefaultValue("undefined")]
    public double? YAxisId { get; set; } 

    /// <summary>
    /// The index of the singleAxis coordinate system to base on.
    /// When mutiple singleAxis exist within an ECharts instance, use this to specify the corresponding singleAxis .
    /// </summary>
    [JsonPropertyName("singleAxisIndex")]
    [DefaultValue(0)]
    public int? SingleAxisIndex { get; set; } 

    /// <summary>
    /// The id of the singleAxis coordinate system to base on.
    /// When mutiple singleAxis exist within an ECharts instance, use this to specify the corresponding singleAxis .
    /// </summary>
    [JsonPropertyName("singleAxisId")]
    [DefaultValue("undefined")]
    public double? SingleAxisId { get; set; } 

    /// <summary>
    /// The index of the geographic coordinate system to base on.
    /// When mutiple geographic exist within an ECharts instance, use this to specify the corresponding geographic .
    ///  
    /// See example : geo-choropleth-scatter
    /// </summary>
    [JsonPropertyName("geoIndex")]
    [DefaultValue(0)]
    public int? GeoIndex { get; set; } 

    /// <summary>
    /// The id of the geographic coordinate system to base on.
    /// When mutiple geographic exist within an ECharts instance, use this to specify the corresponding geographic .
    ///  
    /// See example : geo-choropleth-scatter
    /// </summary>
    [JsonPropertyName("geoId")]
    [DefaultValue("undefined")]
    public double? GeoId { get; set; } 

    /// <summary>
    /// If draw as a polyline.
    ///  
    /// Default to be false .
    /// Can only draw a two end straight line.
    ///  
    /// If it is set true, data.coords can have more than two coord to draw a polyline.
    /// It is useful when visualizing GPS track data.
    /// See example lines-bus .
    /// </summary>
    [JsonPropertyName("polyline")]
    [DefaultValue(false)]
    public bool? Polyline { get; set; } 

    /// <summary>
    /// The setting about the special effects of lines.
    ///  
    /// Tips: All the graphs with trail effect should be put on a individual layer, which means that zlevel need to be different with others.
    /// And the animation ( animation : false)  of this layer is suggested to be turned off at the meanwhile.
    /// Otherwise, other graphic elements in other series and the label of animation would produce unnecessary ghosts.
    /// </summary>
    [JsonPropertyName("effect")]
    public Effect? Effect { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Whether to enable the optimization of large-scale lines graph.
    /// It could be enabled when there is a particularly large number of data(>=5k) .
    ///  
    /// After being enabled, largeThreshold can be used to indicate the minimum number for turning on the optimization.
    ///  
    /// The style of a single data item can't be customized
    /// ]]>
    /// </summary>
    [JsonPropertyName("large")]
    [DefaultValue(true)]
    public bool? Large { get; set; } 

    /// <summary>
    /// The threshold enabling the drawing optimization.
    /// </summary>
    [JsonPropertyName("largeThreshold")]
    [DefaultValue(2000)]
    public double? LargeThreshold { get; set; } 

    /// <summary>
    /// Symbol type at the two ends of the line.
    /// It can be an array for two ends, or assigned separately.
    /// See data.symbol for more format information.
    /// </summary>
    [JsonPropertyName("symbol")]
    [DefaultValue("none")]
    public StringArray? Symbol { get; set; } 

    /// <summary>
    /// Symbol size at the two ends of the line.
    /// It can be an array for two ends, or assigned separately.
    ///  
    /// Attention: You cannot assign width and height separately as normal symbolSize .
    /// </summary>
    [JsonPropertyName("symbolSize")]
    [DefaultValue(10)]
    public NumberOrNumberArray? SymbolSize { get; set; } 

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("lineStyle")]
    public LineStyle? LineStyle { get; set; } 

    /// <summary>
    /// Label settings.
    /// Does not work when polyline is true .
    /// </summary>
    [JsonPropertyName("label")]
    public Label? Label { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v5.0.0   
    /// Unified layout configuration of labels.
    ///  
    /// It provide a chance to adjust the labels' (x, y) position, alignment based on the original layout each series provides.
    ///  
    /// This option can be a callback with following parameters.
    ///  // corresponding index of data
    /// dataIndex: number
    /// // corresponding type of data.
    /// Only available in graph, in which it can be 'node' or 'edge'
    /// dataType?: string
    /// // corresponding index of series
    /// seriesIndex: number
    /// // Displayed text of label.
    /// text: string
    /// // Bounding rectangle of label.
    /// labelRect: {x: number, y: number, width: number, height: number}
    /// // Horizontal alignment of label.
    /// align: 'left' | 'center' | 'right'
    /// // Vertical alignment of label.
    /// verticalAlign: 'top' | 'middle' | 'bottom'
    /// // Bounding rectangle of the element corresponding to.
    /// rect: {x: number, y: number, width: number, height: number}
    /// // Default points array of labelLine.
    /// Currently only provided in pie and funnel series.
    /// // It's null in other series.
    /// labelLinePoints?: number[][]  
    /// Example:  
    /// Align the labels on the right.
    /// Left 10px margin to the edge.
    ///  labelLayout(params) {
    ///     return {
    ///         x: params.rect.x + 10,
    ///         y: params.rect.y + params.rect.height / 2,
    ///         verticalAlign: 'middle',
    ///         align: 'left'
    ///     }
    /// }  
    /// Set the text size based on the size of element bounding rectangle.
    ///  labelLayout(params) {
    ///     return {
    ///         fontSize: Math.max(params.rect.width / 10, 5)
    ///     };
    /// }
    /// ]]>
    /// </summary>
    [JsonPropertyName("labelLayout")]
    public ObjectOrFunction? LabelLayout { get; set; } 

    /// <summary>
    /// Emphasis state.
    /// </summary>
    [JsonPropertyName("emphasis")]
    public Emphasis? Emphasis { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// Configurations of blur state.
    /// Available when emphasis.focus is set.
    /// </summary>
    [JsonPropertyName("blur")]
    public Blur? Blur { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// Configurations of select state.
    /// Available when selectedMode is set.
    /// </summary>
    [JsonPropertyName("select")]
    public Select? Select { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v5.0.0   
    /// Selected mode.
    /// It is disabled by default, and you may set it to be true to enable it.
    ///  
    /// Besides, it can be set to 'single' , 'multiple' or 'series' , for single selection, multiple selections and whole series selection.
    ///   
    /// 'series' is supported since v5.3.0
    /// ]]>
    /// </summary>
    [JsonPropertyName("selectedMode")]
    [DefaultValue(false)]
    public SelectionMode? SelectedMode { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// progressive specifies the amount of graphic elements that can be rendered within a frame (about 16ms) if "progressive rendering" enabled.
    ///  
    /// When data amount is from thousand to more than 10 million, it will take too long time to render all of the graphic elements.
    /// Since ECharts 4, "progressive rendering" is supported in its workflow, which processes and renders data chunk by chunk alone with each frame, avoiding to block the UI thread of the browser.
    ///  
    /// Set progressive: 0 to disable progressive permanently.
    /// By default, progressive is auto-enabled when data amount is bigger than progressiveThreshold .
    /// ]]>
    /// </summary>
    [JsonPropertyName("progressive")]
    [DefaultValue(400)]
    public double? Progressive { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// If current data amount is over the threshold, "progressive rendering" is enabled.
    /// ]]>
    /// </summary>
    [JsonPropertyName("progressiveThreshold")]
    [DefaultValue(3000)]
    public double? ProgressiveThreshold { get; set; } 

    /// <summary>
    /// A group ID assigned to all data items in the series.
    ///  
    /// This option has a lower priority than groupId , which means when groupId is specified for a certain data item the dataGroupId will be simply ignored for that data item.
    /// For more information, please see series.data.groupId .
    /// </summary>
    [JsonPropertyName("dataGroupId")]
    public string? DataGroupId { get; set; } 

    /// <summary>
    /// The data set of lines.
    /// </summary>
    [JsonPropertyName("data")]
    public object? Data { get; set; } 

    /// <summary>
    /// Mark point in a chart.
    /// </summary>
    [JsonPropertyName("markPoint")]
    public MarkPoint? MarkPoint { get; set; } 

    /// <summary>
    /// Use a line in the chart to illustrate.
    /// </summary>
    [JsonPropertyName("markLine")]
    public MarkLine? MarkLine { get; set; } 

    /// <summary>
    /// Used to mark an area in chart.
    /// For example, mark a time interval.
    /// </summary>
    [JsonPropertyName("markArea")]
    public MarkArea? MarkArea { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v4.4.0   
    /// If clip the overflow on the coordinate system.
    /// Clip results varies between series:   Scatter/EffectScatter：Ignore the symbols exceeds the coordinate system.
    /// Not clip the elements.
    ///  Bar：Clip all the overflowed.
    /// With bar width kept.
    ///  Line：Clip the overflowed line.
    ///  Lines: Clip all the overflowed.
    ///  Candlestick: Ignore the elements exceeds the coordinate system.
    ///  PictorialBar: Clip all the overflowed.
    /// (Supported since v5.5.0)  Custom: Clip all the olverflowed.
    ///   
    /// All these series have default value true except pictorialBar and custom series.
    /// Set it to false if you don't want to clip.
    /// ]]>
    /// </summary>
    [JsonPropertyName("clip")]
    [DefaultValue("true")]
    public bool? Clip { get; set; } 

    /// <summary>
    /// zlevel value of all graphical elements in lines graph.
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
    /// z value of all graphical elements in lines graph, which controls order of drawing graphical components.
    /// Components with smaller z values may be overwritten by those with larger z values.
    ///  
    /// z has a lower priority to zlevel , and will not create new Canvas.
    /// </summary>
    [JsonPropertyName("z")]
    [DefaultValue(2)]
    public double? Z { get; set; } 

    /// <summary>
    /// Whether to ignore mouse events.
    /// Default value is false, for triggering and responding to mouse events.
    /// </summary>
    [JsonPropertyName("silent")]
    [DefaultValue(false)]
    public bool? Silent { get; set; } 

    /// <summary>
    /// Whether to enable animation.
    /// </summary>
    [JsonPropertyName("animation")]
    [DefaultValue("true")]
    public bool? Animation { get; set; } 

    /// <summary>
    /// Whether to set graphic number threshold to animation.
    /// Animation will be disabled when graphic number is larger than threshold.
    /// </summary>
    [JsonPropertyName("animationThreshold")]
    [DefaultValue(2000)]
    public double? AnimationThreshold { get; set; } 

    /// <summary>
    /// Duration of the first animation, which supports callback function for different data to have different animation effect:  animationDuration: function (idx) {
    ///     // delay for later data is larger
    ///     return idx * 100;
    /// }
    /// </summary>
    [JsonPropertyName("animationDuration")]
    [DefaultValue("1000")]
    public NumberOrFunction? AnimationDuration { get; set; } 

    /// <summary>
    /// Easing method used for the first animation.
    /// Varied easing effects can be found at easing effect example .
    /// </summary>
    [JsonPropertyName("animationEasing")]
    [DefaultValue("cubicOut")]
    public AnimationEasing? AnimationEasing { get; set; } 

    /// <summary>
    /// Delay before updating the first animation, which supports callback function for different data to have different animation effect.
    ///  
    /// For example:  animationDelay: function (idx) {
    ///     // delay for later data is larger
    ///     return idx * 100;
    /// }  
    /// See this example for more information.
    /// </summary>
    [JsonPropertyName("animationDelay")]
    [DefaultValue(0)]
    public NumberOrFunction? AnimationDelay { get; set; } 

    /// <summary>
    /// Time for animation to complete, which supports callback function for different data to have different animation effect:  animationDurationUpdate: function (idx) {
    ///     // delay for later data is larger
    ///     return idx * 100;
    /// }
    /// </summary>
    [JsonPropertyName("animationDurationUpdate")]
    [DefaultValue("1000")]
    public NumberOrFunction? AnimationDurationUpdate { get; set; } 

    /// <summary>
    /// Easing method used for animation.
    /// </summary>
    [JsonPropertyName("animationEasingUpdate")]
    [DefaultValue("cubicOut")]
    public AnimationEasing? AnimationEasingUpdate { get; set; } 

    /// <summary>
    /// Delay before updating animation, which supports callback function for different data to have different animation effects.
    ///  
    /// For example:  animationDelayUpdate: function (idx) {
    ///     // delay for later data is larger
    ///     return idx * 100;
    /// }  
    /// See this example for more information.
    /// </summary>
    [JsonPropertyName("animationDelayUpdate")]
    [DefaultValue(0)]
    public NumberOrFunction? AnimationDelayUpdate { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v5.2.0   
    /// Configuration related to universal transition animation.
    ///  
    /// Universal Transition provides the ability to morph between any series.
    /// With this feature enabled, each time setOption , transitions between series with the same id will be automatically associated with each other.
    ///  
    /// One-to-many or many-to-one animations such as drill-down, aggregation, etc.
    /// can also be achieved by specifying data items' groupId and childGroupId .
    ///  
    /// This can be enabled directly by configuring universalTransition: true in the series.
    /// It is also possible to provide an object for more detailed configuration.
    /// ]]>
    /// </summary>
    [JsonPropertyName("universalTransition")]
    public UniversalTransition? UniversalTransition { get; set; } 

    /// <summary>
    /// tooltip settings in this series.
    /// </summary>
    [JsonPropertyName("tooltip")]
    public Tooltip? Tooltip { get; set; } 

}
