
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Rich
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("RichStyleName")]
	public RichStyleName? RichStyleName { get; set; } 

}
