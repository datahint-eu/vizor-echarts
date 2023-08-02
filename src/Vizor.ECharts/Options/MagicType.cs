
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class MagicType
{
	/// <summary>
	/// Whether to show the tool.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue(true)]
	public bool? Show { get; set; } 

	/// <summary>
	/// Enabled magic types, including 'line' (for line charts), 'bar' (for bar charts), 'stack' (for stacked charts).
	/// </summary>
	[JsonPropertyName("type")]
	public string[]? Type { get; set; } 

	/// <summary>
	/// Title for different types, can be configured seperately.
	/// </summary>
	[JsonPropertyName("title")]
	public Title? Title { get; set; } 

	/// <summary>
	/// the different types of icon path , which could be configurated individually.
	/// </summary>
	[JsonPropertyName("icon")]
	public Icon? Icon { get; set; } 

	/// <summary>
	/// The style setting of magic type switching icon.
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
	/// Configuration item for each type, which will be used when switching to certain type.
	/// </summary>
	[JsonPropertyName("option")]
	public Option? Option { get; set; } 

	/// <summary>
	/// Series list for each type.
	/// </summary>
	[JsonPropertyName("seriesIndex")]
	public SeriesIndex? SeriesIndex { get; set; } 

}
