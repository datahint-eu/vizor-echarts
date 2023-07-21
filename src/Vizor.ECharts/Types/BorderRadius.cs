using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(BorderRadiusConverter))]
public class BorderRadius
{
    public BorderRadius(double all)
    {
        UpperLeft = UpperRight = BottomRight = BottomLeft = all;
    }

    public BorderRadius(double upperLeft, double upperRight, double bottomRight, double bottomLeft)
    {
        UpperLeft = upperLeft;
        UpperRight = upperRight;
        BottomRight = bottomRight;
        BottomLeft = bottomLeft;
    }

    public double UpperLeft { get; }
    public double UpperRight { get; }
    public double BottomRight { get; }
    public double BottomLeft { get; }

    public static implicit operator BorderRadius(double all)
    {
        return new BorderRadius(all);
    }
}

public class BorderRadiusConverter : JsonConverter<BorderRadius>
{
    public override BorderRadius Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for BorderRadius.");
    }

    public override void Write(Utf8JsonWriter writer, BorderRadius value, JsonSerializerOptions options)
    {
        if (value.UpperLeft == value.UpperRight && value.UpperLeft == value.BottomRight && value.UpperLeft == value.BottomLeft)
        {
            writer.WriteNumberValue(value.UpperLeft);
        }
        else
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(value.UpperLeft);
            writer.WriteNumberValue(value.UpperRight);
            writer.WriteNumberValue(value.BottomRight);
            writer.WriteNumberValue(value.BottomLeft);
            writer.WriteEndArray();
        }
    }
}