using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(TreeLayoutConverter))]
public enum TreeLayout
{
    Orthogonal,
    Radial
}

public class TreeLayoutConverter : JsonConverter<TreeLayout>
{
    public override TreeLayout Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for TreeLayout.");
    }

    public override void Write(Utf8JsonWriter writer, TreeLayout value, JsonSerializerOptions options)
    {
        // Serialize the enum value as a lower-case string
        writer.WriteStringValue(value.ToString().ToLower());
    }
}