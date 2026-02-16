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
		var series = new FunnelSeries();

		// Act - Set and verify the internal SortObject property works
		series.SortObject = FunnelSortOrder.Ascending;

		// Assert - Verify all three properties exist and are accessible
		Assert.IsNotNull(series.SortObject, "SortObject property should be accessible");
		Assert.IsNotNull(series.Sort, "Sort property should be accessible");
		
		// Verify the Sort accessor works
		Assert.AreEqual(FunnelSortOrder.Ascending, series.Sort);
		
		// Verify we can set via the public Sort property
		series.Sort = FunnelSortOrder.Descending;
		Assert.AreEqual(FunnelSortOrder.Descending, series.SortObject);
		
		// Verify we can set via the public SortFunction property
		var func = new JavascriptFunction("function(a, b) { return 0; }");
		series.SortFunction = func;
		Assert.AreEqual(func, series.SortObject);
	}

	[TestMethod]
	public void SunburstSeries_Sort_HasCorrectPropertyStructure()
	{
		// Arrange
		var series = new SunburstSeries();

		// Act - Set and verify the internal SortObject property works
		series.SortObject = SortOrder.Asc;

		// Assert - Verify all three properties exist and are accessible
		Assert.IsNotNull(series.SortObject, "SortObject property should be accessible");
		Assert.IsNotNull(series.Sort, "Sort property should be accessible");
		
		// Verify the Sort accessor works
		Assert.AreEqual(SortOrder.Asc, series.Sort);
		
		// Verify we can set via the public Sort property
		series.Sort = SortOrder.Desc;
		Assert.AreEqual(SortOrder.Desc, series.SortObject);
		
		// Verify we can set via the public SortFunction property
		var func = new JavascriptFunction("function(a, b) { return 0; }");
		series.SortFunction = func;
		Assert.AreEqual(func, series.SortObject);
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
		
		// Test FunnelSeries.Sort
		var funnelSeries = new FunnelSeries();
		funnelSeries.Sort = FunnelSortOrder.Ascending;
		Assert.IsNotNull(funnelSeries.SortObject);
		Assert.AreEqual(FunnelSortOrder.Ascending, funnelSeries.Sort);
		
		// Test SunburstSeries.Sort
		var sunburstSeries = new SunburstSeries();
		sunburstSeries.Sort = SortOrder.Asc;
		Assert.IsNotNull(sunburstSeries.SortObject);
		Assert.AreEqual(SortOrder.Asc, sunburstSeries.Sort);
	}
}
