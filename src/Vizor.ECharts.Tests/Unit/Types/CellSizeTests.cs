using System.Text.Json;
using Vizor.ECharts.Tests.TestFixtures;

namespace Vizor.ECharts.Tests.Unit.Types;

[TestClass]
public class CellSizeTests
{
    [TestMethod]
    public void CellSize_Serializes_SingleNumber_AsSquareArray()
    {
        var chart = new TestChart();
        var cs = new CellSize(20);

        var json = JsonSerializer.Serialize(cs, chart.GetSerializerOptions());
        AssertJsonEqual("[20,20]", json);
    }

    [TestMethod]
    public void CellSize_Serializes_TwoNumbers()
    {
        var chart = new TestChart();
        var cs = new CellSize(20, 40);

        var json = JsonSerializer.Serialize(cs, chart.GetSerializerOptions());
        AssertJsonEqual("[20,40]", json);
    }

    [TestMethod]
    public void CellSize_Serializes_AutoAndNumber()
    {
        var chart = new TestChart();
        var cs = new CellSize("auto", 40);

        var json = JsonSerializer.Serialize(cs, chart.GetSerializerOptions());
        AssertJsonEqual("[\"auto\",40]", json);
    }

    [TestMethod]
    public void CellSize_Serializes_AutoAuto_FromSingleString()
    {
        var chart = new TestChart();
        var cs = new CellSize("auto");

        var json = JsonSerializer.Serialize(cs, chart.GetSerializerOptions());
        AssertJsonEqual("[\"auto\",\"auto\"]", json);
    }

    [TestMethod]
    public void CellSize_Serializes_NumberAndAuto()
    {
        var chart = new TestChart();
        var cs = new CellSize(13.5, "auto");

        var json = JsonSerializer.Serialize(cs, chart.GetSerializerOptions());
        AssertJsonEqual("[13.5,\"auto\"]", json);
    }

    private static void AssertJsonEqual(string expected, string actual)
    {
        // Parse and re-serialize both to normalize formatting
        using var expectedDoc = JsonDocument.Parse(expected);
        using var actualDoc = JsonDocument.Parse(actual);
        var expectedNormalized = JsonSerializer.Serialize(expectedDoc.RootElement);
        var actualNormalized = JsonSerializer.Serialize(actualDoc.RootElement);
        Assert.AreEqual(expectedNormalized, actualNormalized);
    }
}
