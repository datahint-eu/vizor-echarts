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

    public static ChartOptions ScatterChartWithVisualMap()
    {
        return new ChartOptions
        {
            Title = new() { Text = "Scatter with Visual Map" },
            XAxis = new() { Type = AxisType.Value },
            YAxis = new() { Type = AxisType.Value },
            VisualMap = new List<object>
            {
                new ContinuousVisualMap
                {
                    Min = 0,
                    Max = 100,
                    Dimension = 2,
                    InRange = new()
                    {
                        Color = new Color[] { "#50a3ba", "#eac736", "#d94e5d" }
                    }
                }
            },
            Series = new List<ISeries>
            {
                new ScatterSeries
                {
                    Data = new List<SeriesData<double, double, double>>
                    {
                        new(10.0, 20.0, 30.0),
                        new(15.0, 25.0, 50.0),
                        new(20.0, 30.0, 80.0)
                    },
                    SymbolSize = 20
                }
            }
        };
    }

    public static ChartOptions PieChartWithLabel()
    {
        return new ChartOptions
        {
            Title = new() { Text = "Pie Chart", Left = "center" },
            Tooltip = new() { Trigger = TooltipTrigger.Item },
            Legend = new() { Orient = Orient.Vertical, Left = "left" },
            Series = new List<ISeries>
            {
                new PieSeries
                {
                    Radius = new CircleRadius("50%"),
                    Data = new List<object>
                    {
                        new { value = 335, name = "Direct" },
                        new { value = 234, name = "Email" },
                        new { value = 1548, name = "Search" }
                    },
                    Emphasis = new()
                    {
                        ItemStyle = new()
                        {
                            ShadowBlur = 10,
                            ShadowOffsetX = 0,
                            ShadowColor = "rgba(0, 0, 0, 0.5)"
                        }
                    }
                }
            }
        };
    }

    public static ChartOptions GaugeChart()
    {
        return new ChartOptions
        {
            Series = new List<ISeries>
            {
                new GaugeSeries
                {
                    Min = 0,
                    Max = 100,
                    Data = new List<object> { new { value = 75, name = "Score" } }
                }
            }
        };
    }

    public static ChartOptions RadarChart()
    {
        return new ChartOptions
        {
            Radar = new()
            {
                Indicator = new List<RadarIndicator>
                {
                    new() { Name = "Sales", Max = 100 },
                    new() { Name = "Quality", Max = 100 },
                    new() { Name = "Support", Max = 100 }
                }
            },
            Series = new List<ISeries>
            {
                new RadarSeries
                {
                    Data = new List<object>
                    {
                        new { value = new[] { 90, 80, 85 }, name = "Q1" }
                    }
                }
            }
        };
    }

    public static ChartOptions CandlestickChart()
    {
        return new ChartOptions
        {
            Title = new() { Text = "Candlestick Chart" },
            XAxis = new() { Type = AxisType.Category, Data = new List<string> { "2024-01-01", "2024-01-02", "2024-01-03" } },
            YAxis = new() { Type = AxisType.Value },
            Series = new List<ISeries>
            {
                new CandlestickSeries
                {
                    Name = "Stock",
                    Data = new List<object>
                    {
                        new[] { 20, 34, 10, 38 },  // [open, close, lowest, highest]
                        new[] { 40, 35, 30, 50 },
                        new[] { 31, 38, 33, 44 }
                    }
                }
            }
        };
    }
}
