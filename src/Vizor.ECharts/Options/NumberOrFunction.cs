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

	public NumberOrFunction(Guid functionId)
	{
		FunctionId = functionId;
	}

	public double? Number { get; }
	public Guid? FunctionId { get; }

	public static implicit operator NumberOrFunction(double number)
	{
		return new NumberOrFunction(number);
	}

	public static implicit operator NumberOrFunction(Guid functionId)
	{
		return new NumberOrFunction(functionId);
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
		else if (value.FunctionId != null)
		{
			writer.WriteStringValue(value.FunctionId.ToString());
		}
	}
}