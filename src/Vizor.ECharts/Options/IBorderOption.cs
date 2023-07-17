namespace Vizor.ECharts.Options;

public interface IBorderOption
{
	/// <summary>
	/// Border color of title.
	/// Default = #ccc
	/// See Color class.
	/// </summary>
	Color? BorderColor { get; set; }

	/// <summary>
	/// Border width, default=1
	/// </summary>
	double? BorderWidth { get; set; }

	/// <summary>
	/// The radius of rounded corner. Its unit is px. And it supports use array to respectively specify the 4 corner radiuses.
	/// Default all=5
	/// </summary>
	Radius? BorderRadius { get; set; }
}