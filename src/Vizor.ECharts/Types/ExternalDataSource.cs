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