using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Represents a value that can be:
/// - A date string (e.g., '2023-01-01')
/// - A number (milliseconds timestamp or scalar value)
/// - A percentage string (e.g., '50%')
/// Used in DataZoom start/end/min/max properties.
/// </summary>
[JsonConverter(typeof(DateOrNumberOrStringConverter))]
public class DateOrNumberOrString
{
    private readonly object value;

    public DateOrNumberOrString(double value)
    {
        this.value = value;
    }

    public DateOrNumberOrString(int value)
    {
        this.value = value;
    }

    public DateOrNumberOrString(string value)
    {
        this.value = value;
    }

    public object Value => value;

    public static implicit operator DateOrNumberOrString(double value) => new(value);
    public static implicit operator DateOrNumberOrString(int value) => new(value);
    public static implicit operator DateOrNumberOrString(string value) => new(value);

    public override string ToString() => value?.ToString() ?? "null";
}

public class DateOrNumberOrStringConverter : JsonConverter<DateOrNumberOrString>
{
    public override DateOrNumberOrString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.Number => reader.TryGetInt32(out var intVal)
                ? new DateOrNumberOrString(intVal)
                : new DateOrNumberOrString(reader.GetDouble()),
            JsonTokenType.String => new DateOrNumberOrString(reader.GetString() ?? string.Empty),
            _ => throw new JsonException($"Cannot parse DateOrNumberOrString from {reader.TokenType}")
        };
    }

    public override void Write(Utf8JsonWriter writer, DateOrNumberOrString value, JsonSerializerOptions options)
    {
        if (value.Value is int i)
            writer.WriteNumberValue(i);
        else if (value.Value is double d)
            writer.WriteNumberValue(d);
        else if (value.Value is string s)
            writer.WriteStringValue(s);
        else
            writer.WriteNullValue();
    }
}
