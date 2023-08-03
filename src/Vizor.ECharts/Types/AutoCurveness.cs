using System.Text.Json.Serialization;
using System.Text.Json;

namespace Vizor.ECharts;

/// <summary>
/// For the situation where there are multiple links between nodes, the curveness of each link is automatically calculated, not enabled by default.
/// See https://echarts.apache.org/en/option.html#series-graph.autoCurveness
/// </summary>
[JsonConverter(typeof(AutoCurvenessConverter))]
public class AutoCurveness
{
	/// <summary>
	/// When set true to enable automatic curvature calculation, the default edge curvenness array length is 20, if the number of edges between two nodes is more than 20, please use number or Array to set the edge curvenness array.
	/// </summary>
	/// <param name="b"></param>
	public AutoCurveness(bool b)
	{
		Bool = b;
	}

	/// <summary>
	/// When set to number, it indicates the length of the edge curvenness array between two nodes, and the calculation result is given by the internal algorithm.
	/// </summary>
	/// <param name="length"></param>
	public AutoCurveness(double length)
	{
		Length = length;
	}

	/// <summary>
	/// When set to Array, it means that the curveness array is directly specified, and the multilateral curveness is directly selected from the array.
	/// </summary>
	/// <param name="arr"></param>
	public AutoCurveness(double[] arr)
	{
		Array = arr;
	}

	public bool? Bool { get; }

	public double? Length { get; }
	public double[]? Array { get; }

	public static implicit operator AutoCurveness(bool b)
	{
		return new AutoCurveness(b);
	}

	public static implicit operator AutoCurveness(double length)
	{
		return new AutoCurveness(length);
	}

	public static implicit operator AutoCurveness(double[] arr)
	{
		return new AutoCurveness(arr);
	}
}

public class AutoCurvenessConverter : JsonConverter<AutoCurveness>
{
	public override AutoCurveness Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		throw new NotImplementedException("Deserialization is not implemented for AutoCurveness.");
	}

	public override void Write(Utf8JsonWriter writer, AutoCurveness value, JsonSerializerOptions options)
	{
		if (value.Bool != null)
		{
			writer.WriteBooleanValue(value.Bool.Value);
		}
		else if (value.Length != null)
		{
			writer.WriteNumberValue(value.Length.Value);
		}
		else if (value.Array != null)
		{
			writer.WriteStartArray();
			foreach (var val in value.Array)
				writer.WriteNumberValue(val);
			writer.WriteEndArray();
		}
	}
}