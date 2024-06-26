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

	public override string ToString()
	{
		return string.Join(", ", Numbers.Select(n => n.ToString()));
	}
}

public class NumberOrNumberArrayConverter : JsonConverter<NumberOrNumberArray>
{
	public override NumberOrNumberArray Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		if (reader.TokenType == JsonTokenType.Number)
		{
			return new NumberOrNumberArray(reader.GetDouble());
		}
		else if (reader.TokenType == JsonTokenType.StartArray)
		{
			var numbers = new List<double>();
			while (reader.Read())
			{
				if (reader.TokenType == JsonTokenType.EndArray)
				{
					break;
				}

				if (reader.TokenType == JsonTokenType.Number)
				{
					numbers.Add(reader.GetDouble());
				}
				else
				{
					throw new JsonException("Expected number in the array.");
				}
			}
			return new NumberOrNumberArray(numbers.ToArray());
		}
		else
		{
			throw new JsonException("Expected a number or an array of numbers.");
		}
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