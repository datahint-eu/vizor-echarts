
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class GaugeSeriesData
{
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
	/// Data name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; } 

	/// <summary>
	/// Data value.
	/// </summary>
	[JsonPropertyName("value")]
	[DefaultValue("0")]
	public double? Value { get; set; } 

	/// <summary>
	/// The style of data pointer.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

}
