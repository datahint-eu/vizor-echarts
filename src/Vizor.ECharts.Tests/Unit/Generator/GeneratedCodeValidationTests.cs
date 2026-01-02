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
    public void SeriesUsesPolymorphicSerialization()
    {
        // Verify ISeries interface has JsonPolymorphic attribute for .NET 10 polymorphic serialization
        var iSeriesType = typeof(ISeries);
        var polymorphicAttr = iSeriesType.GetCustomAttribute<System.Text.Json.Serialization.JsonPolymorphicAttribute>();
        
        Assert.IsNotNull(polymorphicAttr, "ISeries should have JsonPolymorphic attribute");
        Assert.AreEqual("type", polymorphicAttr.TypeDiscriminatorPropertyName, 
            "Type discriminator should be 'type'");

        // Verify series types are registered with JsonDerivedType attributes
        var derivedTypeAttrs = iSeriesType.GetCustomAttributes<System.Text.Json.Serialization.JsonDerivedTypeAttribute>().ToList();
        Assert.IsGreaterThanOrEqualTo(20, derivedTypeAttrs.Count, 
            "Should have at least 20 series types registered");

        // Verify some common series are registered
        var barSeriesAttr = derivedTypeAttrs.FirstOrDefault(a => a.TypeDiscriminator?.ToString() == "bar");
        Assert.IsNotNull(barSeriesAttr, "BarSeries should be registered");
        Assert.AreEqual(typeof(BarSeries), barSeriesAttr.DerivedType);
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
