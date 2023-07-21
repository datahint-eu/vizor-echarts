using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(ExternalDataSourceConverter))]
public class ExternalDataSource
{
	public ExternalDataSource(string url)
	{
		Url = url;
	}

	//TODO: support additional fetch parameters, see https://developer.mozilla.org/en-US/docs/Web/API/Fetch_API/Using_Fetch, https://developer.mozilla.org/en-US/docs/Web/API/fetch
	//	method: "POST", // *GET, POST, PUT, DELETE, etc.
	//	mode: "cors", // no-cors, *cors, same-origin
	//	cache: "no-cache", // *default, no-cache, reload, force-cache, only-if-cached
	//	credentials: "same-origin", // include, *same-origin, omit
	//	headers: {
	//	  "Content-Type": "application/json",
	//	  // 'Content-Type': 'application/x-www-form-urlencoded',
	//	},
	//	redirect: "follow", // manual, *follow, error
	//	referrerPolicy: "no-referrer", // no-referrer, *no-referrer-when-downgrade, origin, origin-when-cross-origin, same-origin, strict-origin, strict-origin-when-cross-origin, unsafe-url

	public string Url { get; }

	public static explicit operator ExternalDataSource(string url)
	{
		return new ExternalDataSource(url);
	}
}

public class ExternalDataSourceConverter : JsonConverter<ExternalDataSource>
{
	private static readonly ExternalDataSourceConverter instance = new();

	public override ExternalDataSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for ExternalDataSource.");
	}

	public override void Write(Utf8JsonWriter writer, ExternalDataSource value, JsonSerializerOptions options)
	{
		writer.WriteStartObject();
		writer.WriteString("type", "__vi-ext-data");
		writer.WriteString("url", value.Url);
		writer.WriteEndObject();
	}

	public static ExternalDataSourceConverter Instance => instance;
}