// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class PieSeries : ISeries
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
    [DefaultValue("data")]
    public ColorBy? ColorBy { get; set; } 

    /// <summary>
    /// Whether to enable highlighting chart when legend is being hovered.
    /// </summary>
    [JsonPropertyName("legendHoverLink")]
    [DefaultValue("true")]
    public bool? LegendHoverLink { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v5.4.0   
    /// Specifies another coordinate system component on which this series-pie is laid out.
    ///  
    /// Options:   
    /// null / undefined / 'none'  
    /// Not laid out in any coordinate system; instead, laid out independently.
    ///     
    /// 'geo'  
    /// Lay out based on a geographic coordinate system .
    /// When multiple geographic coordinate systems exist within an ECharts instance, the corresponding system should be specified using geoIndex or geoId .
    ///  
    /// See example pie in geo .
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
    /// See also series-pie.coordinateSystemUsage .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coordinateSystem")]
    [DefaultValue("none")]
    public string? CoordinateSystem { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specify how to lay out this series-pie based on the specified coordinateSystem .
    ///  
    /// In most cases, there is no need to specify coordinateSystemUsage , unless the default behavior is unexpected.
    ///  
    /// Options:   
    /// 'data' :  
    /// Each data item of a series (e.g., each series.data[i] ) is laid out separately based on the specified coordinate system.
    /// Currently no non-series component supports coordinateSystemUsage: 'data' .
    ///   
    /// 'box' : (Not applicable in series-pie )  
    /// The entire series or component is laid out as a whole based on the specified coordinate system - that is, the overall bounding rect or basic anchor point is calculated relative to the system.
    ///   For example, a grid component can be laid out in a matrix coordinate system or a calendar coordinate system , where its layout rectangle is calculated by the specified series-pie.coords in that system.
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
    /// See also series-pie.coordinateSystem .
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
    /// series-pie.center and series-pie.coord can be used interchangably in this case.
    ///  
    /// example: pie in geo   
    /// Note: when coordinateSystemUsage is 'data' , the input of coordinate system is series.data[i] rather than this coord .
    ///   
    /// The format this coord is defined by each coordinate system, and it's the same as the second parameter of chart.convertToPixel .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coord")]
    public NumberOrStringArray? Coord { get; set; } 

    /// <summary>
    /// Since v5.4.0   
    /// The index of the geographic coordinate system to base on.
    /// When mutiple geographic exist within an ECharts instance, use this to specify the corresponding geographic .
    ///  
    /// See example : geo-choropleth-scatter
    /// </summary>
    [JsonPropertyName("geoIndex")]
    [DefaultValue(0)]
    public int? GeoIndex { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// The id of the geographic coordinate system to base on.
    /// When mutiple geographic exist within an ECharts instance, use this to specify the corresponding geographic .
    ///  
    /// See example : geo-choropleth-scatter
    /// </summary>
    [JsonPropertyName("geoId")]
    [DefaultValue("undefined")]
    public double? GeoId { get; set; } 

    /// <summary>
    /// Since v5.4.0   
    /// The index of the calendar coordinate system to base on.
    /// When mutiple calendar exist within an ECharts instance, use this to specify the corresponding calendar .
    /// </summary>
    [JsonPropertyName("calendarIndex")]
    [DefaultValue(0)]
    public int? CalendarIndex { get; set; } 

    /// <summary>
    /// Since v5.4.0   
    /// The id of the calendar coordinate system to base on.
    /// When mutiple calendar exist within an ECharts instance, use this to specify the corresponding calendar .
    /// </summary>
    [JsonPropertyName("calendarId")]
    [DefaultValue("undefined")]
    public double? CalendarId { get; set; } 

    /// <summary>
    /// Since v5.4.0   
    /// The index of the matrix coordinate system to base on.
    /// When mutiple matrix exist within an ECharts instance, use this to specify the corresponding matrix .
    /// </summary>
    [JsonPropertyName("matrixIndex")]
    [DefaultValue(0)]
    public int? MatrixIndex { get; set; } 

    /// <summary>
    /// Since v5.4.0   
    /// The id of the matrix coordinate system to base on.
    /// When mutiple matrix exist within an ECharts instance, use this to specify the corresponding matrix .
    /// </summary>
    [JsonPropertyName("matrixId")]
    [DefaultValue("undefined")]
    public double? MatrixId { get; set; } 

    /// <summary>
    /// <![CDATA[
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
    /// The offset distance of selected sector.
    /// </summary>
    [JsonPropertyName("selectedOffset")]
    [DefaultValue("10")]
    public double? SelectedOffset { get; set; } 

    /// <summary>
    /// Whether the layout of sectors of pie chart is clockwise.
    /// </summary>
    [JsonPropertyName("clockwise")]
    [DefaultValue("true")]
    public bool? Clockwise { get; set; } 

    /// <summary>
    /// The start angle, which range is [0, 360].
    /// </summary>
    [JsonPropertyName("startAngle")]
    [DefaultValue("90")]
    public double? StartAngle { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v5.5.0   
    /// The end angle, the default value is 'auto' .
    ///  
    /// When the value is 'auto' , the end angle is calculated automatically based on startAngle to ensure it is a complete circle.
    /// ]]>
    /// </summary>
    [JsonPropertyName("endAngle")]
    [DefaultValue("270")]
    public NumberOrString? EndAngle { get; set; } 

    /// <summary>
    /// The minimum angle of sector (0 ~ 360).
    /// It prevents some sector from being too small when value is small, which will affect user interaction.
    /// </summary>
    [JsonPropertyName("minAngle")]
    [DefaultValue("0")]
    public double? MinAngle { get; set; } 

    /// <summary>
    /// Since v5.5.0   
    /// The interval angle between the sectors (0 ~ 360).
    /// </summary>
    [JsonPropertyName("padAngle")]
    [DefaultValue("0")]
    public double? PadAngle { get; set; } 

    /// <summary>
    /// If a sector is less than this angle (0 ~ 360), label and labelLine will not be displayed.
    /// </summary>
    [JsonPropertyName("minShowLabelAngle")]
    [DefaultValue("0")]
    public double? MinShowLabelAngle { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Whether to show as Nightingale chart, which distinguishs data through radius.
    /// There are 2 optional modes:   'radius' Use central angle to show the percentage of data, radius to show data size.
    ///  'area' All the sectors will share the same central angle, the data size is shown only through radiuses.
    /// ]]>
    /// </summary>
    [JsonPropertyName("roseType")]
    [DefaultValue(false)]
    public PieRoseType? RoseType { get; set; } 

    /// <summary>
    /// Whether to enable the strategy to avoid labels overlap.
    /// Defaults to be enabled, which will move the label positions in the case of labels overlapping
    /// </summary>
    [JsonPropertyName("avoidLabelOverlap")]
    [DefaultValue("true")]
    public bool? AvoidLabelOverlap { get; set; } 

    /// <summary>
    /// Whether to show sector when all data are zero.
    /// </summary>
    [JsonPropertyName("stillShowZeroSum")]
    [DefaultValue("true")]
    public bool? StillShowZeroSum { get; set; } 

    /// <summary>
    /// The precision of the percentage value.
    /// The default value is 2 .
    /// </summary>
    [JsonPropertyName("percentPrecision")]
    [DefaultValue("2")]
    public double? PercentPrecision { get; set; } 

    /// <summary>
    /// The mouse style when mouse hovers on an element, the same as cursor property in CSS .
    /// </summary>
    [JsonPropertyName("cursor")]
    [DefaultValue("pointer")]
    public string? Cursor { get; set; } 

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
    /// Distance between pie series and the left side of the container.
    ///  
    /// left can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
    ///  
    /// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
    /// ]]>
    /// </summary>
    [JsonPropertyName("left")]
    [DefaultValue(0)]
    public NumberOrString? Left { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between pie series and the top side of the container.
    ///  
    /// top can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
    ///  
    /// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
    /// ]]>
    /// </summary>
    [JsonPropertyName("top")]
    [DefaultValue(0)]
    public NumberOrString? Top { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between pie series and the right side of the container.
    ///  
    /// right can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    ///  
    /// Adaptive by default.
    /// ]]>
    /// </summary>
    [JsonPropertyName("right")]
    [DefaultValue(0)]
    public NumberOrString? Right { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between pie series and the bottom side of the container.
    ///  
    /// bottom can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    ///  
    /// Adaptive by default.
    /// ]]>
    /// </summary>
    [JsonPropertyName("bottom")]
    [DefaultValue(0)]
    public NumberOrString? Bottom { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Width of pie series.
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
    /// Height of pie series.
    /// Adaptive by default.
    ///  
    /// height can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("height")]
    [DefaultValue("auto")]
    public NumberOrString? Height { get; set; } 

    /// <summary>
    /// Since v5.2.0   
    /// If display an placeholder circle when there is no data.
    /// </summary>
    [JsonPropertyName("showEmptyCircle")]
    [DefaultValue("true")]
    public bool? ShowEmptyCircle { get; set; } 

    /// <summary>
    /// Since v5.2.0   
    /// Style of circle placeholder.
    /// </summary>
    [JsonPropertyName("emptyCircleStyle")]
    [DefaultValue("true")]
    //TODO: Type Warning: Failed to map property 'emptyCircleStyle' in type 'PieSeries' with types 'boolean,object'
    public object? EmptyCircleStyle { get; set; } 

    /// <summary>
    /// Text label of pie chart, to explain some data information about graphic item like value, name and so on.
    /// label is placed under itemStyle in ECharts 2.x.
    /// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
    /// </summary>
    [JsonPropertyName("label")]
    public Label? Label { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// The style of visual guide line.
    /// Will show when label position is set as 'outside' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("labelLine")]
    public LabelLine? LabelLine { get; set; } 

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
    /// Graphic style of , emphasis is the style when it is highlighted, like being hovered by mouse, or highlighted via legend connect.
    /// </summary>
    [JsonPropertyName("itemStyle")]
    public ItemStyle? ItemStyle { get; set; } 

    /// <summary>
    /// Configurations of emphasis state.
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
    /// Center position of Pie chart, the first of which is the horizontal position, and the second is the vertical position.
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
    public CircleCenter? Center { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Radius of Pie chart.
    /// Value can be:   number : Specify outside radius directly.
    ///  string : For example, '20%' , means that the outside radius is 20% of the viewport size (the little one between width and height of the chart container).
    ///    Array.<number|string> : The first item specifies the inside radius, and the second item specifies the outside radius.
    /// Each item follows the definitions above.
    ///   
    /// Donut chart can be achieved by setting a inner radius.
    /// ]]>
    /// </summary>
    [JsonPropertyName("radius")]
    [DefaultValue("0%, 75%")]
    public CircleRadius? Radius { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// When dataset is used, seriesLayoutBy specifies whether the column or the row of dataset is mapped to the series, namely, the series is "layout" on columns or rows.
    /// Optional values:   'column': by default, the columns of dataset are mapped the series.
    /// In this case, each column represents a dimension.
    ///  'row'：the rows of dataset are mapped to the series.
    /// In this case, each row represents a dimension.
    ///   
    /// Check this example .
    /// ]]>
    /// </summary>
    [JsonPropertyName("seriesLayoutBy")]
    [DefaultValue("column")]
    public SeriesLayoutBy? SeriesLayoutBy { get; set; } 

    /// <summary>
    /// If series.data is not specified, and dataset exists, the series will use dataset .
    /// datasetIndex specifies which dataset will be used.
    /// </summary>
    [JsonPropertyName("datasetIndex")]
    [DefaultValue(0)]
    public int? DatasetIndex { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// dimensions can be used to define dimension info for series.data or dataset.source .
    ///  
    /// Notice: if dataset is used, we can definite dimensions in dataset.dimensions , or provide dimension names in the first column/row of dataset.source , and not need to specify dimensions here.
    /// But if dimensions is specified here, it will be used despite the dimension definitions in dataset.
    ///  
    /// For example:  option = {
    ///     dataset: {
    ///         source: [
    ///             // 'date', 'open', 'close', 'highest', 'lowest'
    ///             [12, 44, 55, 66, 2],
    ///             [23, 6, 16, 23, 1],
    ///             ...
    ///         ]
    ///     },
    ///     series: {
    ///         type: 'xxx',
    ///         // Specify name for each dimensions, which will be displayed in tooltip.
    ///         dimensions: ['date', 'open', 'close', 'highest', 'lowest']
    ///     }
    /// }  series: {
    ///     type: 'xxx',
    ///     dimensions: [
    ///         null,                // If you do not intent to defined this dimension, use null is fine.
    ///         {type: 'ordinal'},   // Specify type of this dimension.
    ///                              // 'ordinal' is always used in string.
    ///                              // If type is not specified, echarts will guess type by data.
    ///         {name: 'good', type: 'number'},
    ///         'bad'                // Equals to {name: 'bad'}.
    ///     ]
    /// }  
    /// Each data item of dimensions can be:   string , for example, 'someName' , which equals to {name: 'someName'} .
    ///  Object , where the attributes can be:  name: string .
    ///  type: string , supports:  number  float , that is, Float64Array  int , that is, Int32Array  ordinal , discrete value, which represents string generally.
    ///  time , time value, see data to check the format of time value.
    ///    displayName: string , generally used in tooltip for dimension display.
    /// If not specified, use name by default.
    ///     
    /// When dimensions is specified, the default tooltip will be displayed vertically, which is better to show dimension names.
    /// Otherwise, tooltip will displayed only value horizontally.
    /// ]]>
    /// </summary>
    [JsonPropertyName("dimensions")]
    public string[]? Dimensions { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Define what is encoded to for each dimension of data .
    /// For example:  option = {
    ///     dataset: {
    ///         source: [
    ///             // Each column is called a dimension.
    ///             // There are five dimensions: 0, 1, 2, 3, 4.
    ///             [12, 44, 55, 66, 2],
    ///             [23, 6, 16, 23, 1],
    ///             ...
    ///         ]
    ///     },
    ///     series: {
    ///         type: 'xxx',
    ///         encode: {
    ///             x: [3, 1, 5],      // Dimension 3, 1, 5 is mapped to x axis.
    ///             y: 2,              // Dimension 2 is mapped to y axis.
    ///             tooltip: [3, 2, 4] // Dimension 3, 2, 4 will be displayed in tooltip.
    ///         }
    ///     }
    /// }  
    /// When dimensions is used to defined name for a certain dimension, encode can refer the name directly.
    /// For example:  series: {
    ///     type: 'xxx',
    ///     dimensions: ['date', 'open', 'close', 'highest', 'lowest'],
    ///     encode: {
    ///         x: 'date',
    ///         y: ['open', 'close', 'highest', 'lowest']
    ///     }
    /// }  
    /// The basic structure of encode is illustrated as follows, where the left part of colon is the name of axis like 'x' , 'y' , 'radius' , 'angle' or some special reserved names like "tooltip", "itemName" etc., and the right part of the colon is the dimension names or dimension indices (based on 0).
    /// One or more dimensions can be specified.
    /// Usually not all of mappings need to be specified, only specify needed ones.
    ///  
    /// The properties available in encode listed as follows:  // In any of the series and coordinate systems,
    /// // these properties are available:
    /// encode: {
    ///     // Display dimension "product" and "score" in the tooltip.
    ///     tooltip: ['product', 'score']
    ///     // Set the series name as the concat of the names of dimensions[1] and dimensions[3].
    ///     // (sometimes the dimension names are too long to type in series.name manually).
    ///     seriesName: [1, 3],
    ///     // Using dimensions[2] as the id of each data item.
    /// This is useful when dynamically
    ///     // update data by `chart.setOption()`, where the new and old data item can be
    ///     // corresponded by id, by which the appropriate animation can be performed when updating.
    ///     itemId: 2,
    ///     // Using dimensions[3] as the name of each data item.
    /// This is useful in charts like
    ///     // 'pie', 'funnel', where data item name can be displayed in legend.
    ///     itemName: 3,
    ///     // Using dimensions[4] as the group ID for each data item.
    /// With universalTransition enabled,
    ///     // the data items from the old option and those from the new one, if sharing a same group ID,
    ///     // will then be matched and applied to a proper animation after `setOption` is called.
    ///     itemGroupId: 4,
    ///     // Using dimension[5] as the child group ID for each data item.
    /// This option is introduced to
    ///     // make multiple levels drilldown and aggregation animation come true.
    /// See childGroupId for more.
    ///     // Since v5.5.0
    ///     itemChildGroupId: 5
    /// }
    /// 
    /// // These properties only work in cartesian(grid) coordinate system:
    /// encode: {
    ///     // Map dimensions[1], dimensions[5] and dimension "score" to the X axis.
    ///     x: [1, 5, 'score'],
    ///     // Map dimensions[0] to the Y axis.
    ///     y: 0
    /// }
    /// 
    /// // These properties only work in polar coordinate system:
    /// encode: {
    ///     radius: 3,
    ///     angle: 2,
    ///     ...
    /// }
    /// 
    /// // These properties only work in geo coordinate system:
    /// encode: {
    ///     lng: 3,
    ///     lat: 2
    /// }
    /// 
    /// // For some type of series that are not in any coordinate system,
    /// // like 'pie', 'funnel' etc.:
    /// encode: {
    ///     value: 3
    /// }  
    /// This is an example for encode .
    ///  
    /// Specially, in [custom series(~series-custom), some property in encode , corresponding to axis, can be set as null to make the series not controlled by the axis, that is, the series data will not be count in the extent of the axis, and the dataZoom on the axis will not filter the series.
    ///  var option = {
    ///     xAxis: {},
    ///     yAxis: {},
    ///     dataZoom: [{
    ///         xAxisIndex: 0
    ///     }, {
    ///         yAxisIndex: 0
    ///     }],
    ///     series: {
    ///         type: 'custom',
    ///         renderItem: function (params, api) {
    ///             return {
    ///                 type: 'circle',
    ///                 shape: {
    ///                     cx: 100, // x position is always 100
    ///                     cy: api.coord([0, api.value(0)])[1],
    ///                     r: 30
    ///                 },
    ///                 style: {
    ///                     fill: 'blue'
    ///                 }
    ///             };
    ///         },
    ///         encode: {
    ///             // Then the series will not be controlled
    ///             // by x axis and corresponding dataZoom.
    ///             x: -1,
    ///             y: 1
    ///         },
    ///         data: [ ...
    /// ]
    ///     }
    /// };
    /// ]]>
    /// </summary>
    [JsonPropertyName("encode")]
    public Encode? Encode { get; set; } 

    /// <summary>
    /// A group ID assigned to all data items in the series.
    ///  
    /// This option has a lower priority than groupId , which means when groupId is specified for a certain data item the dataGroupId will be simply ignored for that data item.
    /// For more information, please see series.data.groupId .
    /// </summary>
    [JsonPropertyName("dataGroupId")]
    public string? DataGroupId { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Data array of  series, which can be a single data value, like:  [12, 34, 56, 10, 23]  
    /// Or, if need extra dimensions for components like visualMap to map to graphic attributes like color, it can also be in the form of array.
    /// For example:  [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]  
    /// In this case, we can assign the second value in each array item to visualMap component.
    ///  
    /// More likely, we need to assign name to each data item, in which case each item should be an object:  [{
    ///     // name of date item
    ///     name: 'data1',
    ///     // value of date item is 8
    ///     value: 10
    /// }, {
    ///     name: 'data2',
    ///     value: 20
    /// }]  
    /// Each data item can be further customized:  [{
    ///     name: 'data1',
    ///     value: 10
    /// }, {
    ///     // name of data item
    ///     name: 'data2',
    ///     value : 56,
    ///     // user-defined label format that only useful for this data item
    ///     label: {},
    ///     // user-defined special itemStyle that only useful for this data item
    ///     itemStyle:{}
    /// }]
    /// ]]>
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
    /// Whether to ignore mouse events.
    /// Default value is false, for triggering and responding to mouse events.
    /// </summary>
    [JsonPropertyName("silent")]
    [DefaultValue(false)]
    public bool? Silent { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Initial animation type.
    ///   'expansion' Default expansion animation.
    ///  'scale' Scale animation.
    /// You can use it with animationEasing='elasticOut' to have popup effect.
    /// ]]>
    /// </summary>
    [JsonPropertyName("animationType")]
    [DefaultValue("expansion")]
    public AnimationType? AnimationType { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v4.4.0   
    /// Animation type when data updates.
    ///   'transition' Changing start and end angle of each sector from the old value to new value.
    ///  'expansion' The whole pie expands again.
    /// ]]>
    /// </summary>
    [JsonPropertyName("animationTypeUpdate")]
    [DefaultValue("transition")]
    public AnimationTypeUpdate? AnimationTypeUpdate { get; set; } 

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
