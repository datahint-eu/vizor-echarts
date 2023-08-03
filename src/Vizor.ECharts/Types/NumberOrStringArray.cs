using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(NumberOrStringArrayConverter))]
public class NumberOrStringArray
{
	public NumberOrStringArray(params NumberOrString[] values)
	{
		Values = values;
	}

	public NumberOrString[] Values { get; }

	public static implicit operator NumberOrStringArray(string value)
	{
		return new NumberOrStringArray(value);
	}

	public static implicit operator NumberOrStringArray(double value)
	{
		return new NumberOrStringArray(value);
	}

	public static implicit operator NumberOrStringArray(NumberOrString value)
	{
		return new NumberOrStringArray(value);
	}

	public static implicit operator NumberOrStringArray(NumberOrString[] values)
	{
		return new NumberOrStringArray(values);
	}

	public static implicit operator NumberOrStringArray(string[] values)
	{
		return new NumberOrStringArray(values.Select(v => new NumberOrString(v)).ToArray());
	}

	public static implicit operator NumberOrStringArray(double[] values)
	{
		return new NumberOrStringArray(values.Select(v => new NumberOrString(v)).ToArray());
	}
}

public class NumberOrStringArrayConverter : JsonConverter<NumberOrStringArray>
{
	public override NumberOrStringArray Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for NumberOrStringArray.");
	}

	public override void Write(Utf8JsonWriter writer, NumberOrStringArray value, JsonSerializerOptions options)
	{
		if (value.Values.Length == 1)
		{
			NumberOrStringConverter.Instance.Write(writer, value.Values[0], options);
		}
		else
		{
			writer.WriteStartArray();

			foreach (var val in value.Values)
				NumberOrStringConverter.Instance.Write(writer, val, options);

			writer.WriteEndArray();
		}
	}
}