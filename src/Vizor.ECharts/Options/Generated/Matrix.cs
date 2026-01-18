// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Matrix
{
    /// <summary>
    /// Component ID, not specified by default.
    /// If specified, it can be used to refer the component in option or API.
    /// </summary>
    [JsonPropertyName("id")]
    public string? Id { get; set; } 

    /// <summary>
    /// zlevel value of all graphical elements in .
    ///  
    /// zlevel is used to make layers with Canvas.
    /// Graphical elements with different zlevel values will be placed in different Canvases, which is a common optimization technique.
    /// We can put those frequently changed elements (like those with animations) to a separate zlevel .
    /// Notice that too many Canvases will increase memory cost, and should be used carefully on mobile phones to avoid crash.
    ///  
    /// Canvases with bigger zlevel will be placed on Canvases with smaller zlevel .
    /// </summary>
    [JsonPropertyName("zlevel")]
    [DefaultValue(0)]
    public double? Zlevel { get; set; } 

    /// <summary>
    /// z value of all graphical elements in , which controls order of drawing graphical components.
    /// Components with smaller z values may be overwritten by those with larger z values.
    ///  
    /// z has a lower priority to zlevel , and will not create new Canvas.
    /// </summary>
    [JsonPropertyName("z")]
    [DefaultValue(2)]
    public double? Z { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between undefined component and the left side of the container.
    ///  
    /// left can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
    ///  
    /// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
    /// ]]>
    /// </summary>
    [JsonPropertyName("left")]
    [DefaultValue("10%")]
    public NumberOrString? Left { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between undefined component and the top side of the container.
    ///  
    /// top can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
    ///  
    /// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
    /// ]]>
    /// </summary>
    [JsonPropertyName("top")]
    [DefaultValue("10%")]
    public NumberOrString? Top { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between undefined component and the right side of the container.
    ///  
    /// right can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    ///  
    /// Adaptive by default.
    /// ]]>
    /// </summary>
    [JsonPropertyName("right")]
    [DefaultValue("auto")]
    public NumberOrString? Right { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between undefined component and the bottom side of the container.
    ///  
    /// bottom can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    ///  
    /// Adaptive by default.
    /// ]]>
    /// </summary>
    [JsonPropertyName("bottom")]
    [DefaultValue("auto")]
    public NumberOrString? Bottom { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Width of matrix component.
    /// Adaptive by default.
    ///  
    /// width can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("width")]
    [DefaultValue("auto")]
    public NumberOrString? Width { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Height of matrix component.
    /// Adaptive by default.
    ///  
    /// height can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("height")]
    [DefaultValue("auto")]
    public NumberOrString? Height { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// X-axis header region.
    /// </summary>
    [JsonPropertyName("x")]
    public X? X { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// Y-axis header region.
    /// </summary>
    [JsonPropertyName("y")]
    public Y? Y { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// Body cells, which are the ones except header cells.
    /// </summary>
    [JsonPropertyName("body")]
    public Body? Body { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// Corner cells, which are the one at the intersection of x and y-axis.
    /// </summary>
    [JsonPropertyName("corner")]
    public Corner? Corner { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// The style of the entire matrix area.
    /// </summary>
    [JsonPropertyName("backgroundStyle")]
    public BackgroundStyle? BackgroundStyle { get; set; } 

    /// <summary>
    /// The secondary z-index of the outer border and the divider line.
    /// </summary>
    [JsonPropertyName("borderZ2")]
    public double? BorderZ2 { get; set; } 

    /// <summary>
    /// The tooltip for cells, follow the same option as tooltip .
    /// Disabled by default.
    /// We can enable tooltip if the text is overflow a cell boundary and truncated.
    ///  matrix: {
    ///     tooltip: {
    ///         show: true
    ///     },
    ///     // ...
    /// }
    /// </summary>
    [JsonPropertyName("tooltip")]
    public Tooltip? Tooltip { get; set; } 

}
