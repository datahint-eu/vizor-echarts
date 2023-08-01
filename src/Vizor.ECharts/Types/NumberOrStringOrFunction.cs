using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(NumberOrStringOrFunctionConverter))]
public class NumberOrStringOrFunction
{
	public NumberOrStringOrFunction(double number)
	{
		Number = number;
	}

	public NumberOrStringOrFunction(string str)
	{
		String = str;
	}

	public NumberOrStringOrFunction(JavascriptFunction function)
	{
		Function = function;
	}

	public double? Number { get; }

	public string? String { get; }

	public JavascriptFunction? Function { get; }

	public static implicit operator NumberOrStringOrFunction(double number)
	{
		return new NumberOrStringOrFunction(number);
	}

	[return: NotNullIfNotNull(nameof(str))]
	public static implicit operator NumberOrStringOrFunction?(string? str)
	{
		if (str == null)
			return null;

		return new NumberOrStringOrFunction(str);
	}

	public static implicit operator NumberOrStringOrFunction(JavascriptFunction function)
	{
		return new NumberOrStringOrFunction(function);
	}
}

public class NumberOrStringOrFunctionConverter : JsonConverter<NumberOrStringOrFunction>
{
	public override NumberOrStringOrFunction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for NumberOrStringOrFunction.");
	}

	public override void Write(Utf8JsonWriter writer, NumberOrStringOrFunction value, JsonSerializerOptions options)
	{
		if (value.Number != null)
		{
			writer.WriteNumberValue(value.Number.Value);
		}
		else if (value.String != null)
		{
			writer.WriteStringValue(value.String);
		}
		else if (value.Function != null)
		{
			JavascriptFunctionConverter.Instance.Write(writer, value.Function, options);
		}
	}
}