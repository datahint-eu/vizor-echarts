
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class MinorTick
{
	/// <summary>
	/// If show minor ticks.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("true")]
	public bool? Show { get; set; }

	/// <summary>
	/// Number of interval splited by minor ticks.
	/// </summary>
	[JsonPropertyName("splitNumber")]
	[DefaultValue("5")]
	public double? SplitNumber { get; set; }

	/// <summary>
	/// Length of minor ticks lines。
	/// </summary>
	[JsonPropertyName("length")]
	[DefaultValue("3")]
	public double? Length { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; }

}
