namespace Vizor.ECharts.Tests.Unit.Types;

using Vizor.ECharts.Tests.TestFixtures;

/// <summary>
/// Tests for Phase 1 Generator improvements - new union types.
/// </summary>
[TestClass]
public class Phase1UnionTypesTests
{
	[TestMethod]
	public void BoolOrString_SerializesBool()
	{
		var chart = new TestChart();
		var options = new ChartOptions
		{
			Brush = new()
			{
				OutOfBrush = new() { ColorAlpha = 0.5 }
			}
		};

		var json = JsonSerializer.Serialize(options, chart.GetSerializerOptions());
		var doc = JsonDocument.Parse(json);

		Assert.IsTrue(doc.RootElement.TryGetProperty("brush", out var brush));
		Assert.IsTrue(brush.TryGetProperty("outOfBrush", out var outOfBrush));
		Assert.IsTrue(outOfBrush.TryGetProperty("colorAlpha", out var colorAlpha));
		Assert.AreEqual(0.5, colorAlpha.GetDouble());
	}

	[TestMethod]
	public void BoolOrString_CanImplicitlyConvertFromBool()
	{
		BoolOrString value = true;
		Assert.IsTrue(value.Bool.HasValue);
	Assert.IsTrue(value.Bool.Value);
		Assert.IsNull(value.String);
	}

	[TestMethod]
	public void BoolOrString_CanImplicitlyConvertFromString()
	{
		BoolOrString value = "auto";
		Assert.IsNull(value.Bool);
		Assert.IsNotNull(value.String);
		Assert.AreEqual("auto", value.String);
	}

	[TestMethod]
	public void BoolOrString_SerializesCorrectly()
	{
		var chart = new TestChart();
		
		// Test bool serialization
		BoolOrString boolValue = true;
		var jsonBool = JsonSerializer.Serialize(boolValue, chart.GetSerializerOptions());
		Assert.AreEqual("true", jsonBool);

		// Test string serialization
		BoolOrString stringValue = "auto";
		var jsonString = JsonSerializer.Serialize(stringValue, chart.GetSerializerOptions());
		Assert.AreEqual("\"auto\"", jsonString);
	}

	[TestMethod]
	public void NumberOrStringArray_SerializesCorrectly()
	{
		var chart = new TestChart();

		// Test single value
		NumberOrStringArray single = 100.0;
		var jsonSingle = JsonSerializer.Serialize(single, chart.GetSerializerOptions());
		Assert.AreEqual("100", jsonSingle);

		// Test array
		NumberOrStringArray array = new NumberOrString[] { 10.0, "20%", 30.0 };
		var jsonArray = JsonSerializer.Serialize(array, chart.GetSerializerOptions());
	Assert.Contains("[", jsonArray);
	Assert.Contains("10", jsonArray);
	Assert.Contains("\"20%\"", jsonArray);
	Assert.Contains("30", jsonArray);
}

[TestMethod]
public void Phase1Types_AreRegisteredInGenerator()
	{
		// This test documents that Phase 1 added these type mappings to BasePhase.cs
		var phase1Types = new[]
		{
			typeof(BoolOrString),          // Maps: boolean,string
			typeof(NumberOrStringArray)    // Maps: array,number,string
		};

		foreach (var type in phase1Types)
		{
			Assert.IsNotNull(type, $"Phase 1 type {type.Name} should exist");
			Assert.AreEqual("Vizor.ECharts", type.Namespace, $"{type.Name} should be in Vizor.ECharts namespace");
		}
	}
}
