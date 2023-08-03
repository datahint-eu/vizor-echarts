namespace Vizor.ECharts;

/// <summary>
/// See https://echarts.apache.org/en/api.html#echarts.registerMap
/// </summary>
public interface IMapDefinition
{
	string Type { get; }

	string Name { get; set; }
}
