using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(NumberArrayConverter))]
public class NumberArray
{
	public NumberArray(double number)
	{
		Numbers = new double[] { number };
	}

	public NumberArray(double[] numbers)
	{
		Numbers = numbers;
	}

	public double[]? Numbers { get; }

	public static implicit operator NumberArray(double number)
	{
		return new NumberArray(number);
	}

	public static implicit operator NumberArray(double[] numbers)
	{
		return new NumberArray(numbers);
	}
}

public class NumberArrayConverter : JsonConverter<NumberArray>
{
	public override NumberArray Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for NumberArray.");
	}

	public override void Write(Utf8JsonWriter writer, NumberArray value, JsonSerializerOptions options)
	{
		if (value.Numbers != null)
		{
			if (value.Numbers.Length == 1)
			{
				writer.WriteNumberValue(value.Numbers[0]);
			}
			else
			{
				writer.WriteStartArray();
				foreach (var val in value.Numbers)
				{
					writer.WriteNumberValue(val);
				}
				writer.WriteEndArray();
			}
		}
	}
}