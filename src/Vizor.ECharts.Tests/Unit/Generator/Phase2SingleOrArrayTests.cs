using System.Reflection;
using System.Text.Json;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vizor.ECharts;
using Vizor.ECharts.Tests.TestFixtures;

namespace Vizor.ECharts.Tests.Unit.Generator;

/// <summary>
/// Phase 2: Tests for SingleOrArrayType pattern (Grid, XAxis, YAxis)
/// Validates that the single-or-array pattern works correctly with typed accessors
/// </summary>
[TestClass]
public class Phase2SingleOrArrayTests
{
	[TestMethod]
	public void Grid_HasCorrectPropertyStructure()
	{
		// Arrange
		var chartOptionsType = typeof(ChartOptions);

		// Act - Check for three properties: GridObject, Grid, GridList
		var gridObjectProp = chartOptionsType.GetProperty("GridObject");
		var gridProp = chartOptionsType.GetProperty("Grid");
		var gridListProp = chartOptionsType.GetProperty("GridList");

		// Assert
		Assert.IsNotNull(gridObjectProp, "GridObject property should exist");
		Assert.IsNotNull(gridProp, "Grid property should exist");
		Assert.IsNotNull(gridListProp, "GridList property should exist");

		// GridObject should be object type
		Assert.AreEqual(typeof(object), Nullable.GetUnderlyingType(gridObjectProp.PropertyType) ?? gridObjectProp.PropertyType);

		// Grid should be Grid type
		Assert.AreEqual(typeof(Grid), Nullable.GetUnderlyingType(gridProp.PropertyType) ?? gridProp.PropertyType);

		// GridList should be List<Grid> type
		Assert.AreEqual(typeof(List<Grid>), Nullable.GetUnderlyingType(gridListProp.PropertyType) ?? gridListProp.PropertyType);
	}

	[TestMethod]
	public void XAxis_HasCorrectPropertyStructure()
	{
		// Arrange
		var chartOptionsType = typeof(ChartOptions);

		// Act
		var xAxisObjectProp = chartOptionsType.GetProperty("XAxisObject");
		var xAxisProp = chartOptionsType.GetProperty("XAxis");
		var xAxisListProp = chartOptionsType.GetProperty("XAxisList");

		// Assert
		Assert.IsNotNull(xAxisObjectProp, "XAxisObject property should exist");
		Assert.IsNotNull(xAxisProp, "XAxis property should exist");
		Assert.IsNotNull(xAxisListProp, "XAxisList property should exist");

		Assert.AreEqual(typeof(object), Nullable.GetUnderlyingType(xAxisObjectProp.PropertyType) ?? xAxisObjectProp.PropertyType);
		Assert.AreEqual(typeof(XAxis), Nullable.GetUnderlyingType(xAxisProp.PropertyType) ?? xAxisProp.PropertyType);
		Assert.AreEqual(typeof(List<XAxis>), Nullable.GetUnderlyingType(xAxisListProp.PropertyType) ?? xAxisListProp.PropertyType);
	}

	[TestMethod]
	public void YAxis_HasCorrectPropertyStructure()
	{
		// Arrange
		var chartOptionsType = typeof(ChartOptions);

		// Act
		var yAxisObjectProp = chartOptionsType.GetProperty("YAxisObject");
		var yAxisProp = chartOptionsType.GetProperty("YAxis");
		var yAxisListProp = chartOptionsType.GetProperty("YAxisList");

		// Assert
		Assert.IsNotNull(yAxisObjectProp, "YAxisObject property should exist");
		Assert.IsNotNull(yAxisProp, "YAxis property should exist");
		Assert.IsNotNull(yAxisListProp, "YAxisList property should exist");

		Assert.AreEqual(typeof(object), Nullable.GetUnderlyingType(yAxisObjectProp.PropertyType) ?? yAxisObjectProp.PropertyType);
		Assert.AreEqual(typeof(YAxis), Nullable.GetUnderlyingType(yAxisProp.PropertyType) ?? yAxisProp.PropertyType);
		Assert.AreEqual(typeof(List<YAxis>), Nullable.GetUnderlyingType(yAxisListProp.PropertyType) ?? yAxisListProp.PropertyType);
	}

	[TestMethod]
	public void Grid_SingleInstance_SerializesCorrectly()
	{
		// Arrange
		var chart = new TestChart();
		var options = new ChartOptions
		{
			Grid = new Grid
			{
				Left = "10%",
				Right = "10%",
				Top = "60",
				Bottom = "60"
			}
		};

		// Act
		string json = JsonSerializer.Serialize(options, chart.GetSerializerOptions());

		// Assert
		Assert.IsNotNull(json);
		Assert.Contains("\"grid\"", json);
		Assert.Contains("\"left\":\"10%\"", json.Replace(" ", ""));
		Assert.Contains("\"right\":\"10%\"", json.Replace(" ", ""));

		// Should not serialize as array
		Assert.DoesNotContain("[{", json, "Single Grid should not serialize as array");
	}

