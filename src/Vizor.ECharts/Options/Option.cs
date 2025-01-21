
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Option
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("line")]
	public Line? Line { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("bar")]
	public Bar? Bar { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("stack")]
	public Stack? Stack { get; set; }

}
