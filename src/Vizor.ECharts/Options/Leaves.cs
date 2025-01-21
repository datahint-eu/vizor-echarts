
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Leaves
{
	/// <summary>
	/// Describes the style of the text label corresponding to the leaf node.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; }

	/// <summary>
	/// The style of the leaf node in the tree.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; }

	/// <summary>
	/// Emphasis state of leaves nodes.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Blur state of leaves nodes.
	/// </summary>
	[JsonPropertyName("blur")]
	public Blur? Blur { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Select state of leaves nodes.
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; }

}
