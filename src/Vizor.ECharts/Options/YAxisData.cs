
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class YAxisData
{
	/// <summary>
	/// Name of a category.
	/// </summary>
	[JsonPropertyName("value")]
	public string? Value { get; set; } 

	/// <summary>
	/// Text style of the category.
	/// </summary>
	[JsonPropertyName("textStyle")]
	public TextStyle? TextStyle { get; set; } 

}
