// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class CandlestickSeriesData
{
	/// <summary>
	/// Name of data item.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; } 

	/// <summary>
	/// Value of data item.
	///  [open, close, lowest, highest]  (namely: [opening value, closing value, lowest value, highest value])
	/// </summary>
	[JsonPropertyName("value")]
	//TODO: Type Warning: array type 'value' in 'CandlestickSeriesData' will be mapped to List<object>
	public List<object>? Value { get; set; } 

	/// <summary>
	/// The groupID of this data item.
	/// groupID will be used to classify the data.
	/// </summary>
	[JsonPropertyName("groupId")]
	public string? GroupId { get; set; } 

	/// <summary>
	/// Style of a candle box.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// Emphasis style of a candle box.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Blur state of single data.
	/// </summary>
	[JsonPropertyName("blur")]
	public Blur? Blur { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Select state of single data.
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; } 

	/// <summary>
	/// tooltip settings in this series data.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

}
