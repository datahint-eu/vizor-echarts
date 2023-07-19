using Vizor.ECharts.BindingGenerator.AST;

namespace Vizor.ECharts.BindingGenerator.Generators;

internal class ObjectTypeClassGenerator
{
	private readonly string outputDir;
	private readonly ObjectType objectType;

	private readonly string optionsFile;

	public ObjectTypeClassGenerator(string outputDir, ObjectType objectType)
	{
		this.outputDir = outputDir;
		this.objectType = objectType;

		optionsFile = Path.Combine(outputDir, objectType.DotNetType + ".cs");
	}

	public string OptionsFile => optionsFile;

	public void Generate()
	{
		using var writer = new CSharpCodeWriter(optionsFile);
		writer.WriteNotice();
		writer.EmptyLine();

		writer.WriteUsing("System.Text.Json.Serialization");
		writer.EmptyLine();

		writer.WriteNamespace("Vizor.ECharts.Generated");
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
				writer.WriteDocumentation(prop.Description);
				writer.WriteLine($"[JsonPropertyName(\"{prop.Name}\")]");
				writer.WriteLine($"public {prop.MappedType.DotNetType}? {prop.PropertyName} {{ get; set; }} ");
				writer.EmptyLine();
			}
		}

		writer.CloseBrace();
	}
}
