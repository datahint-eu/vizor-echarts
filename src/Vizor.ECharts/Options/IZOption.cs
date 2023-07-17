using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

public interface IZOption
{
	/// <summary>
	/// zlevel value of all graphical elements in .
	/// zlevel is used to make layers with Canvas.Graphical elements with different zlevel values will be placed in different Canvases, which is a common optimization technique. We can put those frequently changed elements (like those with animations) to a separate zlevel.Notice that too many Canvases will increase memory cost, and should be used carefully on mobile phones to avoid crash.
	/// Canvases with bigger zlevel will be placed on Canvases with smaller zlevel.
	/// </summary>
	[JsonPropertyName("zlevel")]
	double? ZLevel { get; set; }

	/// <summary>
	/// z value of all graphical elements in , which controls order of drawing graphical components. Components with smaller z values may be overwritten by those with larger z values.
	/// z has a lower priority to zlevel, and will not create new Canvas.
	/// Default=2
	/// </summary>
	double? Z { get; set; }
}
