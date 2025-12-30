using Vizor.ECharts.Tests.TestFixtures;

namespace Vizor.ECharts.Tests.Unit.Serialization;

[TestClass]
public class ChartTypesSnapshotTests
{
    private static JsonSerializerOptions CreateOptions() => new TestChart().GetSerializerOptions();

    [TestMethod]
    public void SerializesScatterChartWithVisualMap()
    {
        var options = ChartOptionsBuilder.ScatterChartWithVisualMap();
        SnapshotHelper.AssertJsonSnapshot(
            options,
            nameof(ChartTypesSnapshotTests),
            nameof(SerializesScatterChartWithVisualMap),
            CreateOptions());
    }

    [TestMethod]
    public void SerializesPieChartWithLabel()
    {
        var options = ChartOptionsBuilder.PieChartWithLabel();
        SnapshotHelper.AssertJsonSnapshot(
            options,
            nameof(ChartTypesSnapshotTests),
            nameof(SerializesPieChartWithLabel),
            CreateOptions());
    }

    [TestMethod]
    public void SerializesGaugeChart()
    {
        var options = ChartOptionsBuilder.GaugeChart();
        SnapshotHelper.AssertJsonSnapshot(
            options,
            nameof(ChartTypesSnapshotTests),
            nameof(SerializesGaugeChart),
            CreateOptions());
    }

    [TestMethod]
    public void SerializesRadarChart()
    {
        var options = ChartOptionsBuilder.RadarChart();
        SnapshotHelper.AssertJsonSnapshot(
            options,
            nameof(ChartTypesSnapshotTests),
            nameof(SerializesRadarChart),
            CreateOptions());
    }

    [TestMethod]
    public void SerializesCandlestickChart()
    {
        var options = ChartOptionsBuilder.CandlestickChart();
        SnapshotHelper.AssertJsonSnapshot(
            options,
            nameof(ChartTypesSnapshotTests),
            nameof(SerializesCandlestickChart),
            CreateOptions());
    }
}
