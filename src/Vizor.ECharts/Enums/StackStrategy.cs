using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<StackStrategy>))]
public enum StackStrategy
{
    SameSign,
    All,
    Positive,
    Negative
}
