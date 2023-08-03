using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(PictorialSymbolRepeatConverter))]
public class PictorialSymbolRepeat
{
	public PictorialSymbolRepeat(double number)
	{
		Number = number;
	}

	public PictorialSymbolRepeat(PictorialSymbolRepeatType repeatType)
	{
		RepeatType = repeatType;
	}

	public double? Number { get; }
	public PictorialSymbolRepeatType? RepeatType { get; }

	public static implicit operator PictorialSymbolRepeat(double number)
	{
		return new PictorialSymbolRepeat(number);
	}

	public static implicit operator PictorialSymbolRepeat(PictorialSymbolRepeatType type)
	{
		return new PictorialSymbolRepeat(type);
	}
}

public enum PictorialSymbolRepeatType
{
	True,
	False,
	Fixed
}


public class PictorialSymbolRepeatConverter : JsonConverter<PictorialSymbolRepeat>
{
	public override PictorialSymbolRepeat Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for PictorialSymbolRepeat.");
	}

	public override void Write(Utf8JsonWriter writer, PictorialSymbolRepeat value, JsonSerializerOptions options)
	{
		if (value.RepeatType != null)
		{
			switch (value.RepeatType.Value)
			{
				case PictorialSymbolRepeatType.True:
					writer.WriteBooleanValue(true);
					break;
				case PictorialSymbolRepeatType.False:
					writer.WriteBooleanValue(false);
					break;
				default:
					writer.WriteStringValue(value.RepeatType!.ToString()!.ToLower());
					break;
			}
		}
		else if (value.Number != null)
		{
			writer.WriteNumberValue(value.Number.Value);
		}
	}
}