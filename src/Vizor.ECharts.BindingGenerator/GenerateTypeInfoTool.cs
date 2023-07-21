using System.Text.Json;
using System.Text.Json.Nodes;
using Vizor.ECharts.BindingGenerator.Types;
using Vizor.ECharts.BindingGenerator.Generators;
using Vizor.ECharts.BindingGenerator.Phases;
using System.Data;

namespace Vizor.ECharts.BindingGenerator;

internal class GenerateTypeInfoTool
{
	public int Run(GenerateTypeInfoOptions options)
	{
		// check if the input file exists
		if (!File.Exists(options.InputFile))
		{
			Console.WriteLine($"ERROR: file '{options.InputFile}' doesn't exist");
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

		// print information about duplicates
		using var fs = new FileStream("typeinfo.txt", FileMode.Create, FileAccess.Write);
		using var writer = new StreamWriter(fs);
		foreach (var pair in typeCollection.TypesWithDuplicates)
		{
			var diffs = new Dictionary<string, List<string>>();
			var similarity = CountSimilarTypes(pair.Value, diffs);

			writer.WriteLine();
			writer.WriteLine($"#{pair.Key}: {pair.Value.Count} (similarity: {similarity})");
			foreach (var diffPair in diffs)
			{
				writer.WriteLine($"#\t{diffPair.Key}");

				foreach (var path in diffPair.Value)
				{
					writer.WriteLine($"\t{path}");
				}
				writer.WriteLine();
			}
		}

		Console.WriteLine("done.");

		return 0;
	}

	private string CountSimilarTypes(List<ObjectType> list, Dictionary<string, List<string>> diffs)
	{
		var remainingIndices = new List<int>(list.Count);
		for (int i = 0; i < list.Count; ++i)
			remainingIndices.Add(i);

		var similarCount = new List<int>();

		while (remainingIndices.Count > 0)
		{
			var similarPaths = new List<string>();

			var current = list[remainingIndices[0]];
			var count = CountSimilarTo(list, remainingIndices, current, similarPaths);

			similarCount.Add(count);
			diffs.Add(GetPropertyList(current), similarPaths);
		}

		return string.Join(',', similarCount);
	}

	private int CountSimilarTo(List<ObjectType> list, List<int> remainingIndices, ObjectType current, List<string> similarPaths)
	{
		int count = 0;

		for (int i = remainingIndices.Count - 1; i >= 0; --i)
		{
			var index = remainingIndices[i];
			var item = list[index];

			if (CompareType(current, item))
			{
				remainingIndices.RemoveAt(i);
				count += 1;
				similarPaths.Add(item.Path);
			}
		}

		return count;
	}

	private bool CompareType(ObjectType lookupType, ObjectType objType)
	{
		var propNamesA = GetPropertyList(lookupType);
		var propNamesB = GetPropertyList(objType);

		return propNamesA == propNamesB;
	}

	private string GetPropertyList(ObjectType objectType)
	{
		var names = objectType.Properties.Select(p => p.Name).ToList();
		names.Sort();
		return string.Join(",", names);
	}
}
