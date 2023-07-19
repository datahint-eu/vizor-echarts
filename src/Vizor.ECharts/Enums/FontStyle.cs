using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(FontStyleConverter))]
public enum FontStyle
{
    Normal,
    Italic,
    Oblique
}

public class FontStyleConverter : JsonConverter<FontStyle>
{
    public override FontStyle Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for FontStyle.");
    }

    public override void Write(Utf8JsonWriter writer, FontStyle value, JsonSerializerOptions options)
    {
        // Serialize the enum value as a lower-case string
        writer.WriteStringValue(value.ToString().ToLower());
    }
}