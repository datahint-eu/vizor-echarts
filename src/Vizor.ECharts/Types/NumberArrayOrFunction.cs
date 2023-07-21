using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(NumberArrayOrFunctionConverter))]
public class NumberArrayOrFunction
{
	public NumberArrayOrFunction(double number)
	{
		Numbers = new double[] { number };
	}

	public NumberArrayOrFunction(double[] numbers)
	{
		Numbers = numbers;
	}

	public NumberArrayOrFunction(JavascriptFunction function)
	{
		Function = function;
	}

	public double[]? Numbers { get; }
	public JavascriptFunction? Function { get; }

	public static implicit operator NumberArrayOrFunction(double number)
	{
		return new NumberArrayOrFunction(number);
	}

	public static implicit operator NumberArrayOrFunction(double[] numbers)
	{
		return new NumberArrayOrFunction(numbers);
	}

	public static implicit operator NumberArrayOrFunction(JavascriptFunction function)
	{
		return new NumberArrayOrFunction(function);
	}
}

public class NumberArrayOrFunctionConverter : JsonConverter<NumberArrayOrFunction>
{
	public override NumberArrayOrFunction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for NumberArrayOrFunction.");
	}

	public override void Write(Utf8JsonWriter writer, NumberArrayOrFunction value, JsonSerializerOptions options)
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
		else if (value.Function != null)
		{
			JavascriptFunctionConverter.Instance.Write(writer, value.Function, options);
		}
	}
}