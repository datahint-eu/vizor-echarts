using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<Step>))]
public enum Step
{
    True,
    False,
    Start,
    Middle,
    End
}