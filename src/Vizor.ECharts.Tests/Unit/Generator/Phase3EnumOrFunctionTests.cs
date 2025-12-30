using System.Reflection;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vizor.ECharts;
using Vizor.ECharts.Tests.TestFixtures;

namespace Vizor.ECharts.Tests.Unit.Generator;

/// <summary>
/// Phase 3: Tests for EnumOrFunctionType pattern (FunnelSeries.Sort, SunburstSeries.Sort)
/// Validates that the enum-or-function pattern works correctly with typed accessors
/// </summary>
[TestClass]
public class Phase3EnumOrFunctionTests
{
	[TestMethod]
	public void FunnelSeries_Sort_HasCorrectPropertyStructure()
	{
		// Arrange
		var funnelSeriesType = typeof(FunnelSeries);

		// Act - Check for three properties: SortObject, Sort, SortFunction
		var sortObjectProp = funnelSeriesType.GetProperty("SortObject");
		var sortProp = funnelSeriesType.GetProperty("Sort");
		var sortFunctionProp = funnelSeriesType.GetProperty("SortFunction");

		// Assert
		Assert.IsNotNull(sortObjectProp, "SortObject property should exist");
		Assert.IsNotNull(sortProp, "Sort property should exist");
		Assert.IsNotNull(sortFunctionProp, "SortFunction property should exist");

		// SortObject should be object type
		Assert.AreEqual(typeof(object), Nullable.GetUnderlyingType(sortObjectProp.PropertyType) ?? sortObjectProp.PropertyType);

		// Sort should be FunnelSortOrder type
		Assert.AreEqual(typeof(FunnelSortOrder), Nullable.GetUnderlyingType(sortProp.PropertyType) ?? sortProp.PropertyType);

		// SortFunction should be JavascriptFunction type
		Assert.AreEqual(typeof(JavascriptFunction), Nullable.GetUnderlyingType(sortFunctionProp.PropertyType) ?? sortFunctionProp.PropertyType);
	}

	[TestMethod]
	public void SunburstSeries_Sort_HasCorrectPropertyStructure()
	{
		// Arrange
		var sunburstSeriesType = typeof(SunburstSeries);

		// Act
		var sortObjectProp = sunburstSeriesType.GetProperty("SortObject");
		var sortProp = sunburstSeriesType.GetProperty("Sort");
		var sortFunctionProp = sunburstSeriesType.GetProperty("SortFunction");

		// Assert
		Assert.IsNotNull(sortObjectProp, "SortObject property should exist");
		Assert.IsNotNull(sortProp, "Sort property should exist");
		Assert.IsNotNull(sortFunctionProp, "SortFunction property should exist");

		Assert.AreEqual(typeof(object), Nullable.GetUnderlyingType(sortObjectProp.PropertyType) ?? sortObjectProp.PropertyType);
		Assert.AreEqual(typeof(SortOrder), Nullable.GetUnderlyingType(sortProp.PropertyType) ?? sortProp.PropertyType);
		Assert.AreEqual(typeof(JavascriptFunction), Nullable.GetUnderlyingType(sortFunctionProp.PropertyType) ?? sortFunctionProp.PropertyType);
	}

	[TestMethod]
	public void FunnelSeries_Sort_EnumValue_SerializesCorrectly()
	{
		// Arrange
		var chart = new TestChart();
		var options = new ChartOptions
		{
			Series = new List<ISeries>
			{
				new FunnelSeries
				{
					Sort = FunnelSortOrder.Ascending,
					Data = new List<FunnelSeriesData>
					{
						new("A", 100),
						new("B", 80)
					}
				}
			}
		};

		// Act
		string json = JsonSerializer.Serialize(options, chart.GetSerializerOptions());

		// Assert
		Assert.IsNotNull(json);
		Assert.Contains("\"sort\"", json);
		Assert.Contains("\"ascending\"", json);
		Assert.DoesNotContain("SortObject", json, "SortObject should not appear in JSON");
	}

	[TestMethod]
	public void FunnelSeries_Sort_FunctionValue_SerializesCorrectly()
	{
		// Arrange
		var chart = new TestChart();
		var sortFunction = new JavascriptFunction("function(a, b) { return a.value - b.value; }");
		
		var options = new ChartOptions
		{
			Series = new List<ISeries>
			{
				new FunnelSeries
				{
					SortFunction = sortFunction,
					Data = new List<FunnelSeriesData>
					{
						new("A", 100),
						new("B", 80)
					}
				}
			}
		};

		// Act
		string json = JsonSerializer.Serialize(options, chart.GetSerializerOptions());

		// Assert
		Assert.IsNotNull(json);
		Assert.Contains("\"sort\"", json);
		Assert.Contains("function(a, b)", json);
		Assert.DoesNotContain("SortFunction", json, "SortFunction property name should not appear in JSON");
	}

