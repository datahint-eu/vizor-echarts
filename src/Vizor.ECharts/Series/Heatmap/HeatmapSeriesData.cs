
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
	public object? Value { get; set; }

	/// <summary>
	/// The groupID of this data item.
	/// groupID will be used to classify the data.
	/// </summary>
	[JsonPropertyName("groupId")]
	public string? GroupId { get; set; }

	/// <summary>
	/// Since v5.5.0
	/// The group ID of the child data of a data item. This option is introduced to make multiple levels drilldown and aggregation animation possilbe.
	/// </summary>
	[JsonPropertyName("childGroupId")]
	public string? ChildGroupId { get; set; }

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
