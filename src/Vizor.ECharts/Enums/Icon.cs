using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://echarts.apache.org/en/option.html#legend.icon
/// </summary>
[JsonConverter(typeof(IconConverter))]
public class Icon
{
    public Icon(string url)
    {
        Url = url;
    }

    public Icon(IconType type)
    {
        Type = type;
    }

    public string? Url { get; }
    public IconType? Type { get; }

	public static implicit operator Icon(string url)
	{
		return new Icon(url);
	}

	public static implicit operator Icon(IconType type)
	{
		return new Icon(type);
	}
}

public enum IconType
{
    Circle,
    Rect,
    RoundRect,
    Triangle,
    Diamond,
    Pin,
    Arrow,
    None
}


public class IconConverter : JsonConverter<Icon>
{
	private static readonly IconConverter instance = new();

	public override Icon Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for Icon.");
    }

    public override void Write(Utf8JsonWriter writer, Icon value, JsonSerializerOptions options)
    {
        if (value.Type != null)
        {
            writer.WriteStringValue(value.Type!.ToString()!.ToLower());
        }
        else if (value.Url != null)
        {
            writer.WriteStringValue(value.Url);
        }
    }

	public static IconConverter Instance => instance;
}