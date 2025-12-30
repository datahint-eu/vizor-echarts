using System.Text.Json;

namespace Vizor.ECharts.Tests.TestFixtures;

internal sealed class TestChart : EChartBase
{
    public TestChart()
    {
        Options = new ChartOptions();
    }

    public JsonSerializerOptions GetSerializerOptions()
    {
        return CreateSerializerOptions();
    }

    public override Task UpdateAsync(bool executeDataLoader = true)
    {
        return Task.CompletedTask;
    }
}
