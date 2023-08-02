
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class HeatmapSeriesData
{
	/// <summary>
	/// Name of data item.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; } 

	/// <summary>
	/// Value of data item.
	/// </summary>
	[JsonPropertyName("value")]
	//TODO: Type Warning: array type 'value' in 'HeatmapSeriesData' will be mapped to List<object>
	public List<object>? Value { get; set; } 

	/// <summary>
	/// The groupID of this data item.
	/// groupID will be used to classify the data.
	/// </summary>
	[JsonPropertyName("groupId")]
	public string? GroupId { get; set; } 

	/// <summary>
	/// It is valid with coordinateSystem of 'cartesian2d' value.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// Style of a single data point.
	/// It is valid with coordinateSystem of 'cartesian2d' value.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

}
