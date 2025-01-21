
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class RadarIndicator
{
	/// <summary>
	/// Indicator's name.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// The maximum value of indicator.
	/// It is an optional configuration, but we recommend to set it manually.
	/// </summary>
	[JsonPropertyName("max")]
	[DefaultValue("100")]
	public double? Max { get; set; }

	/// <summary>
	/// The minimum value of indicator.
	/// It it an optional configuration, with default value of 0.
	/// </summary>
	[JsonPropertyName("min")]
	public double? Min { get; set; }

	/// <summary>
	/// Specfy a color of the indicator.
	/// </summary>
	[JsonPropertyName("color")]
	public Color? Color { get; set; }

}
