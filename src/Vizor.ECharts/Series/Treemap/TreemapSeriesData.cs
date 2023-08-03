
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class TreemapSeriesData
{
	/// <summary>
	/// The value of this node, indicating the area size.
	///  
	/// It could also be an array, such as [2323, 43, 55], in which the first item of array indicates the area size.
	///  
	/// The other items of the array can be used for extra visual mapping.
	/// See details in series-treemp.levels.
	/// </summary>
	[JsonPropertyName("value")]
	public NumberOrNumberArray? Value { get; set; } 

	/// <summary>
	/// id is not mandatory.
	/// But if using API, id is used to locate node.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; } 

	/// <summary>
	/// Show the description text in rectangle.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; } 

	/// <summary>
	/// treemap is able to map any dimensions of data to visual.
	///  
	/// The value of series-treemap.data can be an array.
	/// And each item of the array represents a "dimension".
	/// visualDimension specifies the dimension on which visual mapping will be performed.
	///  
	/// About visual encoding, see details in series-treemap.levels .
	///   
	/// Tps: In treemap, visualDimension attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
	///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
	///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
	/// </summary>
	[JsonPropertyName("visualDimension")]
	[DefaultValue(0)]
	public double? VisualDimension { get; set; } 

	/// <summary>
	/// The minimal value of current level.
	/// Auto-statistics by default.
	///  
	/// When colorMappingBy is set to 'value' , you are able to specify extent manually for visual mapping by specifying visualMin or visualMax .
	/// </summary>
	[JsonPropertyName("visualMin")]
	[DefaultValue("0")]
	public double? VisualMin { get; set; } 

	/// <summary>
	/// The maximal value of current level.
	/// Auto-statistics by default.
	///  
	/// When colorMappingBy is set to 'value' , you are able to specify extent manually for visual mapping by specifying visualMin or visualMax .
	/// </summary>
	[JsonPropertyName("visualMax")]
	[DefaultValue("100")]
	public double? VisualMax { get; set; } 

	/// <summary>
	/// A color list for a level.
	/// Each node in the level will obtain a color from the color list (the rule see colorMappingBy ).
	/// It is empty by default, which means the global color list will be used.
	///  
	/// About visual encoding, see details in series-treemap.levels .
	///   
	/// Tps: In treemap, color attribute could appear in more than one places:     It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
	///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
	/// </summary>
	[JsonPropertyName("color")]
	public Color[]? Color { get; set; } 

	/// <summary>
	/// It indicates the range of tranparent rate (color alpha) for nodes in a level  
	/// .
	/// The range of values is 0 ~ 1.
	///  
	/// For example, colorAlpha can be [0.3, 1] .
	///  
	/// About visual encoding, see details in series-treemap.levels .
	///   
	/// Tps: In treemap, colorAlpha attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
	///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
	///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
	/// </summary>
	[JsonPropertyName("colorAlpha")]
	public double[]? ColorAlpha { get; set; } 

	/// <summary>
	/// It indicates the range of saturation (color alpha) for nodes in a level.
	///  
	/// The range of values is 0 ~ 1.
	///  
	/// For example, colorSaturation can be [0.3, 1] .
	///  
	/// About visual encoding, see details in series-treemap.levels .
	///   
	/// Tps: In treemap, colorSaturation attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
	///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
	///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
	/// </summary>
	[JsonPropertyName("colorSaturation")]
	public double? ColorSaturation { get; set; } 

	/// <summary>
	/// Specify the rule according to which each node obtain color from color list .
	/// Optional values:   'value' :   
	/// Map series-treemap.data.value to color.
	///  
	/// In this way, the color of each node indicate its value.
	///  
	/// visualDimension can be used to specify which dimension of data is used to perform visual mapping.
	///   'index' :   
	/// Map the index (ordinal number) of nodes to color.
	/// Namely, in a level, the first node is mapped to the first color of color list , and the second node gets the second color.
	///  
	/// In this way, adjacent nodes are distinguished by color.
	///   'id' :   
	/// Map series-treemap.data.id to color.
	///  
	/// Since id is used to identify node, if user call setOption to modify the tree, each node will remain the original color before and after setOption called.
	/// See this example .
	///  
	/// About visual encoding, see details in series-treemap.levels .
	///   
	/// Tps: In treemap, colorMappingBy attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
	///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
	///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
	/// </summary>
	[JsonPropertyName("colorMappingBy")]
	[DefaultValue("index")]
	public ColorMappingBy? ColorMappingBy { get; set; } 

	/// <summary>
	/// A node will not be shown when its area size is smaller than this value (unit: px square).
	///  
	/// In this way, tiny nodes will be hidden, otherwise they will huddle together.
	/// When user zoom the treemap, the area size will increase and the rectangle will be shown if the area size is larger than this threshold.
	///  
	/// About visual encoding, see details in series-treemap.levels .
	///   
	/// Tps: In treemap, visibleMin attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
	///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
	///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
	/// </summary>
	[JsonPropertyName("visibleMin")]
	[DefaultValue("10")]
	public double? VisibleMin { get; set; } 

	/// <summary>
	/// Children will not be shown when area size of a node is smaller than this value (unit: px square).
	///  
	/// This can hide the details of nodes when the rectangular area is not large enough.
	/// When users zoom nodes, the child node would show if the area is larger than this threshold.
	///  
	/// About visual encoding, see details in series-treemap.levels .
	///   
	/// Tps: In treemap, childrenVisibleMin attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
	///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
	///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
	/// </summary>
	[JsonPropertyName("childrenVisibleMin")]
	[DefaultValue("10")]
	public double? ChildrenVisibleMin { get; set; } 

	/// <summary>
	/// label decribes the style of the label in each node.
	///   
	/// Tps: In treemap, label attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
	///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
	///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// upperLabel is used to specify whether show label when the node has children.
	/// When upperLabel.show is set as true , the feature that "show parent label" is enabled.
	///  
	/// The same as series-treemap.label , the option upperLabel can be placed at the root of series-treemap directly, or in series-treemap.level , or in each item of series-treemap.data .
	///  
	/// Specifically, series-treemap.label specifies the style when a node is a leaf, while upperLabel specifies the style when a node has children, in which case the label is displayed in the inner top of the node.
	///  
	/// See:    
	/// Tps: In treemap, label attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
	///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
	///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
	/// </summary>
	[JsonPropertyName("upperLabel")]
	public UpperLabel? UpperLabel { get; set; } 

	/// <summary>
	/// Tps: In treemap, itemStyle attribute could appear in more than one places:     It could appear in sereis-treemap , indicating the unified setting of the series.
	///      It could appear in each array element of series-treemap.levels , indicating the unified setting of each level of the tree.
	///      It could appear in each node of series-treemap.data , indicating the particular setting of each node.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// Emphasis state.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Blur state.
	/// </summary>
	[JsonPropertyName("blur")]
	public Blur? Blur { get; set; } 

	/// <summary>
	/// Since v5.0.0   
	/// Select state.
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; } 

	/// <summary>
	/// Enable hyperlink jump when clicking on node.
	/// It is avaliable when series-treemap.nodeClick is 'link' .
	///  
	/// See series-treemap.data.target .
	/// </summary>
	[JsonPropertyName("link")]
	public string? Link { get; set; } 

	/// <summary>
	/// The same meaning as target in html  <a> label, See series-treemap.data.link .
	/// Option values are: 'blank' or 'self' .
	/// </summary>
	[JsonPropertyName("target")]
	[DefaultValue("blank")]
	public string? Target { get; set; } 

	/// <summary>
	/// child nodes, recursive definition, configurations are the same as series-treemap.data .
	/// </summary>
	[JsonPropertyName("children")]
	//TODO: Type Warning: array type 'children' in 'TreemapSeriesData' will be mapped to List<object>
	public List<object>? Children { get; set; } 

	/// <summary>
	/// tooltip settings in this series data.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

}
