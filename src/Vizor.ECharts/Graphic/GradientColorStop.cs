namespace Vizor.ECharts;

/// <summary>
/// See https://github.com/ecomfe/zrender/blob/master/src/graphic/Gradient.ts
/// </summary>
public class GradientColorStop
{
    public GradientColorStop(double offset, Color color)
    {
		Offset = offset;
		Color = color;
	}

	public double Offset { get; set; }
	public Color Color { get; set; }
}
