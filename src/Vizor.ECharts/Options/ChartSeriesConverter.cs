using System.Text.Json.Serialization;
using System.Text.Json;
using Vizor.ECharts.Options.Series.Pie;

namespace Vizor.ECharts.Options;

public class ChartSeriesConverter<TData> : JsonConverter<List<IChartSeries<TData>>>
{
	public override List<IChartSeries<TData>> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for List<IChartSeries<TData>>.");
	}

	public override void Write(Utf8JsonWriter writer, List<IChartSeries<TData>> value, JsonSerializerOptions options)
	{
		writer.WriteStartArray();
		foreach (var series in value)
		{
			JsonSerializer.Serialize(writer, series, series.GetType(), options);
		}
		writer.WriteEndArray();
	}
}

public class ChartSeriesConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
	{
		// Check if the type is an interface and implements IChartSeries<>
		if (typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(List<>))
		{
			return typeToConvert.GenericTypeArguments[0].GetGenericTypeDefinition() == typeof(IChartSeries<>);
		}

		return false;
	}

	public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
	{
		// Create an instance of the generic converter with the appropriate type argument
		Type valueType = typeToConvert.GenericTypeArguments[0].GenericTypeArguments[0];
		Type converterType = typeof(ChartSeriesConverter<>).MakeGenericType(valueType);
		return (JsonConverter)Activator.CreateInstance(converterType);
	}
}
