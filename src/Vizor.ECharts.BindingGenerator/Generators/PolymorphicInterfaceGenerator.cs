using Vizor.ECharts.BindingGenerator.Types;

namespace Vizor.ECharts.BindingGenerator.Generators;

/// <summary>
/// Generates polymorphic interfaces with JsonDerivedType attributes
/// </summary>
internal class PolymorphicInterfaceGenerator
{
    private readonly string outputDirectory;
    private readonly string interfaceName;
    private readonly string subFolder;
    private readonly List<ObjectType> types;
    private readonly string typeSuffix;
    private readonly string? echartsVersion;

    public PolymorphicInterfaceGenerator(
        string outputDirectory, 
        string interfaceName,
        string subFolder,
        IEnumerable<ObjectType> types,
        string typeSuffix,
        string? echartsVersion = null)
    {
        this.outputDirectory = outputDirectory;
        this.interfaceName = interfaceName;
        this.subFolder = subFolder;
        this.types = types.OrderBy(t => t.Name).ToList();
        this.typeSuffix = typeSuffix;
        this.echartsVersion = echartsVersion;
    }

    public void Generate()
    {
        var outputFile = Path.Combine(outputDirectory, subFolder, "Generated", $"{interfaceName}.cs");
        
        using var writer = new CSharpCodeWriter(outputFile);
        
        writer.WriteNotice(echartsVersion);
        writer.WriteUsing("System.Text.Json.Serialization");
        writer.EmptyLine();
        writer.WriteNamespace("Vizor.ECharts");
        writer.EmptyLine();

        writer.WriteLine("[JsonPolymorphic(TypeDiscriminatorPropertyName = \"type\")]");
        
        foreach (var type in types)
        {
            // Get the type discriminator value from the default value of the type property
            var typeProperty = type.Properties.FirstOrDefault(p => p.Name == "type");
            string discriminator = typeProperty?.Default?.ToString()?.Trim('"') ?? 
                type.Name.Replace(typeSuffix, "").ToLowerInvariant();
            
            writer.WriteLine($"[JsonDerivedType(typeof({type.Name}), \"{discriminator}\")]");
        }
        
        writer.WriteLine($"public interface {interfaceName}");
        writer.WriteLine("{");
        writer.WriteLine("}");
        
        Console.WriteLine($"Generated {interfaceName}.cs with {types.Count} types");
    }
}
