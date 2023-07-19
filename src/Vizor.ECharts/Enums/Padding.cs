using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(PaddingConverter))]
public class Padding
{
    public Padding(double all)
    {
        Top = Right = Bottom = Left = all;
    }

    public Padding(double topBottom, double leftRight)
    {
        Top = Bottom = topBottom;
        Right = Left = leftRight;
    }

    public Padding(double top, double right, double bottom, double left)
    {
        Top = top;
        Right = right;
        Bottom = bottom;
        Left = left;
    }

    public double Top { get; }
    public double Right { get; }
    public double Bottom { get; }
    public double Left { get; }
}

public class PaddingConverter : JsonConverter<Padding>
{
    public override Padding Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for Padding.");
    }

    public override void Write(Utf8JsonWriter writer, Padding value, JsonSerializerOptions options)
    {
        if (value.Top == value.Right && value.Top == value.Bottom && value.Top == value.Left)
        {
            writer.WriteNumberValue(value.Top);
        }
        else
        {
            writer.WriteStartArray();
            writer.WriteNumberValue(value.Top);
            writer.WriteNumberValue(value.Right);
            writer.WriteNumberValue(value.Bottom);
            writer.WriteNumberValue(value.Left);
            writer.WriteEndArray();
        }
    }
}