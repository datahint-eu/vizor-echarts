using System.Text.Json.Serialization;

namespace Vizor.ECharts.Internal;

internal class FetchCommand
{
	public FetchCommand(ExternalDataSource ext)
	{
		Url = ext.Url;
		FetchId = ext.FetchId;
		FetchAs = ext.FetchAs;
		Path = ext.Path;
		AfterLoad = ext.AfterLoad?.Function; // serialize as string
		Options = ext.Options;
	}

	[JsonPropertyName("url")]
	public string Url { get; set; }

	[JsonPropertyName("id")]
	public string FetchId { get; }

	[JsonPropertyName("fetchAs")]
	public ExternalDataFetchAs FetchAs { get; }

	[JsonPropertyName("path")]
	public string? Path { get; }

	[JsonPropertyName("afterLoad")]
	public string? AfterLoad { get; }

	[JsonPropertyName("options")]
	public FetchOptions? Options { get; set; }
}
