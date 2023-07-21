using Vizor.ECharts.BindingGenerator.Types;

namespace Vizor.ECharts.BindingGenerator.Generators;

internal class ObjectTypeClassGenerator
{
	private readonly ObjectType objectType;
	private readonly bool isSeriesType;

	private readonly string optionsFile;

	public ObjectTypeClassGenerator(string outputDir, ObjectType objectType, bool isSeriesType = false)
	{
		this.objectType = objectType;
		this.isSeriesType = isSeriesType;

		// create a subdir
		if (isSeriesType)
		{
			var idx = objectType.Name.IndexOf("Series");
			if (idx > 0)
			{
				var seriesName = objectType.Name[0..idx];

				var seriesDir = Path.Combine(outputDir, seriesName);
				if (!Directory.Exists(seriesDir))
				{
					Directory.CreateDirectory(seriesDir);
				}

				optionsFile = Path.Combine(seriesDir, objectType.DotNetType + ".cs");
			}
		}

		optionsFile ??= Path.Combine(outputDir, objectType.DotNetType + ".cs");
	}

	public string OptionsFile => optionsFile;

	public void Generate()
	{
		using var writer = new CSharpCodeWriter(optionsFile);
		writer.WriteNotice();
		writer.EmptyLine();

		writer.WriteUsing("System.ComponentModel");
		writer.WriteUsing("System.Text.Json.Serialization");
		writer.EmptyLine();

		writer.WriteNamespace("Vizor.ECharts");
		writer.EmptyLine();

		writer.WriteClassDeclaration(objectType.DotNetType);
		writer.OpenBrace();

		foreach (var prop in objectType.Properties)
		{
			if (prop.MappedType == null)
			{
				writer.WriteLine($"//TODO: {prop.PropertyName}");
			}
			else
			{
				// the 'type' property of series is mandatory
				string defaultAssign = string.Empty;
				if (isSeriesType && prop.Name == "type")
				{
					defaultAssign = GetDefaultAssign(prop.Default);
				}

				writer.WriteDocumentation(prop.Description);
				writer.WriteLine($"[JsonPropertyName(\"{prop.Name}\")]");
				writer.WriteDefaultValueAttribute(prop.Default);
				writer.WriteLine($"public {prop.MappedType.DotNetType}? {prop.PropertyName} {{ get; set; }} {defaultAssign}");
				writer.EmptyLine();
			}
		}

		writer.CloseBrace();
	}

	private string GetDefaultAssign(object? defaultValue)
	{
		if (defaultValue == null)
			return string.Empty;

		if (defaultValue is string str)
		{
			return $" = \"{str}\";";
		}
		else if (defaultValue is bool b)
		{
			return $" = {b.ToString().ToLower()};";
		}
		else if (defaultValue is double d)
		{
			if ((d - (int)d) != 0)
			{
				// doubles with fractional part --> always write .
				return $" = {d.ToString(System.Globalization.CultureInfo.InvariantCulture)};";
			}
			else
			{
				// integers
				return $" = {d};";
			}
		}
		else
		{
			return $" = {defaultValue};";
		}
	}
}
