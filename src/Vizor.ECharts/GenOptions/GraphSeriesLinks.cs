// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class GraphSeriesLinks
{
	/// <summary>
	/// A string representing the name of source node on edge.
	/// Can also be a number representing the node index.
	/// </summary>
	[JsonPropertyName("source")]
	public NumberOrString? Source { get; set; } 

	/// <summary>
	/// A string representing the name of target node on edge.
	/// Can also be a number representing node index.
	/// </summary>
	[JsonPropertyName("target")]
	public NumberOrString? Target { get; set; } 

	/// <summary>
	/// value of edge, can be mapped to edge length in force graph.
	/// </summary>
	[JsonPropertyName("value")]
	public double? Value { get; set; } 

	/// <summary>
	/// Line style of edges.
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// Emphasis state of specified edge.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Blur state of specified edge.
	/// </summary>
	[JsonPropertyName("blur")]
	public Blur? Blur { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Select state of specified edge.
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; } 

	/// <summary>
	/// Symbol of edge ends.
	/// Can be an array with two item to specify two ends, or a string specifies both ends.
	/// </summary>
	[JsonPropertyName("symbol")]
	public Icon? Symbol { get; set; } 

	/// <summary>
	/// Symbol size of edge ends.
	/// Can be an array with two item to specify two ends, or a string specifies both ends.
	/// </summary>
	[JsonPropertyName("symbolSize")]
	public Icon? SymbolSize { get; set; } 

	/// <summary>
	/// Since v4.5.0   
	/// Prevent this edge from force layout calculating.
	/// </summary>
	[JsonPropertyName("ignoreForceLayout")]
	[DefaultValue(false)]
	public bool? IgnoreForceLayout { get; set; } 

}
