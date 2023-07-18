using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

[JsonConverter(typeof(StringOrFunctionConverter))]
public class StringOrFunction
{
	public StringOrFunction(string value)
	{
		Value = value;
	}

	public StringOrFunction(Guid functionId)
	{
		FunctionId = functionId;
	}

	public string? Value { get; }

	public Guid? FunctionId { get; }

	public static implicit operator StringOrFunction(string value)
	{
		return new StringOrFunction(value);
	}

	public static implicit operator StringOrFunction(Guid functionId)
	{
		return new StringOrFunction(functionId);
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
		else if (value.FunctionId != null)
		{
			// write a unique function id, we replace this with an actual function definition later on
			writer.WriteStringValue(value.FunctionId.ToString());
		}
	}
}