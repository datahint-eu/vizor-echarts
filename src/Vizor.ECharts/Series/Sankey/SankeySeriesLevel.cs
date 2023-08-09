
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class SankeySeriesLevel
{
	/// <summary>
	/// Specify which layer is set, value starts from 0.
	/// </summary>
	[JsonPropertyName("depth")]
	[DefaultValue("0")]
	public double? Depth { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// Since v5.4.1   
	/// The label style of each edge/link.
	/// </summary>
	[JsonPropertyName("edgeLabel")]
	public EdgeLabel? EdgeLabel { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

	/// <summary>
	/// Since v5.0.0
	/// </summary>
	[JsonPropertyName("blur")]
	public Blur? Blur { get; set; } 

	/// <summary>
	/// Since v5.0.0
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; } 

}
