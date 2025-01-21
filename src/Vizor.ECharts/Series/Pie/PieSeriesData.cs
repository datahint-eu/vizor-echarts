
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class PieSeriesData
{
    public PieSeriesData()
    {
    }

    public PieSeriesData(string name, double value)
    {
		Name = name;
		Value = value;
	}

    /// <summary>
    /// The name of data item.
    /// </summary>
    [JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Data value.
	/// </summary>
	[JsonPropertyName("value")]
	public double? Value { get; set; }

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
	/// Whether the data item is selected.
	/// </summary>
	[JsonPropertyName("selected")]
	[DefaultValue(false)]
	public bool? Selected { get; set; }

	/// <summary>
	/// The label configuration of a single sector.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("labelLine")]
	public LabelLine? LabelLine { get; set; }

	/// <summary>
	/// Graphic style of , emphasis is the style when it is highlighted, like being hovered by mouse, or highlighted via legend connect.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; }

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
