// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class LabelLine
{
	/// <summary>
	/// Whether to show the label guide line.
	/// </summary>
	[JsonPropertyName("show")]
	public bool? Show { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Whether to show the label guide line above the corresponding element.
	/// </summary>
	[JsonPropertyName("showAbove")]
	public bool? ShowAbove { get; set; } 

	/// <summary>
	/// The length of the second segment of guide line.
	/// </summary>
	[JsonPropertyName("length2")]
	[DefaultValue("15")]
	public double? Length2 { get; set; } 

	//TODO: Smooth
	/// <summary>
	/// Since v5.0.0   
	/// Minimum turn angle between two segments of guide line to prevent unaesthetic display when angle is too small.
	///  
	/// Can be 0 - 180 degree.
	/// </summary>
	[JsonPropertyName("minTurnAngle")]
	public double? MinTurnAngle { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

}
