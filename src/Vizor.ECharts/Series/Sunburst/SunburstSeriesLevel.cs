
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class SunburstSeriesLevel
{
	/// <summary>
	/// Since v5.2.0   
	/// The inner and outer radius of the current layer, noting that the radius of other layers will not be adaptive.
	/// </summary>
	[JsonPropertyName("radius")]
	public CircleRadius? Radius { get; set; } 

	/// <summary>
	/// To specify the style of the label of the sector.
	///  
	/// Priority： series.data.label > series.levels.label > series.label 。  
	/// Text label of sunburst chart, to explain some data information about graphic item like value, name and so on.
	/// label is placed under itemStyle in ECharts 2.x.
	/// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Configuration of label guide line.
	/// </summary>
	[JsonPropertyName("labelLine")]
	public LabelLine? LabelLine { get; set; } 

	/// <summary>
	/// To specify the style of the sector of the sunburst chart.
	///  
	/// You can specify the style of all sectors with series.itemStyle , or specify the style of each level of sectors with series.levels.itemStyle , or specify a specific style for each sector with series.data.itemStyle .
	/// The priority is from low to high, that is, if series.data.itemStyle is defined, it will override series.itemStyle and series.levels.itemStyle .
	///  
	/// Priority： series.data.itemStyle > series.levels.itemStyle > series.itemStyle 。
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// Emphasis state.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public object? Emphasis { get; set; } 

	/// <summary>
	/// Blur state.
	/// </summary>
	[JsonPropertyName("blur")]
	public object? Blur { get; set; } 

	/// <summary>
	/// Select state.
	/// </summary>
	[JsonPropertyName("select")]
	public object? Select { get; set; } 

}
