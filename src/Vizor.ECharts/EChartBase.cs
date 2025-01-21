using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;
using Vizor.ECharts.Internal;

namespace Vizor.ECharts;

public abstract class EChartBase : ComponentBase, IAsyncDisposable
{
	private static JsonSerializerOptions? cachedJsonOpts;
	protected JsonSerializerOptions? jsonOpts;
	protected DotNetObjectReference<EChartBase>? objRef;

	[Inject]
	public IJSRuntime JSRuntime { get; set; } = default!;

	/// <summary>
	/// A unique ID. DO NOT change this value after the chart has been rendered.
	/// If unsure, leave the default value or use EChart.GenerateRandomId()
	/// </summary>
	[Parameter]
	public string Id { get; set; } = "chart" + GenerateRandomId();

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

	/// <summary>
	/// Custom list of JsonConverters.
	/// REMARK: Use the same list of custom converters in every chart OR set CacheJsonSerializerOptions to false.
	/// For memory consumption, ideally you re-use the same cached JsonSerializerOptions.
	/// </summary>
	[Parameter]
	public JsonConverter[]? JsonConverters { get; set; }

	/// <summary>
	/// Prefer to re-use the same JsonSerializerOptions. (default = true)
	/// Setting this to false is generally a bad idea, unless you know what you are doing.
	///
	/// see https://www.meziantou.net/avoid-performance-issue-with-jsonserializer-by-reusing-the-same-instance-of-json.htm
	/// </summary>
	[Parameter]
	public bool CacheJsonSerializerOptions { get; set; } = true;

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

	[Parameter]
	public ExternalDataSource[]? ExternalDataSources { get; set; }

	[Parameter, EditorRequired]
	public ChartOptions Options { get; set; } = default!;
	
	[Parameter]
	public EventCallback<EventParams> OnChartClick { get; set; }

	[DynamicDependency(nameof(HandleChartClick))]
	public EChartBase()
	{
	}

	protected override void OnInitialized()
	{
		objRef = DotNetObjectReference.Create(this);
	}

	public static string GenerateRandomId() => Guid.NewGuid().ToString("N");

	public async ValueTask DisposeAsync()
	{
		GC.SuppressFinalize(this);

		try
		{
			jsonOpts = null;

			// remove the chart from a group (if needed)
			Group?.Remove(this);

			await JSRuntime.InvokeVoidAsync("vizorECharts.disposeChart", Id);
		}
		catch { }

		try
		{
			objRef?.Dispose();
		}
		catch { }
	}

	public async ValueTask ClearAsync()
	{
		GC.SuppressFinalize(this);

		try
		{
			await JSRuntime.InvokeVoidAsync("vizorECharts.clearChart", Id);
		}
		catch { }
	}

	public abstract Task UpdateAsync(bool executeDataLoader = true);

	protected (string chartOpts, string? mapOpts, string? fetchOpts) Serialize(bool serializeMapOpts)
	{
		// serialize the chart options
		var chartOpts = JsonSerializer.Serialize(Options, jsonOpts);

		// serialize the map options
		var mapOpts = (!serializeMapOpts || Maps == null || Maps.Length == 0) ? null : JsonSerializer.Serialize<object>(Maps, jsonOpts);

		string? fetchOpts = null;
		if (ExternalDataSources != null && ExternalDataSources.Length != 0)
		{
			// NOTE: use the default converter here, because our custom converter throws an exception
			fetchOpts = JsonSerializer.Serialize(ExternalDataSources.Select(s => new FetchCommand(s)));
		}

		return (chartOpts, mapOpts, fetchOpts);
	}

	protected JsonSerializerOptions CreateSerializerOptions()
	{
		// return cached instance if possible
		if (CacheJsonSerializerOptions && cachedJsonOpts != null)
		{
			//NOTE: custom converters cannot be changed after first use of cachedJsonOpts
			return cachedJsonOpts;
		}

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
		jsonOpts.Converters.Add(new ExternalDataSourceConverter());
		jsonOpts.Converters.Add(new ExternalDataSourceRefConverter());

		// store the json opts for re-use later on
		if (CacheJsonSerializerOptions && cachedJsonOpts == null)
			cachedJsonOpts = jsonOpts;

		return jsonOpts;
	}
	
	[JSInvokable("HandleChartClick")]
	public async Task HandleChartClick(EventParams p)
	{
		if (OnChartClick.HasDelegate)
		{
			await OnChartClick.InvokeAsync(p);
		}
	}
}
