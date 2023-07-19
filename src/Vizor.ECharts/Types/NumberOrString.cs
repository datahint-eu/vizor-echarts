using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Types;

[JsonConverter(typeof(NumberOrStringConverter))]
public class NumberOrString
{
    public NumberOrString(double number)
    {
        Number = number;
    }

    public NumberOrString(string value)
    {
        String = value;
    }

    public double? Number { get; }
    public string? String { get; }

    public static implicit operator NumberOrString(double number)
    {
        return new NumberOrString(number);
    }

    public static implicit operator NumberOrString(string jsFunction)
    {
        return new NumberOrString(jsFunction);
    }
}

public class NumberOrStringConverter : JsonConverter<NumberOrString>
{
    private static NumberOrStringConverter instance = new();

    public override NumberOrString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for NumberOrString.");
    }

    public override void Write(Utf8JsonWriter writer, NumberOrString value, JsonSerializerOptions options)
    {
        if (value.Number != null)
        {
            writer.WriteNumberValue(value.Number.Value);
        }
        else if (value.String != null)
        {
            writer.WriteStringValue(value.String);
        }
    }

    public static NumberOrStringConverter Instance => instance;
}