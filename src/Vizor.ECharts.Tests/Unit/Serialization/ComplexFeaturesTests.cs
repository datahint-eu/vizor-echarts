using Vizor.ECharts.Tests.TestFixtures;

namespace Vizor.ECharts.Tests.Unit.Serialization;

[TestClass]
public class ComplexFeaturesTests
{
    private static JsonSerializerOptions CreateOptions() => new TestChart().GetSerializerOptions();

    [TestMethod]
    public void SerializesChartWithDataZoomAndFormatter()
    {
        var options = new ChartOptions
        {
            Title = new() { Text = "DataZoom Example" },
            XAxis = new() { Type = AxisType.Category, Data = new List<string> { "A", "B", "C" } },
            YAxis = new() { Type = AxisType.Value },
            DataZoom = new List<IDataZoom>
            {
                new InsideDataZoom { XAxisIndex = new NumberOrNumberArray(0) },
                new SliderDataZoom { XAxisIndex = new NumberOrNumberArray(0), Start = 10, End = 90 }
            },
            Tooltip = new()
            {
                Trigger = TooltipTrigger.Axis,
                Formatter = new JavascriptFunction("function(params) { return params[0].name + ': ' + params[0].value; }")
            },
            Series = new List<ISeries>
            {
                new LineSeries
                {
                    Data = new List<int> { 10, 20, 30 }
                }
            }
        };

        SnapshotHelper.AssertJsonSnapshot(
            options,
            nameof(ComplexFeaturesTests),
            nameof(SerializesChartWithDataZoomAndFormatter),
            CreateOptions(),
            skipNormalization: true);
    }
}
