using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

/// <summary>
/// Radius of Pie chart. Value can be:
/// number: Specify outside radius directly.
/// string: For example, '20%', means that the outside radius is 20% of the viewport size (the little one between width and height of the chart container).
/// Array.<number|string>: The first item specifies the inside radius, and the second item specifies the outside radius.Each item follows the definitions above.
/// Donut chart can be achieved by setting a inner radius.
/// </summary>
[JsonConverter(typeof(PieRadiusConverter))]
public class PieRadius
{
    public PieRadius(NumberOrString outsideRadius)
    {
        OutsideRadius = outsideRadius;
    }

    public PieRadius(NumberOrString insideRadius, NumberOrString outsideRadius)
    {
        InsideRadius = insideRadius;
        OutsideRadius = outsideRadius;
    }

    public NumberOrString OutsideRadius { get; }
    public NumberOrString? InsideRadius { get; }
}

public class PieRadiusConverter : JsonConverter<PieRadius>
{
    public override PieRadius Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for PieRadius.");
    }

    public override void Write(Utf8JsonWriter writer, PieRadius value, JsonSerializerOptions options)
    {
        if (value.InsideRadius == null)
        {
            NumberOrStringConverter.Instance.Write(writer, value.OutsideRadius, options);
        }
        else
        {
            writer.WriteStartArray();
            NumberOrStringConverter.Instance.Write(writer, value.InsideRadius, options);
            NumberOrStringConverter.Instance.Write(writer, value.OutsideRadius, options);
            writer.WriteEndArray();
        }
    }
}