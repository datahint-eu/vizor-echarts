
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Circular
{
	/// <summary>
	/// Whether to rotate the label automatically.
	/// </summary>
	[JsonPropertyName("rotateLabel")]
	[DefaultValue(false)]
	public bool? RotateLabel { get; set; }

}
