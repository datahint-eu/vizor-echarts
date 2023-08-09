
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class SankeySeriesLink
{
	/// <summary>
	/// The name of source node of edge
	/// </summary>
	[JsonPropertyName("source")]
	public string? Source { get; set; } 

	/// <summary>
	/// The name of target node of edge
	/// </summary>
	[JsonPropertyName("target")]
	public string? Target { get; set; } 

	/// <summary>
	/// The value of edge, which decides the width of edge.
	/// </summary>
	[JsonPropertyName("value")]
	public double? Value { get; set; } 

	/// <summary>
	/// Since v5.4.1   
	/// The label style of each edge/link.
	/// </summary>
	[JsonPropertyName("edgeLabel")]
	public EdgeLabel? EdgeLabel { get; set; } 

	/// <summary>
	/// The line style of edge.
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
