using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<EmphasisFocus>))]
public enum EmphasisFocus
{
    None,
    Self,
    Series
}