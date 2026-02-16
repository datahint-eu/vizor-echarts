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
	/// Dimensions mapped to radius axis (polar coordinate system)
	/// </summary>
	[JsonPropertyName("radius")]
	public NumberOrStringArray? Radius { get; set; }

	/// <summary>
	/// Dimensions mapped to angle axis (polar coordinate system)
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
