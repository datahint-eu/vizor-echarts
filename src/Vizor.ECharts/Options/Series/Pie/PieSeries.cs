using System.Text.Json.Serialization;
using Vizor.ECharts.Data;

namespace Vizor.ECharts.Options.Series.Pie;

public class PieSeries<TData>
	: PieDataOptions
	, IChartSeries<TData>
	, IZOption
	, IPositionOption
	, IWidthHeightOption
	, IAnimationOption
	where TData : class, IPieNameValue
{
	public string Type => "pie";

	/// <summary>
	/// Component ID, not specified by default. If specified, it can be used to refer the component in option or API.
	/// </summary>
	public string? Id { get; set; }

	/// <summary>
	/// Series name used for displaying in tooltip and filtering with legend.
	/// </summary>
	public string? Name { get; set; }

	public List<TData> Data { get; set; } = new();
}
