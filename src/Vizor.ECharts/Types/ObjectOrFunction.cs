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

	public ObjectOrFunction(Guid functionId)
	{
		FunctionId = functionId;
	}

	public object? Value { get; }

	public Guid? FunctionId { get; }

	public static implicit operator ObjectOrFunction(Guid functionId)
	{
		return new ObjectOrFunction(functionId);
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
		else if (value.FunctionId != null)
		{
			// write a unique function id, we replace this with an actual function definition later on
			writer.WriteStringValue(value.FunctionId.ToString());
		}
	}
}