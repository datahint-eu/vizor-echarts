using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(StringArrayConverter))]
public class StringArray
{
    public StringArray(string value)
    {
        Values = new string[] { value };
    }

    public StringArray(string[] values)
    {
        Values = values;
    }

    public string[]? Values { get; }

    public static implicit operator StringArray(string value)
    {
        return new StringArray(value);
    }

    public static implicit operator StringArray(string[] values)
    {
        return new StringArray(values);
    }

    /// <summary>
    /// Allow implicit conversion from IconType to StringArray (lower-cased per ECharts expectations).
    /// </summary>
    public static implicit operator StringArray(IconType iconType)
    {
        return new StringArray(iconType.ToString().ToLowerInvariant());
    }

    /// <summary>
    /// Allow implicit conversion from Icon[] to StringArray (lower-cased per ECharts expectations).
    /// </summary>
    public static implicit operator StringArray(Icon[] icons)
    {
        var values = icons.Select(i => i.Type?.ToString().ToLowerInvariant() ?? i.Url ?? string.Empty).ToArray();
        return new StringArray(values);
    }

    /// <summary>
    /// Allow implicit conversion from double[] to StringArray (for numeric arrays like [5, 20]).
    /// </summary>
    public static implicit operator StringArray(double[] values)
    {
        return new StringArray(values.Select(v => v.ToString()).ToArray());
    }

    /// <summary>
    /// Allow implicit conversion from double to StringArray (for single numeric values).
    /// </summary>
    public static implicit operator StringArray(double value)
    {
        return new StringArray(value.ToString());
    }
}

public class StringArrayConverter : JsonConverter<StringArray>
{
    public override StringArray Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for StringArray.");
    }

    public override void Write(Utf8JsonWriter writer, StringArray value, JsonSerializerOptions options)
    {
        if (value.Values != null)
        {
            if (value.Values.Length == 1)
            {
                writer.WriteStringValue(value.Values[0]);
            }
            else
            {
                writer.WriteStartArray();
                foreach (var val in value.Values)
                {
                    writer.WriteStringValue(val);
                }
                writer.WriteEndArray();
            }
        }
    }
}