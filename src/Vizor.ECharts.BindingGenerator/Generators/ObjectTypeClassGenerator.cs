using Vizor.ECharts.BindingGenerator.Types;

namespace Vizor.ECharts.BindingGenerator.Generators;

internal class ObjectTypeClassGenerator
{
    private readonly ObjectType objectType;

    private readonly string optionsFile;

    public ObjectTypeClassGenerator(string outputDir, ObjectType objectType)
    {
        this.objectType = objectType;

        string dir = outputDir;
        if (objectType.TypeGroup.Contains("Series"))
        {
            var idx = objectType.Name.IndexOf("Series");
            if (idx > 0)
            {
                var seriesName = objectType.Name[0..idx];
                dir = Path.Combine(outputDir, "Series", "Generated", seriesName);
            }
            else
            {
                dir = Path.Combine(outputDir, "Series", "Generated");
            }
        }
        else if (objectType.TypeGroup != "Options")
        {
            dir = Path.Combine(outputDir, "Options", "Generated", objectType.TypeGroup);
        }
        else
        {
            dir = Path.Combine(outputDir, "Options", "Generated");
        }

        if (dir != outputDir && !Directory.Exists(dir))
            Directory.CreateDirectory(dir);

        optionsFile = Path.Combine(dir, objectType.DotNetType + ".cs");
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
            else if (prop.MappedType is SingleOrArrayType singleOrArray)
            {
                // Generate three properties for single-or-array pattern:
                // 1. Internal object backing field with [JsonPropertyName] and [JsonInclude]
                // 2. Single accessor with [JsonIgnore]
                // 3. List accessor with [JsonIgnore]

                writer.WriteDocumentation(prop.Description);
                writer.WriteLine($"[JsonPropertyName(\"{prop.Name}\")]");
                writer.WriteLine($"[JsonInclude]");
                writer.WriteDefaultValueAttribute(prop.Default);
                writer.WriteLine($"internal object? {prop.PropertyName}Object {{ get; set; }}");
                writer.EmptyLine();

                writer.WriteDocumentation(prop.Description);
                writer.WriteLine($"[JsonIgnore]");
                writer.WriteLine($"public {singleOrArray.InnerTypeName}? {prop.PropertyName}");
                writer.OpenBrace();
                writer.WriteLine($"\tget => {prop.PropertyName}Object as {singleOrArray.InnerTypeName};");
                writer.WriteLine($"\tset => {prop.PropertyName}Object = value;");
                writer.CloseBrace();
                writer.EmptyLine();

                writer.WriteDocumentation(prop.Description);
                writer.WriteLine($"[JsonIgnore]");
                writer.WriteLine($"public List<{singleOrArray.InnerTypeName}>? {prop.PropertyName}List");
                writer.OpenBrace();
                writer.WriteLine($"\tget => {prop.PropertyName}Object as List<{singleOrArray.InnerTypeName}>;");
                writer.WriteLine($"\tset => {prop.PropertyName}Object = value;");
                writer.CloseBrace();
                writer.EmptyLine();
            }
            else if (prop.MappedType is EnumOrFunctionType enumOrFunc)
            {
                // Generate three properties for enum-or-function pattern:
                // 1. Internal object backing field with [JsonPropertyName] and [JsonInclude]
                // 2. Public enum accessor with [JsonIgnore]
                // 3. Public function accessor with [JsonIgnore]

                writer.WriteDocumentation(prop.Description);
                writer.WriteLine($"[JsonPropertyName(\"{prop.Name}\")]");
                writer.WriteDefaultValueAttribute(prop.Default);
                writer.WriteLine($"[JsonInclude]");
                writer.WriteLine($"internal object? {prop.PropertyName}Object {{ get; set; }}");
                writer.EmptyLine();

                writer.WriteDocumentation(prop.Description);
                writer.WriteLine($"[JsonIgnore]");
                writer.WriteLine($"public {enumOrFunc.EnumTypeName}? {prop.PropertyName}");
                writer.OpenBrace();
                writer.WriteLine($"\tget => ({enumOrFunc.EnumTypeName}?){prop.PropertyName}Object;");
                writer.WriteLine($"\tset => {prop.PropertyName}Object = value;");
                writer.CloseBrace();
                writer.EmptyLine();

                writer.WriteDocumentation($"A {prop.Name} function.");
                writer.WriteLine($"[JsonIgnore]");
                writer.WriteLine($"public JavascriptFunction? {prop.PropertyName}Function");
                writer.OpenBrace();
                writer.WriteLine($"\tget => {prop.PropertyName}Object as JavascriptFunction;");
                writer.WriteLine($"\tset => {prop.PropertyName}Object = value;");
                writer.CloseBrace();
                writer.EmptyLine();
            }
            else
            {
                // Skip 'type' property for Series and DataZoom - handled by polymorphic serialization
                bool isPolymorphicTypeProperty = 
                    (objectType.TypeGroup == "Series" || objectType.Name.EndsWith("DataZoom")) && 
                    prop.Name == "type";
                
                if (isPolymorphicTypeProperty)
                {
                    continue; // Skip generating the type property
                }

                // the 'type' property of anyOf objects is mandatory and non-nullable
                string defaultAssign = string.Empty;
                bool isTypeProperty = objectType.TypeGroup != "Options" && prop.Name == "type";
                if (isTypeProperty)
                {
                    defaultAssign = GetDefaultAssign(prop.Default);
                }

                writer.WriteDocumentation(prop.Description);
                writer.WriteLine($"[JsonPropertyName(\"{prop.Name}\")]");
                writer.WriteDefaultValueAttribute(prop.Default);

                if (prop.MappedType.TypeWarning != null)
                {
                    writer.WriteLine($"//TODO: Type Warning: {prop.MappedType.TypeWarning}");
                }

                // Type property is non-nullable and init-only (required by ISeries/IDataZoom interfaces)
                string nullableMarker = isTypeProperty ? "" : "?";
                string accessors = isTypeProperty ? "get; init;" : "get; set;";
                writer.WriteLine($"public {prop.MappedType.DotNetType}{nullableMarker} {prop.PropertyName} {{ {accessors} }} {defaultAssign}");
                writer.EmptyLine();

                // Special case: GraphSeries.Links and Categories should have type-safe accessors
                if (objectType.Name == "GraphSeries" && (prop.Name == "links" || prop.Name == "categories"))
                {
                    string accessorType = prop.Name == "links" ? "GraphSeriesLink" : "GraphSeriesCategory";
                    string accessorName = prop.Name == "links" ? "LinksList" : "CategoriesList";
                    
                    writer.WriteLine($"[JsonIgnore]");
                    writer.WriteLine($"public List<{accessorType}>? {accessorName}");
                    writer.OpenBrace();
                    writer.WriteLine($"\tget => {prop.PropertyName} as List<{accessorType}>;");
                    writer.WriteLine($"\tset => {prop.PropertyName} = value;");
                    writer.CloseBrace();
                    writer.EmptyLine();
                }

                // Special case: SankeySeries.Links should have type-safe accessor
                if (objectType.Name == "SankeySeries" && prop.Name == "links")
                {
                    writer.WriteLine($"[JsonIgnore]");
                    writer.WriteLine($"public List<SankeySeriesLink>? LinksList");
                    writer.OpenBrace();
                    writer.WriteLine($"\tget => {prop.PropertyName} as List<SankeySeriesLink>;");
                    writer.WriteLine($"\tset => {prop.PropertyName} = value;");
                    writer.CloseBrace();
                    writer.EmptyLine();
                }
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
