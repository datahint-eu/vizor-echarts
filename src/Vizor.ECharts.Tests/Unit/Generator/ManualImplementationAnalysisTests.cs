namespace Vizor.ECharts.Tests.Unit.Generator;

/// <summary>
/// Analyzes manual implementations in Vizor.ECharts to identify patterns that could be automated in the Generator.
/// </summary>
[TestClass]
public class ManualImplementationAnalysisTests
{
	private static string GetEChartsProjectRoot()
	{
		var testAssemblyPath = typeof(ManualImplementationAnalysisTests).Assembly.Location;
		var testProjectDir = Path.GetDirectoryName(testAssemblyPath)!;
		return Path.GetFullPath(Path.Combine(testProjectDir, "..", "..", "..", "..", "Vizor.ECharts"));
	}

	[TestMethod]
	public void FindUnionTypePropertiesWithObject()
	{
		// Union types that fall back to 'object' are candidates for custom type implementations
		var projectRoot = GetEChartsProjectRoot();
		var optionsDir = Path.Combine(projectRoot, "Options");
		var seriesDir = Path.Combine(projectRoot, "Series");

		var unionTypeProperties = new List<(string FilePath, string PropertyName, string Pattern)>();

		// Search for properties with "Object" suffix that have typed accessors (like TypeObject, SortObject)
		var allFiles = Directory.GetFiles(optionsDir, "*.cs", SearchOption.AllDirectories)
			.Concat(Directory.GetFiles(seriesDir, "*.cs", SearchOption.AllDirectories));

		foreach (var file in allFiles)
		{
			var content = File.ReadAllText(file);
			var lines = content.Split('\n');

			for (int i = 0; i < lines.Length; i++)
			{
				var line = lines[i];

				// Pattern: public object? SomeNameObject { get; set; }
				if (line.Contains("public object?") && line.Contains("Object { get; set; }"))
				{
					var match = System.Text.RegularExpressions.Regex.Match(line, @"public object\?\s+(\w+Object)\s+\{");
					if (match.Success)
					{
						var propertyName = match.Groups[1].Value;
						var relativePath = Path.GetRelativePath(projectRoot, file);

						// Check if there's a typed accessor below it ([JsonIgnore] wrapper)
						var hasTypedAccessor = i + 1 < lines.Length && lines.Skip(i + 1).Take(10).Any(l => l.Contains("[JsonIgnore]"));

						if (hasTypedAccessor)
						{
							unionTypeProperties.Add((relativePath, propertyName, "object with typed accessor"));
						}
					}
				}
			}
		}

		Console.WriteLine($"Found {unionTypeProperties.Count} union type properties using object + typed accessor pattern:");
		foreach (var (filePath, propertyName, pattern) in unionTypeProperties.Take(10))
		{
			Console.WriteLine($"  {filePath}: {propertyName} ({pattern})");
		}

		Assert.IsNotEmpty(unionTypeProperties, "Expected to find union type properties with object fallback");
	}

