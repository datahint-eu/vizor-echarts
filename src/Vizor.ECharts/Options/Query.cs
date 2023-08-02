
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Query
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("minWidth")]
	[DefaultValue("undefined")]
	public double? MinWidth { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("maxHeight")]
	[DefaultValue("undefined")]
	public double? MaxHeight { get; set; } 

	/// <summary>
	/// That is the radio of width / height .
	/// The value can be like 1.3 .
	/// </summary>
	[JsonPropertyName("minAspectRatio")]
	[DefaultValue("undefined")]
	public double? MinAspectRatio { get; set; } 

}
