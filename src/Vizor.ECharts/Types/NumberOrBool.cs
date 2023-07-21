using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(NumberOrBoolConverter))]
public class NumberOrBool
{
	public NumberOrBool(double number)
	{
		Number = number;
	}

	public NumberOrBool(bool b)
	{
		Bool = b;
	}

	public double? Number { get; }
	public bool? Bool { get; }

	public static implicit operator NumberOrBool(double number)
	{
		return new NumberOrBool(number);
	}

	public static implicit operator NumberOrBool(bool b)
	{
		return new NumberOrBool(b);
	}
}

public class NumberOrBoolConverter : JsonConverter<NumberOrBool>
{
	public override NumberOrBool Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for NumberOrBool.");
	}

	public override void Write(Utf8JsonWriter writer, NumberOrBool value, JsonSerializerOptions options)
	{
		if (value.Number != null)
		{
			writer.WriteNumberValue(value.Number.Value);
		}
		else if (value.Bool != null)
		{
			writer.WriteBooleanValue(value.Bool.Value);
		}
	}
}