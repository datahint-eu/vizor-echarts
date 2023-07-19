using System.Text.Json;
using System.Text.Json.Nodes;
using Vizor.ECharts.BindingGenerator.AST;
using Vizor.ECharts.BindingGenerator.Generators;

namespace Vizor.ECharts.BindingGenerator;

internal class GenerateOptionBindingTool
{
	public int Run(GenerateOptionBindingOptions options)
	{
        if (!File.Exists(options.InputFile))
        {
            Console.WriteLine($"ERROR: file '{options.InputFile}' doesn't exist");
            return 1;
        }

		if (!Directory.Exists(options.OutputDirectory))
		{
			Console.WriteLine($"ERROR: directory '{options.OutputDirectory}' doesn't exist");
			return 1;
		}

		var generatedOptionsDir = Path.Combine(options.OutputDirectory, "Generated"); //TODO
		if (!Directory.Exists(generatedOptionsDir))
		{
			Directory.CreateDirectory(generatedOptionsDir);
		}

		var jsonOptions = new JsonDocumentOptions
		{
			CommentHandling = JsonCommentHandling.Skip,
		};

		using JsonDocument document = JsonDocument.Parse(File.ReadAllText(options.InputFile), jsonOptions);
		var optionElem = document.RootElement.GetProperty("option");

		var parser = new Parser();
		var chartOptions = parser.ParseRoot(optionElem);

		Console.WriteLine($"{parser.GeneratedTypes.Count} types will be generated");

		foreach (var objType in parser.GeneratedTypes.Values)
		{
			var generator = new ObjectTypeClassGenerator(generatedOptionsDir, objType);
			Console.WriteLine($"Generating {generator.OptionsFile}");
			generator.Generate();
		}

		return 0;
	}
}