	[TestMethod]
	public void Grid_MultipleInstances_SerializesAsArray()
	{
		// Arrange
		var chart = new TestChart();
		var options = new ChartOptions
		{
			GridList = new List<Grid>
			{
				new Grid { Left = "0%", Right = "50%" },
				new Grid { Left = "50%", Right = "0%" }
			}
		};

		// Act
		string json = JsonSerializer.Serialize(options, chart.GetSerializerOptions());

		// Assert
		Assert.IsNotNull(json);
		Assert.Contains("\"grid\"", json);
		Assert.Contains("[", json);

		// Parse and verify it's an array
		var doc = JsonDocument.Parse(json);
		Assert.IsTrue(doc.RootElement.TryGetProperty("grid", out var gridElem));
		Assert.AreEqual(JsonValueKind.Array, gridElem.ValueKind);
		Assert.AreEqual(2, gridElem.GetArrayLength());
	}

	[TestMethod]
	public void XAxis_SingleAndMultiple_SerializeCorrectly()
	{
		// Arrange
		var chart = new TestChart();
		
		// Arrange - Single XAxis
		var singleOptions = new ChartOptions
		{
			XAxis = new XAxis { Type = AxisType.Category }
		};

		// Arrange - Multiple XAxis
		var multiOptions = new ChartOptions
		{
			XAxisList = new List<XAxis>
			{
				new XAxis { Type = AxisType.Category },
				new XAxis { Type = AxisType.Value }
			}
		};

		// Act
		string singleJson = JsonSerializer.Serialize(singleOptions, chart.GetSerializerOptions());
		string multiJson = JsonSerializer.Serialize(multiOptions, chart.GetSerializerOptions());

		// Assert - Single should not be array
		Assert.Contains("\"xAxis\"", singleJson);
	Assert.DoesNotContain("\"xAxis\":[", singleJson.Replace(" ", ""), "Single XAxis should not be an array");

	// Assert - Multiple should be array
	Assert.Contains("\"xAxis\":[", multiJson.Replace(" ", ""));
		var doc = JsonDocument.Parse(multiJson);
		Assert.IsTrue(doc.RootElement.TryGetProperty("xAxis", out var xAxisElem));
		Assert.AreEqual(JsonValueKind.Array, xAxisElem.ValueKind);
		Assert.AreEqual(2, xAxisElem.GetArrayLength());
	}

	[TestMethod]
	public void GridObject_AcceptsEitherSingleOrList()
	{
		// Arrange
		var options1 = new ChartOptions();
		var options2 = new ChartOptions();

		var singleGrid = new Grid { Left = "10%" };
		var gridList = new List<Grid> { new Grid { Left = "0%" }, new Grid { Right = "0%" } };

		// Act - Set via GridObject
		options1.GridObject = singleGrid;
		options2.GridObject = gridList;

		// Assert - Grid accessor should work for single
		Assert.IsNotNull(options1.Grid);
	Assert.IsNotNull(options1.Grid?.Left);
	Assert.AreEqual("10%", options1.Grid?.Left?.String);

		// Assert - GridList accessor should work for list
		Assert.IsNotNull(options2.GridList);
		Assert.AreEqual(2, options2.GridList?.Count);
	}

	[TestMethod]
	public void Phase2_DocumentsAutomatedProperties()
	{
		// This test documents which properties are now automated by Phase 2
		var automatedProperties = new[]
		{
			"Grid",      // ChartOptions.Grid/GridList
			"XAxis",     // ChartOptions.XAxis/XAxisList
			"YAxis",     // ChartOptions.YAxis/YAxisList
			"Calendar",  // ChartOptions.Calendar/CalendarList (also uses this pattern)
			"Dataset"    // ChartOptions.Dataset/DatasetList (also uses this pattern)
		};

		// Verify these properties follow the single-or-array pattern
		var chartOptionsType = typeof(ChartOptions);
		foreach (var propName in automatedProperties)
		{
			var objectProp = chartOptionsType.GetProperty($"{propName}Object");
			var singleProp = chartOptionsType.GetProperty(propName);
			var listProp = chartOptionsType.GetProperty($"{propName}List");

			Assert.IsNotNull(objectProp, $"{propName}Object should exist");
			Assert.IsNotNull(singleProp, $"{propName} should exist");
			Assert.IsNotNull(listProp, $"{propName}List should exist");

			// Verify JsonPropertyName is on Object property
			var jsonAttr = objectProp.GetCustomAttribute<System.Text.Json.Serialization.JsonPropertyNameAttribute>();
			Assert.IsNotNull(jsonAttr, $"{propName}Object should have JsonPropertyName attribute");

			// Verify JsonIgnore is on accessor properties
			var ignoreAttr1 = singleProp.GetCustomAttribute<System.Text.Json.Serialization.JsonIgnoreAttribute>();
			var ignoreAttr2 = listProp.GetCustomAttribute<System.Text.Json.Serialization.JsonIgnoreAttribute>();
			Assert.IsNotNull(ignoreAttr1, $"{propName} should have JsonIgnore attribute");
			Assert.IsNotNull(ignoreAttr2, $"{propName}List should have JsonIgnore attribute");
		}
	}
}
