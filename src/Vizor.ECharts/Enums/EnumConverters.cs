using System.Text.Json.Serialization;
using System.Text.Json;

namespace Vizor.ECharts;

public class LowerCaseEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct
{
	public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException($"Deserialization is not implemented for {typeof(TEnum).Name}.");
	}

	public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
	{
		// Serialize the enum value as a lower-case string
		writer.WriteStringValue(value.ToString()!.ToLower());
	}
}

public class CamelCaseEnumConverter<TEnum> : JsonConverter<TEnum> where TEnum : struct
{
	public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException($"Deserialization is not implemented for {typeof(TEnum).Name}.");
	}

	public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
	{
		var str = value.ToString()!;
		writer.WriteStringValue(char.ToLower(str[0]) + str[1..]);
	}
}