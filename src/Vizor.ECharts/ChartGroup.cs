namespace Vizor.ECharts;

/// <summary>
/// Allows multiple charts to be grouped together, allowing easy bulk update calls
/// </summary>
public class ChartGroup
{
	private readonly List<EChartBase> charts = new();

	internal void Add(EChartBase chart)
	{
		charts.Add(chart);
	}

	internal void Remove(EChartBase chart)
	{
		charts.Remove(chart);
	}

    public async Task UpdateAsync(bool executeDataLoader = true)
	{
		foreach (var chart in charts)
		{
			await chart.UpdateAsync(executeDataLoader);
		}
	}
}
