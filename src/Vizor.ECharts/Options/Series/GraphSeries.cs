using System.Xml.Linq;
using Vizor.ECharts.Data;

namespace Vizor.ECharts.Options.Series;

public class GraphSeries<TData> : IChartSeries<TData>
{
	public string Type => "graph";

	public string? Id { get; set; }
	public string? Name { get; set; }

	public List<TData> Data { get; set; } = new();

	//TODO
}
