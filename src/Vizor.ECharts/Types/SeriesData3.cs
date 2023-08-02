using System.Text.Json.Serialization;
using System.Text.Json;

namespace Vizor.ECharts;

public struct SeriesData<T1, T2, T3>
{
    public SeriesData(T1? value1, T2? value2, T3? value3)
    {
        Value1 = value1;
        Value2 = value2;
        Value3 = value3;
    }

    public T1? Value1 { get; set; }

    public T2? Value2 { get; set; }

    public T3? Value3 { get; set; }
}

public class SeriesDataConverter<T1, T2, T3> : JsonConverter<SeriesData<T1, T2, T3>>
{
    public override SeriesData<T1, T2, T3> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for SeriesData<T1, T2, T3>.");
    }

    public override void Write(Utf8JsonWriter writer, SeriesData<T1, T2, T3> value, JsonSerializerOptions options)
    {
        writer.WriteStartArray();

        if (value.Value1 == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            JsonSerializer.Serialize(writer, value.Value1, options);
        }

        if (value.Value2 == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            JsonSerializer.Serialize(writer, value.Value2, options);
        }

        if (value.Value3 == null)
        {
            writer.WriteNullValue();
        }
        else
        {
            JsonSerializer.Serialize(writer, value.Value3, options);
        }

        writer.WriteEndArray();
    }
}