using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(FontWeightConverter))]
public enum FontWeight
{
    Normal,
    Bold,
    Bolder,
    Lighter,

    Thin100,
    ExtraLight200,
    Light300,
    Normal400,
    Medium500,
    SemiBold600,
    Bold700,
    ExtraBold800,
    Black900
}

public class FontWeightConverter : JsonConverter<FontWeight>
{
    public override FontWeight Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for FontWeight.");
    }

    public override void Write(Utf8JsonWriter writer, FontWeight value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case FontWeight.Normal:
                writer.WriteStringValue("normal");
                break;
            case FontWeight.Bold:
                writer.WriteStringValue("bold");
                break;
            case FontWeight.Bolder:
                writer.WriteStringValue("bolder");
                break;
            case FontWeight.Lighter:
                writer.WriteStringValue("lighter");
                break;

            case FontWeight.Thin100:
                writer.WriteStringValue("100");
                break;
            case FontWeight.ExtraLight200:
                writer.WriteStringValue("200");
                break;
            case FontWeight.Light300:
                writer.WriteStringValue("300");
                break;
            case FontWeight.Normal400:
                writer.WriteStringValue("400");
                break;
            case FontWeight.Medium500:
                writer.WriteStringValue("500");
                break;
            case FontWeight.SemiBold600:
                writer.WriteStringValue("600");
                break;
            case FontWeight.Bold700:
                writer.WriteStringValue("700");
                break;
            case FontWeight.ExtraBold800:
                writer.WriteStringValue("800");
                break;
            case FontWeight.Black900:
                writer.WriteStringValue("900");
                break;
        }

    }
}