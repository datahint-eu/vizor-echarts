
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class HandleLabel
{
	/// <summary>
	/// Since v5.6.0
	/// Whether to show the label.
	/// </summary>
	[JsonPropertyName("show")]
	public bool? Show { get; set; }

}
