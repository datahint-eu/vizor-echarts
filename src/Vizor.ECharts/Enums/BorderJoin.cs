using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(BorderJoinConverter))]
public enum BorderJoin
{
    Bevel,
    Round,
    Miter
}

public class BorderJoinConverter : JsonConverter<BorderJoin>
{
    public override BorderJoin Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for BorderJoin.");
    }

    public override void Write(Utf8JsonWriter writer, BorderJoin value, JsonSerializerOptions options)
    {
        // Serialize the enum value as a lower-case string
        writer.WriteStringValue(value.ToString().ToLower());
    }
}