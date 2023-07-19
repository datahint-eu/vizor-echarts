namespace Vizor.ECharts.Options;

public interface IShadowOption
{
	/// <summary>
	/// Size of shadow blur. This attribute should be used along with ShadowColor, ShadowOffsetX, ShadowOffsetY to set shadow to component.
	/// Attention: This property works only if Show=true is configured and BackgroundColor is defined other than transparent.
	/// </summary>
	double? ShadowBlur { get; set; }

	/// <summary>
	/// Shadow color. See Color class.
	/// Attention: This property works only if Show=true
	/// </summary>
	Color? ShadowColor { get; set; }

	/// <summary>
	/// Offset distance on the horizontal direction of shadow.
	/// Attention: This property works only if Show=true
	/// </summary>
	double? ShadowOffsetX { get; set; }

	/// <summary>
	/// Offset distance on the vertical  direction of shadow.
	/// Attention: This property works only if Show=true
	/// </summary>
	double? ShadowOffsetY { get; set; }
}
