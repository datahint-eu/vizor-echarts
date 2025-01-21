using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// External data source fetched inside the browser, not in the server
/// 
/// See https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch
/// https://developer.mozilla.org/en-US/docs/Web/API/fetch
/// </summary>
public class ExternalDataSource
{
	public ExternalDataSource(string url)
	{
		FetchId = EChartBase.GenerateRandomId();
		Url = url;
	}

	public ExternalDataSource(string url, ExternalDataFetchAs fetchAs = ExternalDataFetchAs.Json, string? path = null, FetchOptions? options = null, JavascriptFunction? afterLoad = null, string? fetchId = null)
	{
		FetchId = fetchId ?? EChartBase.GenerateRandomId();
		Url = url;
		FetchAs = fetchAs;
		Path = path;
		Options = options;
		AfterLoad = afterLoad;
	}

	/// <summary>
	/// A unique identifier.
	/// </summary>
	public string FetchId { get; }

	/// <summary>
	/// URL of the datasource
	/// </summary>
	public string Url { get; }

	/// <summary>
	/// Determines how the returned data is interpreted.
	/// Default = json
	/// </summary>
	public ExternalDataFetchAs FetchAs { get; set; }= ExternalDataFetchAs.Json;

	/// <summary>
	/// Optional object path in the returned JSON.
	/// Currently only simple expressions are supported, not full JsonPath expressions.
	/// </summary>
	public string? Path { get; set; }

	/// <summary>
	/// A function executed after the data is loaded, allowing the data to be manipulated.
	/// Function signature: function (data)
	/// The function must return the manipulated data object.
	/// 
	/// The function is evaluated AFTER the Path expression.
	/// </summary>
	public JavascriptFunction? AfterLoad { get; set; }

	/// <summary>
	/// Additional options passed to the fetch command
	/// </summary>
	public FetchOptions? Options { get; set; }
}

public class ExternalDataSourceConverter : JsonConverter<ExternalDataSource>
{
	internal ExternalDataSourceConverter()
    {
	}

    public override ExternalDataSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for ExternalDataSource.");
	}

	public override void Write(Utf8JsonWriter writer, ExternalDataSource value, JsonSerializerOptions options)
	{
		throw new InvalidOperationException("ExternalDataSource cannot be serialized, please use ExternalDataSourceRef");
	}
}