// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class SplitArea
{
	/// <summary>
	/// Interval of Axis splitArea, which is available in category axis.
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
	/// Set this to true to show the splitArea.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("true")]
	public bool? Show { get; set; } 

	/// <summary>
	/// Split area style.
	/// </summary>
	[JsonPropertyName("areaStyle")]
	public AreaStyle? AreaStyle { get; set; } 

}
