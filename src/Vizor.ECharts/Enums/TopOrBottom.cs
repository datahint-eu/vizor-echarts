using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<TopOrBottom>))]
public enum TopOrBottom
{
    Top,
    Bottom
}
