// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class AxisLine
{
	/// <summary>
	/// Set this to false to prevent the axis line from showing.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("true")]
	public bool? Show { get; set; } 

	/// <summary>
	/// Specifies whether X or Y axis lies on the other's origin position, where value is 0 on axis.
	/// Valid only if the other axis is of value type, and contains 0 value.
	/// </summary>
	[JsonPropertyName("onZero")]
	[DefaultValue("true")]
	public bool? OnZero { get; set; } 

	/// <summary>
	/// When mutiple axes exists, this option can be used to specify which axis can be "onZero" to.
	/// </summary>
	[JsonPropertyName("onZeroAxisIndex")]
	public int? OnZeroAxisIndex { get; set; } 

	//TODO: Symbol
	/// <summary>
	/// Size of the arrows at two ends.
	/// The first is the width perpendicular to the axis, the next is the width parallel to the axis.
	/// </summary>
	[JsonPropertyName("symbolSize")]
	[DefaultValue("10,15")]
	public double[]? SymbolSize { get; set; } 

	//TODO: SymbolOffset
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

}
