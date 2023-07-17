namespace Vizor.ECharts.Options;

public interface IWidthHeightOption
{
	/// <summary>
	/// Width of legend component. Adaptive by default.
	/// Default=auto
	/// </summary>
	string? Width { get; set; }

	/// <summary>
	/// Height of legend component. Adaptive by default.
	/// Default=auto
	/// </summary>
	string? Height { get; set; }
}