	[TestMethod]
	public void AnalyzeCustomTypesInTypesFolder()
	{
		// Custom types in Types/ folder represent manual implementations for union types
		var projectRoot = GetEChartsProjectRoot();
		var typesDir = Path.Combine(projectRoot, "Types");

		var customTypes = Directory.GetFiles(typesDir, "*.cs", SearchOption.TopDirectoryOnly)
			.Where(f => !f.Contains("SeriesData") && !f.Contains("ExternalData") && !f.Contains("JavascriptFunction"))
			.Select(f => new
			{
				Name = Path.GetFileNameWithoutExtension(f),
				Path = f,
				Content = File.ReadAllText(f)
			})
			.ToList();

		// Categorize by pattern
		var converterTypes = customTypes.Where(t => t.Content.Contains("JsonConverter")).ToList();
		var unionTypes = converterTypes.Where(t =>
			t.Name.Contains("Or") || t.Name.Contains("Array")).ToList();

		Console.WriteLine($"Total custom types in Types/: {customTypes.Count}");
		Console.WriteLine($"Types with JsonConverter: {converterTypes.Count}");
		Console.WriteLine($"Union types (Or/Array): {unionTypes.Count}");

		Console.WriteLine("\nUnion type patterns found:");
		foreach (var type in unionTypes)
		{
			Console.WriteLine($"  {type.Name}");
		}

		// Check which patterns are already handled
		var knownPatterns = new[]
		{
			"NumberOrBool", "NumberOrString", "NumberOrNumberArray",
			"StringOrFunction", "NumberOrFunction", "ObjectOrFunction",
			"ColorOrFunction", "NumberOrStringOrFunction",
			"NumberArrayOrFunction", "NumberArray", "ColorArray",
			"BoolOrString", "NumberOrStringArray"
		};

		var missingPatterns = unionTypes
			.Where(t => !knownPatterns.Contains(t.Name))
			.Select(t => t.Name)
			.ToList();

		if (missingPatterns.Any())
		{
			Console.WriteLine($"\nCustom types NOT in Generator's BasePhase.cs mapping:");
			foreach (var pattern in missingPatterns)
			{
				Console.WriteLine($"  {pattern}");
			}
		}

	Assert.IsGreaterThanOrEqualTo(10, unionTypes.Count, "Expected at least 10 union type implementations");
}

[TestMethod]
public void MapWarningsToManualImplementations()
{
	// Cross-reference warnings.txt with actual implementations
	var projectRoot = GetEChartsProjectRoot();
	var generatorRoot = Path.GetFullPath(Path.Combine(projectRoot, "..", "Vizor.ECharts.BindingGenerator"));
		var warningsFile = Path.Combine(generatorRoot, "warnings.txt");

		if (!File.Exists(warningsFile))
		{
			Assert.Inconclusive("warnings.txt not found");
			return;
		}

		var warnings = File.ReadAllLines(warningsFile);

		// Extract unmapped properties from ERROR lines
		var unmappedProperties = new List<(string PropertyName, string ParentType, string Types)>();

		foreach (var line in warnings.Where(l => l.StartsWith("ERROR:")))
		{
			// Format: ERROR: Failed to map property 'type' in type 'crossStyle' with types 'array,enum,number'
			var match = System.Text.RegularExpressions.Regex.Match(line, 
				@"Failed to map property '(\w+)' in type '(\w+)' with types '([^']+)'");

			if (match.Success)
			{
				unmappedProperties.Add((match.Groups[1].Value, match.Groups[2].Value, match.Groups[3].Value));
			}
		}

		Console.WriteLine($"Unmapped properties from warnings.txt: {unmappedProperties.Count}");

		// Check if these properties exist in the codebase (manual implementations)
		var implementedManually = new List<string>();
		var notImplemented = new List<string>();

		foreach (var (propName, parentType, types) in unmappedProperties.Distinct())
		{
			// Search for the property in the generated code
			var searchPattern = $"[JsonPropertyName(\"{propName}\")]";
			var optionsDir = Path.Combine(projectRoot, "Options");
			var seriesDir = Path.Combine(projectRoot, "Series");

			var found = Directory.GetFiles(optionsDir, "*.cs", SearchOption.AllDirectories)
				.Concat(Directory.GetFiles(seriesDir, "*.cs", SearchOption.AllDirectories))
				.Any(f => File.ReadAllText(f).Contains(searchPattern) &&
					Path.GetFileNameWithoutExtension(f).Equals(parentType, StringComparison.OrdinalIgnoreCase));

			if (found)
			{
				implementedManually.Add($"{parentType}.{propName} ({types})");
			}
			else
			{
				notImplemented.Add($"{parentType}.{propName} ({types})");
			}
		}

		Console.WriteLine($"\nManually implemented (Generator produced fallback): {implementedManually.Count}");
		foreach (var impl in implementedManually.Take(10))
		{
			Console.WriteLine($"  ✓ {impl}");
		}

		Console.WriteLine($"\nNot implemented (skipped entirely): {notImplemented.Count}");
		foreach (var skip in notImplemented.Take(5))
		{
			Console.WriteLine($"  ✗ {skip}");
		}

		Assert.IsNotEmpty(implementedManually, "Expected to find manual implementations for unmapped properties");
	}

	[TestMethod]
	public void AnalyzeGeneratorMappingPatterns()
	{
		// Read TypePatternRegistry.cs to understand current Generator capabilities
		var projectRoot = GetEChartsProjectRoot();
		var generatorRoot = Path.GetFullPath(Path.Combine(projectRoot, "..", "Vizor.ECharts.BindingGenerator"));
		var registryFile = Path.Combine(generatorRoot, "Types", "TypePatternRegistry.cs");

		if (!File.Exists(registryFile))
		{
			Assert.Inconclusive("TypePatternRegistry.cs not found");
			return;
		}

		var content = File.ReadAllText(registryFile);

		// Extract all type pattern mappings from SupportedPatterns dictionary
		var patterns = new List<string>();
		
		// Pattern: { "type1,type2", typeof(CustomType) },
		var dictionaryMatches = System.Text.RegularExpressions.Regex.Matches(content,
			@"\{\s*""([^""]+)"",\s*typeof\([^)]+\)\s*\}");

		foreach (System.Text.RegularExpressions.Match match in dictionaryMatches)
		{
			patterns.Add(match.Groups[1].Value);
		}

		Console.WriteLine($"Generator currently handles {patterns.Count} type combination patterns:");
		foreach (var pattern in patterns.OrderBy(p => p))
		{
			Console.WriteLine($"  {pattern}");
		}

		// Check for patterns in warnings.txt that COULD be added
		var generatorRootPath = Path.GetFullPath(Path.Combine(projectRoot, "..", "Vizor.ECharts.BindingGenerator"));
		var warningsFile = Path.Combine(generatorRootPath, "warnings.txt");

		if (File.Exists(warningsFile))
		{
			var warnings = File.ReadAllLines(warningsFile);
			var unmappedPatterns = warnings
				.Where(l => l.StartsWith("ERROR:"))
				.Select(l =>
				{
					var match = System.Text.RegularExpressions.Regex.Match(l,
						@"with types '([^']+)'");
					return match.Success ? match.Groups[1].Value : null;
				})
				.Where(p => p != null)
				.Distinct()
				.OfType<string>()
				.ToList();

			Console.WriteLine($"\nUnmapped patterns in warnings.txt: {unmappedPatterns.Count}");
			foreach (var pattern in unmappedPatterns!)
			{
				var inGenerator = patterns.Contains(pattern);
				Console.WriteLine($"  {(inGenerator ? "✓" : "✗")} {pattern}");
			}
		}

		Assert.IsGreaterThan(15, patterns.Count, "Expected Generator to handle at least 15 type patterns");
	}

