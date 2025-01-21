
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class ThemeRiverSeries : ISeries
{
	[JsonPropertyName("type")]
	public string Type => "themeRiver";

	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	/// <summary>
	/// Series name used for displaying in tooltip and filtering with legend , or updating data and configuration with setOption .
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// Since v5.2.0   
	/// The policy to take color from option.color .
	/// Valid values:   'series' : assigns the colors in the palette by series, so that all data in the same series are in the same color;  'data' : assigns colors in the palette according to data items, with each data item using a different color.
	/// </summary>
	[JsonPropertyName("colorBy")]
	[DefaultValue("data")]
	public ColorBy? ColorBy { get; set; }

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
	/// Distance between thmemRiver component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue("5%")]
	public NumberOrString? Left { get; set; }

	/// <summary>
	/// Distance between thmemRiver component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue("5%")]
	public NumberOrString? Top { get; set; }

	/// <summary>
	/// Distance between thmemRiver component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue("5%")]
	public NumberOrString? Right { get; set; }

	/// <summary>
	/// Distance between thmemRiver component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue("5%")]
	public NumberOrString? Bottom { get; set; }

	/// <summary>
	/// Width of thmemRiver component.
	/// </summary>
	[JsonPropertyName("width")]
	public NumberOrString? Width { get; set; }

	/// <summary>
	/// Height of thmemRiver component.
	///  
	/// Notes: The positional information of the whole theme river view reuses the positional information of a single time axis, which are left, top, right and bottom.
	/// </summary>
	[JsonPropertyName("height")]
	public NumberOrString? Height { get; set; }

	/// <summary>
	/// coordinate.
	/// The theme river adopts single time axis.
	/// </summary>
	[JsonPropertyName("coordinateSystem")]
	[DefaultValue("single")]
	public string? CoordinateSystem { get; set; }

	/// <summary>
	/// The boundary gap of the direction orthogonal with coordinate axis in diagram, which is set to adjust the diagram position, keeping it on the screen center instead of the upside or downside of the screen.
	/// </summary>
	[JsonPropertyName("boundaryGap")]
	[DefaultValue("[10%, 10%]")]
	public BoundaryGap? BoundaryGap { get; set; }

	/// <summary>
	/// The index of single time axis, which defaults to be 0 because it contains only one axis.
	/// </summary>
	[JsonPropertyName("singleAxisIndex")]
	[DefaultValue(0)]
	public int? SingleAxisIndex { get; set; }

	/// <summary>
	/// label describes style of text labels with which each ribbon-shape river branch corresponds in theme river.
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
	/// Since v5.0.0   
	/// Unified layout configuration of labels.
	///  
	/// It provide a chance to adjust the labels' (x, y) position, alignment based on the original layout each series provides.
	///  
	/// This option can be a callback with following parameters.
	///  // corresponding index of data
	/// dataIndex: number
	/// // corresponding type of data.
	/// Only available in graph, in which it can be 'node' or 'edge'
	/// dataType?: string
	/// // corresponding index of series
	/// seriesIndex: number
	/// // Displayed text of label.
	/// text: string
	/// // Bounding rectangle of label.
	/// labelRect: {x: number, y: number, width: number, height: number}
	/// // Horizontal alignment of label.
	/// align: 'left' | 'center' | 'right'
	/// // Vertical alignment of label.
	/// verticalAlign: 'top' | 'middle' | 'bottom'
	/// // Bounding rectangle of the element corresponding to.
	/// rect: {x: number, y: number, width: number, height: number}
	/// // Default points array of labelLine.
	/// Currently only provided in pie and funnel series.
	/// // It's null in other series.
	/// labelLinePoints?: number[][]  
	/// Example:  
	/// Align the labels on the right.
	/// Left 10px margin to the edge.
	///  labelLayout(params) {
	///     return {
	///         x: params.rect.x + 10,
	///         y: params.rect.y + params.rect.height / 2,
	///         verticalAlign: 'middle',
	///         align: 'left'
	///     }
	/// }  
	/// Set the text size based on the size of element bounding rectangle.
	///  labelLayout(params) {
	///     return {
	///         fontSize: Math.max(params.rect.width / 10, 5)
	///     };
	/// }
	/// </summary>
	[JsonPropertyName("labelLayout")]
	public ObjectOrFunction? LabelLayout { get; set; }

	/// <summary>
	/// style of each ribbon-shape river branch in theme river.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; }

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
	/// Configurations of select state.
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Selected mode.
	/// It is enabled by default, and you may set it to be false to disable it.
	///  
	/// Besides, it can be set to 'single' , 'multiple' or 'series' , for single selection, multiple selections and whole series selection.
	///   
	/// 'series' is supported since v5.3.0
	/// </summary>
	[JsonPropertyName("selectedMode")]
	[DefaultValue(false)]
	public SelectionMode? SelectedMode { get; set; }

	/// <summary>
	/// Can be list of ThemeRiverSeriesData, object[][], ...
	/// 
	/// data: [
	///     ["2015/11/09",10,"DQ"],
	///     ["2015/11/10",10,"DQ"],
	///     ["2015/11/11",10,"DQ"],
	///     ["2015/11/08",10,"SS"],
	///     ["2015/11/09",10,"SS"],
	///     ["2015/11/10",10,"SS"],
	///     ["2015/11/11",10,"SS"],
	///     ["2015/11/12",10,"SS"],
	///     ["2015/11/13",10,"QG"],
	///     ["2015/11/08",10,"QG"],
	///     ["2015/11/11",10,"QG"],
	///     ["2015/11/13",10,"QG"],
	/// ]  
	/// data specification:  
	/// As what is shown above, the data format of theme river is double dimensional array.
	/// Each item of the inner array consists of the time attribute , the value at a time point and the name of an event or theme.
	/// It needs to be noticed that you should provide an event or theme with a complete time quantum as main river.
	/// Other events and themes are based on the main river.
	/// The default value of time point should be set as 0.
	/// That is to say other events or themes are included in the main river.
	/// Once they are beyond the main river, the layout would be wrong.
	/// That is because a baseline should be calculated to draw each event as ribbon shape when the whole diagram layout is calculated.
	/// As the example above, the event "SS" is a main river.
	/// After dispose, we would complete these 3 default time points with the format of ["2015/11/08",0,"DQ"], ["2015/11/12",0,"DQ"], ［"2015/11/13",0,"DQ"］, making it align with the main river.
	/// From what is mentioned, we could set default value on any position of a complete time period.
	/// </summary>
	[JsonPropertyName("data")]
	public object? Data { get; set; }

	/// <summary>
	/// tooltip settings in this series.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; }

}
