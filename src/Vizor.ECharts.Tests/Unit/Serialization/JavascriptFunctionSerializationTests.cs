namespace Vizor.ECharts.Tests.Unit.Serialization;

[TestClass]
public class JavascriptFunctionSerializationTests
{
    private static JsonSerializerOptions CreateOptions() => new TestFixtures.TestChart().GetSerializerOptions();

    [TestMethod]
    public void WritesRawFunctionBody()
    {
        var options = new ChartOptions
        {
            Tooltip = new()
            {
                Formatter = new JavascriptFunction("function (params) { return params[0].value; }")
            }
        };

        string json = JsonSerializer.Serialize(options, CreateOptions());

        Assert.Contains("function (params)", json);
        Assert.DoesNotContain("\\\\", json, "Function should not be double-escaped");
    }
}
