
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class UniversalTransition
{
	/// <summary>
	/// Wheather to enable the universal transition animation.
	/// </summary>
	[JsonPropertyName("enabled")]
	[DefaultValue(false)]
	public bool? Enabled { get; set; } 

	/// <summary>
	/// The seriesKey determines how the series to be animated is associated, it defaults to the id of the series when not configured.
	///  
	/// Usually this is configured as a string, and transitions between series with the same seriesKey will be applied.
	/// It can also be configured as an array like the following.
	///  seriesKey: ['male', 'female']  
	/// Configuring to an array means that all series specified by the array item will be merged into the current series when animating.
	/// For example, this configuration means that series with id or seriesKey of 'male' and 'female' will be merged into the current series.
	/// </summary>
	[JsonPropertyName("seriesKey")]
	public Icon? SeriesKey { get; set; } 

	/// <summary>
	/// divideShape determines how the elements in the current series will split into multiple elements in a one-to-many or many-to-one animation.
	/// Currently supports   'split' Split the shape into multiple shapes.
	///  'clone' Get multiple clones from the current element.
	///   
	/// For better results, different series will have different configurations by default, for example, scatter with smaller and more complex element uses 'clone' by default, while more regular ones like bar charts default to 'split' .
	/// You can set this to the desired splitting strategy according to the needs of your own scenario.
	/// </summary>
	[JsonPropertyName("divideShape")]
	public string? DivideShape { get; set; } 

	/// <summary>
	/// (index: number, count: number) => number  
	/// Configure the animation delay for each shape in a one-to-many or many-to-one animation.
	/// Setting different animation delays can bring a more instereting animation.
	/// For example, the following code creates a staggered effect with a random delay for each shape.
	///  delay: function (index, count) {
	///     return Math.random() * 1000;
	/// }
	/// </summary>
	[JsonPropertyName("delay")]
	public JavascriptFunction? Delay { get; set; } 

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

}
