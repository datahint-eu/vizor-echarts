
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Select
{
	/// <summary>
	/// Since v5.3.0   
	/// If data can be selected.
	/// Available when selectedMode is used.
	/// Can be used to disable selection for part of the data.
	/// </summary>
	[JsonPropertyName("disabled")]
	[DefaultValue("false")]
	public bool? Disabled { get; set; }

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
	/// 
	/// </summary>
	[JsonPropertyName("endLabel")]
	public EndLabel? EndLabel { get; set; }

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
