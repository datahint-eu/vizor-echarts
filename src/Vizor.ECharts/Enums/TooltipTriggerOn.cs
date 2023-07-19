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
[JsonConverter(typeof(TooltipTriggerOnConverter))]
public enum TooltipTriggerOn
{
    MouseMove,
    Click,
    MouseMoveAndClick,
    None
}

public class TooltipTriggerOnConverter : JsonConverter<TooltipTriggerOn>
{
    public override TooltipTriggerOn Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for TooltipTriggerOn.");
    }

    public override void Write(Utf8JsonWriter writer, TooltipTriggerOn value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case TooltipTriggerOn.MouseMove:
                writer.WriteStringValue("mousemove");
                break;
            case TooltipTriggerOn.Click:
                writer.WriteStringValue("click");
                break;
            case TooltipTriggerOn.None:
                writer.WriteStringValue("none");
                break;
            default:
            case TooltipTriggerOn.MouseMoveAndClick:
                writer.WriteStringValue("mousemove|click");
                break;
        }
    }
}