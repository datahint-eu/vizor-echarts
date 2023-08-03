using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://github.com/ecomfe/zrender/blob/master/src/graphic/LinearGradient.ts
/// </summary>
public class LinearGradient : Gradient
{
	public override string Type => "linear";

	public LinearGradient(double x, double y, double x2, double y2, GradientColorStop[]? colorStops = null, bool? global = null)
	{
		X = x;
		Y = y;
		X2 = x2;
		Y2 = y2;

		ColorStops = colorStops;
		Global = global;
	}

	[JsonPropertyName("x")]
	public double X { get; set; }

	[JsonPropertyName("y")]
	public double Y { get; set; }

	[JsonPropertyName("x2")]
	public double X2 { get; set; }

	[JsonPropertyName("y2")]
	public double Y2 { get; set; }
}
