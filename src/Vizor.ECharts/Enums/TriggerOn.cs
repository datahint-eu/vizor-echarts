using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Conditions to trigger tooltip.Options:
/// 'mousemove': Trigger when mouse moves.
/// 'click': Trigger when mouse clicks.
/// 'mousemove|click': Trigger when mouse clicks and moves.
/// 'none': Do not triggered by 'mousemove' and 'click'. Tooltip can be triggered and hidden manually by calling action.tooltip.showTip and action.tooltip.hideTip.It can also be triggered by axisPointer.handle in this case.
/// </summary>
[JsonConverter(typeof(TriggerOnConverter))]
public enum TriggerOn
{
    MouseMove,
    Click,
    MouseMoveAndClick,
    None
}

public class TriggerOnConverter : JsonConverter<TriggerOn>
{
    public override TriggerOn Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for TooltipTriggerOn.");
    }

    public override void Write(Utf8JsonWriter writer, TriggerOn value, JsonSerializerOptions options)
    {
        switch (value)
        {
            case TriggerOn.MouseMove:
                writer.WriteStringValue("mousemove");
                break;
            case TriggerOn.Click:
                writer.WriteStringValue("click");
                break;
            case TriggerOn.None:
                writer.WriteStringValue("none");
                break;
            default:
            case TriggerOn.MouseMoveAndClick:
                writer.WriteStringValue("mousemove|click");
                break;
        }
    }
}