using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<HorizontalAlign>))]
public enum HorizontalAlign
{
    Auto,
    Left,
    Right,
    Center
}