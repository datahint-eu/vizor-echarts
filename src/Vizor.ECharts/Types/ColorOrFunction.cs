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

	public ColorOrFunction(JavascriptFunction function)
	{
		Function = function;
	}

	public Color? Color { get; }
	public JavascriptFunction? Function { get; }

	public static implicit operator ColorOrFunction(Color color)
	{
		return new ColorOrFunction(color);
	}

	public static implicit operator ColorOrFunction(JavascriptFunction function)
	{
		return new ColorOrFunction(function);
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
		else if (value.Function != null)
		{
			JavascriptFunctionConverter.Instance.Write(writer, value.Function, options);
		}
	}
}