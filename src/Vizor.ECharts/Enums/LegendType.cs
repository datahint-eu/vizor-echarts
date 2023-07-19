using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(LegendTypeConverter))]
public enum LegendType
{
    Plain,
    Scroll
}

public class LegendTypeConverter : JsonConverter<LegendType>
{
    public override LegendType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for LegendType.");
    }

    public override void Write(Utf8JsonWriter writer, LegendType value, JsonSerializerOptions options)
    {
        // Serialize the enum value as a lower-case string
        writer.WriteStringValue(value.ToString().ToLower());
    }
}