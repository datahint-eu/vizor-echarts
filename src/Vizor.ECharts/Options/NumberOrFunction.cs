using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(NumberOrFunctionConverter))]
public class NumberOrFunction
{
	public NumberOrFunction(double number)
	{
		Number = number;
	}

	public NumberOrFunction(string jsFunction)
	{
		JsFunction = jsFunction;
	}

	public double? Number { get; }
	public string? JsFunction { get; }

	public static implicit operator NumberOrFunction(double number)
	{
		return new NumberOrFunction(number);
	}

	public static implicit operator NumberOrFunction(string jsFunction)
	{
		return new NumberOrFunction(jsFunction);
	}
}

public class NumberOrFunctionConverter : JsonConverter<NumberOrFunction>
{
	public override NumberOrFunction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for NumberOrFunction.");
	}

	public override void Write(Utf8JsonWriter writer, NumberOrFunction value, JsonSerializerOptions options)
	{
		if (value.Number != null)
		{
			writer.WriteNumberValue(value.Number.Value);
		}
		else if (value.JsFunction != null)
		{
			writer.WriteRawValue(value.JsFunction);
		}
	}
}