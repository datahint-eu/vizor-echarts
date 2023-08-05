using System.Text.Json.Serialization;
using System.Text.Json;
using static Vizor.ECharts.ExternalDataSourceConverter;

namespace Vizor.ECharts;

public class ExternalDataSourceRef
{
    public ExternalDataSourceRef(ExternalDataSource dataSource, string? path)
    {
		DataSource = dataSource;
		Path = path;
	}

	public ExternalDataSource DataSource { get; }
	public string? Path { get; }
}


public class ExternalDataSourceRefConverter : JsonConverter<ExternalDataSourceRef>
{
	private readonly List<FetchCommand> commands;
	private readonly string chartId;

	internal ExternalDataSourceRefConverter(List<FetchCommand> commands, string chartId)
	{
		this.commands = commands;
		this.chartId = chartId;
	}

	public override ExternalDataSourceRef Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for ExternalDataSourceRef.");
	}

	public override void Write(Utf8JsonWriter writer, ExternalDataSourceRef value, JsonSerializerOptions options)
	{
		string raw = $"window.vizorECharts.getChart('{chartId}')['{value.DataSource.FetchId}']";
		if (value.Path != null)
		{
			if (!value.Path.StartsWith('.'))
				raw += '.';
			raw += value.Path;
		}
		writer.WriteRawValue(raw, skipInputValidation: true);

		// check if the external data source is already in the fetch list --> if not: add
		if (!commands.Any(f => f.FetchId == value.DataSource.FetchId))
		{
			commands.Add(new FetchCommand(value.DataSource.Url, value.DataSource.FetchId, value.DataSource.FetchAs, value.DataSource.Path, value.DataSource.AfterLoad, value.DataSource.Options));
		}
	}
}