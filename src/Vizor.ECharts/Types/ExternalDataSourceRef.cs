using System.Text.Json.Serialization;
using System.Text.Json;

namespace Vizor.ECharts;

/// <summary>
/// Reference to externally-fetched data that should be resolved at runtime in the browser.
/// 
/// Used to reference data previously fetched via ExternalDataSource, enabling data to be
/// loaded once from a URL and referenced multiple times in chart options.
/// 
/// SERIALIZATION PATTERN:
/// =====================
/// Serializes to raw JavaScript expression instead of JSON, enabling runtime data resolution:
///   Input:  Categories = new ExternalDataSourceRef(graph, "categories")
///   Output: "window.vizorECharts.getDataSource('graphId').categories"
/// 
/// This allows ECharts to receive the actual data array at runtime, not a string reference.
/// 
/// INTEGRATION WITH PROPERTY TYPES:
/// ================================
/// Can be assigned to properties in two ways:
/// 
/// 1. Via Wrapper Pattern (e.g., SeriesDataList&lt;T&gt;):
///      Data = new ExternalDataSourceRef(dataSource, "nodes")
///      // Has implicit operator: public static implicit operator SeriesDataList&lt;T&gt;(ExternalDataSourceRef ref)
/// 
/// 2. Via Bare object? Property (e.g., GraphSeries.Links, Categories):
///      Links = new ExternalDataSourceRef(dataSource, "links")  // Accepts object directly
///      Categories = new ExternalDataSourceRef(dataSource, "categories")
/// 
/// The wrapper pattern provides better type safety, but bare object? is simpler when
/// there are only a few supported types.
/// </summary>
public class ExternalDataSourceRef
{
    public ExternalDataSourceRef(ExternalDataSource dataSource, string? path = null)
    {
        FetchId = dataSource.FetchId;
        Path = path;
    }

    public ExternalDataSourceRef(string fetchId, string? path = null)
    {
        FetchId = fetchId;
        Path = path;
    }

    public string FetchId { get; }
    public string? Path { get; }
}


public class ExternalDataSourceRefConverter : JsonConverter<ExternalDataSourceRef>
{
    internal ExternalDataSourceRefConverter()
    {
    }

    public override ExternalDataSourceRef Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for ExternalDataSourceRef.");
    }

    public override void Write(Utf8JsonWriter writer, ExternalDataSourceRef value, JsonSerializerOptions options)
    {
        string raw = $"window.vizorECharts.getDataSource('{value.FetchId}')";
        if (value.Path != null)
        {
            if (!value.Path.StartsWith('.'))
                raw += '.';
            raw += value.Path;
        }
        writer.WriteRawValue(raw, skipInputValidation: true);
    }
}