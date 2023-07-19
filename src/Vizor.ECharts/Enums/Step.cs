using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<Step>))]
public enum Step
{
    True,
    False,
    Start,
    Middle,
    End
}