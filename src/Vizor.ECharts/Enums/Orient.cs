using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(OrientConverter))]
public enum Orient
{
    Horizontal,
    Vertical
}

public class OrientConverter : JsonConverter<Orient>
{
    public override Orient Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for Orient.");
    }

    public override void Write(Utf8JsonWriter writer, Orient value, JsonSerializerOptions options)
    {
        // Serialize the enum value as a lower-case string
        writer.WriteStringValue(value.ToString().ToLower());
    }
}