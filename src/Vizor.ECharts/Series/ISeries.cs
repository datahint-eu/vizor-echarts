using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
[JsonDerivedType(typeof(BarSeries), "bar")]
[JsonDerivedType(typeof(LineSeries), "line")]
[JsonDerivedType(typeof(PieSeries), "pie")]
[JsonDerivedType(typeof(ScatterSeries), "scatter")]
[JsonDerivedType(typeof(EffectScatterSeries), "effectScatter")]
[JsonDerivedType(typeof(RadarSeries), "radar")]
[JsonDerivedType(typeof(TreeSeries), "tree")]
[JsonDerivedType(typeof(TreemapSeries), "treemap")]
[JsonDerivedType(typeof(SunburstSeries), "sunburst")]
[JsonDerivedType(typeof(BoxplotSeries), "boxplot")]
[JsonDerivedType(typeof(CandlestickSeries), "candlestick")]
[JsonDerivedType(typeof(HeatmapSeries), "heatmap")]
[JsonDerivedType(typeof(MapSeries), "map")]
[JsonDerivedType(typeof(ParallelSeries), "parallel")]
[JsonDerivedType(typeof(LinesSeries), "lines")]
[JsonDerivedType(typeof(GraphSeries), "graph")]
[JsonDerivedType(typeof(SankeySeries), "sankey")]
[JsonDerivedType(typeof(FunnelSeries), "funnel")]
[JsonDerivedType(typeof(GaugeSeries), "gauge")]
[JsonDerivedType(typeof(PictorialBarSeries), "pictorialBar")]
[JsonDerivedType(typeof(ThemeRiverSeries), "themeRiver")]
[JsonDerivedType(typeof(CustomSeries), "custom")]
public interface ISeries
{
}
