using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Center position of Pie chart, the first of which is the horizontal position, and the second is the vertical position.
/// Percentage is supported.When set in percentage, the item is relative to the container width, and the second item to the height.
/// </summary>
[JsonConverter(typeof(CircleCenterConverter))]
public class CircleCenter
{
    public CircleCenter(NumberOrString horizontal, NumberOrString vertical)
    {
        Horizontal = horizontal;
        Vertical = vertical;
    }

    public NumberOrString Horizontal { get; }
    public NumberOrString Vertical { get; }
}

public class CircleCenterConverter : JsonConverter<CircleCenter>
{
    public override CircleCenter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for CircleCenter.");
    }

    public override void Write(Utf8JsonWriter writer, CircleCenter value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        NumberOrStringConverter.Instance.Write(writer, value.Horizontal, options);
        NumberOrStringConverter.Instance.Write(writer, value.Vertical, options);
        writer.WriteEndArray();
    }
}