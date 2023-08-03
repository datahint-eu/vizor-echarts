using System.Text.Json;
using System.Text.Json.Serialization;
using Vizor.ECharts.Enums;
using Vizor.ECharts.Internal;

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
		Url = url;
	}

	public ExternalDataSource(string url, ExternalDataFetchAs fetchAs = ExternalDataFetchAs.Json, string? path = null, FetchOptions? options = null)
	{
		Url = url;
		FetchAs = fetchAs;
		Path = path;
		Options = options;
	}

	/// <summary>
	/// URL of the datasource
	/// </summary>
	public string Url { get; }

	/// <summary>
	/// Default = json
	/// </summary>
	public ExternalDataFetchAs FetchAs { get; set; } = ExternalDataFetchAs.Json;

	/// <summary>
	/// Optional object path in the returned JSON.
	/// Currently only simple expressions are supported, not full JsonPath expressions.
	/// </summary>
	public string? Path { get; set; }

	/// <summary>
	/// Additional options passed to the fetch command
	/// </summary>
	public FetchOptions? Options { get; set; }

	public static explicit operator ExternalDataSource(string url)
	{
		return new ExternalDataSource(url);
	}
}

public class ExternalDataSourceConverter : JsonConverter<ExternalDataSource>
{
	private readonly List<FetchCommand> commands;
	private readonly string chartId;

	internal ExternalDataSourceConverter(List<FetchCommand> commands, string chartId)
    {
		this.commands = commands;
		this.chartId = chartId;
	}

    public override ExternalDataSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for ExternalDataSource.");
	}

	public override void Write(Utf8JsonWriter writer, ExternalDataSource value, JsonSerializerOptions options)
	{
		var fetchId = Guid.NewGuid().ToString().Replace("-", "");

		string raw = $"window.vizorECharts.getChart('{chartId}')['{fetchId}']";
		writer.WriteRawValue(raw, skipInputValidation: true);

		commands.Add(new FetchCommand(value.Url, fetchId, value.FetchAs, value.Path, value.Options));
	}

	internal class FetchCommand
	{
		public FetchCommand(string url, string id, ExternalDataFetchAs fetchAs, string? path, FetchOptions? options)
        {
			Url = url;
			Id = id;
			FetchAs = fetchAs;
			Path = path;
			Options = options;
		}

		[JsonPropertyName("url")]
        public string Url { get; set; }

		[JsonPropertyName("id")]
		public string Id { get; }

		[JsonPropertyName("fetchAs")]
		public ExternalDataFetchAs FetchAs { get; }

		[JsonPropertyName("path")]
		public string? Path { get; }

		[JsonPropertyName("options")]
		public FetchOptions? Options { get; set; }
	}
}