using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(StringOrFunctionConverter))]
public class StringOrFunction
{
	public StringOrFunction(string value)
	{
		Value = value;
	}

	public StringOrFunction(JavascriptFunction function)
	{
		Function = function;
	}

	public string? Value { get; }

	public JavascriptFunction? Function { get; }

	public static implicit operator StringOrFunction(string value)
	{
		return new StringOrFunction(value);
	}

	public static implicit operator StringOrFunction(JavascriptFunction function)
	{
		return new StringOrFunction(function);
	}
}

public class StringOrFunctionConverter : JsonConverter<StringOrFunction>
{
	public override StringOrFunction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for StringOrFunction.");
	}

	public override void Write(Utf8JsonWriter writer, StringOrFunction value, JsonSerializerOptions options)
	{
		if (value.Value != null)
		{
			writer.WriteStringValue(value.Value);
		}
		else if (value.Function != null)
		{
			JavascriptFunctionConverter.Instance.Write(writer, value.Function, options);
		}
	}
}