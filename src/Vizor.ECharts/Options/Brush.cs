// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Brush
{
	/// <summary>
	/// Icons used, whose values are:   'rect' : Enabling selecting with rectangle area.
	///  'polygon' : Enabling selecting with any shape.
	///  'lineX' : Enabling horizontal selecting.
	///  'lineY' : Enabling vertical selecting.
	///  'keep' : Switching between single selecting and multiple selecting .
	/// The latter one can select multiple areas, while the former one cancels previous selection.
	///  'clear' : Clearing all selection.
	/// </summary>
	[JsonPropertyName("type")]
	public List<object>? Type { get; set; } 

	/// <summary>
	/// Icon path for each icon.
	/// </summary>
	[JsonPropertyName("icon")]
	public Icon? Icon { get; set; } 

	/// <summary>
	/// Title.
	/// </summary>
	[JsonPropertyName("title")]
	public Title? Title { get; set; } 

	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; } 

	/// <summary>
	/// Use the buttons in toolbox.
	///  
	/// Buttons in toolbox that is related to brush includes:   'rect' : for selection-box in rectangle shape;  'polygon' : for selection-box in polygon shape;  'lineX' : for horizontal selection-box;  'lineY' : for vertical selection-box;  'keep' : for setting mode between single and multiple selection, the former of which supports clearing selection on click, and the latter selecting multiple areas;  'clear' : for clearing all selections.
	/// </summary>
	[JsonPropertyName("toolbox")]
	[DefaultValue("[rect, polygon, keep, clear]")]
	public List<object>? Toolbox { get; set; } 

	/// <summary>
	/// Links interaction between selected items in different series.
	///  
	/// Following is an example of enabling selected effect for scatter and parallel charts once a scatter chart is selected.
	///  
	/// brushLink is an array of seriesIndex es, which assignes the series that can be interacted.
	/// For example, it can be:   [3, 4, 5] for interacting series with seriesIndex as 3 , 4 , or 5 ;  'all' for interacting all series;  'none' , or null , or undefined for disabling brushLink .
	///   
	/// Attention  
	/// brushLink is a mapping of dataIndex .
	/// So data of every series with brushLink should be guaranteed to correspond to the other .
	///  
	/// Example:  option = {
	///     brush: {
	///         brushLink: [0, 1]
	///     },
	///     series: [
	///         {
	///             type: 'bar'
	///             data: [232,    4434,    545,      654]     // data has 4 items
	///         },
	///         {
	///             type: 'parallel',
	///             data: [[4, 5], [3, 5], [66, 33], [99, 66]] // data also has 4 items, which correspond to the data above
	///         }
	///     ]
	/// };
	/// </summary>
	[JsonPropertyName("brushLink")]
	public Icon? BrushLink { get; set; } 

	/// <summary>
	/// Assigns which of the series can use brush selecting, whose value can be:   'all' : all series;  'Array' : series index array;  'number' : certain series index.
	/// </summary>
	[JsonPropertyName("seriesIndex")]
	[DefaultValue("all")]
	public object? SeriesIndex { get; set; } 

	/// <summary>
	/// Assigns which of the geo can use brush selecting.
	///  
	/// brush can be set to be global , or belonging to a particular coordinate .
	///  
	/// Global brushes  
	/// Selecting is enabled for everywhere in ECharts's instance in this case.
	/// This is the default situation, when brush is not set to be global.
	///  
	/// Coordinate brushes  
	/// Selecting is enabled only in the assigned coordinates in this case.
	/// Selecting-box will be altered according to scaling and translating of coordinate (see roam and dataZoom ).
	///  
	/// In practice, you may often find coordinate brush to be a more frequently made choice, particularly in geo charts.
	///  
	/// By assigning brush.geoIndex , or brush.xAxisIndex , or brush.yAxisIndex , brush selecting axes can be assigned, whose value can be:   'all' : for all axes;  number : like 0 , for a particular coordinate with that index;  Array : like [0, 4, 2] , for coordinates with those indexes;  'none' , or null , or undefined : for not assigning.
	///   
	/// Example:  option = {
	///     geo: {
	///         ...
	///     },
	///     brush: {
	///         geoIndex: 'all', // brush selecting is enabled only in all geo charts above
	///         ...
	///     }
	/// };  
	/// Example:  option = {
	///     grid: [
	///         {...}, // grid 0
	///         {...}  // grid 1
	///     ],
	///     xAxis: [
	///         {gridIndex: 1, ...}, // xAxis 0 for grid 1
	///         {gridIndex: 0, ...}  // xAxis 1 for grid 0
	///     ],
	///     yAxis: [
	///         {gridIndex: 1, ...}, // yAxis 0 for grid 1
	///         {gridIndex: 0, ...}  // yAxis 1 for grid 0
	///     ],
	///     brush: {
	///         xAxisIndex: [0, 1], // brush selecting is enabled only in coordinates with xAxisIndex as `0` or `1`
	///         ...
	///     }
	/// };
	/// </summary>
	[JsonPropertyName("geoIndex")]
	public object? GeoIndex { get; set; } 

	/// <summary>
	/// Assigns which of the xAxisIndex can use brush selecting.
	///  
	/// brush can be set to be global , or belonging to a particular coordinate .
	///  
	/// Global brushes  
	/// Selecting is enabled for everywhere in ECharts's instance in this case.
	/// This is the default situation, when brush is not set to be global.
	///  
	/// Coordinate brushes  
	/// Selecting is enabled only in the assigned coordinates in this case.
	/// Selecting-box will be altered according to scaling and translating of coordinate (see roam and dataZoom ).
	///  
	/// In practice, you may often find coordinate brush to be a more frequently made choice, particularly in geo charts.
	///  
	/// By assigning brush.geoIndex , or brush.xAxisIndex , or brush.yAxisIndex , brush selecting axes can be assigned, whose value can be:   'all' : for all axes;  number : like 0 , for a particular coordinate with that index;  Array : like [0, 4, 2] , for coordinates with those indexes;  'none' , or null , or undefined : for not assigning.
	///   
	/// Example:  option = {
	///     geo: {
	///         ...
	///     },
	///     brush: {
	///         geoIndex: 'all', // brush selecting is enabled only in all geo charts above
	///         ...
	///     }
	/// };  
	/// Example:  option = {
	///     grid: [
	///         {...}, // grid 0
	///         {...}  // grid 1
	///     ],
	///     xAxis: [
	///         {gridIndex: 1, ...}, // xAxis 0 for grid 1
	///         {gridIndex: 0, ...}  // xAxis 1 for grid 0
	///     ],
	///     yAxis: [
	///         {gridIndex: 1, ...}, // yAxis 0 for grid 1
	///         {gridIndex: 0, ...}  // yAxis 1 for grid 0
	///     ],
	///     brush: {
	///         xAxisIndex: [0, 1], // brush selecting is enabled only in coordinates with xAxisIndex as `0` or `1`
	///         ...
	///     }
	/// };
	/// </summary>
	[JsonPropertyName("xAxisIndex")]
	public object? XAxisIndex { get; set; } 

	/// <summary>
	/// Assigns which of the yAxisIndex can use brush selecting.
	///  
	/// brush can be set to be global , or belonging to a particular coordinate .
	///  
	/// Global brushes  
	/// Selecting is enabled for everywhere in ECharts's instance in this case.
	/// This is the default situation, when brush is not set to be global.
	///  
	/// Coordinate brushes  
	/// Selecting is enabled only in the assigned coordinates in this case.
	/// Selecting-box will be altered according to scaling and translating of coordinate (see roam and dataZoom ).
	///  
	/// In practice, you may often find coordinate brush to be a more frequently made choice, particularly in geo charts.
	///  
	/// By assigning brush.geoIndex , or brush.xAxisIndex , or brush.yAxisIndex , brush selecting axes can be assigned, whose value can be:   'all' : for all axes;  number : like 0 , for a particular coordinate with that index;  Array : like [0, 4, 2] , for coordinates with those indexes;  'none' , or null , or undefined : for not assigning.
	///   
	/// Example:  option = {
	///     geo: {
	///         ...
	///     },
	///     brush: {
	///         geoIndex: 'all', // brush selecting is enabled only in all geo charts above
	///         ...
	///     }
	/// };  
	/// Example:  option = {
	///     grid: [
	///         {...}, // grid 0
	///         {...}  // grid 1
	///     ],
	///     xAxis: [
	///         {gridIndex: 1, ...}, // xAxis 0 for grid 1
	///         {gridIndex: 0, ...}  // xAxis 1 for grid 0
	///     ],
	///     yAxis: [
	///         {gridIndex: 1, ...}, // yAxis 0 for grid 1
	///         {gridIndex: 0, ...}  // yAxis 1 for grid 0
	///     ],
	///     brush: {
	///         xAxisIndex: [0, 1], // brush selecting is enabled only in coordinates with xAxisIndex as `0` or `1`
	///         ...
	///     }
	/// };
	/// </summary>
	[JsonPropertyName("yAxisIndex")]
	public object? YAxisIndex { get; set; } 

	/// <summary>
	/// Default type of brush.
	///   'rect' : for selection-box in rectangle shape;  'polygon' : for selection-box in polygon shape;  'lineX' : for horizontal selection-box;  'lineY' : for vertical selection-box;
	/// </summary>
	[JsonPropertyName("brushType")]
	[DefaultValue("rect")]
	public BrushType? BrushType { get; set; } 

	/// <summary>
	/// Default brush mode, whose value can be:   'single' : for single selection;  'multiple' : for multiple selection.
	/// </summary>
	[JsonPropertyName("brushMode")]
	[DefaultValue("single")]
	public string? BrushMode { get; set; } 

	/// <summary>
	/// Determines whether a selected box can be changed in shape or translated.
	/// </summary>
	[JsonPropertyName("transformable")]
	[DefaultValue(true)]
	public bool? Transformable { get; set; } 

	/// <summary>
	/// Default brush style, whose value is:  {
	///     borderWidth: 1,
	///     color: 'rgba(120,140,180,0.3)',
	///     borderColor: 'rgba(120,140,180,0.8)'
	/// },
	/// </summary>
	[JsonPropertyName("brushStyle")]
	public BrushStyle? BrushStyle { get; set; } 

	/// <summary>
	/// By default, brushSelected is always triggered when selection-box is selected or moved, to tell the outside about the event.
	///  
	/// But efficiency problems may occur when events are triggered too frequently, or the animation result may be affected.
	/// So brush components provides brush.throttleType and brush.throttleDelay to solve this problem.
	///  
	/// Valid throttleType values can be:   'debounce' : for triggering events only when the action has been stopped (no action after some duration).
	/// Time threshold can be assigned with brush.throttleDelay ;  'fixRate' : for triggering event with a certain frequency.
	/// The frequency can be assigned with brush.throttleDelay .
	///   
	/// In this example , debounce is used to make sure the bar chart is updated only when the user has stopped action.
	/// In other cases, the animation result may not be so good.
	/// </summary>
	[JsonPropertyName("throttleType")]
	[DefaultValue("fixRate")]
	public string? ThrottleType { get; set; } 

	/// <summary>
	/// 0 for disabling throttle.
	///  
	/// By default, brushSelected is always triggered when selection-box is selected or moved, to tell the outside about the event.
	///  
	/// But efficiency problems may occur when events are triggered too frequently, or the animation result may be affected.
	/// So brush components provides brush.throttleType and brush.throttleDelay to solve this problem.
	///  
	/// Valid throttleType values can be:   'debounce' : for triggering events only when the action has been stopped (no action after some duration).
	/// Time threshold can be assigned with brush.throttleDelay ;  'fixRate' : for triggering event with a certain frequency.
	/// The frequency can be assigned with brush.throttleDelay .
	///   
	/// In this example , debounce is used to make sure the bar chart is updated only when the user has stopped action.
	/// In other cases, the animation result may not be so good.
	/// </summary>
	[JsonPropertyName("throttleDelay")]
	[DefaultValue(0)]
	public double? ThrottleDelay { get; set; } 

	/// <summary>
	/// Defined whether clearing all select-boxes on click is enabled when brush.brushMode is 'single' .
	/// </summary>
	[JsonPropertyName("removeOnClick")]
	[DefaultValue(true)]
	public bool? RemoveOnClick { get; set; } 

	/// <summary>
	/// Defines visual effects of items in selection.
	///  
	/// Available visual effects include:   symbol : Type of symbol.
	///  symbolSize : Symbol size.
	///  color : Symbol color.
	///  colorAlpha : Symbol alpha channel.
	///  opacity : Opacity of symbol and others (like labels).
	///  colorLightness : Lightness in HSL .
	///  colorSaturation : Saturation in HSL .
	///  colorHue : Hue in HSL .
	///   
	/// In most cases, inBrush can be left unassigned, in which case default visual configuration remains.
	/// </summary>
	[JsonPropertyName("inBrush")]
	public InBrush? InBrush { get; set; } 

	/// <summary>
	/// Defines visual effects of items out of selection.
	///  
	/// Available visual effects include:   symbol : Type of symbol.
	///  symbolSize : Symbol size.
	///  color : Symbol color.
	///  colorAlpha : Symbol alpha channel.
	///  opacity : Opacity of symbol and others (like labels).
	///  colorLightness : Lightness in HSL .
	///  colorSaturation : Saturation in HSL .
	///  colorHue : Hue in HSL .
	///   
	/// Note: If outOfBrush is not assigned, color will be set to be '#ddd' by default.
	/// If the color is not desired, you can use:  brush: {
	///     ...,
	///     outOfBrush: {
	///         colorAlpha: 0.1
	///     }
	/// }
	/// </summary>
	[JsonPropertyName("outOfBrush")]
	public OutOfBrush? OutOfBrush { get; set; } 

	/// <summary>
	/// z-index of brush cover box.
	/// It can be adjusted when incorrect overlap occurs.
	/// </summary>
	[JsonPropertyName("z")]
	[DefaultValue(10000)]
	public double? Z { get; set; } 

}
