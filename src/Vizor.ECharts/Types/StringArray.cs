using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(StringArrayConverter))]
public class StringArray
{
	public StringArray(string value)
	{
		Values = new string[] { value };
	}

	public StringArray(string[] values)
	{
		Values = values;
	}

	public string[]? Values { get; }

	public static implicit operator StringArray(string value)
	{
		return new StringArray(value);
	}

	public static implicit operator StringArray(string[] values)
	{
		return new StringArray(values);
	}
}

public class StringArrayConverter : JsonConverter<StringArray>
{
	public override StringArray Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for StringArray.");
	}

	public override void Write(Utf8JsonWriter writer, StringArray value, JsonSerializerOptions options)
	{
		if (value.Values != null)
		{
			if (value.Values.Length == 1)
			{
				writer.WriteStringValue(value.Values[0]);
			}
			else
			{
				writer.WriteStartArray();
				foreach (var val in value.Values)
				{
					writer.WriteStringValue(val);
				}
				writer.WriteEndArray();
			}
		}
	}
}