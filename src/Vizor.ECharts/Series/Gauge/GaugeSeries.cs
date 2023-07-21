// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class GaugeSeries
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("gauge")]
	public string? Type { get; set; }  = "gauge";

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
	[DefaultValue("data")]
	public ColorBy? ColorBy { get; set; } 

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
	/// Center position of , the first of which is the horizontal position, and the second is the vertical position.
	///  
	/// Percentage is supported.
	/// When set in percentage, the item is relative to the container width, and the second item to the height.
	///  
	/// Example:  // Set to absolute pixel values
	/// center: [400, 300]
	/// // Set to relative percent
	/// center: ['50%', '50%']
	/// </summary>
	[JsonPropertyName("center")]
	[DefaultValue("[50%, 50%]")]
	public double[]? Center { get; set; } 

	/// <summary>
	/// The radius of gauge chart.
	/// It can be a percentage value of the smaller of container half width and half height, also can be an absolute value.
	/// </summary>
	[JsonPropertyName("radius")]
	[DefaultValue("75%")]
	public NumberOrString? Radius { get; set; } 

	/// <summary>
	/// Whether to enable highlighting chart when legend is being hovered.
	/// </summary>
	[JsonPropertyName("legendHoverLink")]
	[DefaultValue("true")]
	public bool? LegendHoverLink { get; set; } 

	/// <summary>
	/// The start angle of gauge chart.
	/// The direct right side of circle center is 0 degree, the right above it is 90 degree, the direct left side of it is 180 degree.
	/// </summary>
	[JsonPropertyName("startAngle")]
	[DefaultValue("225")]
	public double? StartAngle { get; set; } 

	/// <summary>
	/// The end angle of gauge chart.
	/// </summary>
	[JsonPropertyName("endAngle")]
	[DefaultValue("-45")]
	public double? EndAngle { get; set; } 

	/// <summary>
	/// Whether the scale in gauge chart increases clockwise.
	/// </summary>
	[JsonPropertyName("clockwise")]
	[DefaultValue("true")]
	public bool? Clockwise { get; set; } 

	/// <summary>
	/// Data array of  series, which can be a single data value, like:  [12, 34, 56, 10, 23]  
	/// Or, if need extra dimensions for components like visualMap to map to graphic attributes like color, it can also be in the form of array.
	/// For example:  [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]  
	/// In this case, we can assgin the second value in each array item to visualMap component.
	///  
	/// More likely, we need to assign name to each data item, in which case each item should be an object:  [{
	///     // name of date item
	///     name: 'data1',
	///     // value of date item is 8
	///     value: 10
	/// }, {
	///     name: 'data2',
	///     value: 20
	/// }]  
	/// Each data item can be further customized:  [{
	///     name: 'data1',
	///     value: 10
	/// }, {
	///     // name of data item
	///     name: 'data2',
	///     value : 56,
	///     // user-defined label format that only useful for this data item
	///     label: {},
	///     // user-defined special itemStyle that only useful for this data item
	///     itemStyle:{}
	/// }]
	/// </summary>
	[JsonPropertyName("data")]
	public List<GaugeSeriesData>? Data { get; set; } 

	/// <summary>
	/// The minimum data value which map to minAngle .
	/// </summary>
	[JsonPropertyName("min")]
	[DefaultValue("0")]
	public double? Min { get; set; } 

	/// <summary>
	/// The maximum data value which map to maxAngle .
	/// </summary>
	[JsonPropertyName("max")]
	[DefaultValue("100")]
	public double? Max { get; set; } 

	/// <summary>
	/// The number of split segments of gauge chart scale.
	/// </summary>
	[JsonPropertyName("splitNumber")]
	[DefaultValue("10")]
	public double? SplitNumber { get; set; } 

	/// <summary>
	/// The related configuration about the axis line of gauge chart.
	/// </summary>
	[JsonPropertyName("axisLine")]
	public AxisLine? AxisLine { get; set; } 

	/// <summary>
	/// Since v5.0   
	/// Used to show current progress.
	/// </summary>
	[JsonPropertyName("progress")]
	public Progress? Progress { get; set; } 

	/// <summary>
	/// The style of split line.
	/// </summary>
	[JsonPropertyName("splitLine")]
	public SplitLine? SplitLine { get; set; } 

	/// <summary>
	/// The tick line style.
	/// </summary>
	[JsonPropertyName("axisTick")]
	public AxisTick? AxisTick { get; set; } 

	/// <summary>
	/// Axis tick label.
	/// </summary>
	[JsonPropertyName("axisLabel")]
	public AxisLabel? AxisLabel { get; set; } 

	/// <summary>
	/// Gauge chart pointer.
	/// </summary>
	[JsonPropertyName("pointer")]
	public Pointer? Pointer { get; set; } 

	/// <summary>
	/// Since v5.0   
	/// The fixed point of a pointer in a dial.
	/// </summary>
	[JsonPropertyName("anchor")]
	public Anchor? Anchor { get; set; } 

	/// <summary>
	/// The style of gauge chart.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// Configurations of emphasis state.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

	/// <summary>
	/// The title of gauge chart.
	/// </summary>
	[JsonPropertyName("title")]
	public Title? Title { get; set; } 

	/// <summary>
	/// The detail about gauge chart which is used to show data.
	/// </summary>
	[JsonPropertyName("detail")]
	public Detail? Detail { get; set; } 

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
	/// tooltip settings in this series.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

}
