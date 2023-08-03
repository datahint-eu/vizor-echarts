using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Internal;

internal class PolymorphicJsonConverter<T> : JsonConverter<T>
{
	public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException($"Deserialization is not implemented for {typeof(T)}.");
	}

	public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
	{
		if (value == null)
		{
			writer.WriteNullValue();
		}
        else
		{
			JsonSerializer.Serialize(writer, value, value.GetType(), options);
		}
	}
}

internal class PolymorphicListJsonConverter<T> : JsonConverter<List<T>>
{
	public override List<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException($"Deserialization is not implemented for List<{typeof(T)}>.");
	}

	public override void Write(Utf8JsonWriter writer, List<T> value, JsonSerializerOptions options)
	{
		if (value == null)
		{
			writer.WriteNullValue();
		}
		else
		{
			writer.WriteStartArray();
			foreach (var item in value)
			{
				if (item == null)
					writer.WriteNullValue();
				else
					JsonSerializer.Serialize(writer, item, item.GetType(), options);
			}
			writer.WriteEndArray();
		}
	}
}

internal class PolymorphicArrayJsonConverter<T> : JsonConverter<T[]>
{
	public override T[] Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException($"Deserialization is not implemented for {typeof(T)}[].");
	}

	public override void Write(Utf8JsonWriter writer, T[] value, JsonSerializerOptions options)
	{
		if (value == null)
		{
			writer.WriteNullValue();
		}
		else
		{
			writer.WriteStartArray();
			foreach (var item in value)
			{
				if (item == null)
					writer.WriteNullValue();
				else
					JsonSerializer.Serialize(writer, item, item.GetType(), options);
			}
			writer.WriteEndArray();
		}
	}
}
