﻿using System.Text.Json;
using System.Text.Json.Nodes;
using Vizor.ECharts.BindingGenerator.Types;
using Vizor.ECharts.BindingGenerator.Generators;
using Vizor.ECharts.BindingGenerator.Phases;
using System.Data;

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
			var generator = new ObjectTypeClassGenerator(options.OutputDirectory, objType);
			generator.Generate();
		}

		Console.WriteLine("done.");

		return 0;
	}
}
