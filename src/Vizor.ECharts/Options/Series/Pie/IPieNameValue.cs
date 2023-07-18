namespace Vizor.ECharts.Options.Series.Pie;

public interface IPieNameValue
{
	string? Name { get; set; }
	PieDataOptions? Options { get; set; }
	double Value { get; set; }
}