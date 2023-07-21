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

	/// <summary>
	/// Whether to smooth the guide line.
	/// It defaults to be false and can be set as true or the values from 0 to 1 which indicating the smoothness.
	/// </summary>
	[JsonPropertyName("smooth")]
	[DefaultValue(false)]
	public NumberOrBool? Smooth { get; set; } 

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

	/// <summary>
	/// The length of the first segment of guide line.
	/// </summary>
	[JsonPropertyName("length")]
	[DefaultValue("15")]
	public double? Length { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Max angle between guide line and surface normal.
	/// To prevent guide line overlapping with sector.
	///  
	/// Can be 0 - 180 degree.
	/// </summary>
	[JsonPropertyName("maxSurfaceAngle")]
	public double? MaxSurfaceAngle { get; set; } 

}
