using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(NumberOrStringConverter))]
public class NumberOrString
{
	public NumberOrString(double number)
	{
		Number = number;
	}

	public NumberOrString(string value)
	{
		String = value;
	}

	public double? Number { get; }
	public string? String { get; }

	public static implicit operator NumberOrString(double number)
	{
		return new NumberOrString(number);
	}

	[return: NotNullIfNotNull(nameof(str))]
	public static implicit operator NumberOrString?(string? str)
	{
		if (str == null)
			return null;

		return new NumberOrString(str);
	}
}

public class NumberOrStringConverter : JsonConverter<NumberOrString>
{
	private static readonly NumberOrStringConverter instance = new();

	public override NumberOrString Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for NumberOrString.");
	}

	public override void Write(Utf8JsonWriter writer, NumberOrString value, JsonSerializerOptions options)
	{
		if (value.Number != null)
		{
			writer.WriteNumberValue(value.Number.Value);
		}
		else if (value.String != null)
		{
			writer.WriteStringValue(value.String);
		}
	}

	public static NumberOrStringConverter Instance => instance;
}