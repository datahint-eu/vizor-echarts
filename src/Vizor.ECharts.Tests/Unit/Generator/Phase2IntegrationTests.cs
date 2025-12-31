using Microsoft.VisualStudio.TestTools.UnitTesting;
using Vizor.ECharts.BindingGenerator.Diagnostics;
using Vizor.ECharts.BindingGenerator.Types;

namespace Vizor.ECharts.Tests.Unit.Generator;

[TestClass]
public class Phase2IntegrationTests
{
    [TestMethod]
    public void DiagnosticCollector_CollectsMultiplePatterns()
    {
        // Arrange
        var typeCollection = new TypeCollection();
        var patternRegistry = new TypePatternRegistry(typeCollection);
        var collector = new DiagnosticCollector();

        // Simulate collecting diagnostics for various patterns
        // (This is what BasePhase.MapType() does now)
        
        // Supported patterns
        collector.RecordSupported("ChartOptions.title", new List<string> { "string" }, "string");
        collector.RecordSupported("ChartOptions.show", new List<string> { "boolean" }, "bool");
        collector.RecordSupported("ChartOptions.left", new List<string> { "number", "string" }, "NumberOrString");
        collector.RecordSupported("ChartOptions.color", new List<string> { "color" }, "Color");
        
        // Partially supported
        collector.RecordPartiallySupported(
            "Series.symbol", 
            new List<string> { "enum", "function" }, 
            "EnumOrFunctionType",
            "Consider full wrapper");
        
        // Unsupported patterns
        collector.RecordUnsupported("Series.data", new List<string> { "array", "number", "object" }, "object", "Create custom type");
        collector.RecordUnsupported("Axis.labels", new List<string> { "array", "function", "string" });
        
        // Act: Generate report
        var report = collector.GenerateReport();
        
        // Assert: Verify counts
        Assert.AreEqual(7, report.TotalCount);
        Assert.AreEqual(4, report.SupportedCount);
        Assert.AreEqual(1, report.PartiallyCount);
        Assert.AreEqual(2, report.UnsupportedCount);
        
        // Display the results (this shows Phase 2 diagnostic collection working!)
        Console.WriteLine("\n=== DIAGNOSTIC REPORT (Phase 2 Demo) ===");
        Console.WriteLine($"Total properties analyzed: {report.TotalCount}");
        Console.WriteLine($"✅ Supported: {report.SupportedCount}");
        Console.WriteLine($"⚠️ Partially Supported: {report.PartiallyCount}");
        Console.WriteLine($"❌ Unsupported: {report.UnsupportedCount}");
        Console.WriteLine($"🔍 Requires Investigation: {report.InvestigateCount}");
        
        // Show all patterns encountered
        Console.WriteLine("\n=== ALL PATTERNS BY FREQUENCY ===");
        foreach (var pattern in report.AllPatterns())
        {
            var level = pattern.First().Level;
            var icon = level == DiagnosticLevel.Supported ? "✅" :
                      level == DiagnosticLevel.PartiallySupported ? "⚠️" :
                      level == DiagnosticLevel.Unsupported ? "❌" : "🔍";
            Console.WriteLine($"  {icon} {pattern.Key}: {pattern.Count()} occurrence(s)");
        }
        
        // Show unsupported patterns with suggestions
        Console.WriteLine("\n=== UNSUPPORTED PATTERNS WITH SUGGESTIONS ===");
        foreach (var diagnostic in collector.AllDiagnostics.Where(d => d.Level == DiagnosticLevel.Unsupported))
        {
            Console.WriteLine($"  ❌ {diagnostic.PropertyPath}:");
            Console.WriteLine($"     Pattern: {string.Join(", ", diagnostic.Types)}");
            Console.WriteLine($"     Reason: {diagnostic.Message}");
            if (!string.IsNullOrEmpty(diagnostic.Suggestion))
                Console.WriteLine($"     Suggestion: {diagnostic.Suggestion}");
        }
    }
    
    [TestMethod]
    public void DiagnosticCollector_GeneratesMarkdownReport()
    {
        // Arrange
        var typeCollection = new TypeCollection();
        var collector = new DiagnosticCollector();
        
        // Simulate realistic pattern distribution
        collector.RecordSupported("Options.title", new List<string> { "string" }, "string");
        collector.RecordSupported("Options.show", new List<string> { "boolean" }, "bool");
        collector.RecordSupported("Options.width", new List<string> { "number" }, "double?");
        collector.RecordSupported("Options.left", new List<string> { "number", "string" }, "NumberOrString");
        collector.RecordSupported("Options.color", new List<string> { "color" }, "Color");
        collector.RecordSupported("Options.formatter", new List<string> { "function" }, "JavascriptFunction");
        
        collector.RecordPartiallySupported("Options.symbol", new List<string> { "enum", "function" }, "EnumOrFunctionType", "Add wrapper");
        
        collector.RecordUnsupported("Options.complexData", new List<string> { "array", "object", "string" }, "object", "Create custom type");
        collector.RecordUnsupported("Options.wildcard", new List<string> { "*", "number" }, "object", "Investigate usage");
        
        // Act: Generate markdown report
        var report = collector.GenerateReport();
        var markdown = report.ToMarkdown();
        
        // Assert
        Assert.IsNotNull(markdown);
        Assert.Contains("# Type Pattern Analysis Report", markdown);
        Assert.Contains("## Summary", markdown);
        Assert.Contains("## Unsupported Patterns", markdown);
        
        // Display the full markdown report
        Console.WriteLine("\n=== GENERATED MARKDOWN REPORT ===");
        Console.WriteLine(markdown);
    }
}
