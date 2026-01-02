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
		var options = new ChartOptions();

		// Act - Set and verify the internal GridObject property works
		var grid = new Grid { Show = true };
		options.GridObject = grid;

		// Assert - Verify GridObject and Grid properties work
		Assert.IsNotNull(options.GridObject, "GridObject property should be accessible");
		Assert.AreEqual(grid, options.Grid, "Grid accessor should return the value");
		
		// Verify we can set via the public Grid property
		var grid2 = new Grid { Show = false };
		options.Grid = grid2;
		Assert.AreEqual(grid2, options.GridObject);
		
		// Test setting a list
		var gridList = new List<Grid> { grid, grid2 };
		options.GridObject = gridList;
		Assert.AreEqual(gridList, options.GridObject);
	}

	[TestMethod]
	public void XAxis_HasCorrectPropertyStructure()
	{
		// Arrange
		var options = new ChartOptions();

		// Act - Set and verify the internal XAxisObject property works
		var xAxis = new XAxis { Type = AxisType.Category };
		options.XAxisObject = xAxis;

		// Assert - Verify XAxisObject and XAxis properties work
		Assert.IsNotNull(options.XAxisObject, "XAxisObject property should be accessible");
		Assert.AreEqual(xAxis, options.XAxis, "XAxis accessor should return the value");
		
		// Verify we can set via the public XAxis property
		var xAxis2 = new XAxis { Type = AxisType.Value };
		options.XAxis = xAxis2;
		Assert.AreEqual(xAxis2, options.XAxisObject);
		
		// Test setting a list
		var xAxisList = new List<XAxis> { xAxis, xAxis2 };
		options.XAxisObject = xAxisList;
		Assert.AreEqual(xAxisList, options.XAxisObject);
	}

	[TestMethod]
	public void YAxis_HasCorrectPropertyStructure()
	{
		// Arrange
		var options = new ChartOptions();

		// Act - Set and verify the internal YAxisObject property works
		var yAxis = new YAxis { Type = AxisType.Value };
		options.YAxisObject = yAxis;

		// Assert - Verify YAxisObject and YAxis properties work
		Assert.IsNotNull(options.YAxisObject, "YAxisObject property should be accessible");
		Assert.AreEqual(yAxis, options.YAxis, "YAxis accessor should return the value");
		
		// Verify we can set via the public YAxis property
		var yAxis2 = new YAxis { Type = AxisType.Category };
		options.YAxis = yAxis2;
		Assert.AreEqual(yAxis2, options.YAxisObject);
		
		// Test setting a list
		var yAxisList = new List<YAxis> { yAxis, yAxis2 };
		options.YAxisObject = yAxisList;
		Assert.AreEqual(yAxisList, options.YAxisObject);
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

		// Act - Set via public Grid/GridList accessors
		options1.Grid = singleGrid;
		options2.GridList = gridList;

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
		// Verify the single-or-array pattern works for Grid, XAxis, YAxis, etc.
		var options = new ChartOptions();
		
		// Test Grid - can hold single or list
		var grid = new Grid { Show = true };
		options.Grid = grid;
		Assert.AreEqual(grid, options.GridObject);
		
		var gridList = new List<Grid> { grid };
		options.GridObject = gridList;
		Assert.AreEqual(gridList, options.GridObject);
		
		// Test XAxis - can hold single or list
		var xAxis = new XAxis { Type = AxisType.Category };
		options.XAxis = xAxis;
		Assert.AreEqual(xAxis, options.XAxisObject);
		
		var xAxisList = new List<XAxis> { xAxis };
		options.XAxisObject = xAxisList;
		Assert.AreEqual(xAxisList, options.XAxisObject);
		
		// Test YAxis - can hold single or list
		var yAxis = new YAxis { Type = AxisType.Value };
		options.YAxis = yAxis;
		Assert.AreEqual(yAxis, options.YAxisObject);
		
		var yAxisList = new List<YAxis> { yAxis };
		options.YAxisObject = yAxisList;
		Assert.AreEqual(yAxisList, options.YAxisObject);
	}
}
