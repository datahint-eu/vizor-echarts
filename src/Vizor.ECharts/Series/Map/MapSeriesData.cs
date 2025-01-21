
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class MapSeriesData
{
	/// <summary>
	/// The name of the map area where the data belongs to, such as 'China' or 'United Kingdom' .
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// The numerical value of this area.
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
	/// Whether the are selected.
	/// </summary>
	[JsonPropertyName("selected")]
	[DefaultValue(false)]
	public bool? Selected { get; set; }

	/// <summary>
	/// Style of item polygon
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; }

	/// <summary>
	/// Text label of , to explain some data information about graphic item like value, name and so on.
	/// label is placed under itemStyle in ECharts 2.x.
	/// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Configuration of label guide line.
	/// </summary>
	[JsonPropertyName("labelLine")]
	public LabelLine? LabelLine { get; set; }

	/// <summary>
	/// Emphasis state of specified region.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; }

	/// <summary>
	/// Select state of polygon.
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; }

	/// <summary>
	/// tooltip settings in this series data.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; }

}
