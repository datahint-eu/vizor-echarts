using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public class EventParams
{
	/// <summary>
	/// Could be 'series'、'markLine'、'markPoint'、'timeLine', etc..
	/// </summary>
	[JsonPropertyName("componentType")]
	public string ComponentType { get; set; } = default!;
	
	/// <summary>
	/// Could be 'line'、'bar'、'pie', etc.. Works when componentType is 'series'.
	/// </summary>
	[JsonPropertyName("seriesType")]
	public string? SeriesType { get; set; }
	
	/// <summary>
	/// The index in option.series. Works when componentType is 'series'.
	/// </summary>
	[JsonPropertyName("seriesIndex")]
	public int SeriesIndex { get; set; }
	
	/// <summary>
	/// series name, works when componentType is 'series'.
	/// </summary>
	[JsonPropertyName("seriesName")]
	public string? SeriesName { get; set; }

	/// <summary>
	/// name of data (categories).
	/// </summary>
	[JsonPropertyName("name")]
	public string Name { get; set; } = default!;
	
	/// <summary>
	/// the index in 'data' array.
	/// </summary>
	[JsonPropertyName("dataIndex")]
	public int DataIndex { get; set; }
	
	/// <summary>
	/// incoming raw data item
	/// </summary>
	[JsonPropertyName("data")]
	public object? Data { get; set; }
	
	/// <summary>
	/// charts like 'sankey' and 'graph' included nodeData and edgeData at the same time.
	/// dataType can be 'node' or 'edge', indicates whether the current click is on node or edge.
	/// Most charts have one kind of data, the dataType is meaningless in those cases.
	/// </summary>
	[JsonPropertyName("dataType")]
	public string? DataType { get; set; }
	
	/// <summary>
	/// incoming data value
	/// </summary>
	[JsonPropertyName("value")]
	public NumberOrNumberArray? Value { get; set; }
	
	/// <summary>
	/// color of the shape, works when componentType is 'series'.
	/// </summary>
	[JsonPropertyName("color")]
	public Color? Color { get; set; }
}