using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(EmphasisBlurScopeConverter))]
public enum EmphasisBlurScope
{
    CoordinateSystem,
    Series,
    Global
}

public class EmphasisBlurScopeConverter : JsonConverter<EmphasisBlurScope>
{
    public override EmphasisBlurScope Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for EmphasisBlurScope.");
    }

    public override void Write(Utf8JsonWriter writer, EmphasisBlurScope value, JsonSerializerOptions options)
    {
        var str = value.ToString();
        writer.WriteStringValue(char.ToLower(str[0]) + str[1..]);
    }
}