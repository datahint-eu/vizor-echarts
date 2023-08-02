
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class PictorialBarSeries
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("pictorialBar")]
	public string? Type { get; set; }  = "pictorialBar";

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
	/// Since v5.2.0   
	/// The policy to take color from option.color .
	/// Valid values:   'series' : assigns the colors in the palette by series, so that all data in the same series are in the same color;  'data' : assigns colors in the palette according to data items, with each data item using a different color.
	/// </summary>
	[JsonPropertyName("colorBy")]
	[DefaultValue("series")]
	public ColorBy? ColorBy { get; set; } 

	/// <summary>
	/// Whether to enable highlighting chart when legend is being hovered.
	/// </summary>
	[JsonPropertyName("legendHoverLink")]
	[DefaultValue("true")]
	public bool? LegendHoverLink { get; set; } 

	/// <summary>
	/// The coordinate used in the series, whose options are:   
	/// 'cartesian2d'  
	/// Use a two-dimensional rectangular coordinate (also known as Cartesian coordinate), with xAxisIndex and yAxisIndex to assign the corresponding axis component.
	/// </summary>
	[JsonPropertyName("coordinateSystem")]
	[DefaultValue("cartesian2d")]
	public string? CoordinateSystem { get; set; } 

	/// <summary>
	/// Index of x axis to combine with, which is  useful for multiple x axes in one chart.
	/// </summary>
	[JsonPropertyName("xAxisIndex")]
	[DefaultValue(0)]
	public int? XAxisIndex { get; set; } 

	/// <summary>
	/// Index of y axis to combine with, which is  useful for multiple y axes in one chart.
	/// </summary>
	[JsonPropertyName("yAxisIndex")]
	[DefaultValue(0)]
	public int? YAxisIndex { get; set; } 

	/// <summary>
	/// The mouse style when mouse hovers on an element, the same as cursor property in CSS .
	/// </summary>
	[JsonPropertyName("cursor")]
	[DefaultValue("pointer")]
	public string? Cursor { get; set; } 

	/// <summary>
	/// Text label of , to explain some data information about graphic item like value, name and so on.
	/// label is placed under itemStyle in ECharts 2.x.
	/// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Configuration of label guide line.
	/// </summary>
	[JsonPropertyName("labelLine")]
	public LabelLine? LabelLine { get; set; } 

	/// <summary>
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
	/// Since v5.0.0   
	/// Selected mode.
	/// It is enabled by default, and you may set it to be false to disable it.
	///  
	/// Besides, it can be set to 'single' , 'multiple' or 'series' , for single selection, multiple selections and whole series selection.
	///   
	/// 'series' is supported since v5.3.0
	/// </summary>
	[JsonPropertyName("selectedMode")]
	[DefaultValue(false)]
	public SelectionMode? SelectedMode { get; set; } 

	/// <summary>
	/// The width of the bar.
	/// Adaptive when not specified.
	///  
	/// Can be an absolute value like 40 or a percent value like '60%' .
	/// The percent is based on the calculated category width.
	///  
	/// In a single coodinate system, this attribute is shared by multiple 'pictorialBar' series.
	/// This attribute should be set on the last 'pictorialBar' series in the coodinate system, then it will be adopted by all 'pictorialBar' series in the coordinate system.
	/// </summary>
	[JsonPropertyName("barWidth")]
	public NumberOrString? BarWidth { get; set; } 

	/// <summary>
	/// The maximum width of the bar.
	///  
	/// Has higer priority than barWidth .
	///  
	/// Can be an absolute value like 40 or a percent value like '60%' .
	/// The percent is based on the calculated category width.
	///  
	/// In a single coodinate system, this attribute is shared by multiple 'pictorialBar' series.
	/// This attribute should be set on the last 'pictorialBar' series in the coodinate system, then it will be adopted by all 'pictorialBar' series in the coordinate system.
	/// </summary>
	[JsonPropertyName("barMaxWidth")]
	public NumberOrString? BarMaxWidth { get; set; } 

	/// <summary>
	/// The minimum width of the bar.
	/// In cartesian the default value is 1 , otherwise the default value if null .
	///  
	/// Has higer priority than barWidth .
	///  
	/// Can be an absolute value like 40 or a percent value like '60%' .
	/// The percent is based on the calculated category width.
	///  
	/// In a single coodinate system, this attribute is shared by multiple 'pictorialBar' series.
	/// This attribute should be set on the last 'pictorialBar' series in the coodinate system, then it will be adopted by all 'pictorialBar' series in the coordinate system.
	/// </summary>
	[JsonPropertyName("barMinWidth")]
	public NumberOrString? BarMinWidth { get; set; } 

	/// <summary>
	/// The minimum width of bar.
	/// It could be used to avoid the following situation: the interaction would be affected when the value of some data item is too small.
	/// </summary>
	[JsonPropertyName("barMinHeight")]
	[DefaultValue(0)]
	public double? BarMinHeight { get; set; } 

	/// <summary>
	/// The minimum angle of bar.
	/// It could be used to avoid the following situation: the interaction would be affected when the value of some data item is too small.
	/// Valid only for bar series on polar coordinates.
	/// </summary>
	[JsonPropertyName("barMinAngle")]
	[DefaultValue(0)]
	public double? BarMinAngle { get; set; } 

	/// <summary>
	/// The gap between bars between different series, is a percent value like '30%' , which means 30% of the bar width.
	///  
	/// Set barGap as '-100%' can overlap bars that belong to different series, which is useful when making a series of bar be background.
	///  
	/// In a single coodinate system, this attribute is shared by multiple 'pictorialBar' series.
	/// This attribute should be set on the last 'pictorialBar' series in the coodinate system, then it will be adopted by all 'pictorialBar' series in the coordinate system.
	///  
	/// For example:
	/// </summary>
	[JsonPropertyName("barGap")]
	[DefaultValue("-100%")]
	public string? BarGap { get; set; } 

	/// <summary>
	/// The bar gap of a single series, defaults to be 20% of the category gap, can be set as a fixed value.
	///  
	/// In a single coodinate system, this attribute is shared by multiple 'pictorialBar' series.
	/// This attribute should be set on the last 'pictorialBar' series in the coodinate system, then it will be adopted by all 'pictorialBar' series in the coordinate system.
	/// </summary>
	[JsonPropertyName("barCategoryGap")]
	[DefaultValue("20%")]
	public string? BarCategoryGap { get; set; } 

	/// <summary>
	/// Specify the type of graphic elements.
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
	/// Example:   
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     symbol: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         symbol: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         symbol: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("symbol")]
	[DefaultValue("circle")]
	public string? Symbol { get; set; } 

	/// <summary>
	/// Symbol size.
	///  
	/// It can be set as a array, which means [width, height].
	/// For example, [20, 10] means width 20 and height 10 .
	/// It can also be set as a single number, like 10 , which is equivalent to [10, 10] .
	///  
	/// Absolute value can be used (like 10 ), or percent value can be used (like '120%' , ['55%', 23] ).
	///  
	/// When percent value is used, final size of the graphic element is calculated based on its reference bar .
	///  
	/// For example, there is a reference bar based on x axis (that is, it is a vertical bar), and symbolSize is set as ['30%', '50%'] , the final size of its graphic elements is:   width: <width of reference bar> * 30% .
	///  height:  If symbolRepeat is used: <height of reference bar> * 50% .
	///  If symbolRepeat is not used: <height of reference bar> * 50% .
	///     
	/// Analogously, the case that based on y axis can be obtained by exchanging them.
	///  
	/// For example:   
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     symbolSize: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         symbolSize: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         symbolSize: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("symbolSize")]
	[DefaultValue("100%,100%")]
	public NumberOrNumberArray? SymbolSize { get; set; } 

	/// <summary>
	/// Specify the location of the graphic elements.
	/// Optional values:   'start' : The edge of graphic element inscribes with the start of the reference bar.
	///  'end' : The edge of graphic element inscribes with the end of the reference bar.
	///  'center' : The graphic element is at the center of the reference bar.
	///   
	/// For example:   
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     symbolPosition: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         symbolPosition: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         symbolPosition: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("symbolPosition")]
	[DefaultValue("start")]
	public StartOrEndOrCenter? SymbolPosition { get; set; } 

	/// <summary>
	/// Specify the offset of graphic element according to its original position.
	/// Adopting symbolOffset is the final step in layout, which enables adjustment of graphic element position.
	///  
	/// A absolute value can be set (like 10 ), or a percent value can be set (like '120%' 、 ['55%', 23] ), which is based on its symbolSize .
	///  
	/// For example, [0, '-50%'] means the graphic element will be adjusted upward half of the size of itself.
	///  
	/// For example:   
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     symbolOffset: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         symbolOffset: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         symbolOffset: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("symbolOffset")]
	[DefaultValue("0,0")]
	public double[]? SymbolOffset { get; set; } 

	/// <summary>
	/// The degree of the rotation of a graphic element.
	///  
	/// Notice, symbolRotate will not affect the position of the graphic element, but just rotating by its center.
	///  
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     symbolRotate: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         symbolRotate: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         symbolRotate: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("symbolRotate")]
	public double? SymbolRotate { get; set; } 

	/// <summary>
	/// Whether to repeat a graphic element.
	/// Optional values:   false / null / undefined : Do not repeat, that is, each graphic element represents a data item.
	///  true : Repeat, that is, a group of repeated graphic elements represent a data item.
	/// The repeat times is calculated according to data .
	///  a number: Repeat, that is a group of repeated graphic elements represent a data item.
	/// The repeat times is always the given number.
	///  'fixed' : Repeat, that is a group of repeated graphic elements represent a data item.
	/// The repeat times is calcuated according to symbolBoundingData , that is, the repeat times has nothing to do with data .
	/// The setting is useful when graphic elements are used as background.
	///   
	/// For example:   
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     symbolRepeat: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         symbolRepeat: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         symbolRepeat: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("symbolRepeat")]
	public PictorialSymbolRepeat? SymbolRepeat { get; set; } 

	/// <summary>
	/// When symbolRepeat is used, symbolRepeatDirection specifies the render order of the repeated graphic elements.
	/// The setting is useful in these cases below:   
	/// If symbolMargin is set as a negative value, repeated elements will overlap with each other.
	/// symbolRepeatDirection can be used to specify the order of overlap.
	///   
	/// If animationDelay or animationDelayUpdate is used, symbolRepeatDirection specifies the order of index.
	///    
	/// Optional values can be 'start' and 'end' .
	///  
	/// For example:   
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     symbolRepeatDirection: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         symbolRepeatDirection: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         symbolRepeatDirection: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("symbolRepeatDirection")]
	[DefaultValue("start")]
	public StartOrEnd? SymbolRepeatDirection { get; set; } 

	/// <summary>
	/// Specify margin of both sides of a graphic element.
	/// ("both sides" means the two sides in the direction of its value axis).
	/// It works only when symbolRepeat is used.
	///  
	/// Absolute value can be used (like 20 ), or percent value can be used (like '-30%' ), which is based on its symbolSize .
	///  
	/// symbolMargin can be positive value or negative value, which enables overlap of graphic elements when symbolRepeat is used.
	///  
	/// A "!" can be appended on the end of the value, like "30%!" or 25! , which means a extra blank will be added on the both ends, otherwise the graphic elements on both ends will reach the boundary by default.
	///  
	/// Notice:   When symbolRepeat is true / 'fixed' :
	///   The given symbolMargin is just a reference value.
	/// The final gap of graphic elements will be calculated according to symbolRepeat , symbolMargin and symbolBoundingData .
	///  When symbolRepeat is set as a number: symbolMargin does not work any more.
	///   
	/// For example:   
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     symbolMargin: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         symbolMargin: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         symbolMargin: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("symbolMargin")]
	[DefaultValue("0,0")]
	//TODO: Type Warning: Failed to map property 'symbolMargin' in type 'PictorialBarSeries' with types 'number,percentvector,string'
	public object? SymbolMargin { get; set; } 

	/// <summary>
	/// Whether to clip graphic elements.
	///   false /null/undefined: The whole graphic elements represent the size of value.
	///  true : The clipped graphic elements reperent the size of value.
	///   
	/// symbolClip is usually used in this case: both "amount value" and "current value" should be displayed.
	/// In this case, tow series can be used.
	/// One for background, using complete graphic elements, while another for current value, using clipped graphic elements.
	///  
	/// For example:   
	/// Notice, in the example above,   The same symbolBoundingData is used in "background series" and "current value seires", which makes their graphic elements are the same size.
	///  A bigger z is set on "current value series", which makes it is over "background series".
	///   
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     symbolClip: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         symbolClip: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         symbolClip: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("symbolClip")]
	[DefaultValue(false)]
	public bool? SymbolClip { get; set; } 

	/// <summary>
	/// Defines a bounding area availble for the graphic elements.
	/// This setting gives a data, which will then be translated to a coordinate on the coordinate system.
	/// The coordinate specifies the bounding.
	/// Namely, if symbolBoundingData is set, the final size (or layout) of the graphic elements depend on the symbolBoundingData .
	///  
	/// When reference bar is horizontal, symbolBoundingData is coresponding to x axis, while reference bar is vertical, symbolBoundingData is coresponding to y axis.
	///  
	/// Rule:   
	/// If symbolRepeat is not used:  
	///  symbolBoundingData is the same as the size of reference bar by default.
	/// The size of the graphic element is detemined by symbolBoundingData .
	/// For example, if reference bar is vertical, its data is 24 , symbolSize is set as [30, '50%'] , symbolBoundingData is set as 124 , the final size of the graphic element will be 124 * 50% = 62 .
	/// If symbolBoundingData is not set, the final size will be 24 * 50% = 12 .
	///   
	/// If symbolRepeat is used:  
	///  symbolBoundingData is the extreme value of the coordinate system.
	/// symbolBoundingData defines a bounding area, where repeated graphic elements layout according to symbolMargin and symbolRepeat and symbolSize .
	/// Both these settings determine the gap size of the repeated graphic elements.
	///    
	/// symbolBoundingData is usually used in these cases:   
	/// When symbolCilp is used:  
	/// And a series is used to display "amont value", while another series is used to display "current value".
	/// symbolBoundingData can be used to ensure that the graphic elements of these two series are at the same size.
	///    
	/// For example:    
	/// When symbolRepeat is used:  
	///  symbolBoundingData can be use to ensure the gaps of the elements in different bars are the same.
	/// Of cource, you can do not set symbolBoundingData , whose default value is a stable value (extreme value of the coordinate system).
	///    
	/// For example:   
	/// 
	///  symbolBoundingData can also be an array, such as [-40, 60] , which specifies both negative and positive symbolBoundingData.
	///  
	/// Check this example:   
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     symbolBoundingData: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         symbolBoundingData: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         symbolBoundingData: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("symbolBoundingData")]
	public double? SymbolBoundingData { get; set; } 

	/// <summary>
	/// Image can be used as the pattern of graphic elements.
	///  var textureImg = new Image();
	/// textureImg.src = 'data:image/jpeg;base64,...'; // dataURI
	/// // Or
	/// // textureImg.src = 'http://example.website/xx.png'; // URL
	/// ...
	/// itemStyle: {
	///     color: {
	///         image: textureImg,
	///         repeat: 'repeat'
	///     }
	/// }  
	/// symbolPatternSize specifies the size of pattern image.
	/// For example, if symbolPatternSize is 400 , the pattern image will be displayed at the size of 400px * 400px .
	///  
	/// For example:   
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     symbolPatternSize: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         symbolPatternSize: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         symbolPatternSize: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("symbolPatternSize")]
	[DefaultValue("400")]
	public double? SymbolPatternSize { get; set; } 

	/// <summary>
	/// Whether to enable hover animation.
	///  
	/// This attribute can be set at the root level of a series , where all data items in the series will be affected by this attribute.
	/// And this attribute can also be set at each data item in series-pictorialBar.data , where only the data item is affected by this attribute.
	///  
	/// For example:  series: [{
	///     hoverAnimation: ...
	/// // Affect all data items.
	///     data: [23, 56]
	/// }]
	/// // Or
	/// series: [{
	///     data: [{
	///         value: 23
	///         hoverAnimation: ...
	/// // Only affect this data item.
	///     }, {
	///         value: 56
	///         hoverAnimation: ...
	/// // Only affect this data item.
	///     }]
	/// }]
	/// </summary>
	[JsonPropertyName("hoverAnimation")]
	[DefaultValue(false)]
	public bool? HoverAnimation { get; set; } 

	/// <summary>
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
	///         // Specify name for each dimesions, which will be displayed in tooltip.
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
	/// When dimensions is specified, the default tooltip will be displayed vertically, which is better to show diemsion names.
	/// Otherwise, tooltip will displayed only value horizontally.
	/// </summary>
	[JsonPropertyName("dimensions")]
	//TODO: Type Warning: array type 'dimensions' in 'PictorialBarSeries' will be mapped to List<object>
	public List<object>? Dimensions { get; set; } 

	/// <summary>
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
	///     // Using dimensions[4] as the groupId of each data item.
	/// groupId will be used to categorize the data.
	/// And to determine
	///     // How the merge and split animation are performed in the universal transition.
	/// See universalTransition option for detail.
	///     itemGroupId: 4
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
	/// </summary>
	[JsonPropertyName("encode")]
	public Encode? Encode { get; set; } 

	/// <summary>
	/// A groupID common to all data in the series.
	/// the groupID will be used to classify the data and determine how merge and split animations are performed in the universal transition animation.
	///  
	/// If you are using the dataset component to represent the data, it is recommended to use encode.itemGroupID to specify which dimension is encoded as the groupID.
	/// </summary>
	[JsonPropertyName("dataGroupId")]
	public string? DataGroupId { get; set; }

	/// <summary>
	/// Data array of series.
	/// can be list of PictorialBarSeriesData, int[][], double[][], ...
	/// 
	/// Which can be in the following forms:  
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
	/// When needing to customize a data item, it can be set as an object, where property value reprensent real value.
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
	/// zlevel value of all graphical elements in Pictorial bar chart .
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
	/// z value of all graphical elements in Pictorial bar chart , which controls order of drawing graphical components.
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
	/// Since v5.2.0   
	/// Configuration related to universal transition animation.
	///  
	/// Universal Transition provides the ability to morph between any series.
	/// With this feature enabled, each time setOption , transitions between series with the same id will be automatically associated with each other.
	///  
	/// One-to-many or many-to-one animations such as drill-down, aggregation, etc.
	/// can also be achieved by specifying groups of data such as encode.itemGroupId or dataGroupId .
	///  
	/// This can be enabled directly by configuring universalTransition: true in the series.
	/// It is also possible to provide an object for more detailed configuration.
	/// </summary>
	[JsonPropertyName("universalTransition")]
	public UniversalTransition? UniversalTransition { get; set; } 

	/// <summary>
	/// tooltip settings in this series.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

}
