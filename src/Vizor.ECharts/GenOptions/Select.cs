// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Select
{
	/// <summary>
	/// Since v5.3.0   
	/// If data can be selected.
	/// Available when selectedMode is used.
	/// Can be used to disable selection for part of the data.
	/// </summary>
	[JsonPropertyName("disabled")]
	[DefaultValue("false")]
	public bool? Disabled { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

}
