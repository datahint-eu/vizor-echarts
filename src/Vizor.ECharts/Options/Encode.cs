using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Define what is encoded to for each dimension of data
/// See https://echarts.apache.org/en/option.html#series-line.encode
/// </summary>
public partial class Encode
{
	/// <summary>
	/// Dimensions mapped to x-axis
	/// </summary>
	[JsonPropertyName("x")]
	public NumberOrStringArray? X { get; set; }

	/// <summary>
	/// Dimensions mapped to y-axis
	/// </summary>
	[JsonPropertyName("y")]
	public NumberOrStringArray? Y { get; set; }

	/// <summary>
	/// Dimensions displayed in tooltip
	/// </summary>
	[JsonPropertyName("tooltip")]
	public NumberOrStringArray? Tooltip { get; set; }

	/// <summary>
	/// Set the series name as the concat of the names of given dimensions
	/// </summary>
	[JsonPropertyName("seriesName")]
	public NumberOrStringArray? SeriesName { get; set; }

	/// <summary>
	/// Using dimension as the id of each data item. This is useful when dynamically
	/// update data by `chart.setOption()`, where the new and old data item can be
	/// corresponded by id, by which the appropriate animation can be performed when updating.
	/// </summary>
	[JsonPropertyName("itemId")]
	public NumberOrStringArray? ItemId { get; set; }

	/// <summary>
	/// Using dimension as the name of each data item. This is useful in charts like
	/// 'pie', 'funnel', where data item name can be displayed in legend.
	/// </summary>
	[JsonPropertyName("itemName")]
	public NumberOrStringArray? ItemName { get; set; }

	/// <summary>
	/// Using dimension as the groupId of each data item. groupId will be used to categorize the data. And to determine
	/// How the merge and split animation are performed in the universal transition. See universalTransition option for detail.
	/// </summary>
	[JsonPropertyName("itemGroupId")]
	public NumberOrStringArray? ItemGroupId { get; set; }

	/// <summary>
	/// Only available in polar coordinate system
	/// </summary>
	[JsonPropertyName("radius")]
	public NumberOrStringArray? Radius { get; set; }

	/// <summary>
	/// Only available in polar coordinate system
	/// </summary>
	[JsonPropertyName("angle")]
	public NumberOrStringArray? Angle { get; set; }

	/// <summary>
	/// Only available in geo coordinate system
	/// </summary>
	[JsonPropertyName("lng")]
	public NumberOrStringArray? Longitude { get; set; }

	/// <summary>
	/// Only available in geo coordinate system
	/// </summary>
	[JsonPropertyName("lat")]
	public NumberOrStringArray? Latitude { get; set; }

	/// <summary>
	/// Only available in series that are not in any coordinate system (pie, funnel, ...)
	/// </summary>
	[JsonPropertyName("value")]
	public NumberOrStringArray? Value { get; set; }
}
