using Vizor.ECharts.BindingGenerator.Types;

namespace Vizor.ECharts.BindingGenerator.Generators;

internal class ISeriesInterfaceGenerator
{
    private readonly string outputDirectory;
    private readonly List<ObjectType> seriesTypes;

    public ISeriesInterfaceGenerator(string outputDirectory, IEnumerable<ObjectType> seriesTypes)
    {
        this.outputDirectory = outputDirectory;
        this.seriesTypes = seriesTypes.OrderBy(s => s.Name).ToList();
    }

    public void Generate()
    {
        var outputFile = Path.Combine(outputDirectory, "Series", "Generated", "ISeries.cs");
        
        using var writer = new CSharpCodeWriter(outputFile);
        
        writer.WriteNotice();
        writer.WriteUsing("System.Text.Json.Serialization");
        writer.EmptyLine();
        writer.WriteNamespace("Vizor.ECharts");
        writer.EmptyLine();

        writer.WriteLine("[JsonPolymorphic(TypeDiscriminatorPropertyName = \"type\")]");
        
        foreach (var seriesType in seriesTypes)
        {
            // Get the type discriminator value from the default value of the type property
            var typeProperty = seriesType.Properties.FirstOrDefault(p => p.Name == "type");
            string discriminator = typeProperty?.Default?.ToString()?.Trim('"') ?? seriesType.Name.Replace("Series", "").ToLowerInvariant();
            
            writer.WriteLine($"[JsonDerivedType(typeof({seriesType.Name}), \"{discriminator}\")]");
        }
        
        writer.WriteLine("public interface ISeries");
        writer.WriteLine("{");
        writer.WriteLine("}");
        
        Console.WriteLine($"Generated ISeries.cs with {seriesTypes.Count} series types");
    }
}
