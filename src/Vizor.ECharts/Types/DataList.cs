using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Flexible wrapper for data lists that allows implicit conversion from arrays of primitives to lists of data objects.
/// Supports both simple value arrays (int[], string[], etc.) and complex data object lists.
/// Used for properties like Legend.Data, XAxis.Data, etc.
/// </summary>
/// <typeparam name="T">The target data type (e.g., AxisData, LegendData)</typeparam>
[JsonConverter(typeof(DataListConverterFactory))]
public class DataList<T> where T : class
{
    private readonly object data;

    private DataList(object data)
    {
        this.data = data;
    }

    /// <summary>
    /// Gets the underlying data for serialization.
    /// </summary>
    public object GetData() => data;

    // Implicit conversions from various array/list types
    public static implicit operator DataList<T>(List<T> list) => new(list);
    public static implicit operator DataList<T>(T[] array) => new(array);
    
    // For types with implicit string conversion (AxisData, LegendData)
    public static implicit operator DataList<T>(string[] array) => new(array);
    public static implicit operator DataList<T>(List<string> list) => new(list.ToArray());
}

/// <summary>
/// JSON converter factory for DataList{T}.
/// </summary>
internal class DataListConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(DataList<>);
    }

    public override JsonConverter? CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Type elementType = typeToConvert.GetGenericArguments()[0];
        Type converterType = typeof(DataListConverter<>).MakeGenericType(elementType);
        return (JsonConverter?)Activator.CreateInstance(converterType);
    }
}

/// <summary>
/// Generic JSON converter for DataList{T}.
/// Serializes the underlying data directly without wrapping.
/// </summary>
internal class DataListConverter<T> : JsonConverter<DataList<T>> where T : class
{
    public override DataList<T>? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization of DataList is not supported");
    }

    public override void Write(Utf8JsonWriter writer, DataList<T> value, JsonSerializerOptions options)
    {
        JsonSerializer.Serialize(writer, value.GetData(), options);
    }
}
