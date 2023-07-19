// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class MarkPoint
{
	//TODO: Symbol
	//TODO: SymbolSize
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
