// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Brush
{
	/// <summary>
	/// Icons used, whose values are:   'rect' : Enabling selecting with rectangle area.
	///  'polygon' : Enabling selecting with any shape.
	///  'lineX' : Enabling horizontal selecting.
	///  'lineY' : Enabling vertical selecting.
	///  'keep' : Switching between single selecting and multiple selecting .
	/// The latter one can select multiple areas, while the former one cancels previous selection.
	///  'clear' : Clearing all selection.
	/// </summary>
	[JsonPropertyName("type")]
	public List<object>? Type { get; set; } 

	/// <summary>
	/// Icon path for each icon.
	/// </summary>
	[JsonPropertyName("icon")]
	public Icon? Icon { get; set; } 

	/// <summary>
	/// Title.
	/// </summary>
	[JsonPropertyName("title")]
	public Title? Title { get; set; } 

}
