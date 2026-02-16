using System.Collections;
using Vizor.ECharts.Tests.TestFixtures;

namespace Vizor.ECharts.Tests.Unit.Serialization;

[TestClass]
public class SeriesDataConverterFactoryTests
{
    private static JsonSerializerOptions CreateOptions() => new TestChart().GetSerializerOptions();

    [TestMethod]
    public void HandlesSeriesDataPair()
    {
        var data = new SeriesData<double, double>(10.5, 20.25);
        string json = JsonSerializer.Serialize(data, CreateOptions());

        using var doc = JsonDocument.Parse(json);
        var array = doc.RootElement;

        Assert.AreEqual(JsonValueKind.Array, array.ValueKind);
        Assert.AreEqual(2, array.GetArrayLength());
        Assert.AreEqual(10.5, array[0].GetDouble());
        Assert.AreEqual(20.25, array[1].GetDouble());
    }

    [TestMethod]
    public void HandlesSeriesDataList()
    {
        var list = new List<SeriesData<double, double>>
        {
            SeriesDataFixtures.Point(10, 20),
            SeriesDataFixtures.Point(30, 40)
        };

        string json = JsonSerializer.Serialize(list, CreateOptions());

        using var doc = JsonDocument.Parse(json);
        var array = doc.RootElement;

        Assert.AreEqual(2, array.GetArrayLength());
        Assert.AreEqual(10, array[0][0].GetDouble());
        Assert.AreEqual(40, array[1][1].GetDouble());
    }

    [TestMethod]
    public void HandlesMixedObjectList()
    {
        IList mixed = SeriesDataFixtures.MixedList();

        string json = JsonSerializer.Serialize(mixed, CreateOptions());
        using var doc = JsonDocument.Parse(json);

        Assert.AreEqual(4, doc.RootElement.GetArrayLength());
        Assert.AreEqual("text", doc.RootElement[1].GetString());
    }
}
