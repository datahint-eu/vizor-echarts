
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Controller
{
	/// <summary>
	/// Define visual channels that will mapped from dataValues that are in selected range .
	/// User can interact with visualMap component and make a seleced range by mouse or touch.
	///  
	/// See available configurations in visualMap-continuous.inRange
	/// </summary>
	[JsonPropertyName("inRange")]
	public InRange? InRange { get; set; } 

	/// <summary>
	/// Define visual channels that will mapped from dataValues that are out of selected range .
	/// User can interact with visualMap component and make a seleced range by mouse or touch.
	///  
	/// See available configurations in visualMap-continuous.inRange
	/// </summary>
	[JsonPropertyName("outOfRange")]
	public OutOfRange? OutOfRange { get; set; } 

}
