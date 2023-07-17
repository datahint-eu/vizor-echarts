namespace Vizor.ECharts.Options.Series;

public interface IChartSeries
{
	/// <summary>
	/// Series type
	/// </summary>
	public string Type { get; }

	/// <summary>
	/// Component ID, not specified by default. If specified, it can be used to refer the component in option or API.
	/// </summary>
	public string? Id { get; set; }

	/// <summary>
	/// Series name used for displaying in tooltip and filtering with legend, or updating data and configuration with setOption.
	/// </summary>
	public string? Name { get; set; }
}
