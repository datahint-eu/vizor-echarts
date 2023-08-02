
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class TreeSeriesData
{
    /// <summary>
    /// The name of the tree node, used to identify each node.
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    /// <summary>
    /// The value of the node, displayed in the tooltip.
    /// </summary>
    [JsonPropertyName("value")]
    public double? Value { get; set; }

    /// <summary>
    /// Whether to collapse node at initialization.
    /// </summary>
    [JsonPropertyName("collapsed")]
    public bool? Collapsed { get; set; }

    /// <summary>
    /// The style of the node.
    /// </summary>
    [JsonPropertyName("itemStyle")]
    public ItemStyle? ItemStyle { get; set; }

    /// <summary>
    /// Defines the style of the tree edge.
    /// </summary>
    [JsonPropertyName("lineStyle")]
    public LineStyle? LineStyle { get; set; }

    /// <summary>
    /// The label of the node.
    /// </summary>
    [JsonPropertyName("label")]
    public Label? Label { get; set; }

    /// <summary>
    /// Emphasis state of a single node.
    /// </summary>
    [JsonPropertyName("emphasis")]
    public Emphasis? Emphasis { get; set; }

    /// <summary>
    /// Since v5.0.0   
    /// Blur state of a single node.
    /// </summary>
    [JsonPropertyName("blur")]
    public Blur? Blur { get; set; }

    /// <summary>
    /// Since v5.0.0   
    /// Select state of a single node.
    /// </summary>
    [JsonPropertyName("select")]
    public Select? Select { get; set; }

    /// <summary>
    /// tooltip settings in this series data.
    /// </summary>
    [JsonPropertyName("tooltip")]
    public Tooltip? Tooltip { get; set; }

    /// <summary>
    /// Whether to enable animation.
    /// </summary>
    [JsonPropertyName("animation")]
    [DefaultValue("true")]
    public bool? Animation { get; set; }

    /// <summary>
    /// Whether to set graphic number threshold to animation.
    /// Animation will be disabled when graphic number is larger than threshold.
    /// </summary>
    [JsonPropertyName("animationThreshold")]
    [DefaultValue(2000)]
    public double? AnimationThreshold { get; set; }

    /// <summary>
    /// Duration of the first animation, which supports callback function for different data to have different animation effect:  animationDuration: function (idx) {
    ///     // delay for later data is larger
    ///     return idx * 100;
    /// }
    /// </summary>
    [JsonPropertyName("animationDuration")]
    [DefaultValue("1000")]
    public NumberOrFunction? AnimationDuration { get; set; }

    /// <summary>
    /// Easing method used for the first animation.
    /// Varied easing effects can be found at easing effect example .
    /// </summary>
    [JsonPropertyName("animationEasing")]
    [DefaultValue("linear")]
    public AnimationEasing? AnimationEasing { get; set; }

    /// <summary>
    /// Delay before updating the first animation, which supports callback function for different data to have different animation effect.
    ///  
    /// For example:  animationDelay: function (idx) {
    ///     // delay for later data is larger
    ///     return idx * 100;
    /// }  
    /// See this example for more information.
    /// </summary>
    [JsonPropertyName("animationDelay")]
    [DefaultValue(0)]
    public NumberOrFunction? AnimationDelay { get; set; }

    /// <summary>
    /// Time for animation to complete, which supports callback function for different data to have different animation effect:  animationDurationUpdate: function (idx) {
    ///     // delay for later data is larger
    ///     return idx * 100;
    /// }
    /// </summary>
    [JsonPropertyName("animationDurationUpdate")]
    [DefaultValue("1000")]
    public NumberOrFunction? AnimationDurationUpdate { get; set; }

    /// <summary>
    /// Easing method used for animation.
    /// </summary>
    [JsonPropertyName("animationEasingUpdate")]
    [DefaultValue("cubicOut")]
    public AnimationEasing? AnimationEasingUpdate { get; set; }

    /// <summary>
    /// Delay before updating animation, which supports callback function for different data to have different animation effects.
    ///  
    /// For example:  animationDelayUpdate: function (idx) {
    ///     // delay for later data is larger
    ///     return idx * 100;
    /// }  
    /// See this example for more information.
    /// </summary>
    [JsonPropertyName("animationDelayUpdate")]
    [DefaultValue(0)]
    public NumberOrFunction? AnimationDelayUpdate { get; set; }

}
