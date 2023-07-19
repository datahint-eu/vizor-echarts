using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<LegendType>))]
public enum LegendType
{
    Plain,
    Scroll
}