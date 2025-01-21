
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class SplitLine
{
	/// <summary>
	/// Set this to false to prevent the splitLine from showing.
	/// value type axes are shown by default, while category type axes are hidden.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("true")]
	public bool? Show { get; set; }

	/// <summary>
	/// Interval of Axis splitLine, which is available in category axis.
	///  is set to be the same as axisLabel.interval by default.
	///  
	/// It uses a strategy that labels do not overlap by default.
	///  
	/// You may set it to be 0 to display all labels compulsively.
	///  
	/// If it is set to be 1, it means that labels are shown once after one label.
	/// And if it is set to be 2, it means labels are shown once after two labels, and so on.
	///  
	/// On the other hand, you can control by callback function, whose format is shown below:  (index:number, value: string) => boolean  
	/// The first parameter is index of category, and the second parameter is the name of category.
	/// The return values decides whether to display label.
	/// </summary>
	[JsonPropertyName("interval")]
	[DefaultValue("auto")]
	public NumberOrFunction? Interval { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; }

	/// <summary>
	/// The length of split line, can be a pecentage value relative to radius.
	/// </summary>
	[JsonPropertyName("length")]
	[DefaultValue("10")]
	public NumberOrString? Length { get; set; }

	/// <summary>
	/// Since v5.0   
	/// The distance between the split line and axis line.
	/// </summary>
	[JsonPropertyName("distance")]
	[DefaultValue("10")]
	public double? Distance { get; set; }

}
