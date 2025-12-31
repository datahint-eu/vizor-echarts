using Vizor.ECharts.BindingGenerator.Diagnostics;

namespace Vizor.ECharts.Tests.Unit.Generator;

/// <summary>
/// Tests for Phase 1 diagnostic infrastructure.
/// Validates that TypeMappingDiagnostic, DiagnosticCollector, and DiagnosticReport work correctly.
/// </summary>
[TestClass]
public class DiagnosticInfrastructureTests
{
    [TestMethod]
    public void TypeMappingDiagnostic_CanBeCreated()
    {
        var diagnostic = new TypeMappingDiagnostic
        {
            PropertyPath = "TestType.TestProp",
            Types = new List<string> { "string", "number" },
            Level = DiagnosticLevel.Supported,
            Message = "Test message",
            GeneratedType = "NumberOrString"
        };
        
        Assert.AreEqual("TestType.TestProp", diagnostic.PropertyPath);
        Assert.HasCount(2, diagnostic.Types);
        Assert.AreEqual(DiagnosticLevel.Supported, diagnostic.Level);
        Assert.AreEqual("NumberOrString", diagnostic.GeneratedType);
    }
    
    [TestMethod]
    public void TypeMappingDiagnostic_ToStringContainsExpectedInfo()
    {
        var diagnostic = new TypeMappingDiagnostic
        {
            PropertyPath = "CrossStyle.type",
            Types = new List<string> { "enum", "array", "number" },
            Level = DiagnosticLevel.Unsupported,
            Message = "Falls back to object",
            GeneratedType = "object"
        };
        
        var str = diagnostic.ToString();
        Assert.Contains("CrossStyle.type", str);
        Assert.Contains("Unsupported", str);
        Assert.Contains("object", str);
    }
    
    [TestMethod]
    public void DiagnosticCollector_CanRecordSupported()
    {
        var collector = new DiagnosticCollector();
        
        collector.RecordSupported("TestType.Prop", new List<string> { "string" }, "string");
        
        var diagnostics = collector.AllDiagnostics;
        Assert.HasCount(1, diagnostics);
        Assert.AreEqual(DiagnosticLevel.Supported, diagnostics[0].Level);
        Assert.AreEqual("TestType.Prop", diagnostics[0].PropertyPath);
    }
    
    [TestMethod]
    public void DiagnosticCollector_CanRecordPartiallySupported()
    {
        var collector = new DiagnosticCollector();
        
        collector.RecordPartiallySupported(
            "FunnelSeries.sort",
            new List<string> { "enum", "function" },
            "object",
            "Use typed accessor pattern");
        
        var diagnostics = collector.AllDiagnostics;
        Assert.HasCount(1, diagnostics);
        Assert.AreEqual(DiagnosticLevel.PartiallySupported, diagnostics[0].Level);
        Assert.AreEqual("object", diagnostics[0].GeneratedType);
    }
    
    [TestMethod]
    public void DiagnosticCollector_CanRecordUnsupported()
    {
        var collector = new DiagnosticCollector();
        
        collector.RecordUnsupported(
            "CrossStyle.type",
            new List<string> { "array", "enum", "number" },
            "object",
            "Consider EnumOrNumberArray<T>");
        
        var diagnostics = collector.AllDiagnostics;
        Assert.HasCount(1, diagnostics);
        Assert.AreEqual(DiagnosticLevel.Unsupported, diagnostics[0].Level);
    }
    
    [TestMethod]
    public void DiagnosticCollector_CanRecordRequiresInvestigation()
    {
        var collector = new DiagnosticCollector();
        
        collector.RecordRequiresInvestigation(
            "UnknownType.prop",
            new List<string> { "custom", "pattern" },
            "New pattern not yet categorized");
        
        var diagnostics = collector.AllDiagnostics;
        Assert.HasCount(1, diagnostics);
        Assert.AreEqual(DiagnosticLevel.RequiresInvestigation, diagnostics[0].Level);
    }
    
    [TestMethod]
    public void DiagnosticCollector_GetSummaryReturnsCorrectCounts()
    {
        var collector = new DiagnosticCollector();
        
        // Record various diagnostics
        collector.RecordSupported("Type1.prop1", new List<string> { "string" }, "string");
        collector.RecordSupported("Type1.prop2", new List<string> { "number" }, "double");
        collector.RecordPartiallySupported("Type2.prop1", new List<string> { "enum", "function" }, "object", "");
        collector.RecordUnsupported("Type3.prop1", new List<string> { "*", "number" }, "object");
        collector.RecordRequiresInvestigation("Type4.prop1", new List<string> { "custom" }, "");
        
        var summary = collector.GetSummary();
        Assert.AreEqual(2, summary.Supported);
        Assert.AreEqual(1, summary.Partial);
        Assert.AreEqual(1, summary.Unsupported);
        Assert.AreEqual(1, summary.Investigation);
        Assert.AreEqual(5, summary.Total);
    }
    
