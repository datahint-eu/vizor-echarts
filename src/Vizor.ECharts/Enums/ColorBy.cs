using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<ColorBy>))]
public enum ColorBy
{
    Series,
    Data
}
