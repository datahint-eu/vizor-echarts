using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(FunctionConverter))]
public class Function
{
	public Function(Guid functionId)
	{
		FunctionId = functionId;
	}

	public Guid FunctionId { get; }

	public static implicit operator Function(Guid functionId)
	{
		return new Function(functionId);
	}
}

public class FunctionConverter : JsonConverter<Function>
{
	public override Function Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for Function.");
	}

	public override void Write(Utf8JsonWriter writer, Function value, JsonSerializerOptions options)
	{
		// write a unique function id, we replace this with an actual function definition later on
		writer.WriteStringValue(value.FunctionId.ToString());
	}
}