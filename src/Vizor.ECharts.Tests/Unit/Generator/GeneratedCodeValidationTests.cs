using System.Reflection;

namespace Vizor.ECharts.Tests.Unit.Generator;

[TestClass]
public class GeneratedCodeValidationTests
{
    [TestMethod]
    public void GeneratedSeriesTypesImplementISeries()
    {
        var assembly = typeof(ChartOptions).Assembly;
        var seriesTypes = assembly.GetTypes()
            .Where(t => t.Namespace?.StartsWith("Vizor.ECharts") == true
                     && t.Name.EndsWith("Series")
                     && t.IsClass
                     && !t.IsAbstract)
            .ToList();

        Assert.IsNotEmpty(seriesTypes, "Should have generated series types");

        foreach (var seriesType in seriesTypes)
        {
            Assert.IsTrue(
                typeof(ISeries).IsAssignableFrom(seriesType),
                $"{seriesType.Name} should implement ISeries");
        }
    }

    [TestMethod]
    public void GeneratedSeriesHaveTypeProperty()
    {
        var assembly = typeof(ChartOptions).Assembly;
        var seriesTypes = assembly.GetTypes()
            .Where(t => typeof(ISeries).IsAssignableFrom(t)
                     && t.IsClass
                     && !t.IsAbstract)
            .ToList();

        Assert.IsGreaterThanOrEqualTo(10, seriesTypes.Count, "Should have at least 10 series types");

        foreach (var seriesType in seriesTypes)
        {
            var typeProperty = seriesType.GetProperty("Type");
            Assert.IsNotNull(typeProperty, $"{seriesType.Name} should have Type property");
            Assert.AreEqual(typeof(string), typeProperty.PropertyType);
        }
    }

    [TestMethod]
    public void ChartOptionsHasExpectedProperties()
    {
        var optionsType = typeof(ChartOptions);
        var expectedProperties = new[] { "Title", "Legend", "Grid", "XAxis", "YAxis", "Series", "Tooltip" };

        foreach (var propName in expectedProperties)
        {
            var prop = optionsType.GetProperty(propName);
            Assert.IsNotNull(prop, $"ChartOptions should have {propName} property");
        }
    }

    [TestMethod]
    public void EnumsHaveJsonPropertyNames()
    {
        var assembly = typeof(ChartOptions).Assembly;
        var enumTypes = assembly.GetTypes()
            .Where(t => t.Namespace == "Vizor.ECharts" && t.IsEnum)
            .ToList();

        Assert.IsGreaterThan(20, enumTypes.Count, "Should have many enum types");

        // Sample check: AxisType should have Category, Value, Time, Log
        var axisType = enumTypes.FirstOrDefault(t => t.Name == "AxisType");
        Assert.IsNotNull(axisType, "AxisType enum should exist");
        
        var values = Enum.GetNames(axisType);
        Assert.IsTrue(values.Contains("Category"));
        Assert.IsTrue(values.Contains("Value"));
    }

    [TestMethod]
    public void VerifySeriesDataConverterExists()
    {
        var assembly = typeof(ChartOptions).Assembly;
        var converterType = assembly.GetType("Vizor.ECharts.SeriesDataConverterFactory");
        
        Assert.IsNotNull(converterType, "SeriesDataConverterFactory should exist");
        Assert.IsTrue(converterType.IsClass);
    }
}