	[TestMethod]
	public void RecommendGeneratorImprovements()
	{
		// Analyze patterns and suggest which could be automated
		var projectRoot = GetEChartsProjectRoot();
		var generatorRoot = Path.GetFullPath(Path.Combine(projectRoot, "..", "Vizor.ECharts.BindingGenerator"));
		var warningsFile = Path.Combine(generatorRoot, "warnings.txt");

		if (!File.Exists(warningsFile))
		{
			Assert.Inconclusive("warnings.txt not found");
			return;
		}

		var warnings = File.ReadAllLines(warningsFile);

		// Parse unmapped patterns
		var unmappedPatterns = warnings
			.Where(l => l.StartsWith("ERROR:"))
			.Select(l => System.Text.RegularExpressions.Regex.Match(l,
				@"Failed to map property '(\w+)' in type '(\w+)' with types '([^']+)'"))
			.Where(m => m.Success)
			.Select(m => new
			{
				Property = m.Groups[1].Value,
				ParentType = m.Groups[2].Value,
				Types = m.Groups[3].Value
			})
			.ToList();

		// Group by type pattern
		var grouped = unmappedPatterns
			.GroupBy(p => p.Types)
			.OrderByDescending(g => g.Count())
			.ToList();

		Console.WriteLine("Generator improvement recommendations:\n");

		Console.WriteLine("1. Most common unmapped patterns (could be automated):");
		foreach (var group in grouped.Take(5))
		{
			Console.WriteLine($"   Pattern: {group.Key} (occurs {group.Count()} times)");
			Console.WriteLine($"   Examples: {string.Join(", ", group.Take(3).Select(p => $"{p.ParentType}.{p.Property}"))}");

			// Suggest implementation approach
			var types = group.Key.Split(',');
			if (types.Contains("enum") && types.Contains("array"))
			{
				Console.WriteLine($"   → Suggestion: Create custom type like 'EnumOrArray<T>' with implicit conversions");
			}
			else if (types.Contains("boolean") && types.Contains("string"))
			{
				Console.WriteLine($"   → Suggestion: Create 'BoolOrString' type (similar to NumberOrString pattern)");
			}
			else if (types.Contains("enum") && types.Contains("function"))
			{
				Console.WriteLine($"   → Suggestion: Use 'object?' with typed accessors (enum + JavascriptFunction)");
			}
			else if (types.Contains("boolean") && types.Contains("object"))
			{
				Console.WriteLine($"   → Suggestion: Use 'object?' with typed accessors (bool + complex type)");
			}
			else if (types.Length > 3)
			{
				Console.WriteLine($"   → Suggestion: Complex union - keep as 'object?' (manual implementation required)");
			}

			Console.WriteLine();
		}

		Console.WriteLine("2. Patterns already solved manually (check Types/ folder for implementations):");
		var typesDir = Path.Combine(projectRoot, "Types");
		var customTypes = Directory.GetFiles(typesDir, "*.cs", SearchOption.TopDirectoryOnly)
			.Where(f => !f.Contains("SeriesData") && !f.Contains("ExternalData"))
			.Select(f => Path.GetFileNameWithoutExtension(f))
			.Where(n => n!.Contains("Or") || n!.Contains("Array"))
			.ToList();

		foreach (var type in customTypes)
		{
			Console.WriteLine($"   {type}");
		}

		Console.WriteLine($"\n3. Current Generator coverage:");
		Console.WriteLine($"   Total properties in warnings.txt: {unmappedPatterns.Count}");
		Console.WriteLine($"   Distinct unmapped patterns: {grouped.Count}");
		Console.WriteLine($"   Manual implementations in Types/: {customTypes.Count}");

		// Calculate which patterns are solvable
		var solvablePatterns = grouped
			.Where(g => g.Key.Split(',').Length <= 3) // 2-3 type unions are usually solvable
			.Where(g => !g.Key.Contains("*")) // Wildcard types are too complex
			.ToList();

		Console.WriteLine($"   Potentially automatable patterns: {solvablePatterns.Count}/{grouped.Count}");

		Assert.IsNotEmpty(grouped, "Expected to find unmapped patterns for analysis");
	}
}
