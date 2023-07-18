using Vizor.ECharts.Data;

namespace Vizor.ECharts.Options.Series.Pie;

public class PieSeries<TData> : PieSeriesOptions
	, IChartSeries<TData>
	where TData : class, IPieNameValue
{
	public List<TData> Data { get; set; } = new();
}
