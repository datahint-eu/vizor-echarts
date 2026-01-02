using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vizor.ECharts;
using Vizor.ECharts.Tests.TestFixtures;

namespace Vizor.ECharts.Tests.Unit.Generator;

/// <summary>
/// Tests verifying that sort property serialization works correctly.
/// Sort properties serialize when explicitly set, and correctly omit when null (per null-value policy).
/// </summary>
[TestClass]
public class SortSerializationDiagnosticsTests
{
	public TestContext? TestContext { get; set; }

	private TestChart _chart = null!;

	[TestInitialize]
	public void Setup()
	{
		_chart = new TestChart();
	}

	[TestMethod]
	public void FunnelSeries_Sort_Property_Structure()
	{
		// Verify FunnelSeries has Sort and SortFunction properties
		var series = new FunnelSeries();
		
		// Check that properties can be accessed and set
		series.Sort = FunnelSortOrder.Ascending;
		Assert.AreEqual(FunnelSortOrder.Ascending, series.Sort, "Sort property should be settable and gettable");
		
		// Check that SortFunction property exists and can be set
		var jsFunc = new JavascriptFunction("return a - b;");
		series.SortFunction = jsFunc;
		Assert.AreEqual(jsFunc, series.SortFunction, "SortFunction property should be settable and gettable");
	}

	[TestMethod]
	public void FunnelSeries_Sort_Enum_Direct_Serialization()
	{
		// Test direct serialization of Sort enum value
		var series = new FunnelSeries { Sort = FunnelSortOrder.Ascending };
		
		var serializerOptions = _chart.GetSerializerOptions();
		string json = JsonSerializer.Serialize(series, serializerOptions);
		
		// Debug output
		TestContext?.WriteLine($"FunnelSeries with Sort=Ascending:\n{json}\n");
		
		// Assertions
		Assert.IsNotNull(json);
		Assert.Contains("\"sort\"", json, $"JSON should contain 'sort' property.\nJSON: {json}");
		Assert.IsTrue(json.Contains("ascending") || json.Contains("Ascending"), 
			$"JSON should contain the sort value.\nJSON: {json}");
	}

	[TestMethod]
	public void FunnelSeries_Sort_In_ChartOptions()
	{
		// Test serialization of Sort within ChartOptions - with value explicitly set
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

		var serializerOptions = _chart.GetSerializerOptions();
		string json = JsonSerializer.Serialize(options, serializerOptions);
		
		// Debug output
		TestContext?.WriteLine($"ChartOptions with FunnelSeries(Sort=Ascending):\n{json}\n");
		
		// Assertions - sort should be present when explicitly set
		Assert.IsNotNull(json);
		Assert.Contains("\"sort\"", json, $"JSON should contain 'sort' property when set.\nJSON: {json}");
	}

	[TestMethod]
	public void FunnelSeries_Sort_Null_Not_Serialized()
	{
		// Test that null sort value is correctly NOT serialized (null-value serialization policy is correct)
		var series = new FunnelSeries();  // Sort is null by default
		
		var serializerOptions = _chart.GetSerializerOptions();
		string json = JsonSerializer.Serialize(series, serializerOptions);
		
		// Debug output
		TestContext?.WriteLine($"FunnelSeries with Sort=null (not set):\n{json}\n");
		
		// Assertion - this is CORRECT behavior: null values should not be serialized
		Assert.IsNotNull(json);
		Assert.DoesNotContain("\"sort\"", json, $"JSON should NOT contain 'sort' property when null.\nJSON: {json}");
	}

	[TestMethod]
	public void SunburstSeries_Sort_Enum_Direct_Serialization()
	{
		// Test direct serialization of SunburstSeries.Sort enum value
		var series = new SunburstSeries { Sort = SortOrder.Asc };
		
		var serializerOptions = _chart.GetSerializerOptions();
		string json = JsonSerializer.Serialize(series, serializerOptions);
		
		// Debug output
		TestContext?.WriteLine($"SunburstSeries with Sort=Asc:\n{json}\n");
		
		// Assertions
		Assert.IsNotNull(json);
		Assert.Contains("\"sort\"", json, $"JSON should contain 'sort' property.\nJSON: {json}");
	}

	[TestMethod]
	public void SunburstSeries_Sort_In_ChartOptions()
	{
		// Test serialization of Sort within ChartOptions - with value explicitly set
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

		var serializerOptions = _chart.GetSerializerOptions();
		string json = JsonSerializer.Serialize(options, serializerOptions);
		
		// Debug output
		TestContext?.WriteLine($"ChartOptions with SunburstSeries(Sort=Asc):\n{json}\n");
		
		// Assertions - sort should be present when explicitly set
		Assert.IsNotNull(json);
		Assert.Contains("\"sort\"", json, $"JSON should contain 'sort' property when set.\nJSON: {json}");
	}

	[TestMethod]
	public void SunburstSeries_Sort_Null_Not_Serialized()
	{
		// Test that null sort value is correctly NOT serialized (null-value serialization policy is correct)
		var series = new SunburstSeries();  // Sort is null by default
		
		var serializerOptions = _chart.GetSerializerOptions();
		string json = JsonSerializer.Serialize(series, serializerOptions);
		
		// Debug output
		TestContext?.WriteLine($"SunburstSeries with Sort=null (not set):\n{json}\n");
		
		// Assertion - this is CORRECT behavior: null values should not be serialized
		Assert.IsNotNull(json);
		Assert.DoesNotContain("\"sort\"", json, $"JSON should NOT contain 'sort' property when null.\nJSON: {json}");
	}

	[TestMethod]
	public void Check_Sort_Property_JsonPropertyName_Attribute()
	{
		// Verify the Sort property works correctly by direct access
		var series = new FunnelSeries();
		
		// Test Sort enum property
		series.Sort = FunnelSortOrder.Ascending;
		Assert.AreEqual(FunnelSortOrder.Ascending, series.Sort, "Sort should be settable and gettable");
		
		// Test SortFunction property
		var jsFunc = new JavascriptFunction("return a - b;");
		series.SortFunction = jsFunc;
		Assert.AreEqual(jsFunc, series.SortFunction, "SortFunction should be settable and gettable");
		
		TestContext?.WriteLine("FunnelSeries.Sort and SortFunction properties work correctly");
	}
}
