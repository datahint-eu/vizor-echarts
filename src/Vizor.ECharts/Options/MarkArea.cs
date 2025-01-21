
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class MarkArea
{
	/// <summary>
	/// Whether to ignore mouse events.
	/// Default value is false, for triggering and responding to mouse events.
	/// </summary>
	[JsonPropertyName("silent")]
	[DefaultValue(false)]
	public bool? Silent { get; set; }

	/// <summary>
	/// Label in mark area.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; }

	/// <summary>
	/// Style of the mark area.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; }

	/// <summary>
	/// Emphasis status of mark area.
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
	/// The scope of the area is defined by data , which is an array with two item, representing the left-top point and the right-bottom point of rectangle area.
	/// Each item can be defined as follows:   Specify the coordinate in screen coordinate system using x , y , where the unit is pixel (e.g., the value is 5 ), or percent (e.g., the value is '35%' ).
	///    
	/// Specify the coordinate in data coordinate system (i.e., cartesian) using coord , which can be also set as 'min' , 'max' , 'average' (e.g, coord: [23, 'min'] , or coord: ['average', 'max'] ).
	///   
	/// Locate the point on the min value or max value of series.data using type , where valueIndex or valueDim can be used to specify the dimension on which the min, max or average are calculated.
	///   If in cartesian, you can only specify xAxis or yAxis to define a mark area based on only X or Y axis, see sample scatter-weight   
	/// The priority follows as above if more than one above definition used.
	///  data: [
	/// 
	/// 
	///     [
	///         {
	///             name: 'From average to max',
	///             type: 'average'
	///         },
	///         {
	///             type: 'max'
	///         }
	///     ],
	/// 
	///     [
	///         {
	///             name: 'Mark area between two points in data coordiantes',
	///             coord: [10, 20]
	///         },
	///         {
	///             coord: [20, 30]
	///         }
	///     ], [
	///         {
	///             name: 'From 60 to 80',
	///             yAxis: 60
	///         },
	///         {
	///             yAxis: 80
	///         }
	///     ], [
	///         {
	///             name: 'Mark area covers all data'
	///             coord: ['min', 'min']
	///         },
	///         {
	///             coord: ['max', 'max']
	///         }
	///     ],
	/// [
	///         {
	///             name: 'Mark area in two screen points',
	///             x: 100,
	///             y: 100
	///         }, {
	///             x: '90%',
	///             y: '10%'
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
	[DefaultValue("false")]
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
