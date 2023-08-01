using System.Text.Json.Serialization;
using System.Text.Json;

namespace Vizor.ECharts;

public struct SeriesData<T1, T2>
{
	public SeriesData(T1? value1, T2? value2)
	{
		Value1 = value1;
		Value2 = value2;
	}

	public T1? Value1 { get; set; }

	public T2? Value2 { get; set; }
}

public class SeriesDataConverterFactory : JsonConverterFactory
{
	public override bool CanConvert(Type typeToConvert)
	{
		return typeToConvert.IsGenericType && typeToConvert.GetGenericTypeDefinition() == typeof(SeriesData<,>);
	}

	public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
	{
		Type[] genericArgs = typeToConvert.GetGenericArguments();
		Type converterType = typeof(SeriesDataConverter<,>).MakeGenericType(genericArgs);
		return (Activator.CreateInstance(converterType) as JsonConverter)!;
	}
}

public class SeriesDataConverter<T1, T2> : JsonConverter<SeriesData<T1, T2>>
{
	public override SeriesData<T1, T2> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for SeriesData<T1, T2>.");
	}

	public override void Write(Utf8JsonWriter writer, SeriesData<T1, T2> value, JsonSerializerOptions options)
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

		writer.WriteEndArray();
	}
}