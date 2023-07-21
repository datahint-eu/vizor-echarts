// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class MarkPoint
{
	/// <summary>
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
	/// </summary>
	[JsonPropertyName("symbol")]
	[DefaultValue("circle")]
	public StringOrFunction? Symbol { get; set; } 

	/// <summary>
	/// symbol size.
	/// It can be set to single numbers like 10 , or use an array to represent width and height.
	/// For example, [20, 10] means symbol width is 20 , and height is 10 .
	///  
	/// If size of symbols needs to be different, you can set with callback function in the following format:  (value: Array|number, params: Object) => number|Array  
	/// The first parameter value is the value in data , and the second parameter params is the rest parameters of data item.
	/// </summary>
	[JsonPropertyName("symbolSize")]
	[DefaultValue(50)]
	//TODO: Type Warning: Failed to map property 'symbolSize' in type 'markPoint' with types 'array,function,number'
	public object? SymbolSize { get; set; } 

	/// <summary>
	/// Rotate degree of  symbol.
	/// The negative value represents clockwise.
	/// Note that when symbol is set to be 'arrow' in markLine , symbolRotate value will be ignored, and compulsively use tangent angle.
	///  
	/// If rotation of symbols needs to be different, you can set with callback function in the following format:  (value: Array|number, params: Object) => number  
	/// The first parameter value is the value in data , and the second parameter params is the rest parameters of data item.
	///   
	/// Callback is supported since 4.8.0 .
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
	/// Offset of  symbol relative to original position.
	/// By default, symbol will be put in the center position of data.
	/// But if symbol is from user-defined vector path or image, you may not expect symbol to be in center.
	/// In this case, you may use this attribute to set offset to default position.
	/// It can be in absolute pixel value, or in relative percentage value.
	///  
	/// For example, [0, '-50%'] means to move upside side position of symbol height.
	/// It can be used to make the arrow in the bottom to be at data position when symbol is pin.
	/// </summary>
	[JsonPropertyName("symbolOffset")]
	[DefaultValue("[0, 0]")]
	public double[]? SymbolOffset { get; set; } 

	/// <summary>
	/// Whether to ignore mouse events.
	/// Default value is false, for triggering and responding to mouse events.
	/// </summary>
	[JsonPropertyName("silent")]
	[DefaultValue(false)]
	public bool? Silent { get; set; } 

	/// <summary>
	/// Label of mark point.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// Mark point style.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// Emphasis status of mark point.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Configurations of blur state.
	/// Whether to blur follows the series.
	/// </summary>
	[JsonPropertyName("blur")]
	public Blur? Blur { get; set; } 

	/// <summary>
	/// Data array for mark points, each of which is an object.
	/// Here are some ways to assign mark point position.
	///   Assign coordinate according to container with x , y attribute, in which pixel values and percentage are supported.
	///    
	/// Assign coordinate position with coord attribute, in which 'min' , 'max' , 'average' are supported for each dimension.
	///   
	/// Use type attribute to mark the maximum and minimum values in the series, in which valueIndex or valueDim can be used to assign the dimension.
	///    
	/// When multiple attributes exist, priority is as the above order.
	///  
	/// For example:  data: [
	///     {
	///         name: 'maximum',
	///         type: 'max'
	///     }, 
	///     {
	///         name: 'coordinate',
	///         coord: [10, 20]
	///     }, {
	///         name: 'fixed x position',
	///         yAxis: 10,
	///         x: '90%'
	///     }, 
	/// 
	///     {
	///         name: 'screen coordinate',
	///         x: 100,
	///         y: 100
	///     }
	/// ]
	/// </summary>
	[JsonPropertyName("data")]
	public List<MarkPointData>? Data { get; set; } 

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

}
