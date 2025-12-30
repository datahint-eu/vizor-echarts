namespace Vizor.ECharts.Tests.TestFixtures;

internal static class ChartOptionsBuilder
{
    public static ChartOptions LineChartBasic()
    {
        return new ChartOptions
        {
            Title = new() { Text = "Line Chart" },
            XAxis = new() { Type = AxisType.Category, Data = new List<string> { "A", "B", "C" } },
            YAxis = new() { Type = AxisType.Value },
            Series = new List<ISeries>
            {
                new LineSeries
                {
                    Name = "S1",
                    Data = new List<int> { 10, 20, 30 }
                }
            }
        };
    }

    public static ChartOptions BarChartMultipleSeries()
    {
        return new ChartOptions
        {
            Title = new() { Text = "Bar Chart" },
            Legend = new() { Show = true },
            XAxis = new() { Type = AxisType.Category, Data = new List<string> { "Q1", "Q2", "Q3" } },
            YAxis = new() { Type = AxisType.Value },
            Series = new List<ISeries>
            {
                new BarSeries
                {
                    Name = "2019",
                    Data = new List<int> { 120, 132, 101 },
                    Stack = "total"
                },
                new BarSeries
                {
                    Name = "2020",
                    Data = new List<int> { 134, 90, 230 },
                    Stack = "total"
                }
            }
        };
    }
}
