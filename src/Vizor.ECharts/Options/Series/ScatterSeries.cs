using System.Xml.Linq;
using Vizor.ECharts.Data;

namespace Vizor.ECharts.Options.Series;

public class ScatterSeries<TData> : IChartSeries<TData>
{
	public string Type => "scatter";

	public string? Id { get; set; }
	public string? Name { get; set; }

	public List<TData> Data { get; set; } = new();

	//TODO
}
