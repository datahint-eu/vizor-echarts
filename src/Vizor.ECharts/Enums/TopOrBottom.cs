using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<TopOrBottom>))]
public enum TopOrBottom
{
    Top,
    Bottom
}
