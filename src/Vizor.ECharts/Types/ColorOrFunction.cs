using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(ColorOrFunctionConverter))]
public class ColorOrFunction
{
	public ColorOrFunction(Color color)
	{
		Color = color;
	}

	public ColorOrFunction(Guid functionId)
	{
		FunctionId = functionId;
	}

	public Color? Color { get; }
	public Guid? FunctionId { get; }

	public static implicit operator ColorOrFunction(Color color)
	{
		return new ColorOrFunction(color);
	}

	public static implicit operator ColorOrFunction(Guid functionId)
	{
		return new ColorOrFunction(functionId);
	}
}

public class ColorOrFunctionConverter : JsonConverter<ColorOrFunction>
{
	public override ColorOrFunction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for ColorOrFunction.");
	}

	public override void Write(Utf8JsonWriter writer, ColorOrFunction value, JsonSerializerOptions options)
	{
		if (value.Color != null)
		{
			writer.WriteStringValue(value.Color.ToString());
		}
		else if (value.FunctionId != null)
		{
			writer.WriteStringValue(value.FunctionId.ToString());
		}
	}
}