
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class AxisPointer
{
	/// <summary>
	/// Indicator type.
	///  
	/// Options:   
	/// 'line' line indicator.
	///   
	/// 'shadow' shadow crosshair indicator.
	///   
	/// 'none' no indicator displayed.
	///   
	/// 'cross' crosshair indicator, which is actually the shortcut of enable two axisPointers of two orthometric axes.
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("line")]
	public AxisPointerType? Type { get; set; } 

	/// <summary>
	/// The coordinate axis, which could be 'x' , 'y' , 'radius' , or 'angle' .
	/// By default, each coordinate system will automatically chose the axes whose will display its axisPointer (category axis or time axis is used by default).
	/// </summary>
	[JsonPropertyName("axis")]
	[DefaultValue("auto")]
	public string? Axis { get; set; } 

	/// <summary>
	/// Whether snap to point automatically.
	/// The default value is auto determined.
	///  
	/// This feature usually makes sense in value axis and time axis, where tiny points can be seeked automatically.
	/// </summary>
	[JsonPropertyName("snap")]
	public bool? Snap { get; set; } 

	/// <summary>
	/// z value, which controls order of drawing graphical components.
	/// Components with smaller z values may be overwritten by those with larger z values.
	/// </summary>
	[JsonPropertyName("z")]
	public double? Z { get; set; } 

	/// <summary>
	/// label of axisPointer
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// It is valid when axisPointer.type is 'line' .
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

	/// <summary>
	/// It is valid when axisPointer.type is 'shadow' .
	/// </summary>
	[JsonPropertyName("shadowStyle")]
	public ShadowStyle? ShadowStyle { get; set; } 

	/// <summary>
	/// It is valid when axisPointer.type is 'cross' .
	/// </summary>
	[JsonPropertyName("crossStyle")]
	public CrossStyle? CrossStyle { get; set; } 

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
	[DefaultValue("exponentialOut")]
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
	/// axisPointer will not be displayed by default.
	/// But if tooltip.trigger is set as 'axis' or tooltip.axisPointer.type is set as 'cross' , axisPointer will be displayed automatically.
	/// Each coordinate system will automatically chose the axes whose will display its axisPointer.
	/// tooltip.axisPointer.axis can be used to change the choice.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue(false)]
	public bool? Show { get; set; } 

	/// <summary>
	/// Since v5.4.3   
	/// Whether to trigger emphasis of series.
	/// </summary>
	[JsonPropertyName("triggerEmphasis")]
	[DefaultValue("true")]
	public bool? TriggerEmphasis { get; set; } 

	/// <summary>
	/// Whether to trigger tooltip.
	/// </summary>
	[JsonPropertyName("triggerTooltip")]
	[DefaultValue("true")]
	public bool? TriggerTooltip { get; set; } 

	/// <summary>
	/// current value.
	/// When using axisPointer.handle , value can be set to define the initial position of axisPointer.
	/// </summary>
	[JsonPropertyName("value")]
	public double? Value { get; set; } 

	/// <summary>
	/// Current status, can be 'show' 和 'hide' .
	/// </summary>
	[JsonPropertyName("status")]
	public AxisPointerStatus? Status { get; set; } 

	/// <summary>
	/// A button used to drag axisPointer.
	/// This feature is applicable in touch device.
	/// See example .
	/// </summary>
	[JsonPropertyName("handle")]
	public Handle? Handle { get; set; } 

	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; } 

	/// <summary>
	/// axisPointers can be linked to each other.
	/// The term "link" represents that axes are synchronized and move together.
	/// Axes are linked according to the value of axisPointer.
	///  
	/// See sampleA and sampleB .
	///  
	/// link is an array, where each item represents a "link group".
	/// Axes will be linked when they are refered in the same link group.
	/// For example:  link: [
	///     {
	///         // All axes with xAxisIndex 0, 3, 4 and yAxisName 'sameName' will be linked.
	///         xAxisIndex: [0, 3, 4],
	///         yAxisName: 'someName'
	///     },
	///     {
	///         // All axes with xAxisId 'aa', 'cc' and all angleAxis will be linked.
	///         xAxisId: ['aa', 'cc'],
	///         angleAxis: 'all'
	///     },
	///     ...
	/// ]  
	/// As illustrated above, axes can be refered in these approaches in a link group:  {
	///     // 'some' represent the dimension name of a axis, namely, 'x', 'y', 'radius', 'angle', 'single'
	///     someAxisIndex: [...], // can be an array or a value or 'all'
	///     someAxisName: [...],  // can be an array or a value or 'all'
	///     someAxisId: [...],    // can be an array or a value or 'all'
	/// }    
	/// How to link axes with different axis.type ?  
	/// For example, the type of axisA is 'category', and the type of axisB type is 'time', we can write conversion function (mapper) in link group to convert values from an axis to another axis.
	/// For example:  link: [{
	///     xAxisIndex: [0, 1],
	///     yAxisName: ['yy'],
	///     mapper: function (sourceVal, sourceAxisInfo, targetAxisInfo) {
	///         if (sourceAxisInfo.axisName === 'yy') {
	///             // from timestamp to '2012-02-05'
	///             return echarts.time.format('yyyy-MM-dd', sourceVal);
	///         }
	///         else if (targetAxisInfo.axisName === 'yy') {
	///             // from '2012-02-05' to date
	///             return echarts.time.parse(dates[sourceVal]);
	///         }
	///         else {
	///             return sourceVal;
	///         }
	///     }
	/// }]  
	/// Input parameters of mapper:  
	/// {number} sourceVal  
	/// {Object} sourceAxisInfo Including {axisDim, axisId, axisName, axisIndex, ...}  
	/// {Object} targetAxisInfo Including {axisDim, axisId, axisName, axisIndex, ...}  
	/// Return of mapper:  
	/// {number} The result of conversion.
	/// </summary>
	[JsonPropertyName("link")]
	public List<AxisPointerLink>? Link { get; set; } 

	/// <summary>
	/// Conditions to trigger tooltip.
	/// Options:   
	/// 'mousemove'  
	/// Trigger when mouse moves.
	///   
	/// 'click'  
	/// Trigger when mouse clicks.
	///   
	/// 'mousemove|click'  
	/// Trigger when mouse clicks and moves.
	///   
	/// 'none'  
	/// Do not triggered by 'mousemove' and 'click'
	/// </summary>
	[JsonPropertyName("triggerOn")]
	[DefaultValue("mousemove|click")]
	public TriggerOn? TriggerOn { get; set; } 

}
