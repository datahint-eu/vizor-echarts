// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/

using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(InsideDataZoom), "inside")]
[JsonDerivedType(typeof(SliderDataZoom), "slider")]
public interface IDataZoom
{
}
