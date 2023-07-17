namespace Vizor.ECharts.Options.Series;

public class GraphSeries : IChartSeries
{
	public string Type => "graph";

	public string? Id { get; set; }
	public string? Name { get; set; }

	//TODO
}
