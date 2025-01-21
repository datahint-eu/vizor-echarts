
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Calendar
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
	/// Distance between calendar component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue(80)]
	public NumberOrString? Left { get; set; }

	/// <summary>
	/// Distance between calendar component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue(60)]
	public NumberOrString? Top { get; set; }

	/// <summary>
	/// Distance between calendar component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue("auto")]
	public NumberOrString? Right { get; set; }

	/// <summary>
	/// Distance between calendar component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue("auto")]
	public NumberOrString? Bottom { get; set; }

	/// <summary>
	/// The height of calendar coordinates.
	///  
	/// Note: cellSize is 20 by default.
	/// If width is set, cellSize[0] will be forced to auto ;
	/// </summary>
	[JsonPropertyName("width")]
	[DefaultValue("auto")]
	public NumberOrString? Width { get; set; }

	/// <summary>
	/// The height of calendar coordinates.
	///  
	/// Note: cellSize is 20 by default.
	/// If height is set, cellSize[1] will be forced to auto ;
	/// </summary>
	[JsonPropertyName("height")]
	[DefaultValue("auto")]
	public NumberOrString? Height { get; set; }

	/// <summary>
	/// Required, range of Calendar coordinates, support multiple formats.
	///  
	/// Examples:  // one year
	/// range: 2017
	/// 
	/// // one month
	/// range: '2017-02'
	/// 
	/// //  a range
	/// range: ['2017-01-02', '2017-02-23']
	/// 
	/// // note: they will be identified as ['2017-01-01', '2017-02-01']
	/// range: ['2017-01', '2017-02']
	/// </summary>
	[JsonPropertyName("range")]
	public NumberOrStringArray? Range { get; set; }

	/// <summary>
	/// The size of each rect of calendar coordinates, can be set to a single value or array, the first element is width and the second element is height.
	///  
	/// Support setting self-adaptation: auto , the default width and height to be 20.
	///  
	/// Examples:  // Set the width and height to be 20
	/// cellSize: 20
	/// 
	/// // Set the width to be 20, and height to be 40
	/// cellSize: [20, 40]
	/// 
	/// // Set width and height to be self-adaptation
	/// cellSize: [40]
	/// 
	/// // Set the width and height to be 20
	/// cellSize: 'auto'
	/// 
	/// // Set the width to be self-adaptation, and height to be 40
	/// cellSize: ['auto', 40]
	/// </summary>
	[JsonPropertyName("cellSize")]
	[DefaultValue("20")]
	public CellSize? CellSize { get; set; }

	/// <summary>
	/// The layout orientation of calendar.
	///  
	/// Options:   'horizontal'  'vertical'
	/// </summary>
	[JsonPropertyName("orient")]
	[DefaultValue("horizontal")]
	public Orient? Orient { get; set; }

	/// <summary>
	/// Calendar coordinates splitLine style.
	/// </summary>
	[JsonPropertyName("splitLine")]
	public SplitLine? SplitLine { get; set; }

	/// <summary>
	/// Every rect style in calendar coordinates.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; }

	/// <summary>
	/// Day style in calendar coordinates.
	/// </summary>
	[JsonPropertyName("dayLabel")]
	public DayLabel? DayLabel { get; set; }

	/// <summary>
	/// Month label in calendar coordinates.
	/// </summary>
	[JsonPropertyName("monthLabel")]
	public MonthLabel? MonthLabel { get; set; }

	/// <summary>
	/// Year label in calendar coordinates.
	/// </summary>
	[JsonPropertyName("yearLabel")]
	public YearLabel? YearLabel { get; set; }

	/// <summary>
	/// Whether to ignore mouse events.
	/// Default value is false, for triggering and responding to mouse events.
	/// </summary>
	[JsonPropertyName("silent")]
	[DefaultValue(false)]
	public bool? Silent { get; set; }

}
