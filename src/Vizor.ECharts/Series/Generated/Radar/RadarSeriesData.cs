// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class RadarSeriesData
{
    /// <summary>
    /// Data item name
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; } 

    /// <summary>
    /// Numerical value of a single data item.
    /// </summary>
    [JsonPropertyName("value")]
    public object? Value { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// The group ID of a data item.
    /// When universalTransition is enabled, the data items from the old option and those from the new one, if sharing a same group ID, will then be matched and applied to a proper animation after setOption is called.
    ///  
    /// If a data item is not specified with a groupId , Apache ECharts will try to use series.dataGroupId as the group ID for the data item.
    /// If series.dataGroupId is not specified either, Apache ECharts will fall back to using the data item's ID as its group ID.
    ///  
    /// If you are using the dataset component to represent data, you are recommended to use encode.itemGroupId to specify the dimension that is to be encoded as the group ID.
    /// ]]>
    /// </summary>
    [JsonPropertyName("groupId")]
    public string? GroupId { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v5.5.0   
    /// The group ID of the child data of a data item.
    /// This option is introduced to make multiple levels drilldown and aggregation animation possilbe.
    ///   
    /// Before childGroupId is introduced, developers actually can use groupId to make drilldown and aggregation animation already, but with the limit on the times that a continious drilldown or aggregation can happen, which is only one time.
    ///  
    /// childGroupId , together with groupId , help to form "parent-child" relationships between data items of different options, such as:  data: [                        data: [                        data: [
    ///   {                              {                              {
    ///     name: 'Animals',               name: 'Dogs',                  name: 'Corgi',
    ///     value: 3,                      value: 3,                      value: 5,
    ///     groupId: 'things',             groupId: 'animals',            groupId: 'dogs'
    ///     childGroupId: 'animals'        childGroupId: 'dogs'         },
    ///   },                             },                             {
    ///   {                              {                                name: 'Bulldog',
    ///     name: 'Fruits',                name: 'Cats',                  value: 6,
    ///     value: 3,                      value: 4,                      groupId: 'dogs'
    ///     groupId: 'things',             groupId: 'animals',          },
    ///     childGroupId: 'fruits'         childGroupId: 'cats',        {
    ///   },                             },                               name: 'Shiba Inu',
    ///   {                              {                                value: 7,
    ///     name: 'Cars',                  name: 'Birds',                 groupId: 'dogs'
    ///     value: 2,                      value: 3,                    }
    ///     groupId: 'things',             groupId: 'animals',        ]
    ///     childGroupId: 'cars'           childGroupId: 'birds'
    ///   }                              }
    /// ]                              ]  
    /// The 3 groups of data above come from 3 options, and by specifying groupId and childGroupId for the data items a relationship of "parent-child-grandChild" is formed in the 3 options.
    /// In this way,  after setOption is called, Apache ECharts will try to find the "parent-child" or "child-parent" relationship of the old option and the new one.
    /// If the relationship exists, the matching data items will be applied to a drilldown animation or an aggregation one.
    ///  
    /// If a data item has no child data then there is no need to specify a childGroupId at all.
    ///  
    /// If you are using the dataset component to represent data, you are recommended to use encode.itemChildGroupId to specify the dimension that is to be encoded as the child group ID.
    /// ]]>
    /// </summary>
    [JsonPropertyName("childGroupId")]
    public string? ChildGroupId { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Symbol of single data.
    ///  
    /// Icon types provided by ECharts includes  
    /// 'circle' , 'rect' , 'roundRect' , 'triangle' , 'diamond' , 'pin' , 'arrow' , 'none'  
    /// It can be set to an image with 'image://url' , in which URL is the link to an image, or dataURI of an image.
    ///  
    /// An image URL example:  'image://http://example.website/a/b.png' 
    /// A dataURI example:  'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7' 
    /// Icons can be set to arbitrary vector path via 'path://' in ECharts.
    /// As compared with a raster image, vector paths prevent jagging and blurring when scaled, and have better control over changing colors.
    /// The size of the vector icon will be adapted automatically.
    /// Refer to SVG PathData for more information about the format of the path.
    /// You may export vector paths from tools like Adobe  
    /// For example:  'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z'
    /// ]]>
    /// </summary>
    [JsonPropertyName("symbol")]
    [DefaultValue("circle")]
    public Icon? Symbol { get; set; } 

    /// <summary>
    /// single data symbol size.
    /// It can be set to single numbers like 10 , or use an array to represent width and height.
    /// For example, [20, 10] means symbol width is 20 , and height is 10 .
    /// </summary>
    [JsonPropertyName("symbolSize")]
    [DefaultValue(4)]
    public NumberOrNumberArray? SymbolSize { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Rotate degree of single data symbol.
    /// The negative value represents clockwise.
    /// Note that when symbol is set to be 'arrow' in markLine , symbolRotate value will be ignored, and compulsively use tangent angle.
    /// ]]>
    /// </summary>
    [JsonPropertyName("symbolRotate")]
    public double? SymbolRotate { get; set; } 

    /// <summary>
    /// Whether to keep aspect for symbols in the form of path:// .
    /// </summary>
    [JsonPropertyName("symbolKeepAspect")]
    [DefaultValue(false)]
    public bool? SymbolKeepAspect { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Offset of single data symbol relative to original position.
    /// By default, symbol will be put in the center position of data.
    /// But if symbol is from user-defined vector path or image, you may not expect symbol to be in center.
    /// In this case, you may use this attribute to set offset to default position.
    /// It can be in absolute pixel value, or in relative percentage value.
    ///  
    /// For example, [0, '-50%'] means to move upside side position of symbol height.
    /// It can be used to make the arrow in the bottom to be at data position when symbol is pin.
    /// ]]>
    /// </summary>
    [JsonPropertyName("symbolOffset")]
    [DefaultValue("[0, 0]")]
    public NumberOrNumberArray? SymbolOffset { get; set; } 

    /// <summary>
    /// Style setting of the text on single inflection point.
    /// </summary>
    [JsonPropertyName("label")]
    public Label? Label { get; set; } 

    /// <summary>
    /// Style setting of the symbol on single inflection point.
    /// </summary>
    [JsonPropertyName("itemStyle")]
    public ItemStyle? ItemStyle { get; set; } 

    /// <summary>
    /// Line style of a single item.
    /// </summary>
    [JsonPropertyName("lineStyle")]
    public LineStyle? LineStyle { get; set; } 

    /// <summary>
    /// Area filling style of a single item.
    /// </summary>
    [JsonPropertyName("areaStyle")]
    public AreaStyle? AreaStyle { get; set; } 

    /// <summary>
    /// Configurations of emphasis state.
    /// </summary>
    [JsonPropertyName("emphasis")]
    public Emphasis? Emphasis { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// Configurations of blur state.
    /// </summary>
    [JsonPropertyName("blur")]
    public Blur? Blur { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// Configurations of selected state.
    /// </summary>
    [JsonPropertyName("select")]
    public Select? Select { get; set; } 

    /// <summary>
    /// tooltip settings in this series data.
    /// </summary>
    [JsonPropertyName("tooltip")]
    public Tooltip? Tooltip { get; set; } 

}
