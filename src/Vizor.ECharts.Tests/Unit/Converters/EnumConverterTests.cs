using Vizor.ECharts.Tests.TestFixtures;

namespace Vizor.ECharts.Tests.Unit.Converters;

[TestClass]
public class EnumConverterTests
{
    private static JsonSerializerOptions CreateOptions() => new TestFixtures.TestChart().GetSerializerOptions();

    [TestMethod]
    public void SerializesAxisTypeToCamelCase()
    {
        var options = ChartOptionsBuilder.LineChartBasic();
        string json = JsonSerializer.Serialize(options, CreateOptions());

        using var doc = JsonDocument.Parse(json);
        var xAxis = doc.RootElement.GetProperty("xAxis");

        Assert.AreEqual("category", xAxis.GetProperty("type").GetString());
    }

    [TestMethod]
    public void SerializesLegendOrientToCamelCase()
    {
        var options = new ChartOptions
        {
            Legend = new() { Orient = Orient.Vertical }
        };

        string json = JsonSerializer.Serialize(options, CreateOptions());

        using var doc = JsonDocument.Parse(json);
        var legend = doc.RootElement.GetProperty("legend");

        Assert.AreEqual("vertical", legend.GetProperty("orient").GetString());
    }
}
