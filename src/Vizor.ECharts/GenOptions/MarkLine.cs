// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class MarkLine
{
	/// <summary>
	/// Whether to ignore mouse events.
	/// Default value is false, for triggering and responding to mouse events.
	/// </summary>
	[JsonPropertyName("silent")]
	[DefaultValue(false)]
	public bool? Silent { get; set; } 

	/// <summary>
	/// Symbol type at the two ends of the mark line.
	/// It can be an array for two ends, or assigned seperately.
	/// See data.symbol for more format information.
	/// </summary>
	[JsonPropertyName("symbol")]
	public Icon? Symbol { get; set; } 

	/// <summary>
	/// Symbol size at the two ends of the mark line.
	/// It can be an array for two ends, or assigned seperately.
	///  
	/// Attention: You cannot assgin width and height seperately as normal symbolSize .
	/// </summary>
	[JsonPropertyName("symbolSize")]
	public NumberOrNumberArray? SymbolSize { get; set; } 

	/// <summary>
	/// Precision of marking line value, which is useful when displaying average value mark line.
	/// </summary>
	[JsonPropertyName("precision")]
	[DefaultValue(2)]
	public double? Precision { get; set; } 

	/// <summary>
	/// Mark line text.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// Mark line style.
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

	/// <summary>
	/// Emphasis status of mark line.
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
	/// Data array of marking line.
	/// Every array item can be an array of one or two values, representing starting and ending point of the line, and every item is an object.
	/// Here are several ways to assign the positions of starting and ending point.
	///   Assign coordinate according to container with x , y attribute, in which pixel values and percentage are supported.
	///    
	/// Assign coordinate position with coord attribute, in which 'min' , 'max' , 'average' are supported for each dimension.
	///   
	/// Use type attribute to mark the maximum and minimum values in the series, in which valueIndex or valueDim can be used to assign the dimension.
	///   
	/// You may also create a mark line in Cartesian coordinate at a specific position in X or Y axis by assigning xAxis or yAxis .
	/// See scatter-weight for example.
	///    
	/// When multiple attributes exist, priority is as the above order.
	///  
	/// You may also set the type of mark line through type , stating whether it is for the maximum value or average value.
	/// Likewise, dimensions can be assigned through valueIndex .
	///  data: [
	/// 
	/// {
	///         name: 'average line',
	///         // 'average', 'min', and 'max' are supported
	///         type: 'average'
	///     },
	///     {
	///         name: 'Horizontal line with Y value at 100',
	///         yAxis: 100
	///     },
	///     [
	///         {
	///             // Use the same name with starting and ending point
	///             name: 'Minimum to Maximum',
	///             type: 'min'
	///         },
	///         {
	///             type: 'max'
	///         }
	///     ],
	/// [
	///         {
	///             name: 'Markline between two points',
	///             coord: [10, 20]
	///         },
	///         {
	///             coord: [20, 30]
	///         }
	///     ], [{
	///         // Mark line with a fixed X position in starting point.
	/// This is used to generate an arrow pointing to maximum line.
	///         yAxis: 'max',
	///         x: '90%'
	///     }, {
	///         type: 'max'
	///     }],
	/// [
	///         {
	///             name: 'Mark line between two points',
	///             x: 100,
	///             y: 100
	///         },
	///         {
	///             x: 500,
	///             y: 200
	///         }
	///     ]
	/// ]
	/// </summary>
	[JsonPropertyName("data")]
	public object? Data { get; set; } 

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
