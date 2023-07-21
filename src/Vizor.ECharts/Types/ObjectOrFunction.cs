using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(ObjectOrFunctionConverter))]
public class ObjectOrFunction
{
	public ObjectOrFunction(object value)
	{
		Value = value;
	}

	public ObjectOrFunction(JavascriptFunction function)
	{
		Function = function;
	}

	public object? Value { get; }

	public JavascriptFunction? Function { get; }

	public static implicit operator ObjectOrFunction(JavascriptFunction function)
	{
		return new ObjectOrFunction(function);
	}
}

public class ObjectOrFunctionConverter : JsonConverter<ObjectOrFunction>
{
	public override ObjectOrFunction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for ObjectOrFunction.");
	}

	public override void Write(Utf8JsonWriter writer, ObjectOrFunction value, JsonSerializerOptions options)
	{
		if (value.Value != null)
		{
			JsonSerializer.Serialize(writer, value.Value, value.Value.GetType(), options);
		}
		else if (value.Function != null)
		{
			JavascriptFunctionConverter.Instance.Write(writer, value.Function, options);
		}
	}
}