namespace Vizor.ECharts;

/// <summary>
/// See https://echarts.apache.org/handbook/en/best-practices/canvas-vs-svg/
/// </summary>
public enum ChartRenderer
{
	Svg,
	Canvas
}

public static class ChartRendererExtensions
{
	public static string ToJsParam(this ChartRenderer renderer)
	{
		return renderer switch
		{
			ChartRenderer.Svg => "svg",
			ChartRenderer.Canvas => "canvas",
			_ => throw new ArgumentException($"Renderer '{renderer}' not supported")
		};
	}
}