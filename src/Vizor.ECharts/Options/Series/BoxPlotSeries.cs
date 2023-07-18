using System.Xml.Linq;
using Vizor.ECharts.Data;

namespace Vizor.ECharts.Options.Series;

public class BoxPlotSeries<TData> : IChartSeries<TData>
{
	public string Type => "boxplot";

	public string? Id { get; set; }
	public string? Name { get; set; }

	public List<TData> Data { get; set; } = new();
	//TODO
}
