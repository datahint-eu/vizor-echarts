using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<LineCap>))]
public enum LineCap
{
    Butt,
    Round,
    Square
}
