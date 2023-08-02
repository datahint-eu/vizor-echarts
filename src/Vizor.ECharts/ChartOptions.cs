using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class ChartOptions
{
	// see https://devblogs.microsoft.com/dotnet/try-the-new-system-text-json-source-generator/
	[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Default, PropertyNamingPolicy = JsonKnownNamingPolicy.CamelCase, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonSerializable(typeof(ChartOptions))]
	[JsonSerializable(typeof(XAxis))]
	[JsonSerializable(typeof(PieSeries))]
	[JsonSerializable(typeof(PieSeriesData))]
	[JsonSerializable(typeof(List<PieSeriesData>))]
	internal sealed partial class JsonContext : JsonSerializerContext
	{
	}

}
