// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class OuterBounds
{
    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Distance between outerBounds and the left side of the container.
    ///  
    /// left can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
    ///  
    /// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
    /// ]]>
    /// </summary>
    [JsonPropertyName("left")]
    [DefaultValue(0)]
    public NumberOrString? Left { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Distance between outerBounds and the top side of the container.
    ///  
    /// top can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
    ///  
    /// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
    /// ]]>
    /// </summary>
    [JsonPropertyName("top")]
    [DefaultValue(0)]
    public NumberOrString? Top { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Distance between outerBounds and the right side of the container.
    ///  
    /// right can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    ///  
    /// Adaptive by default.
    /// ]]>
    /// </summary>
    [JsonPropertyName("right")]
    [DefaultValue(0)]
    public NumberOrString? Right { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Distance between outerBounds and the bottom side of the container.
    ///  
    /// bottom can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    ///  
    /// Adaptive by default.
    /// ]]>
    /// </summary>
    [JsonPropertyName("bottom")]
    [DefaultValue(0)]
    public NumberOrString? Bottom { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Width of outerBounds .
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
    /// Since v6.0.0   
    /// Height of outerBounds .
    /// Adaptive by default.
    ///  
    /// height can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("height")]
    [DefaultValue("auto")]
    public NumberOrString? Height { get; set; } 

}
