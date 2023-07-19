using System.Text.Json.Serialization;

namespace Vizor.ECharts.Enums;

[JsonConverter(typeof(CamelCaseEnumConverter<ImageType>))]
public enum ImageType
{
	Png,
	Jpg
}
