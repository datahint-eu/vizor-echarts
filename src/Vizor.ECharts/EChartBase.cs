using System.Text.Json.Serialization;
using System.Text.Json;
using Microsoft.AspNetCore.Components;
using Vizor.ECharts.Internal;
using Microsoft.JSInterop;

namespace Vizor.ECharts;

public abstract class EChartBase : ComponentBase, IAsyncDisposable
{
    // one instance per chart, we need it to pass state info of external data sources, ...
    protected JsonSerializerOptions? jsonOpts;

    private readonly List<ExternalDataSourceConverter.FetchCommand> dataFetchCommands = new();
    protected readonly string id = "chart" + Guid.NewGuid().ToString().Replace("-", "");

    [Inject]
    public IJSRuntime JSRuntime { get; set; } = default!;

    [Parameter]
    public string? CssClass { get; set; }

    [Parameter]
    public string? Style { get; set; }

    [Parameter]
    public string? Width { get; set; }

    [Parameter]
    public string? Height { get; set; }

    [Parameter]
    public string? Theme { get; set; }

    [Parameter]
    public ChartGroup? Group { get; set; }

    [Parameter]
    public ChartRenderer Renderer { get; set; } = ChartRenderer.Svg;

    [Parameter]
    public JsonConverter[]? JsonConverters { get; set; }

	/// <summary>
	/// Geo maps, see https://echarts.apache.org/en/api.html#echarts.registerMap
	/// </summary>
	[Parameter]
    public IMapDefinition[]? Maps { get; set; }

    /// <summary>
    /// Function used to retrieve data from external sources.
    /// </summary>
    [Parameter]
    public EventCallback DataLoader { get; set; }

    [Parameter, EditorRequired]
    public ChartOptions Options { get; set; } = default!;

	public async ValueTask DisposeAsync()
	{
		try
		{
			jsonOpts = null;
			dataFetchCommands.Clear();

			// remove the chart from a group (if needed)
			Group?.Remove(this);

			await JSRuntime.InvokeVoidAsync("vizorECharts.disposeChart", id);
		}
		catch { }
	}

    public abstract Task UpdateAsync(bool executeDataLoader = true);

	protected (string chartOpts, string? mapOpts, string? fetchOpts) Serialize(bool serializeMapOpts)
    {
        // clear the fetch option commands
        dataFetchCommands.Clear();

        // serialize the chart options
        var chartOpts = JsonSerializer.Serialize(Options, jsonOpts);

        // serialize the map options
        var mapOpts = (!serializeMapOpts || Maps == null || Maps.Length == 0) ? null : JsonSerializer.Serialize<object>(Maps, jsonOpts);

		// serialize the chart options first, fetch commands are constructed during serialize of chart options
		var fetchOpts = dataFetchCommands.Count == 0 ? null : JsonSerializer.Serialize(dataFetchCommands);

        return (chartOpts, mapOpts, fetchOpts);
    }

    protected JsonSerializerOptions CreateSerializerOptions()
    {
        var jsonOpts = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
#if DEBUG
            WriteIndented = true
#endif
        };

        jsonOpts.Converters.Add(new DateOnlyJsonConverter());
        jsonOpts.Converters.Add(new DateTimeJsonConverter());
        jsonOpts.Converters.Add(new DateTimeOffsetJsonConverter());
        jsonOpts.Converters.Add(new SeriesDataConverterFactory());

		// register extra JSON converters if needed
		if (JsonConverters != null)
        {
            foreach (var converter in JsonConverters)
            {
                jsonOpts.Converters.Add(converter);
            }
        }

        // register the special converter for external data source fetches
        jsonOpts.Converters.Add(new ExternalDataSourceConverter(dataFetchCommands, id));

        return jsonOpts;
    }
}
