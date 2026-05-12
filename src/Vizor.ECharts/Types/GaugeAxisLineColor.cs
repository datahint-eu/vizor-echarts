using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(GaugeAxisLineColorConverter))]
public class GaugeAxisLineColor
{
    public GaugeAxisLineColor(Color color)
    {
        SolidColor = color;
    }

    public GaugeAxisLineColor(GaugeAxisLineColorSegment[] segments)
    {
        Segments = segments;
    }

    public Color? SolidColor { get; }

    public GaugeAxisLineColorSegment[]? Segments { get; }

    public static implicit operator GaugeAxisLineColor(string color)
    {
        return new GaugeAxisLineColor(color);
    }

    public static implicit operator GaugeAxisLineColor(Color color)
    {
        return new GaugeAxisLineColor(color);
    }

    public static implicit operator GaugeAxisLineColor(GaugeAxisLineColorSegment[] segments)
    {
        return new GaugeAxisLineColor(segments);
    }

    public static implicit operator GaugeAxisLineColor((double threshold, string color)[] segments)
    {
        return new GaugeAxisLineColor(segments.Select(s => new GaugeAxisLineColorSegment(s.threshold, s.color)).ToArray());
    }

    public static GaugeAxisLineColorSegment Stop(double threshold, Color color)
    {
        return new GaugeAxisLineColorSegment(threshold, color);
    }
}

public class GaugeAxisLineColorSegment
{
    public GaugeAxisLineColorSegment(double threshold, Color color)
    {
        Threshold = threshold;
        Color = color;
    }

    public double Threshold { get; }

    public Color Color { get; }
}

public class GaugeAxisLineColorConverter : JsonConverter<GaugeAxisLineColor>
{
    public override GaugeAxisLineColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for GaugeAxisLineColor.");
    }

    public override void Write(Utf8JsonWriter writer, GaugeAxisLineColor value, JsonSerializerOptions options)
    {
        if (value.Segments != null)
        {
            writer.WriteStartArray();
            foreach (var segment in value.Segments)
            {
                writer.WriteStartArray();
                writer.WriteNumberValue(segment.Threshold);
                ColorConverter.Instance.Write(writer, segment.Color, options);
                writer.WriteEndArray();
            }
            writer.WriteEndArray();
            return;
        }

        if (value.SolidColor != null)
        {
            ColorConverter.Instance.Write(writer, value.SolidColor, options);
            return;
        }

        writer.WriteNullValue();
    }
}