    [TestMethod]
    public void DiagnosticCollector_CanGenerateReport()
    {
        var collector = new DiagnosticCollector();
        
        collector.RecordSupported("Type1.prop", new List<string> { "string" }, "string");
        collector.RecordUnsupported("Type2.prop", new List<string> { "array", "enum" }, "object");
        
        var report = collector.GenerateReport();
        
        Assert.AreEqual(1, report.SupportedCount);
        Assert.AreEqual(1, report.UnsupportedCount);
        Assert.AreEqual(2, report.TotalCount);
    }
    
    [TestMethod]
    public void DiagnosticCollector_ClearRemovesAllDiagnostics()
    {
        var collector = new DiagnosticCollector();
        
        collector.RecordSupported("Type1.prop", new List<string> { "string" }, "string");
        Assert.HasCount(1, collector.AllDiagnostics);
        
        collector.Clear();
        Assert.IsEmpty(collector.AllDiagnostics);
    }
    
    [TestMethod]
    public void DiagnosticReport_CalculatesPercentagesCorrectly()
    {
        var collector = new DiagnosticCollector();
        
        // 100 supported, 0 unsupported
        for (int i = 0; i < 100; i++)
        {
            collector.RecordSupported($"Type.prop{i}", new List<string> { "string" }, "string");
        }
        
        var report = collector.GenerateReport();
        Assert.AreEqual(100, report.SupportedCount);
        Assert.AreEqual(100, report.TotalCount);
    }
    
    [TestMethod]
    public void DiagnosticReport_ToMarkdownContainsSummary()
    {
        var collector = new DiagnosticCollector();
        
        collector.RecordSupported("Type1.prop", new List<string> { "string" }, "string");
        collector.RecordUnsupported("Type2.prop", new List<string> { "array", "enum" }, "object", "Create union type");
        
        var report = collector.GenerateReport();
        var markdown = report.ToMarkdown();
        
        Assert.Contains("Type Pattern Analysis Report", markdown);
        Assert.Contains("## Summary", markdown);
        Assert.Contains("Total properties analyzed", markdown);
        Assert.Contains("Fully supported", markdown);
        Assert.Contains("Unsupported", markdown);
    }
    
    [TestMethod]
    public void DiagnosticReport_ToMarkdownIncludesUnsupportedPatterns()
    {
        var collector = new DiagnosticCollector();
        
        // Add multiple unsupported with same pattern
        collector.RecordUnsupported("Type1.prop1", new List<string> { "array", "enum" }, "object", "Create EnumOrArray<T>");
        collector.RecordUnsupported("Type2.prop2", new List<string> { "array", "enum" }, "object", "Create EnumOrArray<T>");
        
        var report = collector.GenerateReport();
        var markdown = report.ToMarkdown();
        
        Assert.Contains("Unsupported Patterns", markdown);
        Assert.Contains("array,enum", markdown);
        Assert.Contains("2 occurrences", markdown);
    }
    
    [TestMethod]
    public void DiagnosticReport_UnsupportedPatternsGroupedCorrectly()
    {
        var collector = new DiagnosticCollector();
        
        // Same pattern, different properties
        collector.RecordUnsupported("Type1.propA", new List<string> { "enum", "array" }, "object");
        collector.RecordUnsupported("Type1.propB", new List<string> { "enum", "array" }, "object");
        
        // Different pattern
        collector.RecordUnsupported("Type2.prop", new List<string> { "*", "number" }, "object");
        
        var report = collector.GenerateReport();
        var patterns = report.UnsupportedPatterns().ToList();
        
        Assert.HasCount(2, patterns);
        Assert.AreEqual(2, patterns[0].Count());  // array,enum has 2 occurrences
        Assert.AreEqual(1, patterns[1].Count());  // *,number has 1 occurrence
    }
    
    [TestMethod]
    public void DiagnosticReport_AllPatternsIncludesAllLevels()
    {
        var collector = new DiagnosticCollector();
        
        collector.RecordSupported("Type1.prop1", new List<string> { "string" }, "string");
        collector.RecordPartiallySupported("Type2.prop2", new List<string> { "enum", "function" }, "object", "");
        collector.RecordUnsupported("Type3.prop3", new List<string> { "array", "enum" }, "object");
        
        var report = collector.GenerateReport();
        var allPatterns = report.AllPatterns().ToList();
        
        // Should include all three patterns
        Assert.IsTrue(allPatterns.Any(p => p.Key == "string"));
        Assert.IsTrue(allPatterns.Any(p => p.Key == "enum,function"));
        Assert.IsTrue(allPatterns.Any(p => p.Key == "array,enum"));
    }
}
