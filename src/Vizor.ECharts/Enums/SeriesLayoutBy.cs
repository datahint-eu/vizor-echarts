using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<SeriesLayoutBy>))]
public enum SeriesLayoutBy
{
    Column,
    Row
}