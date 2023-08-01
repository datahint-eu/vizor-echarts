using System.Text.Json.Serialization;
using System.Text.Json;

namespace Vizor.ECharts.Internal;

public class DateTimeJsonConverter : JsonConverter<DateTime>
{
	public override DateTime Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for DateTime.");
	}

	public override void Write(Utf8JsonWriter writer, DateTime value, JsonSerializerOptions options)
	{
		if (value.Kind == DateTimeKind.Local)
			value = value.ToUniversalTime();
		writer.WriteStringValue($"{value.Year:D4}-{value.Month:D2}-{value.Day:D2}T{value.Hour:D2}:{value.Minute:D2}:{value.Second:D2}.{value.Millisecond:D3}Z");
	}
}
