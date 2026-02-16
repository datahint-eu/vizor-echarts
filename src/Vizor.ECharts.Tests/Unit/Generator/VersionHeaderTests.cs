namespace Vizor.ECharts.Tests.Unit.Generator;

[TestClass]
public class VersionHeaderTests
{
    [TestMethod]
    public void WriteNotice_WithVersion_IncludesVersionInHeader()
    {
        // Arrange
        var tempFile = Path.GetTempFileName();
        try
        {
            // Act
            using (var writer = new Vizor.ECharts.BindingGenerator.Generators.CSharpCodeWriter(tempFile))
            {
                writer.WriteNotice("5.6.0");
            }

            // Assert
            var content = File.ReadAllText(tempFile);
            var lines = content.Split('\n').Select(l => l.Trim()).ToArray();
            
            Assert.IsTrue(lines.Any(l => l.Contains("AUTO GENERATED - DO NOT EDIT")), 
                "Header should contain auto-generated warning");
            Assert.IsTrue(lines.Any(l => l.Contains("ECharts Version: 5.6.0")), 
                "Header should contain ECharts version");
            Assert.IsTrue(lines.Any(l => l.Contains("http://www.datahint.eu/")), 
                "Header should contain website URL");
        }
        finally
        {
            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }
    }

    [TestMethod]
    public void WriteNotice_WithoutVersion_OmitsVersionLine()
    {
        // Arrange
        var tempFile = Path.GetTempFileName();
        try
        {
            // Act
            using (var writer = new Vizor.ECharts.BindingGenerator.Generators.CSharpCodeWriter(tempFile))
            {
                writer.WriteNotice(null);
            }

            // Assert
            var content = File.ReadAllText(tempFile);
            var lines = content.Split('\n').Select(l => l.Trim()).ToArray();
            
            Assert.IsTrue(lines.Any(l => l.Contains("AUTO GENERATED - DO NOT EDIT")), 
                "Header should contain auto-generated warning");
            Assert.IsFalse(lines.Any(l => l.Contains("ECharts Version:")), 
                "Header should NOT contain version line when version is null");
            Assert.IsTrue(lines.Any(l => l.Contains("http://www.datahint.eu/")), 
                "Header should contain website URL");
        }
        finally
        {
            if (File.Exists(tempFile))
                File.Delete(tempFile);
        }
    }

    [TestMethod]
    [DataRow("echart-options/5.6.0/option.json", "5.6.0")]
    [DataRow("src/Vizor.ECharts.BindingGenerator/echart-options/5.6.0/option.json", "5.6.0")]
    [DataRow("C:\\Users\\Test\\echart-options\\6.0.0\\option.json", "6.0.0")]
    [DataRow("/Users/paul/echart-options/5.5.1/option.json", "5.5.1")]
    [DataRow("some/other/path/option.json", null)]
    [DataRow("echart-options/option.json", null)]
    public void ExtractVersion_FromPath_ReturnsCorrectVersion(string inputPath, string? expectedVersion)
    {
        // Arrange & Act - mirrors the actual extraction logic in GenerateOptionBindingTool
        string? extractedVersion = null;
        var pathParts = inputPath.Replace("\\", "/").Split('/');
        for (int i = 0; i < pathParts.Length - 1; i++)
        {
            if (pathParts[i] == "echart-options" && i + 1 < pathParts.Length)
            {
                var candidate = pathParts[i + 1];
                // Only accept if it's not a filename (has no extension) or looks like a version folder
                if (!candidate.Contains('.') || candidate.Split('.').Length >= 3)
                {
                    extractedVersion = candidate;
                    break;
                }
            }
        }

        // Assert
        Assert.AreEqual(expectedVersion, extractedVersion, 
            $"Version extraction from path '{inputPath}' should return '{expectedVersion}'");
    }
}
