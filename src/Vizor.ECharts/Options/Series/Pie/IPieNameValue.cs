namespace Vizor.ECharts.Options.Series.Pie;

public interface IPieNameValue
{
	string? Name { get; set; }
	PieSeriesOptions? Options { get; set; }
	double Value { get; set; }
}