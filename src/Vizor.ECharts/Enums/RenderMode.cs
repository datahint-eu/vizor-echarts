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
[JsonConverter(typeof(CamelCaseEnumConverter<RenderMode>))]
public enum RenderMode
{
    Html,
    RichText
}