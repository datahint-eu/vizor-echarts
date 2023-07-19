using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(HAlignConverter))]
public enum HAlign
{
    Auto,
    Left,
    Right,
    Center
}

public class HAlignConverter : JsonConverter<HAlign>
{
    public override HAlign Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for HAlign.");
    }

    public override void Write(Utf8JsonWriter writer, HAlign value, JsonSerializerOptions options)
    {
        // Serialize the enum value as a lower-case string
        writer.WriteStringValue(value.ToString().ToLower());
    }
}