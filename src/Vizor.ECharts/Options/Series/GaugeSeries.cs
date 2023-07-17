namespace Vizor.ECharts.Options.Series;

public class GaugeSeries : IChartSeries
{
	public string Type => "gauge";

	public string? Id { get; set; }
	public string? Name { get; set; }

	//TODO
}
