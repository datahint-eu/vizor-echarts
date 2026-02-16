// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class TreemapSeries : ISeries
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
    /// Distance between treemap series and the left side of the container.
    ///  
    /// left can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
    ///  
    /// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
    /// ]]>
    /// </summary>
    [JsonPropertyName("left")]
    [DefaultValue("center")]
    public NumberOrString? Left { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between treemap series and the top side of the container.
    ///  
    /// top can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
    ///  
    /// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
    /// ]]>
    /// </summary>
    [JsonPropertyName("top")]
    [DefaultValue("middle")]
    public NumberOrString? Top { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between treemap series and the right side of the container.
    ///  
    /// right can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    ///  
    /// Adaptive by default.
    /// ]]>
    /// </summary>
    [JsonPropertyName("right")]
    [DefaultValue("auto")]
    public NumberOrString? Right { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between treemap series and the bottom side of the container.
    ///  
    /// bottom can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    ///  
    /// Adaptive by default.
    /// ]]>
    /// </summary>
    [JsonPropertyName("bottom")]
    [DefaultValue("auto")]
    public NumberOrString? Bottom { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Width of treemap series.
    ///  
    /// width can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("width")]
    [DefaultValue("80%")]
    public NumberOrString? Width { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Height of treemap series.
    ///  
    /// height can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("height")]
    [DefaultValue("80%")]
    public NumberOrString? Height { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specifies another coordinate system component on which this series-treemap is laid out.
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
    /// See also series-treemap.coordinateSystemUsage .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coordinateSystem")]
    [DefaultValue("none")]
    public string? CoordinateSystem { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specify how to lay out this series-treemap based on the specified coordinateSystem .
    ///  
    /// In most cases, there is no need to specify coordinateSystemUsage , unless the default behavior is unexpected.
    ///  
    /// Options:   
    /// 'data' :  
    /// Each data item of a series (e.g., each series.data[i] ) is laid out separately based on the specified coordinate system.
    /// Currently no non-series component supports coordinateSystemUsage: 'data' .
    ///   
    /// 'box' : (Not applicable in series-treemap )  
    /// The entire series or component is laid out as a whole based on the specified coordinate system - that is, the overall bounding rect or basic anchor point is calculated relative to the system.
    ///   For example, a grid component can be laid out in a matrix coordinate system or a calendar coordinate system , where its layout rectangle is calculated by the specified series-treemap.coords in that system.
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
    /// See also series-treemap.coordinateSystem .
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
    /// The expected square ratio.
    /// Layout would approach the ratio as close as possible.
    ///  
    /// It defaults to be the golden ratio: 0.5 * (1 + Math.sqrt(5)) .
    /// </summary>
    [JsonPropertyName("squareRatio")]
    [DefaultValue("0.75")]
    public double? SquareRatio { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// When leafDepth is set, the feature "drill down" is enabled, which means when clicking a tree node, this node will be set as root and its children will be shown.
    ///  
    /// leafDepth represents how many levels are shown at most.
    /// For example, when leafDepth is set to 1 , only one level will be shown.
    ///  
    /// leafDepth is null / undefined by default, which means that "drill down" is disabled.
    ///  
    /// An example about drill down:
    /// ]]>
    /// </summary>
    [JsonPropertyName("leafDepth")]
    public double? LeafDepth { get; set; } 

    /// <summary>
    /// Marker when the node is able to be drilled down.
    /// </summary>
    [JsonPropertyName("drillDownIcon")]
    [DefaultValue("▶")]
    public string? DrillDownIcon { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Whether to enable mouse or touch roam (move and zoom).
    /// Optional values are:   false : roam is disabled.
    ///  'scale' or 'zoom' : zoom only.
    ///  'move' or 'pan' : move (translation) only.
    ///  true : both zoom and move (translation) are available.
    /// ]]>
    /// </summary>
    [JsonPropertyName("roam")]
    [DefaultValue(true)]
    public Roam? Roam { get; set; } 

    /// <summary>
    /// Since v5.5.1   
    /// Limit of zooming , with min and max .
    ///  
    /// The value less than 1 indicates zooming out, while the value greater than 1 indicates zooming in.
    /// </summary>
    [JsonPropertyName("scaleLimit")]
    public ScaleLimit? ScaleLimit { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// The behaviour when clicking a node.
    /// Optional values are:   false : Do nothing after clicked.
    ///  'zoomToNode' : Zoom to clicked node.
    ///  'link' : If there is link in node data, do hyperlink jump after clicked.
    /// ]]>
    /// </summary>
    [JsonPropertyName("nodeClick")]
    [DefaultValue("zoomToNode")]
    public BoolOrString? NodeClick { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// The treemap will be auto zoomed to a appropriate ratio when a node is clicked (when nodeClick is set as 'zoomToNode' and no drill down happens).
    /// This configuration item indicates the ratio.
    /// ]]>
    /// </summary>
    [JsonPropertyName("zoomToNodeRatio")]
    [DefaultValue("0.1")]
    public double? ZoomToNodeRatio { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// treemap is able to map any dimensions of data to visual.
    ///  
    /// The value of series-treemap.data can be an array.
    /// And each item of the array represents a "dimension".
    /// visualDimension specifies the dimension on which visual mapping will be performed.
    ///  
    /// About visual encoding, see details in series-treemap.levels .
    ///   
    /// Tps: In treemap, visualDimension attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
    ///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
    ///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
    /// ]]>
    /// </summary>
    [JsonPropertyName("visualDimension")]
    [DefaultValue(0)]
    public double? VisualDimension { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// The minimal value of current level.
    /// Auto-statistics by default.
    ///  
    /// When colorMappingBy is set to 'value' , you are able to specify extent manually for visual mapping by specifying visualMin or visualMax .
    /// ]]>
    /// </summary>
    [JsonPropertyName("visualMin")]
    [DefaultValue("0")]
    public double? VisualMin { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// The maximal value of current level.
    /// Auto-statistics by default.
    ///  
    /// When colorMappingBy is set to 'value' , you are able to specify extent manually for visual mapping by specifying visualMin or visualMax .
    /// ]]>
    /// </summary>
    [JsonPropertyName("visualMax")]
    [DefaultValue("100")]
    public double? VisualMax { get; set; } 

    /// <summary>
    /// It indicates the range of transparent rate (color alpha) for nodes of the series  
    /// .
    /// The range of values is 0 ~ 1.
    ///  
    /// For example, colorAlpha can be [0.3, 1] .
    ///  
    /// About visual encoding, see details in series-treemap.levels .
    ///   
    /// Tps: In treemap, colorAlpha attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
    ///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
    ///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
    /// </summary>
    [JsonPropertyName("colorAlpha")]
    //TODO: Type Warning: array type 'colorAlpha' in 'TreemapSeries' will be mapped to List<object>
    public List<object>? ColorAlpha { get; set; } 

    /// <summary>
    /// It indicates the range of saturation (color alpha) for nodes  of the series.
    ///  
    /// The range of values is 0 ~ 1.
    ///  
    /// For example, colorSaturation can be [0.3, 1] .
    ///  
    /// About visual encoding, see details in series-treemap.levels .
    ///   
    /// Tps: In treemap, colorSaturation attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
    ///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
    ///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
    /// </summary>
    [JsonPropertyName("colorSaturation")]
    public double? ColorSaturation { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Specify the rule according to which each node obtain color from color list .
    /// Optional values:   'value' :   
    /// Map series-treemap.data.value to color.
    ///  
    /// In this way, the color of each node indicate its value.
    ///  
    /// visualDimension can be used to specify which dimension of data is used to perform visual mapping.
    ///   'index' :   
    /// Map the index (ordinal number) of nodes to color.
    /// Namely, in a level, the first node is mapped to the first color of color list , and the second node gets the second color.
    ///  
    /// In this way, adjacent nodes are distinguished by color.
    ///   'id' :   
    /// Map series-treemap.data.id to color.
    ///  
    /// Since id is used to identify node, if user call setOption to modify the tree, each node will remain the original color before and after setOption called.
    /// See this example .
    ///  
    /// About visual encoding, see details in series-treemap.levels .
    ///   
    /// Tps: In treemap, colorMappingBy attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
    ///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
    ///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
    /// ]]>
    /// </summary>
    [JsonPropertyName("colorMappingBy")]
    [DefaultValue("index")]
    public ColorMappingBy? ColorMappingBy { get; set; } 

    /// <summary>
    /// A node will not be shown when its area size is smaller than this value (unit: px square).
    ///  
    /// In this way, tiny nodes will be hidden, otherwise they will huddle together.
    /// When user zoom the treemap, the area size will increase and the rectangle will be shown if the area size is larger than this threshold.
    ///  
    /// About visual encoding, see details in series-treemap.levels .
    ///   
    /// Tps: In treemap, visibleMin attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
    ///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
    ///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
    /// </summary>
    [JsonPropertyName("visibleMin")]
    [DefaultValue("10")]
    public double? VisibleMin { get; set; } 

    /// <summary>
    /// Children will not be shown when area size of a node is smaller than this value (unit: px square).
    ///  
    /// This can hide the details of nodes when the rectangular area is not large enough.
    /// When users zoom nodes, the child node would show if the area is larger than this threshold.
    ///  
    /// About visual encoding, see details in series-treemap.levels .
    ///   
    /// Tps: In treemap, childrenVisibleMin attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
    ///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
    ///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
    /// </summary>
    [JsonPropertyName("childrenVisibleMin")]
    [DefaultValue("10")]
    public double? ChildrenVisibleMin { get; set; } 

    /// <summary>
    /// label describes the style of the label in each node.
    ///   
    /// Tps: In treemap, label attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
    ///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
    ///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
    /// </summary>
    [JsonPropertyName("label")]
    public Label? Label { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// upperLabel is used to specify whether show label when the node has children.
    /// When upperLabel.show is set as true , the feature that "show parent label" is enabled.
    ///  
    /// The same as series-treemap.label , the option upperLabel can be placed at the root of series-treemap directly, or in series-treemap.level , or in each item of series-treemap.data .
    ///  
    /// Specifically, series-treemap.label specifies the style when a node is a leaf, while upperLabel specifies the style when a node has children, in which case the label is displayed in the inner top of the node.
    ///  
    /// See:    
    /// Tps: In treemap, label attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
    ///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
    ///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
    /// ]]>
    /// </summary>
    [JsonPropertyName("upperLabel")]
    public UpperLabel? UpperLabel { get; set; } 

    /// <summary>
    /// Tps: In treemap, itemStyle attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
    ///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
    ///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
    /// </summary>
    [JsonPropertyName("itemStyle")]
    public ItemStyle? ItemStyle { get; set; } 

    /// <summary>
    /// Emphasis state.
    /// </summary>
    [JsonPropertyName("emphasis")]
    public Emphasis? Emphasis { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// Blur state.
    /// </summary>
    [JsonPropertyName("blur")]
    public Blur? Blur { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// Select state.
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
    /// To show the path of the current node.
    /// </summary>
    [JsonPropertyName("breadcrumb")]
    public Breadcrumb? Breadcrumb { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// Configuration of label guide line.
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
    /// <![CDATA[
    /// Multiple Levels Configuration  
    /// treemap adopts 4-level configuration:  "each node" --> "each level" --> "each series".
    /// 
    /// That is, we can configurate each node, can also configurate each level of the tree, or set overall configurations on each series.
    /// The highest priority is node configuration.
    ///  
    /// levels is configurations on each levels, which is used most.
    ///  
    /// For example:  // Notice that in fact the data structure is not "tree", but is "forest".
    /// data: [
    ///     {
    ///         name: 'nodeA',
    ///         children: [
    ///             {name: 'nodeAA'},
    ///             {name: 'nodeAB'},
    ///         ]
    ///     },
    ///     {
    ///         name: 'nodeB',
    ///         children: [
    ///             {name: 'nodeBA'}
    ///         ]
    ///     }
    /// ],
    /// levels: [
    ///     {...}, // configurations of the top level of the data structure "forest"
    ///         // (the level that contains 'nodeA', 'nodeB' shown above).
    ///     {...}, // configurations of the next level
    ///         // (the level that contains 'nodeAA', 'nodeAB', 'nodeBA' shown above)
    ///     {...}, // configurations of the next level
    ///     ...
    /// ]  
    /// The Rules about Visual Mapping  
    /// When designing a treemap, we primarily focus on how to visually distinguish "different levels", "different categories in the same level", which requires appropriate settings of "rectangular color", "border thickness", "border color" and even "color saturation of rectangular" and so on on each level.
    ///  
    /// See example .
    /// The top level is divided into several parts by colors "red", "green", "blue", and etc ...
    /// In each color block, colorSaturation is used to distinguish nodes in sublevel.
    /// The border color of the top level is "white", while the border color of the sublevel is the color that based on the current block color and processed by borderColorSaturation .
    ///  
    /// treemap uses this rule of visual configuration: each level computes its visual value based on the configurations ( color , colorSaturation , borderColor , borderColorSaturation ) on this level.
    /// If there is no certain configuration in a node, it inherits the configuration from its parent.
    ///  
    /// In this way, this effect can be configured: set a color list on the parent level, and set colorSaturation on the child level, and then each node in the parent level would obtain a color from the color list, and each node in the child level would obtain a value from colorSaturation and compound it with the color inherited from its parent node to get its final color.
    ///  
    /// Dimensions and "Extra Visual Mapping"  
    /// See the example below: every value field is set as an Array, in which each item in the array represents a dimension respectively.
    ///  [
    ///     {
    ///         value: [434, 6969, 8382],
    ///         children: [
    ///             {
    ///                 value: [1212, 4943, 5453],
    ///                 id: 'someid-1',
    ///                 name: 'description of this node',
    ///                 children: [...]
    ///             },
    ///             {
    ///                 value: [4545, 192, 439],
    ///                 id: 'someid-2',
    ///                 name: 'description of this node',
    ///                 children: [...]
    ///             },
    ///             ...
    ///         ]
    ///     },
    ///     {
    ///         value: [23, 59, 12],
    ///         children: [...]
    ///     },
    ///     ...
    /// ]  
    /// treemap will map the first dimension (the first item of the array) to "area".
    /// If we want to express more information, we could map another dimension (specified by series-treemap.visualDimension ) to another visual types, such as colorSaturation and so on.
    /// See the example and select the legend 'Growth'.
    ///  
    /// How to avoid confusion by setting border/gap of node  
    /// If all of the border/gaps are set with the same color, confusion might occur when rectangulars in different levels display at the same time.
    ///  
    /// See the example .
    /// Notice that the child rectangles in the red area are in the deeper level than rectangles that are saparated by white gap.
    /// So in the red area, basically we set gap color with red, and use borderColorSaturation to lift the saturation.
    ///  
    /// Explanation about borderWidth, gapWidth, borderColor
    /// ]]>
    /// </summary>
    [JsonPropertyName("levels")]
    public List<TreemapSeriesLevel>? Levels { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// the the data format of series-treemap.data is a forest.
    /// For example:  [ // Tips, the top level is an array.
    ///     {
    ///         value: 1212,
    ///         children: [
    ///             {
    ///                 value: 2323,    // The value of this node, indicating the area size.
    ///                                 // it could also be an array, such as [2323, 43, 55], in which the first item of array indicates the area size.
    ///                                 // The other items of the array can be used for extra visual mapping.
    /// See details in series-treemap.levels.
    ///                 id: 'someid-1', // id is not mandatory.
    ///                                 // But if using API, id is used to locate node.
    ///                 name: 'description of this node', // show the description text in rectangle.
    ///                 children: [...],
    ///                 label: {        // The label config of this node (if necessary).
    ///                     ...
    ///         // see series-treemap.label.
    ///                 },
    ///                 itemStyle: {    // the itemStyle of this node (if necessary).
    ///                     ...
    ///         // the see series-treemap.itemStyle.
    ///                 }
    ///             },
    ///             {
    ///                 value: 4545,
    ///                 id: 'someid-2',
    ///                 name: 'description of this node',
    ///                 children: [
    ///                     {
    ///                         value: 5656,
    ///                         id: 'someid-3',
    ///                         name: 'description of this node',
    ///                         children: [...]
    ///                     },
    ///                     ...
    ///                 ]
    ///             }
    ///         ]
    ///     },
    ///     {
    ///         value: [23, 59, 12]
    ///         // if there is no children, here could be nothing.
    ///     },
    ///     ...
    /// ]
    /// ]]>
    /// </summary>
    [JsonPropertyName("data")]
    public object? Data { get; set; } 

    /// <summary>
    /// Whether to ignore mouse events.
    /// Default value is false, for triggering and responding to mouse events.
    /// </summary>
    [JsonPropertyName("silent")]
    [DefaultValue(false)]
    public bool? Silent { get; set; } 

    /// <summary>
    /// Duration of the first animation, which supports callback function for different data to have different animation effect:  animationDuration: function (idx) {
    ///     // delay for later data is larger
    ///     return idx * 100;
    /// }
    /// </summary>
    [JsonPropertyName("animationDuration")]
    [DefaultValue("1500")]
    public NumberOrFunction? AnimationDuration { get; set; } 

    /// <summary>
    /// Easing method used for the first animation.
    /// Varied easing effects can be found at easing effect example .
    /// </summary>
    [JsonPropertyName("animationEasing")]
    [DefaultValue("quinticInOut")]
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
    /// tooltip settings in this series.
    /// </summary>
    [JsonPropertyName("tooltip")]
    public Tooltip? Tooltip { get; set; } 

    /// <summary>
    /// Since v5.6.0   
    /// The mouse style when mouse hovers on an element, the same as cursor property in CSS .
    /// </summary>
    [JsonPropertyName("cursor")]
    [DefaultValue("pointer")]
    public string? Cursor { get; set; } 

}
