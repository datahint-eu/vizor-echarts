namespace Vizor.ECharts.Options.Series;

public class CustomSeries : IChartSeries
{
	public string Type => "custom";

	public string? Id { get; set; }
	public string? Name { get; set; }

	//TODO
}
