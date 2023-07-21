using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

/// <summary>
/// See https://echarts.apache.org/en/option.html#legend.icon
/// </summary>
[JsonConverter(typeof(MultiIndexConverter))]
public class MultiIndex
{
	public MultiIndex(int index)
	{
		Indices = new int[] { index };
	}

	public MultiIndex(int[] indices)
	{
		Indices = indices;
	}

	public MultiIndex(MultiIndexType type)
	{
		Type = type;
	}

	public int[]? Indices { get; }
	public MultiIndexType? Type { get; }

	public static implicit operator MultiIndex(int index)
	{
		return new MultiIndex(index);
	}

	public static implicit operator MultiIndex(int[] indices)
	{
		return new MultiIndex(indices);
	}

	public static implicit operator MultiIndex(MultiIndexType type)
	{
		return new MultiIndex(type);
	}
}

public enum MultiIndexType
{
	All,
	None
}


public class MultiIndexConverter : JsonConverter<MultiIndex>
{
	public override MultiIndex Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for MultiIndex.");
	}

	public override void Write(Utf8JsonWriter writer, MultiIndex value, JsonSerializerOptions options)
	{
		if (value.Type != null)
		{
			writer.WriteStringValue(value.Type!.ToString()!.ToLower());
		}
		else if (value.Indices != null)
		{
			if (value.Indices.Length == 1)
			{
				writer.WriteNumberValue(value.Indices[0]);
			}
			else
			{
				writer.WriteStartArray();
				foreach (var val in value.Indices)
				{
					writer.WriteNumberValue(val);
				}
				writer.WriteEndArray();
			}
		}
	}
}