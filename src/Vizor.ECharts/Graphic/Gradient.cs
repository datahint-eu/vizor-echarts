using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://github.com/ecomfe/zrender/blob/master/src/graphic/Gradient.ts
/// </summary>
public abstract class Gradient : IGraphicColor
{
	[JsonPropertyName("type")]
	public abstract string Type { get; }

	[JsonPropertyName("id")]
	public int? Id { get; set; }

	[JsonPropertyName("colorStops")]
	public GradientColorStop[]? ColorStops { get; set; }

	[JsonPropertyName("global")]
	public bool? Global { get; set; }
}
