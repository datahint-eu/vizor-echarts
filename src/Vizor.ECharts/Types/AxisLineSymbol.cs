using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Center position of Pie chart, the first of which is the horizontal position, and the second is the vertical position.
/// Percentage is supported.When set in percentage, the item is relative to the container width, and the second item to the height.
/// </summary>
[JsonConverter(typeof(AxisLineSymbol))]
public class AxisLineSymbol
{
	public AxisLineSymbol(Icon both)
	{
		Start = both;
		End = both;
		AreSame = true;
	}

	public AxisLineSymbol(Icon start, Icon end)
	{
		Start = start;
		End = end;
		AreSame = false;
	}

	public Icon Start { get; }
	public Icon End { get; }

	internal bool AreSame { get; }
}

public class AxisLineSymbolConverter : JsonConverter<AxisLineSymbol>
{
	public override AxisLineSymbol Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for AxisLineSymbol.");
	}

	public override void Write(Utf8JsonWriter writer, AxisLineSymbol value, JsonSerializerOptions options)
	{
		if (value.AreSame)
		{
			IconConverter.Instance.Write(writer, value.Start, options);
		}
		else
		{
			writer.WriteStartArray();
			IconConverter.Instance.Write(writer, value.Start, options);
			IconConverter.Instance.Write(writer, value.End, options);
			writer.WriteEndArray();
		}
	}
}