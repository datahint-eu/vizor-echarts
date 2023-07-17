namespace Vizor.ECharts.Options;

public interface ITextShadowOption
{
	/// <summary>
	/// Stroke color of the text. See Color class.
	/// Default = "transparent"
	/// </summary>
	Color? TextShadowColor { get; set; }

	/// <summary>
	/// Shadow blur of the text itself.
	/// </summary>
	double? TextShadowBlur { get; set; }

	/// <summary>
	/// Shadow X offset of the text itself.
	/// </summary>
	double? TextShadowOffsetX { get; set; }

	/// <summary>
	/// Shadow Y offset of the text itself.
	/// </summary>
	double? TextShadowOffsetY { get; set; }
}
