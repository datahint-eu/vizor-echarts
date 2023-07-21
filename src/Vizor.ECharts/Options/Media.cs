// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Media
{
	/// <summary>
	/// If more than one properties used, it means "and".
	/// </summary>
	[JsonPropertyName("query")]
	public Query? Query { get; set; } 

	/// <summary>
	/// Each item of this array is an echarts option ( ECUnitOption ).
	/// It will be applied when this query is matched.
	/// </summary>
	[JsonPropertyName("option")]
	public Option? Option { get; set; } 

}
