// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class DataZoom
{
	/// <summary>
	/// Whether to show the tool.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue(true)]
	public bool? Show { get; set; } 

	/// <summary>
	/// Restored and zoomed title text.
	/// </summary>
	[JsonPropertyName("title")]
	public Title? Title { get; set; } 

	/// <summary>
	/// Zooming and restore icon path.
	/// </summary>
	[JsonPropertyName("icon")]
	public Icon? Icon { get; set; } 

	/// <summary>
	/// The style setting of data area zooming icon.
	/// Since icon label is displayed only when hovering on the icon, the label configuration options are available under emphasis .
	/// </summary>
	[JsonPropertyName("iconStyle")]
	public IconStyle? IconStyle { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

	/// <summary>
	/// The same meaning as dataZoom.filterMode .
	/// </summary>
	[JsonPropertyName("filterMode")]
	[DefaultValue("filter")]
	public string? FilterMode { get; set; } 

	//TODO: XAxisIndex
	//TODO: YAxisIndex
	/// <summary>
	/// Style of brush rectangle.
	/// </summary>
	[JsonPropertyName("brushStyle")]
	public BrushStyle? BrushStyle { get; set; } 

}
