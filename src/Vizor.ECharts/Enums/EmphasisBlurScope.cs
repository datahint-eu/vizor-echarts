using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<EmphasisBlurScope>))]
public enum EmphasisBlurScope
{
    CoordinateSystem,
    Series,
    Global
}
