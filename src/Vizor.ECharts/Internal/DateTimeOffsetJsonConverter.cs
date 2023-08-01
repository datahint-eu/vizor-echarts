using System.Text.Json.Serialization;
using System.Text.Json;

namespace Vizor.ECharts.Internal;

public class DateTimeOffsetJsonConverter : JsonConverter<DateTimeOffset>
{
	public override DateTimeOffset Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for DateTimeOffset.");
	}

	public override void Write(Utf8JsonWriter writer, DateTimeOffset value, JsonSerializerOptions options)
	{
		var dt = value.ToUniversalTime().DateTime;
		writer.WriteStringValue($"{dt.Year:D4}-{dt.Month:D2}-{dt.Day:D2}T{dt.Hour:D2}:{dt.Minute:D2}:{dt.Second:D2}.{dt.Millisecond:D3}Z");
	}
}
