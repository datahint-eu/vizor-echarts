using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// he size of each rect of calendar coordinates, can be set to a single value or array, the first element is width and the second element is height.
/// Support setting self-adaptation: auto, the default width and height to be 20.
/// </summary>
[JsonConverter(typeof(CellSizeConverter))]
public class CellSize
{
	public CellSize(NumberOrString widthAndHeight)
	{
		Width = widthAndHeight;
		Height = widthAndHeight;
	}

	public CellSize(NumberOrString width, NumberOrString height)
	{
		Width = width;
		Height = height;
	}

	public NumberOrString Width { get; }
	public NumberOrString Height { get; }

	public static implicit operator CellSize(NumberOrString widthAndHeight)
	{
		return new CellSize(widthAndHeight);
	}
}

public class CellSizeConverter : JsonConverter<CellSize>
{
	public override CellSize Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for CellSize.");
	}

	public override void Write(Utf8JsonWriter writer, CellSize value, JsonSerializerOptions options)
	{
		writer.WriteStartArray();
		NumberOrStringConverter.Instance.Write(writer, value.Width, options);
		NumberOrStringConverter.Instance.Write(writer, value.Height, options);
		writer.WriteEndArray();
	}
}