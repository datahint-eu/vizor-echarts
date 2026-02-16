// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class GraphSeries : ISeries
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
    /// Whether to enable highlighting chart when legend is being hovered.
    /// </summary>
    [JsonPropertyName("legendHoverLink")]
    [DefaultValue("true")]
    public bool? LegendHoverLink { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Specifies another coordinate system component on which this series-graph is laid out.
    ///  
    /// Options:   
    /// null / undefined / 'none'  
    /// Not laid out in any coordinate system; instead, laid out independently.
    ///     
    /// 'cartesian2d'  
    /// Lay out based on a two-dimensional rectangular coordinate system (also known as Cartesian coordinate system) .
    /// When multiple xAxis or multiple yAxis exist within an ECharts instance, the corresponding axes should be specified using xAxisIndex and yAxisIndex or xAxisId and yAxisId .
    ///  
    /// Note: some commonly used series, such as series-line , series-bar , etc., can not be laid out directly based on matrix coordinate system or calendar coordinate system , but they can be laid out on a grid(Cartesian) , and that grid can be laid out on a matrix or calendar .
    ///     
    /// 'polar'  
    /// Lay out based on a polar coordinate system .
    /// When multiple polar coordinate systems exist within an ECharts instance, the corresponding system should be specified using polarIndex or polarId .
    ///     
    /// 'geo'  
    /// Lay out based on a geographic coordinate system .
    /// When multiple geographic coordinate systems exist within an ECharts instance, the corresponding system should be specified using geoIndex or geoId .
    ///     
    /// 'singleAxis'  
    /// Lay out based on a singleAxis coordinate system .
    /// When multiple singleAxis coordinate systems exist within an ECharts instance, the corresponding system should be specified using singleAxisIndex or singleAxisId .
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
    /// See also series-graph.coordinateSystemUsage .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coordinateSystem")]
    [DefaultValue("none")]
    public string? CoordinateSystem { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specify how to lay out this series-graph based on the specified coordinateSystem .
    ///  
    /// In most cases, there is no need to specify coordinateSystemUsage , unless the default behavior is unexpected.
    ///  
    /// Options:   
    /// 'data' :  
    /// Each data item of a series (e.g., each series.data[i] ) is laid out separately based on the specified coordinate system.
    /// Currently no non-series component supports coordinateSystemUsage: 'data' .
    ///   
    /// 'box' : (Not applicable in series-graph )  
    /// The entire series or component is laid out as a whole based on the specified coordinate system - that is, the overall bounding rect or basic anchor point is calculated relative to the system.
    ///   For example, a grid component can be laid out in a matrix coordinate system or a calendar coordinate system , where its layout rectangle is calculated by the specified series-graph.coords in that system.
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
    /// See also series-graph.coordinateSystem .
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
    /// The index of the polar coordinate system to base on.
    /// When mutiple polar exist within an ECharts instance, use this to specify the corresponding polar .
    /// </summary>
    [JsonPropertyName("polarIndex")]
    [DefaultValue(0)]
    public int? PolarIndex { get; set; } 

    /// <summary>
    /// The id of the polar coordinate system to base on.
    /// When mutiple polar exist within an ECharts instance, use this to specify the corresponding polar .
    /// </summary>
    [JsonPropertyName("polarId")]
    [DefaultValue("undefined")]
    public double? PolarId { get; set; } 

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
    /// The index of the calendar coordinate system to base on.
    /// When mutiple calendar exist within an ECharts instance, use this to specify the corresponding calendar .
    /// </summary>
    [JsonPropertyName("calendarIndex")]
    [DefaultValue(0)]
    public int? CalendarIndex { get; set; } 

    /// <summary>
    /// The id of the calendar coordinate system to base on.
    /// When mutiple calendar exist within an ECharts instance, use this to specify the corresponding calendar .
    /// </summary>
    [JsonPropertyName("calendarId")]
    [DefaultValue("undefined")]
    public double? CalendarId { get; set; } 

    /// <summary>
    /// The index of the matrix coordinate system to base on.
    /// When mutiple matrix exist within an ECharts instance, use this to specify the corresponding matrix .
    /// </summary>
    [JsonPropertyName("matrixIndex")]
    [DefaultValue(0)]
    public int? MatrixIndex { get; set; } 

    /// <summary>
    /// The id of the matrix coordinate system to base on.
    /// When mutiple matrix exist within an ECharts instance, use this to specify the corresponding matrix .
    /// </summary>
    [JsonPropertyName("matrixId")]
    [DefaultValue("undefined")]
    public double? MatrixId { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Graph layout.
    ///  
    /// Options:   
    /// 'none' No any layout, use x , y provided in node as the position of node.
    ///   
    /// 'circular' Adopt circular layout, see the example Les Miserables .
    ///   
    /// 'force' Adopt force-directed layout, see the example Force , the detail about configurations of layout are in graph.force
    /// ]]>
    /// </summary>
    [JsonPropertyName("layout")]
    [DefaultValue("none")]
    public GraphLayout? Layout { get; set; } 

    /// <summary>
    /// Configuration about circular layout.
    /// </summary>
    [JsonPropertyName("circular")]
    public Circular? Circular { get; set; } 

    /// <summary>
    /// Configuration items about force-directed layout.
    /// Force-directed layout simulates spring/charge model, which will add a repulsion between 2 nodes and add a attraction between 2 nodes of each edge.
    /// In each iteration nodes will move under the effect of repulsion and attraction.
    /// After several iterations, the nodes will be static in a balanced position.
    /// As a result, the energy local minimum of this whole model will be realized.
    ///  
    /// The result of force-directed layout has a good symmetries and clustering, which is also aesthetically pleasing.
    /// </summary>
    [JsonPropertyName("force")]
    public Force? Force { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// center specifies which point on the graphic elements should be placed at the center of the viewport (i.e., typically, the center of the canvas).
    ///  
    /// center is typically used in control or fetch the position of graphic elements when roamming is performed.
    /// When roaming, the values in center and zoom will be modified correspondingly.
    ///  
    /// Notice: the values in center are based on the original layout coordinates, rather than the viewport (canvas) coordinates.
    /// If you intend to adjust the position and size of graphic elements by viewport coordinates, use series-graph.left / .right / .top / .bottom / .width / .height .
    ///  
    /// If using absolute numbers in center :   If series-graph.layout is 'none' , you need to provide coordinates for each node explicitly in series-graph.data.x , series-graph.data.y .
    /// In this case, center can be absolute numbers as that kind of coordinates.
    /// For example, option = {
    ///       series: {
    ///           type: 'graph',
    ///           center: [0, 10],
    ///           data: [
    ///               {x: 100, y: 3000},
    ///               {x: 150, y: 3500},
    ///               {x: 200, y: 4000},
    ///           ],
    ///       }
    ///   }
    ///   // The bounding rect of the graph is determined by series.data.x/series.data.y:
    ///   //    minX: 100, maxX: 200,
    ///   //    minY: 3000, maxY: 4000,
    ///   // `center: [0, 10]` indicates that the point `[0, 10]` should be placed in
    ///   //  the center of the viewport (typically, canvas).
    ///   // Consequently, the graph will be displayed at the right side of the viewport,
    ///   //  and probably overflow.
    ///   Otherwise, when specifying an auto-layout strategy in series-graph.layout , the coordinates are not user-determinable, so using absolute numbers in center is unfeasible.
    ///   
    /// A percentage string can also be used in center , like '30%' , based on the bounding rect.
    /// You can use '0%' to place the top or left of bounding rect to the center of the viewport (typically, canvas), or use '100%' to place the right or bottom to the center of the viewport, or use '50%' to place the entire graphic elements at the the center of the viewport.
    /// For example:  center: [115, '30%']
    /// // Place the top of graphic elements to the center of the viewport (canvas)
    /// center: [115, '0%']
    /// // Place the left of graphic elements to the center of the viewport (canvas)
    /// center: ['0%', 13]
    /// // Place the bottom of graphic elements to the center of the viewport (canvas)
    /// center: [115, '100%']
    /// // Place the right of graphic elements to the center of the viewport (canvas)
    /// center: ['100%', 13]
    /// // Place graphic elements at center of the viewport (canvas)
    /// center: ['50%', '50%']   
    /// The percentage string is introduced since v5.3.3 .
    /// It is initially based on canvas width/height.
    /// But that is not reasonable, and then changed to be based on the bounding rect since v6.0.0 .
    ///   
    /// See graph roam indicator example to understand the concept.
    /// ]]>
    /// </summary>
    [JsonPropertyName("center")]
    [DefaultValue("50%,50%")]
    public NumberOrStringArray? Center { get; set; } 

    /// <summary>
    /// Zoom rate of current viewport.
    ///  
    /// The value less than 1 indicates zooming out, while the value greater than 1 indicates zooming in.
    ///  
    /// When roaming , the values in center and zoom will be modified correspondingly.
    ///  
    /// See graph roam indicator example to understand the concept.
    /// </summary>
    [JsonPropertyName("zoom")]
    [DefaultValue("1")]
    public double? Zoom { get; set; } 

    /// <summary>
    /// Limit of zooming , with min and max .
    ///  
    /// The value less than 1 indicates zooming out, while the value greater than 1 indicates zooming in.
    /// </summary>
    [JsonPropertyName("scaleLimit")]
    public ScaleLimit? ScaleLimit { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Whether to enable mouse or touch roam (move and zoom).
    /// Optional values are:   false : roam is disabled.
    ///  'scale' or 'zoom' : zoom only.
    ///  'move' or 'pan' : move (translation) only.
    ///  true : both zoom and move (translation) are available.
    ///   
    /// When roaming, the values in center and zoom will be modified correspondingly.
    /// ]]>
    /// </summary>
    [JsonPropertyName("roam")]
    [DefaultValue(false)]
    public Roam? Roam { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Roaming can be triggered by mouse dragging or mouse wheel.
    ///  
    /// Options:   
    /// 'selfRect' :  
    /// The roaming can only be triggered on the bounding rect of the graphic elements.
    ///   
    /// 'global' :  
    /// The roaming can be triggered in canvas globally.
    ///    
    /// See graph roam indicator example to understand the concept.
    /// ]]>
    /// </summary>
    [JsonPropertyName("roamTrigger")]
    [DefaultValue("selfRect")]
    public string? RoamTrigger { get; set; } 

    /// <summary>
    /// Related zooming ratio of nodes when mouse zooming in or out.
    /// When it is set as 0, the node will not zoom as the mouse zooms.
    /// </summary>
    [JsonPropertyName("nodeScaleRatio")]
    [DefaultValue("0.6")]
    public double? NodeScaleRatio { get; set; } 

    /// <summary>
    /// If node is draggable.
    ///  
    /// Note that this option is only available when using force-directed layout before v5.4.1 .
    /// </summary>
    [JsonPropertyName("draggable")]
    [DefaultValue("false")]
    public bool? Draggable { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Symbol of node.
    ///  
    /// Icon types provided by ECharts includes  
    /// 'circle' , 'rect' , 'roundRect' , 'triangle' , 'diamond' , 'pin' , 'arrow' , 'none'  
    /// It can be set to an image with 'image://url' , in which URL is the link to an image, or dataURI of an image.
    ///  
    /// An image URL example:  'image://http://example.website/a/b.png' 
    /// A dataURI example:  'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7' 
    /// Icons can be set to arbitrary vector path via 'path://' in ECharts.
    /// As compared with a raster image, vector paths prevent jagging and blurring when scaled, and have better control over changing colors.
    /// The size of the vector icon will be adapted automatically.
    /// Refer to SVG PathData for more information about the format of the path.
    /// You may export vector paths from tools like Adobe  
    /// For example:  'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
    /// ]]>
    /// </summary>
    [JsonPropertyName("symbol")]
    [DefaultValue("circle")]
    public Icon? Symbol { get; set; } 

    /// <summary>
    /// node symbol size.
    /// It can be set to single numbers like 10 , or use an array to represent width and height.
    /// For example, [20, 10] means symbol width is 20 , and height is 10 .
    /// </summary>
    [JsonPropertyName("symbolSize")]
    public NumberOrNumberArray? SymbolSize { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Rotate degree of node symbol.
    /// The negative value represents clockwise.
    /// Note that when symbol is set to be 'arrow' in markLine , symbolRotate value will be ignored, and compulsively use tangent angle.
    /// ]]>
    /// </summary>
    [JsonPropertyName("symbolRotate")]
    public double? SymbolRotate { get; set; } 

    /// <summary>
    /// Whether to keep aspect for symbols in the form of path:// .
    /// </summary>
    [JsonPropertyName("symbolKeepAspect")]
    [DefaultValue(false)]
    public bool? SymbolKeepAspect { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Offset of node symbol relative to original position.
    /// By default, symbol will be put in the center position of data.
    /// But if symbol is from user-defined vector path or image, you may not expect symbol to be in center.
    /// In this case, you may use this attribute to set offset to default position.
    /// It can be in absolute pixel value, or in relative percentage value.
    ///  
    /// For example, [0, '-50%'] means to move upside side position of symbol height.
    /// It can be used to make the arrow in the bottom to be at data position when symbol is pin.
    /// ]]>
    /// </summary>
    [JsonPropertyName("symbolOffset")]
    [DefaultValue("[0, 0]")]
    public NumberOrNumberArray? SymbolOffset { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Symbol of two ends of edge line.
    ///  
    /// For example:  edgeSymbol: ['circle', 'arrow']
    /// ]]>
    /// </summary>
    [JsonPropertyName("edgeSymbol")]
    [DefaultValue("[none, none]")]
    public StringArray? EdgeSymbol { get; set; } 

    /// <summary>
    /// Size of symbol of two ends of edge line.
    /// Can be an array or a single number.
    ///  
    /// For example:  // Start symbol has size 5 and end symbol has size 10
    /// edgeSymbolSize: [5, 10],
    /// // All has size 10
    /// edgeSymbolSize: 10
    /// </summary>
    [JsonPropertyName("edgeSymbolSize")]
    [DefaultValue("10")]
    public NumberOrNumberArray? EdgeSymbolSize { get; set; } 

    /// <summary>
    /// The mouse style when mouse hovers on an element, the same as cursor property in CSS .
    /// </summary>
    [JsonPropertyName("cursor")]
    [DefaultValue("pointer")]
    public string? Cursor { get; set; } 

    /// <summary>
    /// Graphic style of , emphasis is the style when it is highlighted, like being hovered by mouse, or highlighted via legend connect.
    /// </summary>
    [JsonPropertyName("itemStyle")]
    public ItemStyle? ItemStyle { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// The style of edge line.
    /// lineStyle.color can be 'source' or 'target' , which will use the color of source node or target node.
    /// ]]>
    /// </summary>
    [JsonPropertyName("lineStyle")]
    public LineStyle? LineStyle { get; set; } 

    /// <summary>
    /// Text label of , to explain some data information about graphic item like value, name and so on.
    /// label is placed under itemStyle in ECharts 2.x.
    /// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
    /// </summary>
    [JsonPropertyName("label")]
    public Label? Label { get; set; } 

    /// <summary>
    /// 
    /// </summary>
    [JsonPropertyName("edgeLabel")]
    public EdgeLabel? EdgeLabel { get; set; } 

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
    /// The categories of node, which is optional.
    /// If there is a classification of nodes, the category of each node can be assigned through data[i].category .
    /// And the style of category will also be applied to the style of nodes.
    /// categories can also be used in legend .
    /// </summary>
    [JsonPropertyName("categories")]
    public object? Categories { get; set; } 

    [JsonIgnore]
    public List<GraphSeriesCategory>? CategoriesList
    {
        	get => Categories as List<GraphSeriesCategory>;
        	set => Categories = value;
    }

    /// <summary>
    /// For the situation where there are multiple links between nodes, the curveness of each link is automatically calculated, not enabled by default.
    ///  
    /// When set to true , it enables automatic curvature calculation.
    /// The default edge curveness array length is 20 , if the number of edges between two nodes is more than 20 , please use number or Array to set the edge curveness array.
    ///  
    /// When set to number , it indicates the length of the edge curveness array between two nodes, and the calculation result is given by the internal algorithm.
    ///  
    /// When set to Array , it means that the curveness array is directly specified, and the multilateral curveness is directly selected from the array.
    ///  
    /// Notice： if lineStyle.curveness has been set, this property is invalid.
    /// </summary>
    [JsonPropertyName("autoCurveness")]
    [DefaultValue(false)]
    public AutoCurveness? AutoCurveness { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Nodes list of graph.
    ///  data: [{
    ///     name: '1',
    ///     x: 10,
    ///     y: 10,
    ///     value: 10
    /// }, {
    ///     name: '2',
    ///     x: 100,
    ///     y: 100,
    ///     value: 20,
    ///     symbolSize: 20,
    ///     itemStyle: {
    ///         color: 'red'
    ///     }
    /// }]
    /// ]]>
    /// </summary>
    [JsonPropertyName("data")]
    public object? Data { get; set; } 

    /// <summary>
    /// Alias of data
    /// </summary>
    [JsonPropertyName("nodes")]
    public List<GraphSeriesData>? Nodes { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Relational data between nodes.
    /// Example:  links: [{
    ///     source: 'n1',
    ///     target: 'n2'
    /// }, {
    ///     source: 'n2',
    ///     target: 'n3'
    /// }]
    /// ]]>
    /// </summary>
    [JsonPropertyName("links")]
    public object? Links { get; set; } 

    [JsonIgnore]
    public List<GraphSeriesLink>? LinksList
    {
        	get => Links as List<GraphSeriesLink>;
        	set => Links = value;
    }

    /// <summary>
    /// Alias of links
    /// </summary>
    [JsonPropertyName("edges")]
    public List<GraphSeriesLink>? Edges { get; set; } 

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
    /// Distance between graph series and the left side of the container.
    ///  
    /// left can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
    ///  
    /// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    /// ]]>
    /// </summary>
    [JsonPropertyName("left")]
    [DefaultValue("center")]
    public NumberOrString? Left { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between graph series and the top side of the container.
    ///  
    /// top can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
    ///  
    /// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    /// ]]>
    /// </summary>
    [JsonPropertyName("top")]
    [DefaultValue("middle")]
    public NumberOrString? Top { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between graph series and the right side of the container.
    ///  
    /// right can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    ///  
    /// Adaptive by default.
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    /// ]]>
    /// </summary>
    [JsonPropertyName("right")]
    [DefaultValue("auto")]
    public NumberOrString? Right { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between graph series and the bottom side of the container.
    ///  
    /// bottom can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    ///  
    /// Adaptive by default.
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    /// ]]>
    /// </summary>
    [JsonPropertyName("bottom")]
    [DefaultValue("auto")]
    public NumberOrString? Bottom { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Width of graph series.
    ///  
    /// width can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    /// ]]>
    /// </summary>
    [JsonPropertyName("width")]
    [DefaultValue("auto")]
    public NumberOrString? Width { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Height of graph series.
    ///  
    /// height can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    /// ]]>
    /// </summary>
    [JsonPropertyName("height")]
    [DefaultValue("auto")]
    public NumberOrString? Height { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// aspect ratio here refers to width / height .
    ///  
    /// "preserve aspect" refers whether to preserve the aspect ratio of the original bounding rect of the content to be rendered.
    ///  
    /// A rectangular area allocated to graph series is determined by series-graph.left / .right / .top / .bottom / .width / .height .
    ///  
    /// But the aspect ratio of this rectangle may not match that of the content's original bounding rect, which may cause distortion.
    ///  
    /// Options of preserveAspect :   null / undefined / false (default): The original aspect ratio of the content will not be preserved, but stretched to fill the graph series rectangular area , which may cause distortion.
    ///  'contain' / true : The original aspect ratio of the content is preserved; the bounding rect of the content are fully contained by the graph series rectangular area , and scaled up as much as possible to meet the graph series rectangular area .
    /// preserveAspectAlign and preserveAspectVerticalAlign can be used to adjust the position in this case.
    ///  'cover' : The original aspect ratio of the content is preserved; the bounding rect of the content covers the graph series rectangular area , and scaled down as much as possible to meet the graph series rectangular area .
    /// preserveAspectAlign and preserveAspectVerticalAlign can be used to adjust the position in this case.
    ///   
    /// See graph roam indicator example to understand the concept.
    /// ]]>
    /// </summary>
    [JsonPropertyName("preserveAspect")]
    [DefaultValue("false")]
    public BoolOrString? PreserveAspect { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Options: 'left' | 'right' | 'center' .
    ///  
    /// See preserveAspect .
    ///  
    /// See graph roam indicator example to understand the concept.
    /// ]]>
    /// </summary>
    [JsonPropertyName("preserveAspectAlign")]
    [DefaultValue("center")]
    //TODO: Type Warning: enum type 'preserveAspectAlign' in 'GraphSeries' with values 'left,right,center' is not mapped
    public string? PreserveAspectAlign { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Options: 'top' | 'bottom' | 'middle' .
    ///  
    /// See preserveAspect .
    ///  
    /// See graph roam indicator example to understand the concept.
    /// ]]>
    /// </summary>
    [JsonPropertyName("preserveAspectVerticalAlign")]
    [DefaultValue("middle")]
    //TODO: Type Warning: enum type 'preserveAspectVerticalAlign' in 'GraphSeries' with values 'top,bottom,middle' is not mapped
    public string? PreserveAspectVerticalAlign { get; set; } 

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
    /// tooltip settings in this series.
    /// </summary>
    [JsonPropertyName("tooltip")]
    public Tooltip? Tooltip { get; set; } 

}
