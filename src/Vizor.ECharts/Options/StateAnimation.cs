
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class StateAnimation
{
	/// <summary>
	/// Duration of animation.
	/// Animation will be disabled when set to 0.
	/// </summary>
	[JsonPropertyName("duration")]
	[DefaultValue(300)]
	public double? Duration { get; set; }

	/// <summary>
	/// Easing of animation.
	/// </summary>
	[JsonPropertyName("easing")]
	[DefaultValue("cubicOut")]
	public string? Easing { get; set; }

}
