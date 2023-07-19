using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(NumberOrNumberArrayConverter))]
public class NumberOrNumberArray
{
	public NumberOrNumberArray(double number)
	{
		Numbers = new double[] { number };
	}

	public NumberOrNumberArray(double[] numbers)
	{
		Numbers = numbers;
	}

	public double[] Numbers { get; }

	public static implicit operator NumberOrNumberArray(double number)
	{
		return new NumberOrNumberArray(number);
	}

	public static implicit operator NumberOrNumberArray(double[] numbers)
	{
		return new NumberOrNumberArray(numbers);
	}
}

public class NumberOrNumberArrayConverter : JsonConverter<NumberOrNumberArray>
{
	public override NumberOrNumberArray Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for NumberOrNumberArray.");
	}

	public override void Write(Utf8JsonWriter writer, NumberOrNumberArray value, JsonSerializerOptions options)
	{
		if (value.Numbers.Length == 1)
		{
			writer.WriteNumberValue(value.Numbers[0]);
		}
		else
		{
			writer.WriteStartArray();
			foreach (var val in value.Numbers)
				writer.WriteNumberValue(val);
			writer.WriteEndArray();
		}
	}
}