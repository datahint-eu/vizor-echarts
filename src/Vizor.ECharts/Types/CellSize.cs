using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// The size of each rect of calendar coordinates, can be set to a single value or array, the first element is width and the second element is height.
/// Support setting self-adaptation: auto, the default width and height to be 20.
/// ECharts examples: cellSize: 20 | cellSize: [20, 40] | cellSize: ['auto', 40] | cellSize: 'auto'
/// </summary>
[JsonConverter(typeof(CellSizeConverter))]
public record CellSize(NumberOrString Width, NumberOrString Height)
{
    /// <summary>
    /// Initialize with same value for both width and height.
    /// </summary>
    public CellSize(NumberOrString both) : this(both, both) { }

    /// <summary>
    /// Allow implicit conversion from single NumberOrString to CellSize (applies to both dimensions).
    /// </summary>
    public static implicit operator CellSize(NumberOrString widthAndHeight)
    {
        return new CellSize(widthAndHeight);
    }

    /// <summary>
    /// Allow implicit conversion to NumberOrNumberArray for properties expecting array-like dimensions.
    /// </summary>
    public static implicit operator NumberOrNumberArray(CellSize cellSize)
    {
        return new NumberOrNumberArray(new NumberOrString[] { cellSize.Width, cellSize.Height });
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