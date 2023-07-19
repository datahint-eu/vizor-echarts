using System.Text.Json;
using System.Text.Json.Nodes;
using Vizor.ECharts.BindingGenerator.AST;

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

		var jsonOptions = new JsonDocumentOptions
		{
			CommentHandling = JsonCommentHandling.Skip,
		};

		using JsonDocument document = JsonDocument.Parse(File.ReadAllText(options.InputFile), jsonOptions);
		var optionElem = document.RootElement.GetProperty("option");

		var parser = new Parser();
		var chartOptions = parser.ParseRoot(optionElem);

		/*
		{
			// Access the root element
			JsonElement root = document.RootElement;

			// Iterate through all properties
			foreach (JsonProperty property in root.EnumerateObject())
			{
				Console.WriteLine($"Property Name: {property.Name}");

				// Access the property values
				foreach (JsonProperty subProperty in property.Value.EnumerateObject())
				{
					Console.WriteLine($"   Subproperty Name: {subProperty.Name}, Value: {subProperty.Value}");
				}
			}
		}
		*/

		return 0;
	}
}
