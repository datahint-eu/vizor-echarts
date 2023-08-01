using System.Text.Json.Serialization;
using System.Text.Json;

namespace Vizor.ECharts.Internal;

public class DateOnlyJsonConverter : JsonConverter<DateOnly>
{
	public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
	throw new NotImplementedException("Deserialization is not implemented for DateOnly.");
}

	public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
	{
		writer.WriteStringValue($"{value.Year:D4}-{value.Month:D2}-{value.Day:D2}");
	}
}
