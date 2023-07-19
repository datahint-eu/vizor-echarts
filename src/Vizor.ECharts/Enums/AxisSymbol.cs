using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(AxisSymbolConverter))]
public class AxisSymbol
{
    public AxisSymbol(AxisSymbolType[] types)
    {
        Types = types;
    }

    public AxisSymbol(AxisSymbolType type)
    {
        Types = new AxisSymbolType[] { type };
    }

    public AxisSymbolType[] Types { get; }
}

public enum AxisSymbolType
{
    None,
    Arrow
}


public class AxisSymbolConverter : JsonConverter<AxisSymbol>
{
    public override AxisSymbol Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for AxisSymbol.");
    }

    public override void Write(Utf8JsonWriter writer, AxisSymbol value, JsonSerializerOptions options)
    {
        if (value.Types.Length == 1)
        {
            writer.WriteStringValue(value.Types[0].ToString()!.ToLower());
        }
        else
        {
            writer.WriteStartArray();
            foreach (var val in value.Types)
            {
                writer.WriteStringValue(val.ToString().ToLower());
            }
            writer.WriteEndArray();
        }
    }
}