
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Emphasis
{
	/// <summary>
	/// Since v4.4.0
	/// </summary>
	[JsonPropertyName("selectorLabel")]
	public SelectorLabel? SelectorLabel { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("handleStyle")]
	public HandleStyle? HandleStyle { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("moveHandleStyle")]
	public MoveHandleStyle? MoveHandleStyle { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("iconStyle")]
	public IconStyle? IconStyle { get; set; }

	/// <summary>
	/// Since v5.3.0   
	/// Whether to disable the emphasis state.
	///  
	/// When emphasis state is disabled.
	/// There will be no highlight effect when the mouse hovered the element, tooltip is triggered, or the legend is hovered.
	/// It can be used to improve interaction fluency when there are massive graphic elements.
	/// </summary>
	[JsonPropertyName("disabled")]
	[DefaultValue("false")]
	public bool? Disabled { get; set; }

	/// <summary>
	/// Since v5.1.0   
	/// When the data is highlighted, whether to fade out of other data to focus the highlighted.
	/// The following configurations are supported:   'none' Do not fade out other data, it's by default.
	///  'self' Only focus (not fade out) the element of the currently highlighted data.
	///   
	/// Example:  emphasis: {
	///     focus: 'self'
	/// }
	/// </summary>
	[JsonPropertyName("focus")]
	[DefaultValue("none")]
	public string? Focus { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; }

	/// <summary>
	/// Style of the checkpoint.
	/// </summary>
	[JsonPropertyName("checkpointStyle")]
	public CheckpointStyle? CheckpointStyle { get; set; }

	/// <summary>
	/// Style of the control button.
	/// </summary>
	[JsonPropertyName("controlStyle")]
	public ControlStyle? ControlStyle { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Whether to scale to highlight the data in emphasis state.
	/// number has been supported since v5.3.2 , the default scale value is 1.1.
	/// </summary>
	[JsonPropertyName("scale")]
	[DefaultValue(true)]
	public NumberOrBool? Scale { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// The range of fade out when focus is enabled.
	/// Support the following configurations   'coordinateSystem'  'series'  'global'
	/// </summary>
	[JsonPropertyName("blurScope")]
	[DefaultValue("coordinateSystem")]
	public string? BlurScope { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Configuration of label guide line.
	/// </summary>
	[JsonPropertyName("labelLine")]
	public LabelLine? LabelLine { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("areaStyle")]
	public AreaStyle? AreaStyle { get; set; }

	/// <summary>
	/// Since v5.0.0
	/// </summary>
	[JsonPropertyName("endLabel")]
	public EndLabel? EndLabel { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Size of scale.
	/// Available when emphasis.scale is set as true .
	/// </summary>
	[JsonPropertyName("scaleSize")]
	[DefaultValue("10")]
	public double? ScaleSize { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("upperLabel")]
	public UpperLabel? UpperLabel { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("edgeLabel")]
	public EdgeLabel? EdgeLabel { get; set; }

}
