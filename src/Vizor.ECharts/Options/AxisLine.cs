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

	/// <summary>
	/// Symbol of the two ends of the axis.
	/// It could be a string, representing the same symbol for two ends; or an array with two string elements, representing the two ends separately.
	/// It's set to be 'none' by default, meaning no arrow for either end.
	/// If it is set to be 'arrow' , there shall be two arrows.
	/// If there should only one arrow at the end, it should set to be ['none', 'arrow'] .
	/// </summary>
	[JsonPropertyName("symbol")]
	[DefaultValue("none")]
	//TODO: Type Warning: Failed to map property 'symbol' in type 'axisLine' with types 'array,icon,string'
	public object? Symbol { get; set; } 

	/// <summary>
	/// Size of the arrows at two ends.
	/// The first is the width perpendicular to the axis, the next is the width parallel to the axis.
	/// </summary>
	[JsonPropertyName("symbolSize")]
	[DefaultValue("10,15")]
	public double[]? SymbolSize { get; set; } 

	/// <summary>
	/// Arrow offset of axis.
	/// If is array, the first number is the offset of the arrow at the beginning, and the second number is the offset of the arrow at the end.
	/// If is number, it means the arrows have the same offset.
	/// </summary>
	[JsonPropertyName("symbolOffset")]
	[DefaultValue("0,0")]
	public NumberArray? SymbolOffset { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Whether to add round caps at the end.
	/// </summary>
	[JsonPropertyName("roundCap")]
	[DefaultValue(false)]
	public bool? RoundCap { get; set; } 

}
