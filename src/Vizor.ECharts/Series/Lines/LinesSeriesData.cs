
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class LinesSeriesData
{
	/// <summary>
	/// the name of data.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

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
	/// An array includes two ore more than two coordinates.
	/// Each coordinate could be [x, y] in rectangular coordinate and [lng, lat] in geographic coordinate .
	/// </summary>
	[JsonPropertyName("coords")]
	public List<double[]>? Coords { get; set; }

	/// <summary>
	/// The line style of this data item.
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; }

	/// <summary>
	/// Label of a single line.
	/// Available when polyline is not true .
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; }

	/// <summary>
	/// Since v5.0.0
	/// </summary>
	[JsonPropertyName("blur")]
	public Blur? Blur { get; set; }

	/// <summary>
	/// Since v5.0.0
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; }

	/// <summary>
	/// tooltip settings in this series data.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; }

}
