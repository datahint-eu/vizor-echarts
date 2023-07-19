using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/globalCompositeOperation
/// </summary>
[JsonConverter(typeof(BlendModeConverter))]
public enum BlendMode
{
    SourceOver,
    SourceIn,
    SourceOut,
    SourceAtop,
    DestinationOver,
    DestinationIn,
    DestinationOut,
    DestinationAtop,
    Lighter,
    Copy,
    Xor,
    Multiply,
    Screen,
    Overlay,
    Darken,
    Lighten,
    ColorDodge,
    ColorBurn,
    HardLight,
    SoftLight,
    Difference,
    Exclusion,
    Hue,
    Saturation,
    Color,
    Luminosity
}

public class BlendModeConverter : JsonConverter<BlendMode>
{
    public override BlendMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for BlendMode.");
    }

    public override void Write(Utf8JsonWriter writer, BlendMode value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(GetValue(value));
    }

    private static string GetValue(BlendMode value)
    {
        return value switch
        {
            BlendMode.SourceOver => "source-over",
            BlendMode.SourceIn => "source-in",
            BlendMode.SourceOut => "source-out",
            BlendMode.SourceAtop => "source-atop",
            BlendMode.DestinationOver => "destination-over",
            BlendMode.DestinationIn => "destination-in",
            BlendMode.DestinationOut => "destination-out",
            BlendMode.DestinationAtop => "destination-atop",
            _ => value.ToString().ToLower()
        };
    }
}