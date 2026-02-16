using Vizor.ECharts.Tests.TestFixtures;

namespace Vizor.ECharts.Tests.Unit.Serialization;

[TestClass]
public class EdgeCasesTests
{
    private static JsonSerializerOptions CreateOptions() => new TestChart().GetSerializerOptions();

    [TestMethod]
    public void SerializesEmptyChartOptions()
    {
        var options = new ChartOptions();
        string json = JsonSerializer.Serialize(options, CreateOptions());

        using var doc = JsonDocument.Parse(json);
        Assert.AreEqual(JsonValueKind.Object, doc.RootElement.ValueKind);
    }

    [TestMethod]
    public void SerializesChartWithNullSeries()
    {
        var options = new ChartOptions
        {
            Title = new() { Text = "Null Series" },
            Series = null
        };

        string json = JsonSerializer.Serialize(options, CreateOptions());
        Assert.DoesNotContain("\"series\"", json, "Null series should not appear in JSON");
    }

    [TestMethod]
    public void SerializesMultipleAxesAndGrids()
    {
        var options = new ChartOptions
        {
            Grid = new Grid { Top = "10%", Bottom = "50%" },
            XAxis = new() { Type = AxisType.Category, GridIndex = 0 },
            YAxis = new() { Type = AxisType.Value, GridIndex = 0 }
        };

        string json = JsonSerializer.Serialize(options, CreateOptions());

        using var doc = JsonDocument.Parse(json);
        Assert.IsTrue(doc.RootElement.TryGetProperty("grid", out _));
        Assert.IsTrue(doc.RootElement.TryGetProperty("xAxis", out _));
        Assert.IsTrue(doc.RootElement.TryGetProperty("yAxis", out _));
    }

    [TestMethod]
    public void SerializesSeriesWithNullData()
    {
        var options = new ChartOptions
        {
            XAxis = new() { Type = AxisType.Category },
            YAxis = new() { Type = AxisType.Value },
            Series = new List<ISeries>
            {
                new LineSeries
                {
                    Name = "Test",
                    Data = null
                }
            }
        };

        string json = JsonSerializer.Serialize(options, CreateOptions());
        
        using var doc = JsonDocument.Parse(json);
        Assert.IsTrue(doc.RootElement.TryGetProperty("series", out var series));
        Assert.AreEqual(1, series.GetArrayLength());
        Assert.AreEqual("line", series[0].GetProperty("type").GetString());
    }
}
