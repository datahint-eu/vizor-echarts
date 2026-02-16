using Vizor.ECharts.Tests.TestFixtures;

namespace Vizor.ECharts.Tests.Unit.Serialization;

[TestClass]
public class ChartOptionsSerializationTests
{
    private static JsonSerializerOptions CreateOptions() => new TestChart().GetSerializerOptions();

    [TestMethod]
    public void SerializesLineChartWithBasicOptions()
    {
        var options = ChartOptionsBuilder.LineChartBasic();
        var serializerOptions = CreateOptions();

        string json = JsonSerializer.Serialize(options, serializerOptions);

        Assert.IsFalse(string.IsNullOrWhiteSpace(json));
        Assert.Contains("\"title\"", json);
        Assert.Contains("\"line\"", json);

        SnapshotHelper.AssertJsonSnapshot(
            options,
            nameof(ChartOptionsSerializationTests),
            nameof(SerializesLineChartWithBasicOptions),
            serializerOptions);
    }

    [TestMethod]
    public void SerializesBarChartWithMultipleSeries()
    {
        var options = ChartOptionsBuilder.BarChartMultipleSeries();
        var serializerOptions = CreateOptions();

        string json = JsonSerializer.Serialize(options, serializerOptions);


        Assert.IsFalse(string.IsNullOrWhiteSpace(json));
        Assert.Contains("\"bar\"", json);
        Assert.Contains("\"stack\"", json);

        SnapshotHelper.AssertJsonSnapshot(
            options,
            nameof(ChartOptionsSerializationTests),
            nameof(SerializesBarChartWithMultipleSeries),
            serializerOptions);
    }
}
