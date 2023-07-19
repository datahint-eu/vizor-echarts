using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

/// <summary>
/// Conditions to trigger tooltip.Options:
/// 'mousemove': Trigger when mouse moves.
/// 'click': Trigger when mouse clicks.
/// 'mousemove|click': Trigger when mouse clicks and moves.
/// 'none': Do not triggered by 'mousemove' and 'click'. Tooltip can be triggered and hidden manually by calling action.tooltip.showTip and action.tooltip.hideTip.It can also be triggered by axisPointer.handle in this case.
/// </summary>
[JsonConverter(typeof(TooltipRenderModeConverter))]
public enum TooltipRenderMode
{
    Html,
    RichText
}

public class TooltipRenderModeConverter : JsonConverter<TooltipRenderMode>
{
    public override TooltipRenderMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for TooltipRenderMode.");
    }

    public override void Write(Utf8JsonWriter writer, TooltipRenderMode value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case TooltipRenderMode.RichText:
                writer.WriteStringValue("richText");
                break;
            default:
                writer.WriteStringValue("html");
                break;
        }
    }
}