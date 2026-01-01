// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class MapSeriesData
{
    /// <summary>
    /// <![CDATA[
    /// The name of the map area where the data belongs to, such as 'China' or 'United Kingdom' .
    /// ]]>
    /// </summary>
    [JsonPropertyName("name")]
    public string? Name { get; set; } 

    /// <summary>
    /// The numerical value of this area.
    /// </summary>
    [JsonPropertyName("value")]
    public double? Value { get; set; } 

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
    /// Whether the are selected.
    /// </summary>
    [JsonPropertyName("selected")]
    [DefaultValue(false)]
    public bool? Selected { get; set; } 

    /// <summary>
    /// Since v5.6.0   
    /// Whether to ignore mouse events.
    /// Default value is false, for triggering and responding to mouse events.
    /// </summary>
    [JsonPropertyName("silent")]
    [DefaultValue(false)]
    public bool? Silent { get; set; } 

    /// <summary>
    /// Style of item polygon
    /// </summary>
    [JsonPropertyName("itemStyle")]
    public ItemStyle? ItemStyle { get; set; } 

    /// <summary>
    /// Text label of , to explain some data information about graphic item like value, name and so on.
    /// label is placed under itemStyle in ECharts 2.x.
    /// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
    /// </summary>
    [JsonPropertyName("label")]
    public Label? Label { get; set; } 

    /// <summary>
    /// Since v5.0.0   
    /// Configuration of label guide line.
    /// </summary>
    [JsonPropertyName("labelLine")]
    public LabelLine? LabelLine { get; set; } 

    /// <summary>
    /// Emphasis state of specified region.
    /// </summary>
    [JsonPropertyName("emphasis")]
    public Emphasis? Emphasis { get; set; } 

    /// <summary>
    /// Select state of polygon.
    /// </summary>
    [JsonPropertyName("select")]
    public Select? Select { get; set; } 

    /// <summary>
    /// tooltip settings in this series data.
    /// </summary>
    [JsonPropertyName("tooltip")]
    public Tooltip? Tooltip { get; set; } 

}
