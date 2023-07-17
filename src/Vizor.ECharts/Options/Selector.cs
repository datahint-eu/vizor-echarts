using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

/// <summary>
/// Border type
/// See https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/lineDashOffset
/// </summary>
[JsonConverter(typeof(SelectorConverter))]
public class Selector
{
	public Selector(bool enabled)
	{
		Enabled = enabled;
	}

	public Selector(params SelectorType[] buttons)
	{
		Buttons = buttons;
	}

	public Selector(params KeyValuePair<SelectorType, string>[] buttonsWithLabel)
	{
		ButtonsWithLabel = buttonsWithLabel;
	}

	public bool Enabled { get; }
	public SelectorType[]? Buttons { get; }
	public KeyValuePair<SelectorType, string>[]? ButtonsWithLabel { get; }
}

public enum SelectorType
{
	All,
	Inverse
}


public class SelectorConverter : JsonConverter<Selector>
{
	public override Selector Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for Selector.");
	}

	public override void Write(Utf8JsonWriter writer, Selector value, JsonSerializerOptions options)
	{
		if (value.ButtonsWithLabel != null)
		{
			writer.WriteStartArray();
			foreach (var val in value.ButtonsWithLabel)
			{
				writer.WriteStartObject();
				writer.WriteString("type", val.Key.ToString()!.ToLower());
				writer.WriteString("title", val.Value);
				writer.WriteEndObject();
			}
			writer.WriteEndArray();

		}
		else if (value.Buttons != null)
		{
			writer.WriteStartArray();
			foreach (var val in value.Buttons)
			{
				writer.WriteStringValue(val.ToString()!.ToLower());
			}
			writer.WriteEndArray();
		}
		else
		{
			writer.WriteBooleanValue(value.Enabled);
		}
	}
}