	[TestMethod]
	public void SunburstSeries_Sort_EnumValue_SerializesCorrectly()
	{
		// Arrange
		var chart = new TestChart();
		var options = new ChartOptions
		{
			Series = new List<ISeries>
			{
				new SunburstSeries
				{
					Sort = SortOrder.Asc,
					Data = new List<SunburstSeriesData>
					{
						new() { Name = "A", Value = 100 }
					}
				}
			}
		};

		// Act
		string json = JsonSerializer.Serialize(options, chart.GetSerializerOptions());

		// Assert
		Assert.IsNotNull(json);
		Assert.Contains("\"sort\"", json);
		Assert.Contains("\"asc\"", json);
	}

	[TestMethod]
	public void SortObject_AcceptsEitherEnumOrFunction()
	{
		// Arrange
		var series1 = new FunnelSeries();
		var series2 = new FunnelSeries();

		var enumValue = FunnelSortOrder.Descending;
		var funcValue = new JavascriptFunction("function(a, b) { return b.value - a.value; }");

		// Act - Set via SortObject
		series1.SortObject = enumValue;
		series2.SortObject = funcValue;

		// Assert - Sort accessor should work for enum
		Assert.IsNotNull(series1.Sort);
		Assert.AreEqual(FunnelSortOrder.Descending, series1.Sort);

		// Assert - SortFunction accessor should work for function
		Assert.IsNotNull(series2.SortFunction);
		Assert.AreEqual(funcValue.Function, series2.SortFunction?.Function);
	}

	[TestMethod]
	public void Sort_Accessors_SetSortObjectCorrectly()
	{
		// Arrange
		var series = new FunnelSeries();

		// Act - Set via enum accessor
		series.Sort = FunnelSortOrder.None;

		// Assert
		Assert.IsNotNull(series.SortObject);
		Assert.AreEqual(FunnelSortOrder.None, series.SortObject);

		// Act - Set via function accessor
		var func = new JavascriptFunction("function() {}");
		series.SortFunction = func;

		// Assert
		Assert.IsNotNull(series.SortObject);
		Assert.AreEqual(func, series.SortObject);
	}

	[TestMethod]
	public void Phase3_DocumentsAutomatedProperties()
	{
		// This test documents which properties are now automated by Phase 3
		var automatedProperties = new[]
		{
			new { Type = typeof(FunnelSeries), PropertyName = "Sort", EnumType = typeof(FunnelSortOrder) },
			new { Type = typeof(SunburstSeries), PropertyName = "Sort", EnumType = typeof(SortOrder) }
		};

		foreach (var prop in automatedProperties)
		{
			var objectProp = prop.Type.GetProperty($"{prop.PropertyName}Object");
			var enumProp = prop.Type.GetProperty(prop.PropertyName);
			var funcProp = prop.Type.GetProperty($"{prop.PropertyName}Function");

			Assert.IsNotNull(objectProp, $"{prop.Type.Name}.{prop.PropertyName}Object should exist");
			Assert.IsNotNull(enumProp, $"{prop.Type.Name}.{prop.PropertyName} should exist");
			Assert.IsNotNull(funcProp, $"{prop.Type.Name}.{prop.PropertyName}Function should exist");

			// Verify JsonPropertyName is on Object property
			var jsonAttr = objectProp.GetCustomAttribute<System.Text.Json.Serialization.JsonPropertyNameAttribute>();
			Assert.IsNotNull(jsonAttr, $"{prop.Type.Name}.{prop.PropertyName}Object should have JsonPropertyName attribute");

			// Verify JsonIgnore is on accessor properties
			var ignoreAttr1 = enumProp.GetCustomAttribute<System.Text.Json.Serialization.JsonIgnoreAttribute>();
			var ignoreAttr2 = funcProp.GetCustomAttribute<System.Text.Json.Serialization.JsonIgnoreAttribute>();
			Assert.IsNotNull(ignoreAttr1, $"{prop.Type.Name}.{prop.PropertyName} should have JsonIgnore attribute");
			Assert.IsNotNull(ignoreAttr2, $"{prop.Type.Name}.{prop.PropertyName}Function should have JsonIgnore attribute");

			// Verify types
			Assert.AreEqual(prop.EnumType, Nullable.GetUnderlyingType(enumProp.PropertyType) ?? enumProp.PropertyType);
			Assert.AreEqual(typeof(JavascriptFunction), Nullable.GetUnderlyingType(funcProp.PropertyType) ?? funcProp.PropertyType);
		}
	}
}
