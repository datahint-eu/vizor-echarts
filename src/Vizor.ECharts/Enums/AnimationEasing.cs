using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

/// <summary>
/// See https://echarts.apache.org/examples/en/editor.html?c=line-easing
/// </summary>
[JsonConverter(typeof(AnimationEasingConverter))]
public enum AnimationEasing
{
    Linear,
    QuadraticIn,
    QuadraticOut,
    QuadraticInOut,
    CubicIn,
    CubicOut,
    CubicInOut,
    QuarticIn,
    QuarticOut,
    QuarticInOut,
    QuinticIn,
    QuinticOut,
    QuinticInOut,
    SinusoidalIn,
    SinusoidalOut,
    SinusoidalInOut,
    ExponentialIn,
    ExponentialOut,
    ExponentialInOut,
    CircularIn,
    CircularOut,
    CircularInOut,
    ElasticIn,
    ElasticOut,
    ElasticInOut,
    BackIn,
    BackOut,
    BackInOut,
    BounceIn,
    BounceOut,
    BounceInOut
}

public class AnimationEasingConverter : JsonConverter<AnimationEasing>
{
    public override AnimationEasing Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for AnimationEasing.");
    }

    public override void Write(Utf8JsonWriter writer, AnimationEasing value, JsonSerializerOptions options)
    {
        var str = value.ToString();
        writer.WriteStringValue(char.ToLower(str[0]) + str[1..]);
    }
}