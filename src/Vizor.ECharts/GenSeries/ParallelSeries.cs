// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class ParallelSeries
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("parallel")]
	public string? Type { get; set; }  = "parallel";

	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; } 

	/// <summary>
	/// The coordinate used in the series, whose options are:   
	/// 'parallel'  
	/// Use parallel coordinates, with parallelIndex to assign the corresponding parallel coordinate components.
	/// </summary>
	[JsonPropertyName("coordinateSystem")]
	[DefaultValue("parallel")]
	public string? CoordinateSystem { get; set; } 

	/// <summary>
	/// Index of parallel coordinates to combine with, which is useful for multiple parallel axes in one chart.
	/// </summary>
	[JsonPropertyName("parallelIndex")]
	[DefaultValue(0)]
	public int? ParallelIndex { get; set; } 

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
	/// Line style.
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

	/// <summary>
	/// When perform brush selection, the unselected lines will be set as this transparency rate (which could darken those lines).
	/// </summary>
	[JsonPropertyName("inactiveOpacity")]
	[DefaultValue("0.05")]
	public double? InactiveOpacity { get; set; } 

	/// <summary>
	/// When perform brush selection, the selected lines will be set as this transparency rate (which could highlight those lines).
	/// </summary>
	[JsonPropertyName("activeOpacity")]
	[DefaultValue("1")]
	public double? ActiveOpacity { get; set; } 

	/// <summary>
	/// Whether to update view in realtime.
	/// </summary>
	[JsonPropertyName("realtime")]
	[DefaultValue("true")]
	public bool? Realtime { get; set; } 

	//TODO: Smooth
	/// <summary>
	/// progressive specifies the amount of graphic elements that can be rendered within a frame (about 16ms) if "progressive rendering" enabled.
	///  
	/// When data amount is from thousand to more than 10 million, it will take too long time to render all of the graphic elements.
	/// Since ECharts 4, "progressive rendering" is supported in its workflow, which processes and renders data chunk by chunk alone with each frame, avoiding to block the UI thread of the browser.
	///  
	/// Set progressive: 0 to disable progressive permanently.
	/// By default, progressive is auto-enabled when data amount is bigger than progressiveThreshold .
	/// </summary>
	[JsonPropertyName("progressive")]
	[DefaultValue(500)]
	public double? Progressive { get; set; } 

	/// <summary>
	/// If current data amount is over the threshold, "progressive rendering" is enabled.
	/// </summary>
	[JsonPropertyName("progressiveThreshold")]
	[DefaultValue(3000)]
	public double? ProgressiveThreshold { get; set; } 

	/// <summary>
	/// Chunk approach, optional values:   'sequential' : slice data by data index.
	///  'mod' : slice data by mod, which make the data items of each chunk coming from all over the data, bringing better visual effect while progressive rendering.
	/// </summary>
	[JsonPropertyName("progressiveChunkMode")]
	[DefaultValue("sequential")]
	public string? ProgressiveChunkMode { get; set; } 

	/// <summary>
	/// For example, series-parallel.data is the following data:  [
	///     [1,  55,  9,   56,  0.46,  18,  6,  'good'],
	///     [2,  25,  11,  21,  0.65,  34,  9,  'excellent'],
	///     [3,  56,  7,   63,  0.3,   14,  5,  'good'],
	///     [4,  33,  7,   29,  0.33,  16,  6,  'excellent'],
	///     { // Data item can also be an Object, so that perticular settings of its line can be set here.
	///         value: [5,  42,  24,  44,  0.76,  40,  16, 'excellent']
	///         lineStyle: {...},
	///     }
	///     ...
	/// ]  
	/// In data above, each row is a "data item", and each column represents a "dimension".
	/// For example, the meanings of columns above are: "data", "AQI", "PM2.5", "PM10", "carbon monoxide level", "nitrogen dioxide level", and "sulfur dioxide level".
	/// </summary>
	[JsonPropertyName("data")]
	public List<ParallelSeriesData>? Data { get; set; } 

	/// <summary>
	/// zlevel value of all graphical elements in parallel.
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
	/// z value of all graphical elements in parallel, which controls order of drawing graphical components.
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

}
