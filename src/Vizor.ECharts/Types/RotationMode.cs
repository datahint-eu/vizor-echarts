using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Represents label rotation which can be specified as:
/// - boolean: true for automatic/tangential rotation
/// - number: rotation angle in degrees  
/// - string: rotation mode like 'tangential'
/// Used in label.rotate properties across various chart series.
/// </summary>
[JsonConverter(typeof(RotationModeConverter))]
public class RotationMode
{
    private readonly object value;

    public RotationMode(bool value)
    {
        this.value = value;
    }

    public RotationMode(double value)
    {
        this.value = value;
    }

    public RotationMode(int value)
    {
        this.value = value;
    }

    public RotationMode(string value)
    {
        this.value = value;
    }

    public object Value => value;

    public static implicit operator RotationMode(bool value) => new(value);
    public static implicit operator RotationMode(double value) => new(value);
    public static implicit operator RotationMode(int value) => new(value);
    public static implicit operator RotationMode(string value) => new(value);

    public override string ToString() => value?.ToString() ?? "null";
}

public class RotationModeConverter : JsonConverter<RotationMode>
{
    public override RotationMode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        return reader.TokenType switch
        {
            JsonTokenType.True => new RotationMode(true),
            JsonTokenType.False => new RotationMode(false),
            JsonTokenType.Number => reader.TryGetInt32(out var intVal) 
                ? new RotationMode(intVal)
                : new RotationMode(reader.GetDouble()),
            JsonTokenType.String => new RotationMode(reader.GetString() ?? string.Empty),
            _ => throw new JsonException($"Cannot parse RotationMode from {reader.TokenType}")
        };
    }

    public override void Write(Utf8JsonWriter writer, RotationMode value, JsonSerializerOptions options)
    {
        if (value.Value is bool b)
            writer.WriteBooleanValue(b);
        else if (value.Value is int i)
            writer.WriteNumberValue(i);
        else if (value.Value is double d)
            writer.WriteNumberValue(d);
        else if (value.Value is string s)
            writer.WriteStringValue(s);
        else
            writer.WriteNullValue();
    }
}
