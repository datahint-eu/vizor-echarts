using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// see https://echarts.apache.org/en/option.html#series-line.coordinateSystem
/// </summary>
[JsonConverter(typeof(LowerCaseEnumConverter<LineCoordinateSystem>))]
public enum LineCoordinateSystem
{
    Cartesian2D,
    Polar
}
