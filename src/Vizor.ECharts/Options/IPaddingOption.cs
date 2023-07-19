using Vizor.ECharts;

namespace Vizor.ECharts.Options;

public interface IPaddingOption
{
	/// <summary>
	/// Space around content. The unit is px. Default values for each position are 5. And they can be set to different values with left, right, top, and bottom.
	/// Default all=5
	/// </summary>
	public Padding? Padding { get; set; }
}
