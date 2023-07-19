using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(VAlignConverter))]
public enum VAlign
{
    Auto,
    Top,
    Bottom,
    Middle
}

public class VAlignConverter : JsonConverter<VAlign>
{
    public override VAlign Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for VAlign.");
    }

    public override void Write(Utf8JsonWriter writer, VAlign value, JsonSerializerOptions options)
    {
        // Serialize the enum value as a lower-case string
        writer.WriteStringValue(value.ToString().ToLower());
    }
}