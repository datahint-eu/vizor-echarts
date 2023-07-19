using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<SelectionMode>))]
public enum SelectionMode
{
    True,
    False,
    Single,
    Multiple
}