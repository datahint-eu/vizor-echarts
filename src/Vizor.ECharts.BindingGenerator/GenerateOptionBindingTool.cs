using System.Text.Json;

using Vizor.ECharts.BindingGenerator.Generators;
using Vizor.ECharts.BindingGenerator.Phases;
using Vizor.ECharts.BindingGenerator.Types;

namespace Vizor.ECharts.BindingGenerator;

internal class GenerateOptionBindingTool
{
    public int Run(GenerateOptionBindingOptions options)
    {
        // check if the input file exists
        if (!File.Exists(options.InputFile))
        {
            Console.WriteLine($"ERROR: file '{options.InputFile}' doesn't exist");
            return 1;
        }

        // check if the output dir exists
        if (!Directory.Exists(options.OutputDirectory))
        {
            Console.WriteLine($"ERROR: directory '{options.OutputDirectory}' doesn't exist");
            return 1;
        }

        // Extract ECharts version from input path (e.g., "5.6.0" from "echart-options/5.6.0/option.json")
        string? echartsVersion = null;
        var pathParts = options.InputFile.Replace("\\", "/").Split('/');
        for (int i = 0; i < pathParts.Length - 1; i++)
        {
            if (pathParts[i] == "echart-options" && i + 1 < pathParts.Length)
            {
                var candidate = pathParts[i + 1];
                // Only accept if it's not a filename (has no extension) or looks like a version folder
                if (!candidate.Contains('.') || candidate.Split('.').Length >= 3)
                {
                    echartsVersion = candidate;
                    break;
                }
            }
        }

        // parse the input JSON
        var jsonOptions = new JsonDocumentOptions
        {
            CommentHandling = JsonCommentHandling.Skip,
        };
        using JsonDocument document = JsonDocument.Parse(File.ReadAllText(options.InputFile), jsonOptions);
        var optionElem = document.RootElement.GetProperty("option");

        // process the input JSON
        var typeCollection = new TypeCollection();
        var phases = new List<BasePhase> {
            new GenerateObjectTypesPhase(typeCollection)
        };

        foreach (var phase in phases)
        {
            phase.Run(optionElem);
        }

        //var parser = new Parser();
        //var chartOptions = parser.ParseRoot(optionElem);

        // write regular option type classes
        foreach (var objType in typeCollection.ListObjectTypesToGenerate())
        {
            // Skip shared hand-coded types
            if (objType.IsShared)
                continue;

            var generator = new ObjectTypeClassGenerator(options.OutputDirectory, objType, echartsVersion);
            generator.Generate();
        }

        // Generate ISeries interface with all JsonDerivedType attributes
        var seriesTypes = typeCollection.ListObjectTypesToGenerate()
            .Where(t => t.TypeGroup == "Series" && !t.IsShared && 
                t.Name.EndsWith("Series") && 
                !t.Name.EndsWith("SeriesData") && 
                !t.Name.EndsWith("SeriesLevel") && 
                !t.Name.EndsWith("SeriesLink") && 
                !t.Name.EndsWith("SeriesCategory"))
            .ToList();
        
        if (seriesTypes.Count > 0)
        {
            var iSeriesGenerator = new PolymorphicInterfaceGenerator(
                options.OutputDirectory, 
                "ISeries",
                "Series",
                seriesTypes,
                "Series",
                echartsVersion);
            iSeriesGenerator.Generate();
        }

        // Generate IDataZoom interface with all JsonDerivedType attributes
        var dataZoomTypes = typeCollection.ListObjectTypesToGenerate()
            .Where(t => !t.IsShared && t.Name.EndsWith("DataZoom"))
            .ToList();
        
        if (dataZoomTypes.Count > 0)
        {
            var iDataZoomGenerator = new PolymorphicInterfaceGenerator(
                options.OutputDirectory,
                "IDataZoom",
                "Options/DataZoom",
                dataZoomTypes,
                "DataZoom",
                echartsVersion);
            iDataZoomGenerator.Generate();
        }

        // Generate IVisualMap interface with all JsonDerivedType attributes
        var visualMapTypes = typeCollection.ListObjectTypesToGenerate()
            .Where(t => !t.IsShared && t.Name.EndsWith("VisualMap"))
            .ToList();
        
        if (visualMapTypes.Count > 0)
        {
            var iVisualMapGenerator = new PolymorphicInterfaceGenerator(
                options.OutputDirectory,
                "IVisualMap",
                "Options/VisualMap",
                visualMapTypes,
                "VisualMap",
                echartsVersion);
            iVisualMapGenerator.Generate();
        }

        Console.WriteLine("done.");

        return 0;
    }
}
