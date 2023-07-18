using Vizor.ECharts.Data;

namespace Vizor.ECharts.Options.Series;

public interface IChartSeries<TData>
{
	/// <summary>
	/// Series type
	/// </summary>
	string Type { get; }

	/// <summary>
	/// Component ID, not specified by default. If specified, it can be used to refer the component in option or API.
	/// </summary>
	string? Id { get; set; }

	/// <summary>
	/// Series name used for displaying in tooltip and filtering with legend, or updating data and configuration with setOption.
	/// </summary>
	string? Name { get; set; }

	/// <summary>
	/// The chart data
	/// </summary>
	List<TData> Data { get; set; } 
}
