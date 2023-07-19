// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class AxisPointer
{
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
	/// Indicator type.
	///  
	/// Options:   
	/// 'line' line indicator.
	///   
	/// 'shadow' shadow crosshair indicator.
	///   
	/// 'none' no indicator displayed.
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("line")]
	public AxisPointerType? Type { get; set; } 

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

	//TODO: Status
	/// <summary>
	/// A button used to drag axisPointer.
	/// This feature is applicable in touch device.
	/// See example .
	/// </summary>
	[JsonPropertyName("handle")]
	public Handle? Handle { get; set; } 

}
