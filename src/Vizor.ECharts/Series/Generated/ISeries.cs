// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/

using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(BarSeries), "bar")]
[JsonDerivedType(typeof(BoxplotSeries), "boxplot")]
[JsonDerivedType(typeof(CandlestickSeries), "candlestick")]
[JsonDerivedType(typeof(CustomSeries), "custom")]
[JsonDerivedType(typeof(EffectScatterSeries), "effectScatter")]
[JsonDerivedType(typeof(FunnelSeries), "funnel")]
[JsonDerivedType(typeof(GaugeSeries), "gauge")]
[JsonDerivedType(typeof(GraphSeries), "graph")]
[JsonDerivedType(typeof(HeatmapSeries), "heatmap")]
[JsonDerivedType(typeof(LineSeries), "line")]
[JsonDerivedType(typeof(LinesSeries), "lines")]
[JsonDerivedType(typeof(MapSeries), "map")]
[JsonDerivedType(typeof(ParallelSeries), "parallel")]
[JsonDerivedType(typeof(PictorialBarSeries), "pictorialBar")]
[JsonDerivedType(typeof(PieSeries), "pie")]
[JsonDerivedType(typeof(RadarSeries), "radar")]
[JsonDerivedType(typeof(SankeySeries), "sankey")]
[JsonDerivedType(typeof(ScatterSeries), "scatter")]
[JsonDerivedType(typeof(SunburstSeries), "sunburst")]
[JsonDerivedType(typeof(ThemeRiverSeries), "themeRiver")]
[JsonDerivedType(typeof(TreemapSeries), "treemap")]
[JsonDerivedType(typeof(TreeSeries), "tree")]
public interface ISeries
{
}
