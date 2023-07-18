using System.Text.Json.Serialization;
using System.Text.Json;

namespace Vizor.ECharts.Options.Series.Pie;

[JsonConverter(typeof(PieNameValueConverter))]
public class PieNameValue : IPieNameValue
{
	public string? Name { get; set; }

	public double Value { get; set; }

	public PieDataOptions? Options { get; set; }
}

public class PieNameValueConverter : JsonConverter<PieNameValue>
{
	public override PieNameValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for PieNameValue.");
	}

	public override void Write(Utf8JsonWriter writer, PieNameValue value, JsonSerializerOptions options)
	{
		writer.WriteStartObject();

		// Write Name and Value properties
		writer.WriteString("name", value.Name);
		writer.WriteNumber("value", value.Value);

		// Serialize PieSeriesOptions directly into the JSON output
		if (value.Options != null)
		{
			using var doc = JsonSerializer.SerializeToDocument(value.Options, options);
			foreach (JsonProperty property in doc.RootElement.EnumerateObject())
			{
				property.WriteTo(writer);
			}
		}

		writer.WriteEndObject();
	}
}