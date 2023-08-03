
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class AreaStyle
{
	/// <summary>
	/// Color of split area.
	/// SplitArea color could also be set in color array, which the split lines would take as their colors in turns.
	/// Dark and light colors in turns are used by default.
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("[rgba(250,250,250,0.3),rgba(200,200,200,0.3)]")]
	public Color[]? Color { get; set; } 

	/// <summary>
	/// Size of shadow blur.
	/// This attribute should be used along with shadowColor , shadowOffsetX , shadowOffsetY to set shadow to component.
	///  
	/// For example:  {
	///     shadowColor: 'rgba(0, 0, 0, 0.5)',
	///     shadowBlur: 10
	/// }
	/// </summary>
	[JsonPropertyName("shadowBlur")]
	[DefaultValue("")]
	public double? ShadowBlur { get; set; } 

	/// <summary>
	/// Shadow color.
	/// Support same format as color .
	/// </summary>
	[JsonPropertyName("shadowColor")]
	[DefaultValue("")]
	public Color? ShadowColor { get; set; } 

	/// <summary>
	/// Offset distance on the horizontal direction of shadow.
	/// </summary>
	[JsonPropertyName("shadowOffsetX")]
	[DefaultValue("0")]
	public double? ShadowOffsetX { get; set; } 

	/// <summary>
	/// Offset distance on the vertical direction of shadow.
	/// </summary>
	[JsonPropertyName("shadowOffsetY")]
	[DefaultValue("0")]
	public double? ShadowOffsetY { get; set; } 

	/// <summary>
	/// Opacity of the component.
	/// Supports value from 0 to 1, and the component will not be drawn when set to 0.
	/// </summary>
	[JsonPropertyName("opacity")]
	[DefaultValue("1")]
	public double? Opacity { get; set; } 

	/// <summary>
	/// Origin position of area.
	///  
	/// By default, the area between axis line and data will be filled.
	/// This config enables you to fill the area from data to the max or min of the axis data or a specified value.
	///  
	/// Valid values:   'auto' to fill between axis line and data ( Default )  'start' to fill between min axis value (when not inverse ) and data  'end' to fill between max axis value (when not inverse ) and data  number to fill between specified value and data (Since v5.3.2 )
	/// </summary>
	[JsonPropertyName("origin")]
	[DefaultValue("auto")]
	//TODO: Type Warning: Failed to map property 'origin' in type 'areaStyle' with types 'enum,number'
	public object? Origin { get; set; } 

}
