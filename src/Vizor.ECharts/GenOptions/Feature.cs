// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Feature
{
	/// <summary>
	/// Save as image.
	/// </summary>
	[JsonPropertyName("saveAsImage")]
	public SaveAsImage? SaveAsImage { get; set; } 

	/// <summary>
	/// Restore configuration item.
	/// </summary>
	[JsonPropertyName("restore")]
	public Restore? Restore { get; set; } 

	/// <summary>
	/// Data view tool, which could display data in current chart and updates chart after being edited.
	/// </summary>
	[JsonPropertyName("dataView")]
	public DataView? DataView { get; set; } 

	/// <summary>
	/// Data area zooming, which only supports rectangular coordinate by now.
	/// </summary>
	[JsonPropertyName("dataZoom")]
	public DataZoom? DataZoom { get; set; } 

	/// <summary>
	/// Magic type switching.
	/// 示例:  feature: {
	///     magicType: {
	///         type: ['line', 'bar', 'stack']
	///     }
	/// }
	/// </summary>
	[JsonPropertyName("magicType")]
	public MagicType? MagicType { get; set; } 

	/// <summary>
	/// Brush-selecting icon.
	///  
	/// It can also be configured at brush.toolbox .
	/// </summary>
	[JsonPropertyName("brush")]
	public Brush? Brush { get; set; } 

}
