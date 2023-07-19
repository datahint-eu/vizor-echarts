using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(CamelCaseEnumConverter<ImageType>))]
public enum ImageType
{
	Png,
	Jpg
}
