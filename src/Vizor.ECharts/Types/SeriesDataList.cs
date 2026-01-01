using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Flexible series data container that accepts raw arrays, Lists of data objects, or mixed data.
/// Supports implicit conversions from int[], double[], string[] arrays for simple charts,
/// and List&lt;T&gt; or T[] for complex data with styling.
/// 
/// PATTERN: Type-Safe Wrapper with Implicit Conversions
/// =====================================================
/// This class uses a wrapper pattern to provide type safety and discoverability while maintaining
/// internal flexibility. Instead of using bare object? properties, this approach:
/// 
/// • Provides implicit operators for each supported type (List&lt;T&gt;, ExternalDataSourceRef, etc.)
/// • Enables IntelliSense to show all valid assignment types
/// • Uses a custom JSON converter to serialize the internal object based on its runtime type
/// • Maintains API clarity - users see exactly what types are accepted
/// 
/// Usage:
///   Data = new int[] { 1, 2, 3 }                           // Simple values
///   Data = new List&lt;MyDataObject&gt; { ... }              // Complex objects
///   Data = new ExternalDataSourceRef(dataSource, "path")   // External data
/// 
/// Serialization:
///   The custom JsonConverter inspects the internal object type and serializes accordingly.
///   ExternalDataSourceRef serializes to: window.vizorECharts.getDataSource('id').path
///   Lists serialize to JSON arrays.
/// 
/// When to use this pattern:
///   • When you need type safety and API clarity
///   • When there are multiple valid input types
///   • When you want IDE support for discovering valid assignments
/// </summary>
[JsonConverter(typeof(SeriesDataListConverter))]
public class SeriesDataList<T> where T : class
{
    private object? _data;

    // Implicit conversion from simple value arrays
    public static implicit operator SeriesDataList<T>(int[] values) => 
        new() { _data = values };
    
    public static implicit operator SeriesDataList<T>(double[] values) => 
        new() { _data = values };
    
    public static implicit operator SeriesDataList<T>(string[] values) => 
        new() { _data = values };

    public static implicit operator SeriesDataList<T>(float[] values) => 
        new() { _data = values };

    // Implicit conversion from List of primitives (for convenience)
    public static implicit operator SeriesDataList<T>(List<int> values) => 
        new() { _data = values };
    
    public static implicit operator SeriesDataList<T>(List<double> values) => 
        new() { _data = values };

    // Implicit conversion from 2D arrays (for coordinate pairs, heatmap data, etc.)
    public static implicit operator SeriesDataList<T>(int[][] values) => 
        new() { _data = values };
    
    public static implicit operator SeriesDataList<T>(double[][] values) => 
        new() { _data = values };

    // Implicit conversion from List of data objects
    public static implicit operator SeriesDataList<T>(List<T> values) => 
        new() { _data = values };

    // Implicit conversion from array of data objects
    public static implicit operator SeriesDataList<T>(T[] values) => 
        new() { _data = values.ToList() };

    // Implicit conversion from List<SeriesData<T1,T2>> for coordinate pair data
    public static implicit operator SeriesDataList<T>(List<SeriesData<int, int>> values) => 
        new() { _data = values };
    
    public static implicit operator SeriesDataList<T>(List<SeriesData<double, double>> values) => 
        new() { _data = values };
    
    public static implicit operator SeriesDataList<T>(List<SeriesData<DateTime, int>> values) => 
        new() { _data = values };
    
    public static implicit operator SeriesDataList<T>(List<SeriesData<DateOnly, int>> values) => 
        new() { _data = values };

    // Implicit conversion from external data reference (for lazy/fetched datasets)
    public static implicit operator SeriesDataList<T>(ExternalDataSourceRef externalRef) =>
        new() { _data = externalRef };

    // Implicit conversion from List<SeriesData<T1,T2,T3>> for three-value data
    public static implicit operator SeriesDataList<T>(List<SeriesData<int, int, int>> values) => 
        new() { _data = values };
    
    public static implicit operator SeriesDataList<T>(List<SeriesData<double, double, double>> values) => 
        new() { _data = values };
    
    public static implicit operator SeriesDataList<T>(List<SeriesData<string, int, string>> values) => 
        new() { _data = values };
    
    public static implicit operator SeriesDataList<T>(List<SeriesData<DateTime, int, int>> values) => 
        new() { _data = values };

    /// <summary>
    /// Gets or sets an item in the underlying list by index.
    /// Only works when the internal data is a List&lt;T&gt;.
    /// </summary>
    public T? this[int index]
    {
        get => (_data as List<T>)?[index];
        set
        {
            if (_data is List<T> list && index >= 0 && index < list.Count)
            {
                list[index] = value!;
            }
        }
    }

    internal object? GetData() => _data;
}

public class SeriesDataListConverter : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert) =>
        typeToConvert.IsGenericType && 
        typeToConvert.GetGenericTypeDefinition() == typeof(SeriesDataList<>);

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Type itemType = typeToConvert.GetGenericArguments()[0];
        Type converterType = typeof(SeriesDataListConverter<>).MakeGenericType(itemType);
        return (Activator.CreateInstance(converterType) as JsonConverter)!;
    }
}

public class SeriesDataListConverter<T> : JsonConverter<SeriesDataList<T>> where T : class
{
    public override SeriesDataList<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for SeriesDataList<T>.");
    }

    public override void Write(Utf8JsonWriter writer, SeriesDataList<T> value, JsonSerializerOptions options)
    {
        var data = value.GetData();
        if (data == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            JsonSerializer.Serialize(writer, data, options);
        }
    }
}
