using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

/// <summary>
/// 'item': Triggered by data item, which is mainly used for charts that don't have a category axis like scatter charts or pie charts.
/// 'axis': Triggered by axes, which is mainly used for charts that have category axes, like bar charts or line charts.
/// 'none': Trigger nothing.
/// </summary>
[JsonConverter(typeof(TooltipTriggerConverter))]
public enum TooltipTrigger
{
    Item,
    Axis,
    None
}

public class TooltipTriggerConverter : JsonConverter<TooltipTrigger>
{
    public override TooltipTrigger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for TooltipTrigger.");
    }

    public override void Write(Utf8JsonWriter writer, TooltipTrigger value, JsonSerializerOptions options)
    {
        // Serialize the enum value as a lower-case string
        writer.WriteStringValue(value.ToString().ToLower());
    }
}