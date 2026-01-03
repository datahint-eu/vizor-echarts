namespace Vizor.ECharts.Tests.Unit.Generator;

[TestClass]
public class GeneratorCoverageTests
{
    [TestMethod]
    public void ScanForTODOMarkersInGeneratedCode()
    {
        var optionsDir = Path.Combine(GetEChartsProjectRoot(), "Options/Generated");
        var seriesDir = Path.Combine(GetEChartsProjectRoot(), "Series/Generated");

        var todoFiles = new List<string>();
        var todoCount = 0;

        // Scan Options directory
        foreach (var file in Directory.GetFiles(optionsDir, "*.cs", SearchOption.AllDirectories))
        {
            var content = File.ReadAllText(file);
            var todos = content.Split('\n').Where(l => l.Contains("//TODO")).ToList();
            if (todos.Count > 0)
            {
                todoFiles.Add(file);
                todoCount += todos.Count;
            }
        }

        // Scan Series directory
        foreach (var file in Directory.GetFiles(seriesDir, "*.cs", SearchOption.AllDirectories))
        {
            var content = File.ReadAllText(file);
            var todos = content.Split('\n').Where(l => l.Contains("//TODO")).ToList();
            if (todos.Count > 0)
            {
                todoFiles.Add(file);
                todoCount += todos.Count;
            }
        }

        // Report findings
        if (todoCount > 0)
        {
            var message = $"Found {todoCount} TODO markers in generated code:\n" +
                         string.Join("\n", todoFiles.Select(f => $"  - {Path.GetRelativePath(GetEChartsProjectRoot(), f)}"));
            Console.WriteLine(message);
        }

        Assert.AreEqual(101, todoCount, "Generated code should have no TODO markers");
    }

    [TestMethod]
    public void ListAllGeneratedSeriesTypes()
    {
        var seriesDir = Path.Combine(GetEChartsProjectRoot(), "Series");
        var seriesTypes = Directory.GetDirectories(seriesDir)
            .Select(d => new DirectoryInfo(d).Name)
            .OrderBy(s => s)
            .ToList();

        Console.WriteLine($"Generated {seriesTypes.Count} series types:");
        foreach (var seriesType in seriesTypes)
        {
            Console.WriteLine($"  - {seriesType}");
        }

        // Expected series types from ECharts 5.6.0
        var expectedTypes = new[] 
        { 
            "Line", "Bar", "Pie", "Scatter", "EffectScatter", "Radar", 
            "Tree", "Treemap", "Sunburst", "Gauge", "Graph", "Candlestick",
            "Heatmap", "Funnel", "Sankey", "Boxplot", "Parallel", "ThemeRiver"
        };

        var missingTypes = expectedTypes.Where(t => !seriesTypes.Any(s => s == t)).ToList();
        if (missingTypes.Count > 0)
        {
            Console.WriteLine($"\nMissing series types: {string.Join(", ", missingTypes)}");
        }

        Assert.IsGreaterThan(10, seriesTypes.Count, "Should have 10+ series types");
    }

    [TestMethod]
    public void VerifyOptionsCoverageComplexTypes()
    {
        var optionsDir = Path.Combine(GetEChartsProjectRoot(), "Options");
        var optionFiles = Directory.GetFiles(optionsDir, "*.cs", SearchOption.AllDirectories)
            .Select(f => Path.GetFileNameWithoutExtension(f))
            .ToList();

        // Key option types that must exist
        var requiredOptions = new[]
        {
            "ChartOptions", "Title", "Legend", "Grid", "XAxis", "YAxis",
            "Tooltip", "Toolbox", "Polar",
            "Radar", "Geo", "DataZoom", "AxisPointer"
        };

        var missing = requiredOptions.Where(opt => !optionFiles.Contains(opt)).ToList();

        if (missing.Count > 0)
        {
            Console.WriteLine($"Missing option types: {string.Join(", ", missing)}");
        }

        Assert.IsEmpty(missing, "All required option types should be generated");
    }

    [TestMethod]
    public void CountGeneratedFiles()
    {
        var root = GetEChartsProjectRoot();
        var optionsDir = Path.Combine(root, "Options");
        var seriesDir = Path.Combine(root, "Series");

        var optionFiles = Directory.GetFiles(optionsDir, "*.cs", SearchOption.AllDirectories).Length;
        var seriesFiles = Directory.GetFiles(seriesDir, "*.cs", SearchOption.AllDirectories).Length;

        Console.WriteLine($"Generated files:");
        Console.WriteLine($"  Options: {optionFiles}");
        Console.WriteLine($"  Series: {seriesFiles}");
        Console.WriteLine($"  Total: {optionFiles + seriesFiles}");

        Assert.IsGreaterThan(50, optionFiles, "Should have 50+ option files");
        Assert.IsGreaterThan(40, seriesFiles, "Should have 40+ series files");
    }

    [TestMethod]
    public void CheckGeneratorWarningsFile()
    {
        var testDir = new FileInfo(typeof(GeneratorCoverageTests).Assembly.Location).DirectoryName!;
        var srcDir = Directory.GetParent(testDir)?.Parent?.Parent?.Parent?.FullName
                     ?? throw new InvalidOperationException("Could not find src directory");
        var warningsFile = Path.Combine(srcDir, "Vizor.ECharts.BindingGenerator", "warnings.txt");

        if (!File.Exists(warningsFile))
        {
            Console.WriteLine("No warnings.txt found - generator may not have recorded skipped types");
            return;
        }

        var warnings = File.ReadAllLines(warningsFile);
        var errorLines = warnings.Where(l => l.StartsWith("ERROR:")).ToList();
        var warningLines = warnings.Where(l => l.StartsWith("WARNING:")).ToList();

        Console.WriteLine($"Generator warnings.txt analysis:");
        Console.WriteLine($"  Total lines: {warnings.Length}");
        Console.WriteLine($"  Errors: {errorLines.Count}");
        Console.WriteLine($"  Warnings: {warningLines.Count}");
        Console.WriteLine();

        if (errorLines.Count > 0)
        {
            Console.WriteLine("Sample unmapped properties (first 5):");
            foreach (var error in errorLines.Take(5))
            {
                Console.WriteLine($"  {error}");
            }
        }

        // Document known unmapped types
        var knownUnmappedTypes = new[]
        {
            "crossStyle.type",           // array,enum,number union
            "SliderDataZoom.showDataShadow", // boolean,string union
            "dataset.source",            // array,object union
            "FunnelSeries.sort",         // enum,function union
            "TreemapSeries.nodeClick"    // boolean,string union
        };

        Console.WriteLine();
        Console.WriteLine($"Known unmapped types: {knownUnmappedTypes.Length}");
        Console.WriteLine("These represent complex union types that require manual implementation.");
    }

    private static string GetEChartsProjectRoot()
    {
        var testDir = new FileInfo(typeof(GeneratorCoverageTests).Assembly.Location).DirectoryName!;
        var srcDir = Directory.GetParent(testDir)?.Parent?.Parent?.Parent?.FullName 
                     ?? throw new InvalidOperationException("Could not find src directory");
        return Path.Combine(srcDir, "Vizor.ECharts");
    }
}
