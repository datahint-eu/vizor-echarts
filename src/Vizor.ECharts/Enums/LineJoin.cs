using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<LineJoin>))]
public enum LineJoin
{
    Bevel,
    Round,
    Miter
}