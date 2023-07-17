namespace Vizor.ECharts.Options;

public interface IOption
{
	/// <summary>
	/// /// Component ID, not specified by default. If specified, it can be used to refer the component in option or API.
	/// </summary>
	string? Id { get; set; }

	/// <summary>
	/// Set this to false to prevent the item from showing
	/// </summary>
	bool? Show { get; set; }
}
