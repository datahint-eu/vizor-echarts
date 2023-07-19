using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<TreeLayout>))]
public enum TreeLayout
{
    Orthogonal,
    Radial
}