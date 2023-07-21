// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class FilterdatasetTransform
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("filter")]
	public string? Type { get; set; }  = "filter";

	/// <summary>
	/// The condition of transform "filter".
	///  
	/// See the tutorial of data transform .
	/// </summary>
	[JsonPropertyName("config")]
	public object? Config { get; set; } 

	/// <summary>
	/// When using data transform, we might run into the trouble that the final chart do not display correctly but we do not know where the config is wrong.
	/// There is a property transform.print might help in such case.
	/// ( transform.print is only available in dev environment).
	///  option = {
	///     dataset: [{
	///         source: [ ...
	/// ]
	///     }, {
	///         transform: {
	///             type: 'filter',
	///             config: { ...
	/// }
	///             // The result of this transform will be printed
	///             // in dev tool via `console.log`.
	///             print: true
	///         }
	///     }],
	///     ...
	/// }
	/// </summary>
	[JsonPropertyName("print")]
	[DefaultValue(false)]
	public bool? Print { get; set; } 

}
