using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Center position for geo layout; two values (horizontal, vertical) as number or percent.
/// </summary>
[JsonConverter(typeof(LayoutCenterConverter))]
public class LayoutCenter
{
    public LayoutCenter(NumberOrString horizontal, NumberOrString vertical)
    {
        Horizontal = horizontal;
        Vertical = vertical;
    }

    public NumberOrString Horizontal { get; }
    public NumberOrString Vertical { get; }
}

public class LayoutCenterConverter : JsonConverter<LayoutCenter>
{
    public override LayoutCenter Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for LayoutCenter.");
    }

    public override void Write(Utf8JsonWriter writer, LayoutCenter value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();
        NumberOrStringConverter.Instance.Write(writer, value.Horizontal, options);
        NumberOrStringConverter.Instance.Write(writer, value.Vertical, options);
        writer.WriteEndArray();
    }
}
