// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Projection
{
	/// <summary>
	/// (coord: [number, number]) => [number, number]  
	/// Projection of latitude and longitude coordinates to other coordinates.
	/// </summary>
	[JsonPropertyName("project")]
	public Function? Project { get; set; } 

	/// <summary>
	/// (point: [number, number]) => [number, number]  
	/// Calculate the raw latitude and longitude coordinates from the projected coordinates
	/// </summary>
	[JsonPropertyName("unproject")]
	public Function? Unproject { get; set; } 

	/// <summary>
	/// This property is mainly used to adapt the stream interface used in d3-geo .
	/// After introducing stream, you can introduce both the Antimeridian Clipping and Adaptive Sampling algorithms implemented in d3-geo .
	///  const projection = d3.geoProjection((x, y) => ([x, y / 0.75]))
	///     .rotate([-115, 0]);
	/// // ...
	/// series: {
	///     type: 'map',
	///     projection: {
	///         // We still need project and unproject when stream is provided.
	///         project: (point) => projection(point),
	///         unproject: (point) => projection.invert(point),
	///         // We can directly use the stream method in d3 projection.
	///         stream: projection.stream
	///     }
	/// }  
	/// Note: stream is not required in the projection .
	/// </summary>
	[JsonPropertyName("stream")]
	public Function? Stream { get; set; } 

}
