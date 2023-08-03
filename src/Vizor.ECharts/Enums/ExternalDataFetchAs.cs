using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<ExternalDataFetchAs>))]
public enum ExternalDataFetchAs
{
	Json,
	String
}
