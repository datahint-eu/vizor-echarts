using Vizor.ECharts;

namespace Vizor.ECharts.Options;

/// <summary>
/// see https://echarts.apache.org/en/option.html#stateAnimation
/// </summary>
public class StateAnimation
{
	/// <summary>
	/// Duration of animation. Animation will be disabled when set to 0.
	/// Default = 300
	/// </summary>
	public double? Duration { get; set; }

	/// <summary>
	/// Easing of animation. Default = CubicOut
	/// </summary>
	public AnimationEasing? Easing { get; set; }
}
