// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Progress
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// Whether to show the progress of gauge chart.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("true")]
	public bool? Show { get; set; } 

	/// <summary>
	/// Whether the progress overlaps when there are multiple groups of data.
	/// </summary>
	[JsonPropertyName("overlap")]
	[DefaultValue("true")]
	public bool? Overlap { get; set; } 

	/// <summary>
	/// The width of progress.
	/// </summary>
	[JsonPropertyName("width")]
	[DefaultValue("true")]
	public NumberOrBool? Width { get; set; } 

	/// <summary>
	/// Whether to add round caps at the end
	/// </summary>
	[JsonPropertyName("roundCap")]
	[DefaultValue(false)]
	public bool? RoundCap { get; set; } 

	/// <summary>
	/// Whether to clip overflow.
	/// </summary>
	[JsonPropertyName("clip")]
	[DefaultValue(false)]
	public bool? Clip { get; set; } 

}
