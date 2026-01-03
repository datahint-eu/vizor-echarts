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

            var generator = new ObjectTypeClassGenerator(options.OutputDirectory, objType);
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
                "Series");
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
                "DataZoom");
            iDataZoomGenerator.Generate();
        }

        Console.WriteLine("done.");

        return 0;
    }
}
