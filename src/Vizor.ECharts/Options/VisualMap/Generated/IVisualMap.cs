// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/

using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(ContinuousVisualMap), "continuous")]
[JsonDerivedType(typeof(PiecewiseVisualMap), "piecewise")]
public interface IVisualMap
{
}
