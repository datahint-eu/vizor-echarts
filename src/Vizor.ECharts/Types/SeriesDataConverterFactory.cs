using System.Text.Json.Serialization;
using System.Text.Json;

namespace Vizor.ECharts;

public class SeriesDataConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
            return false;

        var genericDef = typeToConvert.GetGenericTypeDefinition();
        return genericDef == typeof(SeriesData<,>) || genericDef == typeof(SeriesData<,,>);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Type[] genericArgs = typeToConvert.GetGenericArguments();

        Type converterType = genericArgs.Length switch
        {
            2 => typeof(SeriesDataConverter<,>).MakeGenericType(genericArgs),
            3 => typeof(SeriesDataConverter<,,>).MakeGenericType(genericArgs),
            _ => throw new NotSupportedException($"SeriesDataConverterFactory does not support SeriesData<> with {genericArgs.Length} generic params")
        };

        return (Activator.CreateInstance(converterType) as JsonConverter)!;
    }
}
