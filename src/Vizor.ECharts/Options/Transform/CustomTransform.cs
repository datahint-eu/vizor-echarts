using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public class CustomTransform : IDatasetTransform
{
    public CustomTransform(string type)
    {
		Type = type;
	}

	/// <summary>
	/// The transform type
	/// </summary>
	[JsonPropertyName("type")]
	public string Type { get; }

	/// <summary>
	/// Options 
	/// </summary>
	[JsonPropertyName("config")]
	public object? Config { get; set; }

	/// <summary>
	/// When using data transform, we might run into the trouble that the final chart do not display correctly but we do not know where the config is wrong.
	/// There is a property transform.print might help in such case.
	/// </summary>
	[JsonPropertyName("print")]
	[DefaultValue(false)]
	public bool? Print { get; set; }
}
