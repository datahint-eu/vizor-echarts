using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// Center position of Pie chart, the first of which is the horizontal position, and the second is the vertical position.
/// Percentage is supported.When set in percentage, the item is relative to the container width, and the second item to the height.
/// </summary>
[JsonConverter(typeof(BoundaryGapConverter))]
public class BoundaryGap
{
	public BoundaryGap(bool b)
	{
		Bool = b;
	}

	public BoundaryGap(NumberOrString min, NumberOrString max)
	{
		Min = min;
		Max = max;
	}

	public bool? Bool { get; }

	public NumberOrString? Min { get; }
	public NumberOrString? Max { get; }

	public static implicit operator BoundaryGap(bool b)
	{
		return new BoundaryGap(b);
	}
}

public class BoundaryGapConverter : JsonConverter<BoundaryGap>
{
	public override BoundaryGap Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for BoundaryGap.");
	}

	public override void Write(Utf8JsonWriter writer, BoundaryGap value, JsonSerializerOptions options)
	{
		if (value.Bool != null)
		{
			writer.WriteBooleanValue(value.Bool.Value);
		}
		else if (value.Min != null && value.Max != null)
		{
			writer.WriteStartArray();
			NumberOrStringConverter.Instance.Write(writer, value.Min, options);
			NumberOrStringConverter.Instance.Write(writer, value.Max, options);
			writer.WriteEndArray();
		}
	}
}