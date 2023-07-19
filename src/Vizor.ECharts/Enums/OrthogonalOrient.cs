using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(OrthogonalOrientConverter))]
public enum OrthogonalOrient
{
    LeftToRight,
    RightToLeft,
    TopToBottom,
    BottomToTop,

    Horizontal,
    Vertical
}

public class OrthogonalOrientConverter : JsonConverter<OrthogonalOrient>
{
    public override OrthogonalOrient Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for OrthogonalOrient.");
    }

    public override void Write(Utf8JsonWriter writer, OrthogonalOrient value, JsonSerializerOptions options)
    {
        writer.WriteStringValue(GetValue(value));
    }

    private static string GetValue(OrthogonalOrient value)
    {
        return value switch
        {
            OrthogonalOrient.LeftToRight or OrthogonalOrient.Horizontal => "LR",
            OrthogonalOrient.RightToLeft => "RL",
            OrthogonalOrient.TopToBottom or OrthogonalOrient.Vertical => "TB",
            OrthogonalOrient.BottomToTop => "BT",
            _ => "LR"
        };
    }
}