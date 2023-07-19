using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<FontStyle>))]
public enum FontStyle
{
    Normal,
    Italic,
    Oblique
}
