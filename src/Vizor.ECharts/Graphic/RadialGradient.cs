using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://github.com/ecomfe/zrender/blob/master/src/graphic/RadialGradient.ts
/// </summary>
public class RadialGradient : Gradient
{
	public override string Type => "radial";

	public RadialGradient(double x, double y, double r, GradientColorStop[]? colorStops = null, bool? global = null)
	{
		X = x;
		Y = y;
		R = r;

		ColorStops = colorStops;
		Global = global;
	}

	[JsonPropertyName("x")]
	public double X { get; set; }

	[JsonPropertyName("y")]
	public double Y { get; set; }

	[JsonPropertyName("r")]
	public double R { get; set; }
}
