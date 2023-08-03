using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://echarts.apache.org/en/api.html#echarts.registerMap
/// </summary>
public class GeoMapDefinition : IMapDefinition
{
	public GeoMapDefinition(string name, string geoData, object? specialAreas = null)
	{
		Name = name;
		GeoJson = geoData;
		SpecialAreas = specialAreas;
	}

	public GeoMapDefinition(string name, object geoData, object? specialAreas = null)
	{
		Name = name;
		GeoJson = geoData;
		SpecialAreas = specialAreas;
	}

	public GeoMapDefinition(string name, ExternalDataSource dataSource, object? specialAreas = null)
	{
		Name = name;
		GeoJson = dataSource;
		SpecialAreas = specialAreas;
	}

	public string Type => "geoJSON";

	/// <summary>
	/// Map name, referring to map value set in geo component or map.
	/// </summary>
	[JsonPropertyName("mapName")]
	public string Name { get; set; }

	/// <summary>
	/// Data in GeoJson format.
	/// See https://geojson.org/ for more format information.
	/// Can be a JSON string or a parsed object. This key can also be geoJson.
	/// </summary>
	[JsonPropertyName("geoJSON")]
	public object? GeoJson { get; set; }

	/// <summary>
	/// Zoomed part of a specific area in the map for better visual effect.
	/// </summary>
	[JsonPropertyName("specialAreas")]
	public object? SpecialAreas { get; set; }
}
