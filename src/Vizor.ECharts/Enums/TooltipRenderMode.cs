using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Render mode for tooltip. By default, it is set to be 'html' so that extra DOM element is used for tooltip. It can also set to be 'richText' so that the tooltip will be rendered inside Canvas. 
/// </summary>
[JsonConverter(typeof(CamelCaseEnumConverter<TooltipRenderMode>))]
public enum TooltipRenderMode
{
    Html,
    RichText
}