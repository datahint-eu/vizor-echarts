
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class OutOfBrush
{
    [JsonPropertyName("colorAlpha")]
    public double? ColorAlpha { get; set; }
}
