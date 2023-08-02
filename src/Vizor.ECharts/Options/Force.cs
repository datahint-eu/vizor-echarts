
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Force
{
	/// <summary>
	/// The initial layout before force-directed layout, which will influence on the result of force-directed layout.
	///  
	/// It defaults not to do any layout and use x , y provided in node as the position of node.
	/// If it doesn't exist, the position will be generated randomly.
	///  
	/// You can also use circular layout 'circular' .
	/// </summary>
	[JsonPropertyName("initLayout")]
	public string? InitLayout { get; set; } 

	/// <summary>
	/// The repulsion factor between nodes.
	/// The repulsion will be stronger and the distance between 2 nodes becomes further as this value becomes larger.
	///  
	/// It can be an array to represent the range of repulsion.
	/// In this case larger value have larger repulsion and smaller value will have smaller repulsion.
	/// </summary>
	[JsonPropertyName("repulsion")]
	[DefaultValue("50")]
	public NumberOrNumberArray? Repulsion { get; set; } 

	/// <summary>
	/// The gravity factor enforcing nodes approach to the center.
	/// The nodes will be closer to the center as the value becomes larger.
	/// </summary>
	[JsonPropertyName("gravity")]
	[DefaultValue("0.1")]
	public double? Gravity { get; set; } 

	/// <summary>
	/// The distance between 2 nodes on edge.
	/// This distance is also affected by repulsion .
	///  
	/// It can be an array to represent the range of edge length.
	/// In this case edge with larger value will be shorter, which means two nodes are closer.
	/// And edge with smaller value will be longer.
	/// </summary>
	[JsonPropertyName("edgeLength")]
	[DefaultValue("30")]
	public NumberOrNumberArray? EdgeLength { get; set; } 

	/// <summary>
	/// Because the force-directed layout will be steady after several iterations, this parameter will be decide whether to show the iteration animation of layout.
	/// It is not recommended to be closed on browser when there are a lot of node data (>100) as the layout process will cause browser to hang.
	/// </summary>
	[JsonPropertyName("layoutAnimation")]
	[DefaultValue("true")]
	public bool? LayoutAnimation { get; set; } 

	/// <summary>
	/// Since v4.5.0   
	/// It will slow down the nodes' movement.
	/// The value range is from 0 to 1.
	///  
	/// But it is still an experimental option, see #11024 .
	/// </summary>
	[JsonPropertyName("friction")]
	[DefaultValue("0.6")]
	public double? Friction { get; set; } 

}
