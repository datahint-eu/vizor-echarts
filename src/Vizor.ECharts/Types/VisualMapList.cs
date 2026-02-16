using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Flexible VisualMap container that accepts a single IVisualMap or a list of IVisualMaps.
/// Supports implicit conversions from single VisualMap instances or lists.
/// </summary>
[JsonConverter(typeof(VisualMapListConverter))]
public class VisualMapList
{
    private object? _data;

    // Implicit conversion from single ContinuousVisualMap
    public static implicit operator VisualMapList(ContinuousVisualMap? map) => 
        new() { _data = map };
    
    // Implicit conversion from single PiecewiseVisualMap
    public static implicit operator VisualMapList(PiecewiseVisualMap? map) => 
        new() { _data = map };

    // Implicit conversion from List of VisualMaps
    public static implicit operator VisualMapList(List<IVisualMap>? maps) => 
        new() { _data = maps };
    
    // Implicit conversion from array of VisualMaps
    public static implicit operator VisualMapList(IVisualMap[]? maps) => 
        new() { _data = maps?.ToList() };

    internal object? GetData() => _data;
}

public class VisualMapListConverter : JsonConverter<VisualMapList>
{
    public override VisualMapList Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for VisualMapList.");
    }

    public override void Write(Utf8JsonWriter writer, VisualMapList value, JsonSerializerOptions options)
    {
        var data = value.GetData();
        if (data == null)
        {
            writer.WriteNullValue();
            return;
        }

        // If it's a single IVisualMap, serialize it as a single object (not wrapped in array)
        if (data is IVisualMap singleMap)
        {
            JsonSerializer.Serialize(writer, singleMap, singleMap.GetType(), options);
        }
        // If it's a list, serialize as array
        else if (data is List<IVisualMap> mapList)
        {
            writer.WriteStartArray();
            foreach (var map in mapList)
            {
                JsonSerializer.Serialize(writer, map, map.GetType(), options);
            }
            writer.WriteEndArray();
        }
        else
        {
            JsonSerializer.Serialize(writer, data, options);
        }
    }
}
