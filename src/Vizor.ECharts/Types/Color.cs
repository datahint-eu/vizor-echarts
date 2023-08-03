using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://echarts.apache.org/en/option.html#color
/// </summary>
[JsonConverter(typeof(ColorConverter))]
public class Color
{
	private readonly string? color;
	private readonly object? graphicColor;

	/// <summary>
	/// Can be in hex format: #ccc, RGB: rgb(128, 128, 128) or RGBA: rgba(128, 128, 128, 0.5)
	/// Can also have the value 'transparent'
	/// See the convenience functions FromHex, FromRGB and FromRGBA
	/// </summary>
	/// <param name="color"></param>
	public Color(string color)
	{
		this.color = color;
	}

	public Color(IGraphicColor graphicColor)
	{
		this.graphicColor = graphicColor;
	}

	public string? Value => color;

	public object? GraphicColor => graphicColor; //NOTE: in .NET 6 we cannot use IGraphicColor, it will break serialization

	public static implicit operator Color(string color)
	{
		return new Color(color);
	}

	public static implicit operator Color(LinearGradient color)
	{
		return new Color(color);
	}

	public static implicit operator Color(RadialGradient color)
	{
		return new Color(color);
	}

	public static Color FromHex(string hex)
	{
		if (hex.StartsWith("#"))
		{
			return new Color(hex);
		}

		return new Color('#' + hex);
	}

	public static Color FromRGB(byte r, byte g, byte b)
	{
		return new Color($"rgb({(int)r}, {(int)g}, {(int)b})");
	}

	public static Color FromRGBA(byte r, byte g, byte b, double a)
	{
		return new Color($"rgba({(int)r}, {(int)g}, {(int)b}, {a})");
	}

	public static Color Transparent => new("transparent");
}

public class ColorConverter : JsonConverter<Color>
{
	private static ColorConverter instance = new();

	public override Color Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		return new Color(reader.GetString() ?? "");
	}

	public override void Write(Utf8JsonWriter writer, Color value, JsonSerializerOptions options)
	{
		if (value.GraphicColor != null)
		{
			string colorStops = "null";
			string global = "null";
			if (value.GraphicColor is Gradient g)
			{
				colorStops = JsonSerializer.Serialize(g.ColorStops, options);
				global = g.Global switch
				{
					true => "true",
					false => "false",
					_ => "null"
				};
			}

			switch (value.GraphicColor)
			{
				case LinearGradient lg:
					writer.WriteRawValue($"new echarts.graphic.LinearGradient({lg.X}, {lg.Y}, {lg.X2}, {lg.Y2}, {colorStops}, {global})", true);
					break;
				case RadialGradient rg:
					writer.WriteRawValue($"new echarts.graphic.RadialGradient({rg.X}, {rg.Y}, {rg.R}, {colorStops}, {global})", true);
					break;

			}
		}
		else
		{
			writer.WriteStringValue(value.Value);
		}
	}

	public static ColorConverter Instance => instance;
}