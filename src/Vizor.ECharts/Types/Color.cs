using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(ColorConverter))]
public class Color
{
    private readonly string color;

    /// <summary>
    /// Can be in hex format: #ccc, RGB: rgb(128, 128, 128) or RGBA: rgba(128, 128, 128, 0.5)
    /// Can also have the value 'transparent'
    /// See the convenience functions FromHex, FromRGB and FromRGBA
    /// </summary>
    /// <param name="color"></param>
    public Color(string color)
    {
        this.color = color;
    }

    public override string ToString() => color;

    public static Color FromHex(string hex)
    {
        if (hex.StartsWith("#"))
        {
            return new Color(hex);
        }

        return new Color('#' + hex);
    }

    public static Color FromRGB(byte r, byte g, byte b)
    {

        return new Color($"rgb({(int)r}, {(int)g}, {(int)b})");
    }

    public static Color FromRGBA(byte r, byte g, byte b, double a)
    {
        return new Color($"rgba({(int)r}, {(int)g}, {(int)b}, {a})");
    }

    public static Color Transparent => new("transparent");
}

public class ColorConverter : JsonConverter<Color>
{
    public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        //TODO:
        return new Color(reader.GetString());
    }

    public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(value.ToString());
    }
}