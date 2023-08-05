using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<ExternalDataFetchAs>))]
public enum ExternalDataFetchAs
{
	Json,
	String
}
