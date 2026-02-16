using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(BoolOrStringConverter))]
public class BoolOrString
{
    public BoolOrString(bool b)
    {
        Bool = b;
    }

    public BoolOrString(string value)
    {
        String = value;
    }

    public bool? Bool { get; }
    public string? String { get; }

    public static implicit operator BoolOrString(bool b)
    {
        return new BoolOrString(b);
    }

    [return: NotNullIfNotNull(nameof(str))]
    public static implicit operator BoolOrString?(string? str)
    {
        if (str == null)
            return null;

        return new BoolOrString(str);
    }
}

public class BoolOrStringConverter : JsonConverter<BoolOrString>
{
    private static readonly BoolOrStringConverter instance = new();

    public override BoolOrString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for BoolOrString.");
    }

    public override void Write(Utf8JsonWriter writer, BoolOrString value, JsonSerializerOptions options)
    {
        if (value.Bool != null)
        {
            writer.WriteBooleanValue(value.Bool.Value);
        }
        else if (value.String != null)
        {
            writer.WriteStringValue(value.String);
        }
    }

    public static BoolOrStringConverter Instance => instance;
}
