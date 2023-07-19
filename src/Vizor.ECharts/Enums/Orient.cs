using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<Orient>))]
public enum Orient
{
    Horizontal,
    Vertical
}
