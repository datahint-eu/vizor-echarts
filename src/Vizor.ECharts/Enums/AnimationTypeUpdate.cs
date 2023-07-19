using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<AnimationTypeUpdate>))]
public enum AnimationTypeUpdate
{
    Transition,
    Expansion
}