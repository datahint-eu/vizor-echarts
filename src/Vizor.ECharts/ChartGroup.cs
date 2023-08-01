namespace Vizor.ECharts;

/// <summary>
/// Allows multiple charts to be grouped together, allowing easy bulk update calls
/// </summary>
public class ChartGroup
{
	private List<EChart> charts = new List<EChart>();

	internal void Add(EChart chart)
	{
		charts.Add(chart);
	}

	internal void Remove(EChart chart)
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
