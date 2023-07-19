using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<TreeLayout>))]
public enum TreeLayout
{
    Orthogonal,
    Radial
}