using System.Collections;

namespace Vizor.ECharts.Tests.TestFixtures;

internal static class SeriesDataFixtures
{
    public static SeriesData<double, double> Point(double x, double y) => new(x, y);

    public static IList MixedList() => new ArrayList { 10, "text", true, null };

    public static IList ScatterPoints() => new ArrayList
    {
        new double[] { 10, 20 },
        new double[] { 30, 40 }
    };
}
