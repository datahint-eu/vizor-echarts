
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class PictorialBarSeriesData
{
	/// <summary>
	/// The name of data item.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; } 

	/// <summary>
	/// The value of a single data item.
	/// </summary>
	[JsonPropertyName("value")]
	public double? Value { get; set; } 

	/// <summary>
	/// The groupID of this data item.
	/// groupID will be used to classify the data.
	/// </summary>
	[JsonPropertyName("groupId")]
	public string? GroupId { get; set; } 

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
	public NumberOrString? SymbolMargin { get; set; } 

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
	/// Specify the relationship of overlap between graphic elements.
	/// A bigger value means higher.
	/// </summary>
	[JsonPropertyName("z")]
	public double? Z { get; set; } 

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
	/// Specify the delay time before animation start.
	/// Callback function can be used, where different delay time can be used on different element.
	///  
	/// For example:  animationDelay: function (dataIndex, params) {
	///     return params.index * 30;
	/// }
	/// // Or inverse:
	/// animationDelay: function (dataIndex, params) {
	///     return (params.count - 1 - params.index) * 30;
	/// }  
	/// For example:
	/// </summary>
	[JsonPropertyName("animationDelay")]
	[DefaultValue(0)]
	public NumberOrFunction? AnimationDelay { get; set; } 

	/// <summary>
	/// Specify the delay time before update animation.
	/// Callback function can be used, where different delay time can be used on different element.
	///  
	/// For example:  animationDelay: function (dataIndex, params) {
	///     return params.index * 30;
	/// }
	/// // Or inverse:
	/// animationDelay: function (dataIndex, params) {
	///     return (params.count - 1 - params.index) * 30;
	/// }  
	/// For example:
	/// </summary>
	[JsonPropertyName("animationDelayUpdate")]
	[DefaultValue(0)]
	public NumberOrFunction? AnimationDelayUpdate { get; set; } 

	/// <summary>
	/// The style setting of the text label in a single bar.
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
	/// 
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// Emphasis state of the specified single data.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Blur state of the specified single data.
	/// </summary>
	[JsonPropertyName("blur")]
	public Blur? Blur { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Select state of the specified single data.
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; } 

	/// <summary>
	/// tooltip settings in this series data.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

}
