using Vizor.ECharts.Enums;
using Vizor.ECharts.Types;

namespace Vizor.ECharts.Options;

public interface IAnimationOption
{
	/// <summary>
	/// Whether to enable animation. Default = true
	/// </summary>
	public bool? Animation { get; set; }

	/// <summary>
	/// Whether to set graphic number threshold to animation. Animation will be disabled when graphic number is larger than threshold.
	/// Default = 2000
	/// </summary>
	public int? AnimationThreshold { get; set; }

	/// <summary>
	/// Duration of the first animation, which supports callback function for different data to have different animation effect.
	/// Default = 1000
	/// </summary>
	public NumberOrFunction? AnimationDuration { get; set; }

	/// <summary>
	/// Easing method used for the first animation.
	/// Varied easing effects can be found at https://echarts.apache.org/examples/en/editor.html?c=line-easing
	/// Default = CubicOut
	/// </summary>
	public AnimationEasing? AnimationEasing { get; set; }

	/// <summary>
	/// Delay before updating the first animation, which supports callback function for different data to have different animation effect.
	/// </summary>
	public NumberOrFunction? AnimationDelay { get; set; }

	/// <summary>
	/// Time for animation to complete, which supports callback function for different data to have different animation effect.
	/// Default = 300
	/// </summary>
	public NumberOrFunction? AnimationDurationUpdate { get; set; }

	/// <summary>
	/// Easing method used for animation.
	/// Varied easing effects can be found at https://echarts.apache.org/examples/en/editor.html?c=line-easing
	/// Default = CubicOut
	/// </summary>
	public AnimationEasing? AnimationEasingUpdate { get; set; }

	/// <summary>
	/// Delay before updating animation, which supports callback function for different data to have different animation effect.
	/// </summary>
	public NumberOrFunction? AnimationDelayUpdate { get; set; }
}
