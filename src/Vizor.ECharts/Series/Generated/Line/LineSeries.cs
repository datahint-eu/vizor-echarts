// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class LineSeries : ISeries
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
    /// Specifies another coordinate system component on which this series-line is laid out.
    ///  
    /// Options:   
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
    /// 'singleAxis'  
    /// Lay out based on a singleAxis coordinate system .
    /// When multiple singleAxis coordinate systems exist within an ECharts instance, the corresponding system should be specified using singleAxisIndex or singleAxisId .
    ///    
    /// Support for series and component layout on coordinate systems:  
    /// The leftmost column lists the series and components that will be laid out (coordinate systems themselves are also components), and the topmost row lists the coordinate systems that can be laid out on.
    ///      no coord sys  grid (cartesian2d)  polar  geo  singleAxis  radar  parallel  calendar  matrix      grid (cartesian2d)  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    polar  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    geo  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    singleAxis  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    calendar  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ❌  ❌    matrix  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ❌  ❌    series-line  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-bar  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-pie  ✅  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-scatter  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-effectScatter  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-radar  ❌  ❌  ❌  ❌  ❌  ✅  ❌  ❌ (✅ if via radar coord sys)  ❌ (✅ if via radar coord sys)    series-tree  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-treemap  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-sunburst  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-boxplot  ❌  ✅  ❌  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-candlestick  ❌  ✅  ❌  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-heatmap  ❌  ✅  ❌  ✅  ❌  ❌  ❌  ✅  ✅    series-map  ✅ (create a geo coord sys exclusively)  ❌  ❌  ✅  ❌  ❌  ❌  ✅  ✅    series-parallel  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ❌ (✅ if via parallel coord sys)  ❌ (✅ if via parallel coord sys)    series-lines  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ❌ (✅ if via another coord sys like geo )  ❌ (✅ if via another coord sys like geo )    series-graph  ✅ (create a "view" coord sys exclusively)  ✅  ✅  ✅  ❌  ❌  ❌  ✅  ✅    series-sankey  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-funnel  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-gauge  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-pictorialBar  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-themeRiver  ❌  ❌  ❌  ❌  ✅  ❌  ❌  ❌ (✅ if via another coord sys like singleAxis )  ❌ (✅ if via another coord sys like singleAxis )    series-chord  ✅  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    title  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    legend  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    dataZoom  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    visualMap  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    toolbox  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    timeline  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    thumbnail  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅     
    /// See also series-line.coordinateSystemUsage .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coordinateSystem")]
    [DefaultValue("cartesian2d")]
    public string? CoordinateSystem { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specify how to lay out this series-line based on the specified coordinateSystem .
    ///  
    /// In most cases, there is no need to specify coordinateSystemUsage , unless the default behavior is unexpected.
    ///  
    /// Options:   
    /// 'data' :  
    /// Each data item of a series (e.g., each series.data[i] ) is laid out separately based on the specified coordinate system.
    /// Currently no non-series component supports coordinateSystemUsage: 'data' .
    ///   
    /// 'box' : (Not applicable in series-line )  
    /// The entire series or component is laid out as a whole based on the specified coordinate system - that is, the overall bounding rect or basic anchor point is calculated relative to the system.
    ///   For example, a grid component can be laid out in a matrix coordinate system or a calendar coordinate system , where its layout rectangle is calculated by the specified series-line.coords in that system.
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
    /// See also series-line.coordinateSystem .
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
    /// <![CDATA[
    /// Symbol of .
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
    /// If symbols needs to be different, you can set with callback function in the following format:  (value: Array|number, params: Object) => string  
    /// The first parameter value is the value in data , and the second parameter params is the rest parameters of data item.
    /// ]]>
    /// </summary>
    [JsonPropertyName("symbol")]
    [DefaultValue("circle")]
    public StringOrFunction? Symbol { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// symbol size.
    /// It can be set to single numbers like 10 , or use an array to represent width and height.
    /// For example, [20, 10] means symbol width is 20 , and height is 10 .
    ///  
    /// If size of symbols needs to be different, you can set with callback function in the following format:  (value: Array|number, params: Object) => number|Array  
    /// The first parameter value is the value in data , and the second parameter params is the rest parameters of data item.
    /// ]]>
    /// </summary>
    [JsonPropertyName("symbolSize")]
    [DefaultValue(4)]
    public NumberArrayOrFunction? SymbolSize { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Rotate degree of  symbol.
    /// The negative value represents clockwise.
    /// Note that when symbol is set to be 'arrow' in markLine , symbolRotate value will be ignored, and compulsively use tangent angle.
    ///  
    /// If rotation of symbols needs to be different, you can set with callback function in the following format:  (value: Array|number, params: Object) => number  
    /// The first parameter value is the value in data , and the second parameter params is the rest parameters of data item.
    ///   
    /// Callback is supported since 4.8.0 .
    /// ]]>
    /// </summary>
    [JsonPropertyName("symbolRotate")]
    public NumberOrFunction? SymbolRotate { get; set; } 

    /// <summary>
    /// Whether to keep aspect for symbols in the form of path:// .
    /// </summary>
    [JsonPropertyName("symbolKeepAspect")]
    [DefaultValue(false)]
    public bool? SymbolKeepAspect { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Offset of  symbol relative to original position.
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
    /// Whether to show symbol.
    /// It would be shown during tooltip hover.
    /// </summary>
    [JsonPropertyName("showSymbol")]
    [DefaultValue("true")]
    public bool? ShowSymbol { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Only work when main axis is 'category' axis ( axis.type is 'category' ).
    /// Optional values:   'auto' : Default value.
    /// Show all symbols if there is enough space.
    /// Otherwise follow the interval strategy with with axisLabel.interval .
    ///  true : Show all symbols.
    ///  false : Follow the interval strategy with axisLabel.interval .
    /// ]]>
    /// </summary>
    [JsonPropertyName("showAllSymbol")]
    [DefaultValue("auto")]
    public bool? ShowAllSymbol { get; set; } 

    /// <summary>
    /// Whether to enable highlighting chart when legend is being hovered.
    /// </summary>
    [JsonPropertyName("legendHoverLink")]
    [DefaultValue("true")]
    public bool? LegendHoverLink { get; set; } 

    /// <summary>
    /// If stack the value.
    /// On the same category axis, the series with the same stack name would be put on top of each other.
    ///  
    /// See also stackStrategy on how to customize how values are stacked.
    ///  
    /// Notice: stack only supports stacking on value and log axis for now.
    /// time and category axis are not supported.
    ///  
    /// The effect of the below example could be seen through stack switching of toolbox on the top right corner:
    /// </summary>
    [JsonPropertyName("stack")]
    public string? Stack { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v5.3.3   
    /// How to stack values if the stack property has been set.
    /// Options:   'samesign' : only stack values if the value to be stacked has the same sign as the currently cumulated stacked value.
    ///  'all' : stack all values, irrespective of the signs of the current or cumulative stacked value.
    ///  'positive' : only stack positive values.
    ///  'negative' : only stack negative values.
    /// ]]>
    /// </summary>
    [JsonPropertyName("stackStrategy")]
    [DefaultValue("samesign")]
    public StackStrategy? StackStrategy { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Stack order.
    /// Optional values:   'seriesAsc' (default, stack in series order)  'seriesDesc' (reverse stack order)   
    /// Note:  stackOrder should be defined for all series with the same stack name.
    /// If stackOrder is defined for only some of the series, the stack order may change unexpectedly when certain series are hidden (e.g., through legend toggle).
    ///  
    /// Not supported in polar coordinate system.
    /// ]]>
    /// </summary>
    [JsonPropertyName("stackOrder")]
    [DefaultValue("seriesAsc")]
    public string? StackOrder { get; set; } 

    /// <summary>
    /// The mouse style when mouse hovers on an element, the same as cursor property in CSS .
    /// </summary>
    [JsonPropertyName("cursor")]
    [DefaultValue("pointer")]
    public string? Cursor { get; set; } 

    /// <summary>
    /// Whether to connect the line across null points.
    /// </summary>
    [JsonPropertyName("connectNulls")]
    [DefaultValue(false)]
    public bool? ConnectNulls { get; set; } 

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
    /// Since v5.2.2   
    /// Whether line and area can trigger the event.
    /// </summary>
    [JsonPropertyName("triggerLineEvent")]
    [DefaultValue(false)]
    public bool? TriggerLineEvent { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Whether to show as a step line.
    /// It can be true , false .
    /// Or 'start' , 'middle' , 'end' .
    /// Which will configure the turn point of step line.
    ///  
    /// See the example using different step options:
    /// ]]>
    /// </summary>
    [JsonPropertyName("step")]
    [DefaultValue(false)]
    public Step? Step { get; set; } 

    /// <summary>
    /// Text label of , to explain some data information about graphic item like value, name and so on.
    /// label is placed under itemStyle in ECharts 2.x.
    /// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
    /// </summary>
    [JsonPropertyName("label")]
    public Label? Label { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// Label on the end of line.
    /// </summary>
    [JsonPropertyName("endLabel")]
    public EndLabel? EndLabel { get; set; } 

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
    /// The style of the symbol point of broken line.
    /// </summary>
    [JsonPropertyName("itemStyle")]
    public ItemStyle? ItemStyle { get; set; } 

    /// <summary>
    /// Line style.
    /// </summary>
    [JsonPropertyName("lineStyle")]
    public LineStyle? LineStyle { get; set; } 

    /// <summary>
    /// The style of area.
    /// </summary>
    [JsonPropertyName("areaStyle")]
    public AreaStyle? AreaStyle { get; set; } 

    /// <summary>
    /// Highlight style of the graphic.
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
    /// Whether to show as smooth curve.
    ///  
    /// If is typed in boolean , then it means whether to enable smoothing.
    /// If is typed in number , valued from 0 to 1, then it means smoothness.
    /// A smaller value makes it less smooth.
    ///  
    /// Please refer to smoothMonotone to change smoothing algorithm.
    /// </summary>
    [JsonPropertyName("smooth")]
    [DefaultValue(false)]
    public NumberOrBool? Smooth { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Whether the broken line keep the monotonicity when it is smoothed.
    /// It can be set as 'x' , 'y' to keep the monotonicity on x axis or y axis.
    ///  
    /// It is usually used on dual value axis.
    ///  
    /// Here are 2 examples of broken line chart with dual value axis, showing the differences when smoothMonotone is without any setting, and smoothMonotone is set as 'x' .
    ///   No setting about smoothMonotone :   
    ///   It is set as 'x' :
    /// ]]>
    /// </summary>
    [JsonPropertyName("smoothMonotone")]
    public string? SmoothMonotone { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// The downsampling strategy used when the data size is much larger than pixel size.
    /// It will improve the performance when turned on.
    /// Defaults to be turned off, indicating that all the data points will be drawn.
    ///  
    /// Options:   'lttb' Use Largest-Triangle-Three-Bucket algorithm to filter points.
    /// It will keep the trends and extremas.
    ///  'average' Use average value of filter points  'min' Use minimum value of filter points  'max' Use maximum value of filter points  'minmax' Use maximum extremum absolute value of filter points (Since v5.5.0 )  'sum' Use sum of filter points
    /// ]]>
    /// </summary>
    [JsonPropertyName("sampling")]
    public string? Sampling { get; set; } 

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
    /// A group ID assigned to all data items in the series.
    ///  
    /// This option has a lower priority than groupId , which means when groupId is specified for a certain data item the dataGroupId will be simply ignored for that data item.
    /// For more information, please see series.data.groupId .
    /// </summary>
    [JsonPropertyName("dataGroupId")]
    public string? DataGroupId { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Data array of series, which can be in the following forms:  
    /// Notice, if no data specified in series, and there is dataset in option, series will use the first dataset as its datasource.
    /// If data has been specified, dataset will not used.
    ///  
    /// series.datasetIndex can be used to specify other dataset .
    ///  
    /// Basically, data is represented by a two-dimension array, like the example below, where each column is named as a "dimension".
    ///  series: [{
    ///     data: [
    ///         // dimX   dimY   other dimensions ...
    ///         [  3.4,    4.5,   15,   43],
    ///         [  4.2,    2.3,   20,   91],
    ///         [  10.8,   9.5,   30,   18],
    ///         [  7.2,    8.8,   18,   57]
    ///     ]
    /// }]   In cartesian (grid) , "dimX" and "dimY" correspond to xAxis and yAxis respectively.
    ///  In polar "dimX" and "dimY" correspond to radiusAxis and angleAxis respectively.
    ///  Other dimensions are optional, which can be used in other places.
    /// For example:  visualMap can map one or more dimensions to visual (color, symbol size ...).
    ///  series.symbolSize can be set as a callback function, where symbol size can be calculated by values of a certain dimension.
    ///  Values in other dimensions can be shown by tooltip.formatter or series.label.formatter .
    ///     
    /// Especially, when there is one and only one category axis (axis.type is 'category' ), data can be simply be represented by a one-dimension array, like:  xAxis: {
    ///     data: ['a', 'b', 'm', 'n']
    /// },
    /// series: [{
    ///     // Each item corresponds to each item in xAxis.data.
    ///     data: [23,  44,  55,  19]
    ///     // In fact, it is the simplification of the format below:
    ///     // data: [[0, 23], [1, 44], [2, 55], [3, 19]]
    /// }]  
    /// 
    ///  Relationship between "value" and axis.type   
    /// When a dimension corresponds to a value axis (axis.type is 'value' or 'log' ):  
    /// The value can be a number (like 12 ) (can also be a number in a string format, like '12' ).
    ///   
    /// When a dimension corresponds to a category axis (axis.type is 'category' ):  
    /// The value should be the ordinal of the axis.data (based on 0 ), the string value of the axis.data.
    /// For example:  xAxis: {
    ///       type: 'category',
    ///       data: ['Monday', 'Tuesday', 'Wednesday', 'Thursday']
    ///   },
    ///   yAxis: {
    ///       type: 'category',
    ///       data: ['a', 'b', 'm', 'n', 'p', 'q']
    ///   },
    ///   series: [{
    ///       data: [
    ///           // xAxis      yAxis
    ///           [  0,           0,    2  ], // This point is located at xAxis: 'Monday', yAxis: 'a'.
    ///           [  'Thursday',  2,    1  ], // This point is located at xAxis: 'Thursday', yAxis: 'm'.
    ///           [  2,          'p',   2  ], // This point is located at xAxis: 'Wednesday', yAxis: 'p'.
    ///           [  3,           3,    5  ]
    ///       ]
    ///   }]  
    /// There is an example of double category axes: Github Punchcard .
    ///   
    /// When a dimension corresponds to a time axis (type is 'time' ), the value can be:   a timestamp, like 1484141700832 , which represents a UTC time.
    ///  a date string, in one of the formats below:  a subset of ISO 8601 , only including (all of these are treated as local time unless timezone is specified, which is consistent with moment ):  only part of year/month/date/time are specified: '2012-03' , '2012-03-01' , '2012-03-01 05' , '2012-03-01 05:06' .
    ///  separated by "T" or a space: '2012-03-01T12:22:33.123' , '2012-03-01 12:22:33.123' .
    ///  timezone specified: '2012-03-01T12:22:33Z' , '2012-03-01T12:22:33+8000' , '2012-03-01T12:22:33-05:00' .
    ///    other date string format (all of these are treated as local time): '2012' , '2012-3-1' , '2012/3/1' , '2012/03/01' , '2009/6/12 2:00' , '2009/6/12 2:05:08' , '2009/6/12 2:05:08.123' .
    ///    a JavaScript Date instance created by user:  Caution, when using a data string to create a Date instance, browser differences and inconsistencies should be considered.
    ///  For example: In chrome, new Date('2012-01-01') is treated as a Jan 1st 2012 in UTC, while new Date('2012-1-1') and new Date('2012/01/01') are treated as Jan 1st 2012 in local timezone.
    /// In safari new Date('2012-1-1') is not supported.
    ///  So if you intent to perform new Date(dateString) , it is strongly recommended to use a time parse library (e.g., moment ), or use echarts.time.parse , or check this .
    ///       
    /// 
    ///  Customize a data item:  
    /// When needing to customize a data item, it can be set as an object, where property value represent real value.
    /// For example:  [
    ///     12,
    ///     24,
    ///     {
    ///         value: [24, 32],
    ///         // label style, only works in this data item.
    ///         label: {},
    ///         // item style, only works in this data item.
    ///         itemStyle:{}
    ///     },
    ///     33
    /// ]
    /// // Or
    /// [
    ///     [12, 332],
    ///     [24, 32],
    ///     {
    ///         value: [24, 32],
    ///         // label style, only works in this data item.
    ///         label: {},
    ///         // item style, only works in this data item.
    ///         itemStyle:{}
    ///     },
    ///     [33, 31]
    /// ]  
    /// 
    ///  Empty value:  
    /// '-' or null or undefined or NaN can be used to describe that a data item does not exist (ps： not exist does not means its value is 0 ).
    ///  
    /// For example, line chart can break when encounter an empty value, and scatter chart do not display graphic elements for empty values.
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
    /// zlevel value of all graphical elements in Line.
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
    /// z value of all graphical elements in Line, which controls order of drawing graphical components.
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
    [DefaultValue("linear")]
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
