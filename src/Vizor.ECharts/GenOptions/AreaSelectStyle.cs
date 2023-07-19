// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class AreaSelectStyle
{
	/// <summary>
	/// Width of selecting box.
	/// </summary>
	[JsonPropertyName("width")]
	[DefaultValue("20")]
	public double? Width { get; set; } 

	/// <summary>
	/// Border width of the select box.
	/// </summary>
	[JsonPropertyName("borderWidth")]
	[DefaultValue("1")]
	public double? BorderWidth { get; set; } 

	/// <summary>
	/// Border color of the select box.
	/// </summary>
	[JsonPropertyName("borderColor")]
	[DefaultValue("rgba(160,197,232)")]
	public Color? BorderColor { get; set; } 

	/// <summary>
	/// Border fill color of the select box.
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("rgba(160,197,232)")]
	public Color? Color { get; set; } 

	/// <summary>
	/// Opacity of the select box.
	/// </summary>
	[JsonPropertyName("opacity")]
	[DefaultValue("0.3")]
	public double? Opacity { get; set; } 

}
