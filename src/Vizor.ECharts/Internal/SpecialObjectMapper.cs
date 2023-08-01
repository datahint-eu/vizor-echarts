using System.Runtime.CompilerServices;
using System.Text.Json;

namespace Vizor.ECharts.Internal;

/// <summary>
/// ChartOptions can contain multiple JavascriptFunction, ExternalDataSource, ... objects.
/// IF we serialize them, the vizorECharts.initChart function must iterate the ENTIRE object and replace the content dynamically.
/// This can be very expensive in big charts
///
/// Since JsonSerializer doesn't have a state, we have no way of knowing if any of the properties that were serialized is a JavascriptFunction, ExternalDataSource, ... .
/// We solve this using the SpecialObjectMapper class.
/// 
/// See https://learn.microsoft.com/en-us/dotnet/api/system.runtime.compilerservices.conditionalweaktable-2?view=net-7.0
/// ConditionalWeakTable is a class that automatically clears keys if references to the object are garbage collected
/// 
/// See https://www.stevejgordon.co.uk/accessing-state-in-system-text-json-custom-converters
/// </summary>
internal static class SpecialObjectMapper
{
    private static readonly ConditionalWeakTable<JsonSerializerOptions, SpecialObjectSerializeState> map = new();

    public static JsonSerializerOptions CreateOptions()
    {
        var jsonOpts = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull,
#if DEBUG
            WriteIndented = true
#endif
        };

        jsonOpts.Converters.Add(new DateOnlyJsonConverter());
		jsonOpts.Converters.Add(new DateTimeJsonConverter());
		jsonOpts.Converters.Add(new DateTimeOffsetJsonConverter());
        jsonOpts.Converters.Add(new SeriesDataConverterFactory());

		map.Add(jsonOpts, new SpecialObjectSerializeState());

        return jsonOpts;
    }

    public static void ClearFlags(JsonSerializerOptions options)
    {
        if (map.TryGetValue(options, out var state))
        {
            state.Clear();
        }
    }

    public static void MarkUseExternalDataSource(JsonSerializerOptions options)
    {
        if (map.TryGetValue(options, out var state))
        {
            state.UseExternalDataSource = true;
        }
    }

    public static void MarkUseJavascriptFunction(JsonSerializerOptions options)
    {
        if (map.TryGetValue(options, out var state))
        {
            state.UseJavascriptFunction = true;
        }
    }

    public static bool ShouldMapSpecialObjects(JsonSerializerOptions options)
    {
        if (map.TryGetValue(options, out var state))
        {
            return state.MapSpecialObjects;
        }

        return false;
    }
}

internal class SpecialObjectSerializeState
{
    public bool UseExternalDataSource { get; set; }

    public bool UseJavascriptFunction { get; set; }

    public bool MapSpecialObjects => UseExternalDataSource || UseJavascriptFunction;

    public void Clear()
    {
        UseExternalDataSource = false;
        UseJavascriptFunction = false;
    }
}
