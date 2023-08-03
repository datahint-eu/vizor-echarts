
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://echarts.apache.org/en/option.html#toolbox.feature.magicType.seriesIndex
/// </summary>
public partial class SeriesIndex
{
	public object? Line { get; set; } 

	[JsonPropertyName("bar")]
	public object? Bar { get; set; } 

}
