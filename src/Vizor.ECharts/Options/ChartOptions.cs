// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class ChartOptions
{
	/// <summary>
	/// Title component, including main title and subtitle.
	///  
	/// In ECharts 2.x, a single instance of ECharts could contains one title component at most.
	/// However, in ECharts 3, there could be one or more than one title components.
	/// It is more useful when multiple diagrams in one instance all need titles.
	///  
	/// Here are some instances of different animation easing functions, among which every instance has a title component:
	/// </summary>
	[JsonPropertyName("title")]
	public Title? Title { get; set; } 

	/// <summary>
	/// Legend component.
	///  
	/// Legend component shows symbol, color and name of different series.
	/// You can click legends to toggle displaying series in the chart.
	///  
	/// In ECharts 3, a single echarts instance may contain multiple legend components, which makes it easier for the layout of multiple legend components.
	///  
	/// If there have to be too many legend items, vertically scrollable legend or horizontally scrollable legend are options to paginate them.
	/// Check legend.type please.
	/// </summary>
	[JsonPropertyName("legend")]
	public Legend? Legend { get; set; } 

	/// <summary>
	/// Drawing grid in rectangular coordinate.
	/// In a single grid, at most two X and Y axes each is allowed.
	/// Line chart , bar chart , and scatter chart (bubble chart) can be drawn in grid.
	///  
	/// In ECharts 2.x, there could only be one single grid component at most in a single echarts instance.
	/// But in ECharts 3, there is no limitation.
	///  
	/// Following is an example of Anscombe Quartet:
	/// </summary>
	[JsonPropertyName("grid")]
	public Grid? Grid { get; set; } 

	/// <summary>
	/// The x axis in cartesian(rectangular) coordinate.
	/// Usually a single grid component can place at most 2 x axis, one on the bottom and another on the top.
	/// offset can be used to avoid overlap when you need to put more than two x axis.
	/// </summary>
	[JsonPropertyName("xAxis")]
	public XAxis? XAxis { get; set; } 

	/// <summary>
	/// The y axis in cartesian(rectangular) coordinate.
	/// Usually a single grid component can place at most 2 y axis, one on the left and another on the right.
	/// offset can be used to avoid overlap when you need to put more than two y axis.
	/// </summary>
	[JsonPropertyName("yAxis")]
	public YAxis? YAxis { get; set; } 

	/// <summary>
	/// Polar coordinate can be used in scatter and line chart.
	/// Every polar coordinate has an angleAxis and a radiusAxis .
	///  
	/// For example:
	/// </summary>
	[JsonPropertyName("polar")]
	public Polar? Polar { get; set; } 

	/// <summary>
	/// Radial axis of polar coordinate.
	/// </summary>
	[JsonPropertyName("radiusAxis")]
	public RadiusAxis? RadiusAxis { get; set; } 

	/// <summary>
	/// The angle axis in Polar Coordinate.
	/// </summary>
	[JsonPropertyName("angleAxis")]
	public AngleAxis? AngleAxis { get; set; } 

	/// <summary>
	/// Coordinate for radar charts .
	/// This component is equal to the polar component in ECharts 2.
	/// Because the polar component in the echarts 3 is reconstructed to be the standard polar coordinate component, this component is renamed to be radar to avoid confusion.
	///  
	/// Radar chart coordinate is different from polar coordinate, in that every axis indicator of the radar chart coordinate is an individual dimension.
	/// The style of indicator coordinate axis could be configured through the following configuration items, including name , axisLine , axisTick , axisLabel , splitLine , splitArea .
	///  
	/// Here is a custom example of radar component.
	/// </summary>
	[JsonPropertyName("radar")]
	public Radar? Radar { get; set; } 

	/// <summary>
	/// dataZoom component is used for zooming a specific area, which enables user to investigate data in detail, or get an overview of the data, or get rid of outlier points.
	///  
	/// These types of dataZoom component are supported:   
	/// dataZoomInside : Data zoom functionalities is embeded inside coordinate systems, enable user to zoom or roam coordinate system by mouse dragging, mouse move or finger touch (in touch screen).
	///   
	/// dataZoomSlider : A special slider bar is provided, on which coordinate systems can be zoomed or roamed by mouse dragging or finger touch (in touch screen).
	///   
	/// dataZoomSelect : A marquee tool is provided for zooming or roaming coordinate system.
	/// That is toolbox.feature.dataZoom , which can only be configured in toolbox.
	///    
	/// Example:   
	/// 
	///   
	/// ✦ Relationship between dataZoom and axis ✦  
	/// Basically dataZoom component operates "window" on axis to zoom or roam coordinate system.
	///   
	/// Use dataZoom.xAxisIndex or dataZoom.yAxisIndex or dataZoom.radiusAxisIndex or dataZoom.angleAxisIndex to specify which axes are operated by dataZoom .
	///   
	/// A single chart instance can contain several dataZoom components, each of which controls different axes.
	/// The dataZoom components that control the same axis will be automatically linked (i.e., all of them will be updated when one of them is updated by user action or API call).
	///  
	/// 
	///   
	/// ✦ How dataZoom componets operates axes and data ✦  
	/// Generally dataZoom component zoom or roam coordinate system through data filtering and set the windows of axes internally.
	///  
	/// Its behaviours vary according to filtering mode settings ( dataZoom.filterMode ).
	///  
	/// Possible values:   
	/// 'filter': data that outside the window will be filtered , which may lead to some changes of windows of other axes.
	/// For each data item, it will be filtered if one of the relevant dimensions is out of the window.
	///   
	/// 'weakFilter': data that outside the window will be filtered , which may lead to some changes of windows of other axes.
	/// For each data item, it will be filtered only if all of the relevant dimensions are out of the same side of the window.
	///   
	/// 'empty': data that outside the window will be set to NaN , which will not lead to changes of windows of other axes.
	///   
	/// 'none': Do not filter data.
	///    
	/// How to set filterMode is up to users, depending on the requirments and scenarios.
	/// Expirically:   
	/// If only xAxis or only yAxis is controlled by dataZoom , filterMode: 'filter' is typically used, which enable the other axis auto adapte its window to the extent of the filtered data.
	///   
	/// If both xAxis and yAxis are operated by dataZoom :   
	/// If xAxis and yAxis should not effect mutually (e.g.
	/// a scatter chart with both axes on the type of 'value' ), they should be set to be filterMode: 'empty' .
	///   
	/// If xAxis is the main axis and yAxis is the auxiliary axis (or vise versa) (e.g., in a bar chart, when dragging dataZoomX to change the window of xAxis, we need the yAxis to adapt to the clipped data, but when dragging dataZoomY to change the window of yAxis, we need the xAxis not to be changed), in this case, xAxis should be set to be filterMode: 'filter' , while yAxis should be set to be filterMode: 'empty' .
	///      
	/// It can be demonstrated by the sample:  option = {
	///     dataZoom: [
	///         {
	///             id: 'dataZoomX',
	///             type: 'slider',
	///             xAxisIndex: [0],
	///             filterMode: 'filter'
	///         },
	///         {
	///             id: 'dataZoomY',
	///             type: 'slider',
	///             yAxisIndex: [0],
	///             filterMode: 'empty'
	///         }
	///     ],
	///     xAxis: {type: 'value'},
	///     yAxis: {type: 'value'},
	///     series{
	///         type: 'bar',
	///         data: [
	///             // The first column corresponds to xAxis,
	///             // and the second coloum corresponds to yAxis.
	///             [12, 24, 36],
	///             [90, 80, 70],
	///             [3, 9, 27],
	///             [1, 11, 111]
	///         ]
	///     }
	/// }  
	/// In the sample above, dataZoomX is set as filterMode: 'filter' .
	/// When use drags dataZoomX (do not touch dataZoomY ) and the valueWindow of xAxis is changed to [2, 50] consequently, dataZoomX travel the first column of series.data and filter items that out of the window.
	/// The series.data turns out to be:  [
	///     [12, 24, 36],
	///     // [90, 80, 70] This item is filtered, as 90 is out of the window.
	///     [3, 9, 27]
	///     // [1, 11, 111] This item is filtered, as 1 is out of the window.
	/// ]  
	/// Before filtering, the second column, which corresponds to yAxis, has values 24 , 80 , 9 , 11 .
	/// After filtering, only 24 and 9 are left.
	/// Then the extent of yAxis is adjusted to adapt the two values (if yAxis.min and yAxis.max are not set).
	///  
	/// So filterMode: 'filter' can be used to enable the other axis to auto adapt the filtered data.
	///  
	/// Then let's review the sample from the beginning, dataZoomY is set as filterMode: 'empty' .
	/// So if user drags dataZoomY (do not touch dataZoomX ) and its window is changed to [10, 60] consequently, dataZoomY travels the second column of series.data and set NaN to all of the values that outside the window (NaN cause the graphical elements, i.e., bar elements, do not show, but still hold the place).
	/// The series.data turns out to be:  [
	///     [12, 24, 36],
	///     [90, NaN, 70], // Set to NaN
	///     [3, NaN, 27],  // Set to NaN
	///     [1, 11, 111]
	/// ]  
	/// In this case, the first column (i.e., 12 , 90 , 3 , 1 , which corresponds to xAxis ), will not be changed at all.
	/// So dragging yAxis will not change extent of xAxis , which is good for requirements like outlier filtering.
	///  
	/// See this example:   
	/// Moreover, when min , max of an axis is set (e.g., yAxis: {min: 0, max: 400} ), this extent of the axis will not be modified by the behaviour of dataZoom of other axis any more.
	///  
	/// 
	///   
	/// ✦ How to set window ✦  
	/// You can set the current window in two forms:   
	/// percent value: see dataZoom.start and dataZoom.end .
	///   
	/// absolute value: see dataZoom.startValue and dataZoom.endValue .
	///    
	/// Notice: If use percent value form, and it is in the scenario below, the result of dataZoom depends on the sequence of dataZoom definitions appearing in option .
	///  option = {
	///     dataZoom: [
	///         {
	///             id: 'dataZoomX',
	///             type: 'slider',
	///             xAxisIndex: [0],
	///             filterMode: 'filter',   // Set as 'filter' so that the modification
	///                                     // of window of xAxis willl effect the
	///                                     // window of yAxis.
	///             start: 30,
	///             end: 70
	///         },
	///         {
	///             id: 'dataZoomY',
	///             type: 'slider',
	///             yAxisIndex: [0],
	///             filterMode: 'empty',
	///             start: 20,
	///             end: 80
	///         }
	///     ],
	///     xAxis: {
	///         type: 'value'
	///     },
	///     yAxis: {
	///         type: 'value'
	///         // Notice there is no min or max set to
	///         // restrict the view extent of yAxis.
	///     },
	///     series{
	///         type: 'bar',
	///         data: [
	///             // The first column corresponds to xAxis,
	///             // and the second column corresponds to yAxis.
	///             [12, 24, 36],
	///             [90, 80, 70],
	///             [3, 9, 27],
	///             [1, 11, 111]
	///         ]
	///     }
	/// }  
	/// What is the exact meaning of start: 20, end: 80 in dataZoomY in the example above?   
	/// If yAxis.min and yAxis.max are set:  
	///  start: 20, end: 80 of dataZoomY means: from 20% to 80% out of [yAxis.min, yAxis.max] .
	///  
	/// If one of yAxis.min and yAxis.max is not set, the corresponding edge of the full extend also follow rule as follows.
	///   
	/// If yAxis.min and yAxis.max are not set:   
	/// If dataZoomX is set to be filterMode: 'empty' :  
	///  start: 20, end: 80 of dataZoomY means: from 20% to 80% out of [dataMinY to dataMaxY] of series.data (i.e., [9, 80] in the example above).
	///   
	/// If dataZoomX is set to filterMode: 'filter' :  
	/// Since dataZoomX is defined before dataZoomY , start: 30, end: 70 of dataZoomX means: from 30% to 70% out of full series.data, whereas start: 20, end: 80 of dataZoomY means: from 20% to 80% out of the series.data having been filtered by dataZoomX .
	///  
	/// If you want to change the process sequence, you can just change the sequence of the definitions apearing in option .
	/// </summary>
	[JsonPropertyName("dataZoom")]
	public List<ChartOptionsDataZoom>? DataZoom { get; set; } 

	/// <summary>
	/// visualMap is a type of component for visual encoding, which maps the data to visual channels, including:   symbol : Type of symbol.
	///  symbolSize : Symbol size.
	///  color : Symbol color.
	///  colorAlpha : Symbol alpha channel.
	///  opacity : Opacity of symbol and others (like labels).
	///  colorLightness : Lightness in HSL .
	///  colorSaturation : Saturation in HSL .
	///  colorHue : Hue in HSL .
	///   
	/// Multiple visualMap component could be defined in a chart instance, which enable that different dimensions of a series data are mapped to different visual channels.
	///  
	/// visualMap could be defined as Piecewise (visualMapPiecewise) or Continuous (visualMapContinuous) , which is distinguished by the property type .
	/// For instance:  option = {
	///     visualMap: [
	///         { // the first visualMap component
	///             type: 'continuous', // defined to be continuous visualMap
	///             ...
	///         },
	///         { // the second visualMap component
	///             type: 'piecewise', // defined to be piecewise visualMap
	///             ...
	///         }
	///     ],
	///     ...
	/// };  
	/// 
	///  ✦ Configure mapping ✦  
	/// The dimension of series.data can be specified by visualMap.dimension , from which the value can be retrieved and mapped onto visual channels, which can be defined in visualMap.inRange and visualMap.outOfRange .
	///  
	/// 
	/// In series that controlled by visualMap, if a data item needs to escape from controlled by visualMap, you can set like this:  series: {
	///     type: '...',
	///     data: [
	///         {name: 'Shanghai', value: 251},
	///         {name: 'Haikou', value: 21},
	///         // Mark as `visualMap: false`, then this item does not controlled by visualMap any more,
	///         // and series visual config (like color, symbol, ...) can be used to this item.
	///         {name: 'Beijing', value: 821, },
	///         ...
	///     ]
	/// } 
	/// 
	///  ✦ The relationship between visualMap of ECharts3 and dataRange of ECharts2 ✦  
	/// visualMap is renamed from the dataRange of ECharts2, and the scope of functionalities are extended a lot.
	/// The configurations of dataRange are still compatible in ECharts3, which automatically convert them to visualMap .
	/// It is recommended to use visualMap instead of dataRange in ECharts3.
	///  
	/// 
	///  ✦ The detailed configurations of visualMap are elaborated as follows.
	/// ✦
	/// </summary>
	[JsonPropertyName("visualMap")]
	public List<ChartOptionsVisualMap>? VisualMap { get; set; } 

	/// <summary>
	/// Tooltip component.
	///   
	/// General Introduction:  
	/// tooltip can be configured on different places:   
	/// Configured on global: tooltip   
	/// Configured in a coordinate system: grid.tooltip , polar.tooltip , single.tooltip   
	/// Configured in a series: series.tooltip   
	/// Configured in each item of series.data : series.data.tooltip
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

	/// <summary>
	/// This is the global configurations of axisPointer.
	///   
	/// axisPointer is a tool for displaying reference line and axis value under mouse pointer.
	///  
	/// For example:   
	/// In the demo above, axisPointer.link is used to link axisPointer from different coordinate systems.
	///  
	/// axisPointer can also be used on touch device, where user can drag the button to move the reference line and label.
	///   
	/// In the cases that more than one axis exist, axisPointer helps to look inside the data.
	///      
	/// Notice: Generally, axisPointers is configured in each axes who need them (for example xAxis.axisPointer ), or configured in tooltip (for example tooltip.axisPointer ).
	///    
	/// But these configurations can only be configured in global axisPointer: axisPointer.triggerOn , axisPointer.link .
	///     
	/// How to display axisPointer:  
	/// In cartesian (grid) and polar](~polar) and (single axis , each axis has its own axisPointer.
	///  
	/// Those axisPointer will not be displayed by default, utill configured as follows:   
	/// Set someAxis.axisPointer.show (like xAxis.axisPointer.show ) as true .
	/// Then axisPointer of this axis will be displayed.
	///   
	/// Set tooltip.trigger as 'axis' , or set tooltip.axisPointer.type as 'cross' .
	/// Then coordinate system will automatically chose the axes who will display their axisPointers.
	/// ( tooltip.axisPointer.axis can be used to change the choice.) Notice, axis.axisPointer will override tooltip.axisPointer settings.
	///     
	/// How to display the label of axisPointer:  
	/// The label of axisPointer will not be displayed by default(namely, only reference line will be displayed by default), utill configured as follows:   
	/// Set someAxis.axisPointer.label.show (for example xAxis.axisPointer.label.show ) as true .
	/// Then the label of the axisPointer will be displayed.
	///   
	/// Set tooltip.axisPointer.type as 'cross' .
	/// Then the label of the crossed axisPointers will be displayed.
	///     
	/// How to configure axisPointer on touch device:  
	/// Set someAxis.axisPointer.handle.show (for example xAxis.axisPointer.handle.show as true .
	/// Then the button for dragging will be displayed.
	/// (This feature is not supported on polar).
	///  
	/// Notice: If tooltip does not work well in this case, try to set tooltip.triggerOn as 'none' (for the effect: show tooltip when finger holding on the button, and hide tooltip after finger left the button), or set tooltip.alwaysShowContent as true (then tooltip will always be displayed).
	///  
	/// See the example .
	///   
	/// Snap to point  
	/// In value axis and time axis, if snap is set as true, axisPointer will snap to point automatically.
	/// </summary>
	[JsonPropertyName("axisPointer")]
	public AxisPointer? AxisPointer { get; set; } 

	/// <summary>
	/// A group of utility tools, which includes export , data view , dynamic type switching , data area zooming , and reset .
	///  
	/// Example:
	/// </summary>
	[JsonPropertyName("toolbox")]
	public Toolbox? Toolbox { get; set; } 

	/// <summary>
	/// brush is an area-selecting component, with which user can select part of data from a chart to display in detail, or do calculations with them.
	///  
	/// 
	///   
	/// Brush type and triggering button  
	/// Currently, supported brush types include: scatter , bar , candlestick .
	/// (Note that parallel contains brush function by itself, which is not provided by brush component.)  
	/// Click the button in toolbox to enable operations like area selecting , or canceling selecting .
	///  
	/// 
	/// Example of horizontal brush : (Click the button in toolbox to enable brushing.)   
	/// 
	/// Example of brush in bar charts:   
	/// Button for brush can be assigned in toolbox or brush configuration .
	///  
	/// The following types of brushes are supported: rect , polygon , lineX , lineY .
	/// See brush.toolbox for more information.
	///  
	/// keep button can be used to toggle a single or multiple selections.
	///   Only one select box is available in single selection mode, and the select-box can be removed by clicking on the blank area.
	///  Multiple select boxes are available in multiple selection mode, and the select-boxes cannot be removed by click on the blank area.
	/// Instead, you need to click the clear button.
	///   
	/// 
	///   
	/// Relationship between brush-selecting and coordinates  
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
	/// 
	///   
	/// Control select-box with API  
	/// dispatchAction can be used to render select-box programatically.
	/// For example:  myChart.dispatchAction({
	///     type: 'brush',
	///     areas: [
	///         {
	///             geoIndex: 0,
	///             // Assign select-box type
	///             brushType: 'polygon',
	///             // Assign select-box shape
	///             coordRange: [[119.72,34.85],[119.68,34.85],[119.5,34.84],[119.19,34.77]]
	///         }
	///     ]
	/// });  
	/// Please refer to action.brush for more information.
	///  
	/// 
	///   
	/// brushLink  
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
	/// Please refer to brush.brushLink .
	///  
	/// 
	///   
	/// throttle / debounce  
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
	///  
	/// 
	///   
	/// Visual configurations of selected and unselected items  
	/// Refer to brush.inBrush and brush.outOfBrush .
	///  
	/// 
	///   
	/// Here is the configuration in detail.
	/// </summary>
	[JsonPropertyName("brush")]
	public Brush? Brush { get; set; } 

	/// <summary>
	/// Geographic coordinate system component.
	///  
	/// Geographic coordinate system component is used to draw maps, which also supports scatter series , and line series .
	///  
	/// From 3.1.10 , geo component also supports mouse events, whose parameters are:  {
	///     componentType: 'geo',
	///     // geo component's index in option
	///     geoIndex: number,
	///     // name of clicking area, e.g., Shanghai
	///     name: string,
	///     // clicking region object as input, see geo.regions
	///     region: Object
	/// }  
	/// Tip: The region color can also be controlled by map series.
	/// See series-map.geoIndex .
	/// </summary>
	[JsonPropertyName("geo")]
	public Geo? Geo { get; set; } 

	/// <summary>
	/// Introduction about Parallel coordinates  
	/// Parallel Coordinates is a common way of visualizing high-dimensional geometry and analyzing multivariate data.
	///  
	/// For example, series-parallel.data is the following data:  [
	///     [1,  55,  9,   56,  0.46,  18,  6,  'good'],
	///     [2,  25,  11,  21,  0.65,  34,  9,  'excellent'],
	///     [3,  56,  7,   63,  0.3,   14,  5,  'good'],
	///     [4,  33,  7,   29,  0.33,  16,  6,  'excellent'],
	///     { // Data item can also be an Object, so that perticular settings of its line can be set here.
	///         value: [5,  42,  24,  44,  0.76,  40,  16, 'excellent']
	///         lineStyle: {...},
	///     }
	///     ...
	/// ]  
	/// In data above, each row is a "data item", and each column represents a "dimension".
	/// For example, the meanings of columns above are: "data", "AQI", "PM2.5", "PM10", "carbon monoxide level", "nitrogen dioxide level", and "sulfur dioxide level".
	///  
	/// Parallel coordinates are often used to visualize multi-dimension data shown above.
	/// Each axis represents a dimension (namely, a column), and each line represents a data item.
	/// Data can be brush-selected on axes.
	/// For example:   
	/// Brief about Configuration  
	/// Basic configuration parallel coordinates is shown as follow:  option = {
	///     parallelAxis: [                     // Definitions of axes.
	///         {dim: 0, name: schema[0].text}, // Each axis has a 'dim' attribute, representing dimension index in data.
	///         {dim: 1, name: schema[1].text},
	///         {dim: 2, name: schema[2].text},
	///         {dim: 3, name: schema[3].text},
	///         {dim: 4, name: schema[4].text},
	///         {dim: 5, name: schema[5].text},
	///         {dim: 6, name: schema[6].text},
	///         {dim: 7, name: schema[7].text,
	///             type: 'category',           // Also supports category data.
	///             data: ['Excellent', 'good', 'light pollution', 'moderate pollution', 'heavy pollution', 'severe pollution']
	///         }
	///     ],
	///     parallel: {                         // Definition of a parallel coordinate system.
	///         left: '5%',                     // Location of parallel coordinate system.
	///         right: '13%',
	///         bottom: '10%',
	///         top: '20%',
	///         parallelAxisDefault: {          // A pattern for axis definition, which can avoid repeating in `parallelAxis`.
	///             type: 'value',
	///             nameLocation: 'end',
	///             nameGap: 20
	///         }
	///     },
	///     series: [                           // Here the three series sharing the same parallel coordinate system.
	///         {
	///             name: 'Beijing',
	///             type: 'parallel',           // The type of this series is 'parallel'
	///             data: [
	///                 [1,  55,  9,   56,  0.46,  18,  6,  'good'],
	///                 [2,  25,  11,  21,  0.65,  34,  9,  'excellent'],
	///                 ...
	///             ]
	///         },
	///         {
	///             name: 'Shanghai',
	///             type: 'parallel',
	///             data: [
	///                 [3,  56,  7,   63,  0.3,   14,  5,  'good'],
	///                 [4,  33,  7,   29,  0.33,  16,  6,  'excellent'],
	///                 ...
	///             ]
	///         },
	///         {
	///             name: 'Guangzhou',
	///             type: 'parallel',
	///             data: [
	///                 [4,  33,  7,   29,  0.33,  16,  6,  'excellent'],
	///                 [5,  42,  24,  44,  0.76,  40,  16, 'excellent'],
	///                 ...
	///             ]
	///         }
	///     ]
	/// };  
	/// Three components are involved here: parallel , parallelAxis , series-parallel   
	/// parallel  
	/// This component is the coordinate system.
	/// One or more series (like "Beijing", "Shanghai", and "Guangzhou" in the above example) can share one coordinate system.
	///  
	/// Like other coordinate systems, multiple parallel coordinate systems can be created in one echarts instance.
	///  
	/// Position setting is also carried out here.
	///   
	/// parallelAxis  
	/// This is axis configuration.
	/// Multiple axes are needed in parallel coordinates.
	///  
	///  parallelAxis.parallelIndex is used to specify which coordinate system this axis belongs to.
	/// The first coordinate system is used by default.
	///   
	/// series-parallel  
	/// This is the definition of parallel series, which will be drawn on parallel coordinate system.
	///  
	///  parallelAxis.parallelIndex is used to specify which coordinate system this axis belongs to.
	/// The first coordinate system is used by default.
	///    
	/// Notes and Best Practices  
	/// When configuring multiple parallelAxis , there might be some common attributes in each axis configuration.
	/// To avoid writing them repeatly, they can be put under parallel.parallelAxisDefault .
	/// Before initializing axis, configurations in parallel.parallelAxisDefault will be merged into parallelAxis to generate the final axis configuration.
	///  
	/// If data is too large and cause bad performance  
	/// It is suggested to set series-parallel.lineStyle.width to be 0.5 (or less), which may improve performance significantly.
	///  
	/// Display High-Dimension Data  
	/// When dimension number is extremely large, say, more than 50 dimensions, there will be more than 50 axes, which may hardly display in a page.
	///  
	/// In this case, you may use parallel.axisExpandable to improve the display.
	/// See this example:
	/// </summary>
	[JsonPropertyName("parallel")]
	public Parallel? Parallel { get; set; } 

	/// <summary>
	/// This component is the coordinate axis for parallel coordinate.
	///  
	/// Introduction about Parallel coordinates  
	/// Parallel Coordinates is a common way of visualizing high-dimensional geometry and analyzing multivariate data.
	///  
	/// For example, series-parallel.data is the following data:  [
	///     [1,  55,  9,   56,  0.46,  18,  6,  'good'],
	///     [2,  25,  11,  21,  0.65,  34,  9,  'excellent'],
	///     [3,  56,  7,   63,  0.3,   14,  5,  'good'],
	///     [4,  33,  7,   29,  0.33,  16,  6,  'excellent'],
	///     { // Data item can also be an Object, so that perticular settings of its line can be set here.
	///         value: [5,  42,  24,  44,  0.76,  40,  16, 'excellent']
	///         lineStyle: {...},
	///     }
	///     ...
	/// ]  
	/// In data above, each row is a "data item", and each column represents a "dimension".
	/// For example, the meanings of columns above are: "data", "AQI", "PM2.5", "PM10", "carbon monoxide level", "nitrogen dioxide level", and "sulfur dioxide level".
	///  
	/// Parallel coordinates are often used to visualize multi-dimension data shown above.
	/// Each axis represents a dimension (namely, a column), and each line represents a data item.
	/// Data can be brush-selected on axes.
	/// For example:   
	/// Brief about Configuration  
	/// Basic configuration parallel coordinates is shown as follow:  option = {
	///     parallelAxis: [                     // Definitions of axes.
	///         {dim: 0, name: schema[0].text}, // Each axis has a 'dim' attribute, representing dimension index in data.
	///         {dim: 1, name: schema[1].text},
	///         {dim: 2, name: schema[2].text},
	///         {dim: 3, name: schema[3].text},
	///         {dim: 4, name: schema[4].text},
	///         {dim: 5, name: schema[5].text},
	///         {dim: 6, name: schema[6].text},
	///         {dim: 7, name: schema[7].text,
	///             type: 'category',           // Also supports category data.
	///             data: ['Excellent', 'good', 'light pollution', 'moderate pollution', 'heavy pollution', 'severe pollution']
	///         }
	///     ],
	///     parallel: {                         // Definition of a parallel coordinate system.
	///         left: '5%',                     // Location of parallel coordinate system.
	///         right: '13%',
	///         bottom: '10%',
	///         top: '20%',
	///         parallelAxisDefault: {          // A pattern for axis definition, which can avoid repeating in `parallelAxis`.
	///             type: 'value',
	///             nameLocation: 'end',
	///             nameGap: 20
	///         }
	///     },
	///     series: [                           // Here the three series sharing the same parallel coordinate system.
	///         {
	///             name: 'Beijing',
	///             type: 'parallel',           // The type of this series is 'parallel'
	///             data: [
	///                 [1,  55,  9,   56,  0.46,  18,  6,  'good'],
	///                 [2,  25,  11,  21,  0.65,  34,  9,  'excellent'],
	///                 ...
	///             ]
	///         },
	///         {
	///             name: 'Shanghai',
	///             type: 'parallel',
	///             data: [
	///                 [3,  56,  7,   63,  0.3,   14,  5,  'good'],
	///                 [4,  33,  7,   29,  0.33,  16,  6,  'excellent'],
	///                 ...
	///             ]
	///         },
	///         {
	///             name: 'Guangzhou',
	///             type: 'parallel',
	///             data: [
	///                 [4,  33,  7,   29,  0.33,  16,  6,  'excellent'],
	///                 [5,  42,  24,  44,  0.76,  40,  16, 'excellent'],
	///                 ...
	///             ]
	///         }
	///     ]
	/// };  
	/// Three components are involved here: parallel , parallelAxis , series-parallel   
	/// parallel  
	/// This component is the coordinate system.
	/// One or more series (like "Beijing", "Shanghai", and "Guangzhou" in the above example) can share one coordinate system.
	///  
	/// Like other coordinate systems, multiple parallel coordinate systems can be created in one echarts instance.
	///  
	/// Position setting is also carried out here.
	///   
	/// parallelAxis  
	/// This is axis configuration.
	/// Multiple axes are needed in parallel coordinates.
	///  
	///  parallelAxis.parallelIndex is used to specify which coordinate system this axis belongs to.
	/// The first coordinate system is used by default.
	///   
	/// series-parallel  
	/// This is the definition of parallel series, which will be drawn on parallel coordinate system.
	///  
	///  parallelAxis.parallelIndex is used to specify which coordinate system this axis belongs to.
	/// The first coordinate system is used by default.
	///    
	/// Notes and Best Practices  
	/// When configuring multiple parallelAxis , there might be some common attributes in each axis configuration.
	/// To avoid writing them repeatly, they can be put under parallel.parallelAxisDefault .
	/// Before initializing axis, configurations in parallel.parallelAxisDefault will be merged into parallelAxis to generate the final axis configuration.
	///  
	/// If data is too large and cause bad performance  
	/// It is suggested to set series-parallel.lineStyle.width to be 0.5 (or less), which may improve performance significantly.
	///  
	/// Display High-Dimension Data  
	/// When dimension number is extremely large, say, more than 50 dimensions, there will be more than 50 axes, which may hardly display in a page.
	///  
	/// In this case, you may use parallel.axisExpandable to improve the display.
	/// See this example:
	/// </summary>
	[JsonPropertyName("parallelAxis")]
	public ParallelAxis? ParallelAxis { get; set; } 

	/// <summary>
	/// An axis with a single dimension.
	/// It can be used to display data in one dimension.
	/// For example:
	/// </summary>
	[JsonPropertyName("singleAxis")]
	public SingleAxis? SingleAxis { get; set; } 

	/// <summary>
	/// timeline component, which provides functions like switching and playing between multiple ECharts options .
	///  
	/// Here is an example:   
	/// Different from other cases, timeline component requires multiple options.
	/// We call first the parameter of setOption as ECOption , and call the traditional single ECharts option as ECUnitOption .
	///   In the case that timeline and media query are not set, an ECUnitOption is an ECOption .
	///  In the case that timeline or media query are set, an ECOption is made up with several ECUnitOption s.
	///  The properties at the root of ECOption form an ECUnitOption , which is also called baseOption , representing the default settings.
	///  Each item of the array options form an ECUnitOption , which can be also called switchableOption , representing options for each time tick.
	///    baseOption and one switchableOption are used to calculate the finalOption , based on which the chart will be final rendered.
	///   
	/// For example:  myChart.setOption({
	///     // This is the properties of `baseOption`.
	///     timeline: {
	///         ...,
	///         // each item in `timeline.data` corresponds to each
	///         // `option` in `options` array.
	///         data: ['2002-01-01', '2003-01-01', '2004-01-01']
	///     },
	///     title: {
	///         subtext: ' Data is from National Bureau of Statistics '
	///     },
	///     grid: { ...
	/// },
	///     xAxis: [ ...
	/// ],
	///     yAxis: [ ...
	/// ],
	///     series: [{
	///         // other configurations of series 1
	///         type: 'bar',
	///         ...
	///     }, {
	///         // other configurations of series 2
	///         type: 'line',
	///         ...
	///     }, {
	///         // other configurations of series 3
	///         type: 'pie',
	///         ...
	///     }],
	///     // `switchableOption`s:
	///     options: [{
	///         // it is an option corresponding to '2002-01-01'
	///         title: {
	///         text: 'the statistics of the year 2002'
	///         },
	///         series: [
	///             { data: [] }, // the data of series 1
	///             { data: [] }, // the data of series 2
	///             { data: [] }  // the data of series 3
	///         ]
	///     }, {
	///         // it is an option corresponding to '2003-01-01'
	///         title: {
	///             text: 'the statistics of the year 2003'
	///         },
	///         series: [
	///             { data: [] },
	///             { data: [] },
	///             { data: [] }
	///         ]
	///     }, {
	///         // it is an option corresponding to '2004-01-01'
	///         title: {
	///             text: 'the statistics of the year 2004'
	///         },
	///         series: [
	///             { data: [] },
	///             { data: [] },
	///             { data: [] }
	///         ]
	///     }]
	/// });  
	/// 
	///  How the finalOption calculated?  
	/// When initializing, a switchableOption corresponding to the current time tick are merged into baseOption to form the finalOption .
	/// Each time the current tick changed, the new switchableOption corresponding to the new time tick are merged into the finalOption .
	///  
	/// There are two merging strategy.
	///   By default, use NORMAL_MERGE .
	///  If timeline.replaceMerge is set, use REPLACE_MERGE .
	/// See setOption for more details of REPLACE_MERGE .
	///   
	/// 
	///  Compatibility with ECharts 4:  
	/// We also support these equivalent setting styles:  option = {
	///     baseOption: {
	///         timeline: {},
	///         series: [],
	///         // ...
	/// other properties of baseOption.
	///     },
	///     options: []
	/// };
	/// </summary>
	[JsonPropertyName("timeline")]
	public Timeline? Timeline { get; set; } 

	/// <summary>
	/// graphic component enables creating graphic elements in ECharts.
	///  
	/// Those graphic type are supported.
	///  
	/// image , text , circle , sector , ring , polygon , polyline , rect , line , bezierCurve , arc , group ,  
	/// This example shows how to make a watermark and text block:   
	/// This example use hidden graphic elements to implement dragging:   
	/// Graphic Component Configuration  
	/// A simple way to define a graphic element:  myChart.setOption({
	///     ...,
	///     graphic: {
	///         type: 'image',
	///         ...
	///     }
	/// });  
	/// Define multiple graphic elements:  myChart.setOption({
	///     ...,
	///     graphic: [
	///         { // A 'image' element.
	///             type: 'image',
	///             ...
	///         },
	///         { // A 'text' element, with id specified.
	///             type: 'text',
	///             id: 'text1',
	///             ...
	///         },
	///         { // A 'group' element, in which children can be defined.
	///             type: 'group',
	///             children: [
	///                 {
	///                     type: 'rect',
	///                     id: 'rect1',
	///                     ...
	///                 },
	///                 {
	///                     type: 'image',
	///                     ...
	///                 },
	///                 ...
	///             ]
	///         }
	///         ...
	///     ]
	/// });  
	/// How to remove or replace existing elements by setOption :  myChart.setOption({
	///     ...,
	///     graphic: [
	///         { // Remove the element 'text1' defined above.
	///             id: 'text1',
	///             $action: 'remove',
	///             ...
	///         },
	///         { // Replace the element 'rect1' to a new circle element.
	///           // Note, although in the sample above 'rect1' is a children of a group,
	///           // it is not necessary to consider level relationship when setOption
	///           // again if you use id to specify them.
	///             id: 'rect1',
	///             $action: 'replace',
	///             type: 'circle',
	///             ...
	///         }
	///     ]
	/// });  
	/// Notice, when using setOption to modify existing elements, if id is not specified, new options will be mapped to existing elements by their order, which might bring unexpected result sometimes.
	/// So, generally, using id is recommended.
	///  
	/// Graphic Element Configuration  
	/// Different types of graphic elements has their own configuration respectively, but they have these common configuration below:  {
	///     // id is used to specifying element when willing to update it.
	///     // id can be ignored if you do not need it.
	///     id: 'xxx',
	/// 
	///     // Specify element type.
	/// Can not be ignored when define a element at the first time.
	///     type: 'image',
	/// 
	///     // All of the properties below can be ignored and a default value will be assigned.
	/// 
	///     // Specify the operation should be performed to the element when calling `setOption`.
	///     // Default value is 'merge', other values can be 'replace' or 'remove'.
	///     $action: 'replace',
	/// 
	///     // These four properties is used to locating the element.
	/// Each property can be absolute
	///     // value (like 10, means 10 pixel) or precent (like '12%') or 'center'/'middle'.
	///     left: 10,
	///     // right: 10,
	///     top: 'center',
	///     // bottom: '10%',
	/// 
	///     shape: {
	///         // Here are configurations for shape, like `x`, `y`, `cx`, `cy`, `width`,
	///         // `height`, `r`, `points`, ...
	///         // Note, if `left`/`right`/`top`/`bottom` has been set, `x`/`y`/`cx`/`cy`
	///         // do not work here.
	///     },
	/// 
	///     style: {
	///         // Here are configurations for style of the element, like `fill`, `stroke`,
	///         // `lineWidth`, `shadowBlur`, ...
	///     },
	/// 
	///     // z value of the elements.
	///     z: 10,
	///     // Whether response to mouse events / touch events.
	///     silent: true,
	///     // Whether the element is visible.
	///     invisible: false,
	///     // Used to specify whether the entire transformed element (containing children if is group)
	///     // is confined in its container.
	/// Optional values: 'raw', 'all'.
	///     bounding: 'raw',
	///     // Can be dragged or not.
	///     draggable: false,
	///     // Event handler, can also be onmousemove, ondrag, ...
	/// (listed below)
	///     onclick: function () {...}
	/// }  
	/// Event Handlers of Graphic Element  
	/// These events are supported: onclick , onmouseover , onmouseout , onmousemove , onmousewheel , onmousedown , onmouseup , ondrag , ondragstart , ondragend , ondragenter , ondragleave , ondragover , ondrop .
	///  
	/// Hierarchy of Graphic Elements  
	/// Only group element has children, which enable a group of elements to be positioned and transformed together.
	///  
	/// Shape Configuration of Graphic Element  
	/// Elements with different types have different shape setting repectively.
	/// For example:  {
	///     type: 'rect',
	///     shape: {
	///         x: 10,
	///         y: 10,
	///         width: 100,
	///         height: 200
	///     }
	/// },
	/// {
	///     type: 'circle',
	///     shape: {
	///         cx: 20,
	///         cy: 30,
	///         r: 100
	///     }
	/// },
	/// {
	///     type: 'image',
	///     style: {
	///         image: 'http://example.website/a.png',
	///         x: 100,
	///         y: 200,
	///         width: 230,
	///         height: 400
	///     }
	/// },
	/// {
	///     type: 'text',
	///     style: {
	///         text: 'This text',
	///         x: 100,
	///         y: 200
	///     }
	/// 
	/// }  
	/// Transforming and Absolutely Positioning of Graphic Element  
	/// Element can be transformed (translation, rotation, scale).
	/// See position , rotation , scale , origin  
	/// For example:  {
	///     type: 'rect', // or any other types.
	/// 
	///     // Translation, using [0, 0] by default.
	///     position: [100, 200],
	/// 
	///     // Scale, using [1, 1] by default.
	///     scale: [2, 4],
	/// 
	///     // Rotation, using 0 by default.
	/// Negative value means rotating clockwise.
	///     rotation: Math.PI / 4,
	/// 
	///     // Origin point of rotation and scale, using [0, 0] by default.
	///     origin: [10, 20],
	/// 
	///     shape: {
	///         // ...
	///     }
	/// }  
	/// Each element is transformed in the coordinate system of its parent, namely, transform of a element and its parent can be "stacked".
	///  
	/// Transformation is performed by this order:   Translate [-el.origin[0], -el.origin[1]].
	///  Scale according to el.scale.
	///  Rotate according to el.rotation.
	///  Translate back according to el.origin.
	///  Translate according to el.position.
	///   
	/// Namely, scaling and rotating firstly, and then translate.
	/// By this mechanism, translation does not affect origin of scale and rotation.
	///  
	/// Relatively Positioning  
	/// In real application, size of a container is always not fixed.
	/// So mechanism of relative position is required.
	/// In graphic component, left / right / top / bottom / width / height are used to position element relatively.
	///  
	/// For example:  { // Position the image at the bottom center of its container.
	///     type: 'image',
	///     left: 'center', // Position at the center horizontally.
	///     bottom: '10%',  // Position beyond the bottom boundary 10%.
	///     style: {
	///         image: 'http://example.website/a.png',
	///         width: 45,
	///         height: 45
	///     }
	/// },
	/// { // Position the entire rotated group at the right-bottom corner of its container.
	///     type: 'group',
	///     right: 0,  // Position at the right boundary.
	///     bottom: 0, // Position at the bottom boundary.
	///     rotation: Math.PI / 4,
	///     children: [
	///         {
	///             type: 'rect',
	///             left: 'center', // Position at horizontal center according to its parent.
	///             top: 'middle',  // Position at vertical center according to its parent.
	///             shape: {
	///                 width: 190,
	///                 height: 90
	///             },
	///             style: {
	///                 fill: '#fff',
	///                 stroke: '#999',
	///                 lineWidth: 2,
	///                 shadowBlur: 8,
	///                 shadowOffsetX: 3,
	///                 shadowOffsetY: 3,
	///                 shadowColor: 'rgba(0,0,0,0.3)'
	///             }
	///         },
	///         {
	///             type: 'text',
	///             left: 'center', // Position at horizontal center according to its parent.
	///             top: 'middle',  // Position at vertical center according to its parent.
	///             style: {
	///                 fill: '#777',
	///                 text: [
	///                     'This is text',
	///                     'This is text',
	///                     'Print some text'
	///                 ].join('\n'),
	///                 font: '14px Microsoft YaHei'
	///             }
	///         }
	///     ]
	/// }  
	/// Note, bounding can be used to specify whether the entire transformed element (containing children if is group) is confined in its container.
	/// </summary>
	[JsonPropertyName("graphic")]
	public object? Graphic { get; set; } 

	/// <summary>
	/// Calendar coordinates.
	///  
	/// In ECharts, we are very creative to achieve the calendar chart, by using the calendar coordinates to achieve the calendar chart,
	/// as shown in the following example, we can use calendar coordinates in heatmap, scatter, effectScatter, and graph.
	///  
	/// Example of using heatmap in calendar coordinates:   
	/// Example of using effectScatter in calendar coordinates:   
	/// Example of using graph in calendar coordinates:   
	/// By combining calendar coordinate system and charts, you may be able to create more wonderful effects.
	///  
	/// Display Text in Calendar , Display Pies in Calendar   
	/// Calendar layout  
	/// Calendar coordinate system can be placed horizontally or vertically.
	/// By convention, the heatmap calendar is horizontal.
	/// But if we need bigger cell size in other cases, the total width may be too wide.
	/// So calendar.orient can help in this case.
	///   
	/// Adapt to container size  
	/// Calendar coordinate system can be configured to adapt to container size, which is useful when page size is not sure.
	/// First of all, like other components, those location and size configurations can be specified on canlendar: left  right  top  bottom  width  height , which make calendar possible to modify its size according to container size.
	/// Besides, cellSize can be specified to fix the size of each cell of calendar.
	/// </summary>
	[JsonPropertyName("calendar")]
	public Calendar? Calendar { get; set; } 

	/// <summary>
	/// dataset component is published since ECharts 4.
	/// dataset brings convenience in data management separated with styles and enables data reuse by different series.
	/// More importantly, it enables data encoding from data to visual, which brings convenience in some scenarios.
	///  
	/// More details about dataset can be checked in the tutorial .
	/// </summary>
	[JsonPropertyName("dataset")]
	public Dataset? Dataset { get; set; } 

	/// <summary>
	/// The W3C has developed the WAI-ARIA , the Accessible Rich Internet Applications Suite, which is dedicated to making web content and web applications accessible.
	/// Apache ECharts 4 complies with this specification by supporting the automatic generation of intelligent descriptions based on chart configuration items, allowing blind people to understand the chart content with the help of a reading device, making the chart accessible to a wider audience.
	/// In addition, Apache ECharts 5 adds support for applique textures as an auxiliary expression of color to further differentiate the data.
	///  
	/// It is turned off by default and needs to be turned on by setting aria.enabled to true .
	/// </summary>
	[JsonPropertyName("aria")]
	public object? Aria { get; set; } 

	/// <summary>
	/// To specify whether it's dark mode.
	///  
	/// ECharts will automatically detect it via backgroundColor by default and adjust the text color accordingly.
	///  
	/// This option is usually used in themes.
	/// </summary>
	[JsonPropertyName("darkMode")]
	public bool? DarkMode { get; set; } 

	/// <summary>
	/// The color list of palette.
	/// If no color is set in series, the colors would be adopted sequentially and circularly from this list as the colors of series.
	///  
	/// Defaults:  ['#5470c6', '#91cc75', '#fac858', '#ee6666', '#73c0de', '#3ba272', '#fc8452', '#9a60b4', '#ea7ccc']  
	/// Supported color formats.
	///   
	/// Use RGB for colors, like 'rgb(128, 128, 128)' , or RGBA if you want to add an alpha channel for opacity, like 'rgba(128, 128, 128, 0.5) , or use hex string, like '#ccc' .
	///   
	/// Gradient Color or Pattern  // Linear gradient with first four parameters x0, y0, x2, y2, ranging from 0 - 1, corresponding to the percentage in the graphical wraparound box, if globalCoord is ``true``, then the four values are absolute pixel positions
	/// {
	///   type: 'linear',
	///   x: 0,
	///   y: 0,
	///   x2: 0,
	///   y2: 1,
	///   colorStops: [{
	///       offset: 0, color: 'red' // color at 0%
	///   }, {
	///       offset: 1, color: 'blue' // color at 100%
	///   }],
	///   global: false // default is false
	/// }
	/// // Radial gradient, the first three parameters are the center x, y and radius, the values are the same as the linear gradient
	/// {
	///   type: 'radial',
	///   x: 0.5,
	///   y: 0.5,
	///   r: 0.5,
	///   colorStops: [{
	///       offset: 0, color: 'red' // color at 0%
	///   }, {
	///       offset: 1, color: 'blue' // color at 100%
	///   }],
	///   global: false // default is false
	/// }
	/// // Pattern
	/// {
	///   image: imageDom, // supported as HTMLImageElement, HTMLCanvasElement, but not path string of SVG
	///   repeat: 'repeat' // whether to tile, can be 'repeat-x', 'repeat-y', 'no-repeat'
	/// }
	/// </summary>
	[JsonPropertyName("color")]
	//TODO: Type Warning: array type 'color' in 'chartOptions' will be mapped to List<object>
	public List<object>? Color { get; set; } 

	/// <summary>
	/// Background color.
	/// No background by default.
	///   
	/// Supports setting as solid color using rgb(255,255,255) , rgba(255,255,255,1) , #fff , etc.
	/// Also supports setting as gradient color and pattern fill, see option.color for details
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	public Color? BackgroundColor { get; set; } 

	/// <summary>
	/// Global font style.
	/// </summary>
	[JsonPropertyName("textStyle")]
	public TextStyle? TextStyle { get; set; } 

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
	[DefaultValue("cubicOut")]
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

	/// <summary>
	/// Animation configurations of state switchment.
	/// Can be configured in each series individually.
	/// </summary>
	[JsonPropertyName("stateAnimation")]
	public StateAnimation? StateAnimation { get; set; } 

	/// <summary>
	/// Sets the type of compositing operation to apply when drawing a new shape.
	/// See the different type: https://developer.mozilla.org/en-US/docs/Web/API/CanvasRenderingContext2D/globalCompositeOperation .
	///  
	/// The default is 'source-over' .
	/// Support settings for each series.
	///  
	/// 'lighter' is also a common type of compositing operation.
	/// In this mode, the area where the number of graphics is concentrated is superimposed into a high-brightness color (white).
	/// It often used to highlight the effect of the area.
	/// See example Global airline
	/// </summary>
	[JsonPropertyName("blendMode")]
	[DefaultValue("source-over")]
	public BlendMode? BlendMode { get; set; } 

	/// <summary>
	/// When the number of element of the whole chart is larger than hoverLayerThreshold , a seperate hover layer is used to render hovered elements.
	///  
	/// The seperate hover layer is used to avoid re-painting the whole canvas when hovering on elements.
	/// Instead, the hovered elements are rendered in a seperate layer so that other elements don't have to be rendered again.
	///  
	/// ECharts 2 use seperate layer for all cases.
	/// But it brings some problems like the hovered elements may not covering everything else correctly, or translucent elements may not overlay correctly to each other.
	/// And it brings extra member cost due to the extra canvas and may bring burden on mobile devices.
	/// So since ECharts 3, the hover layer is not used by default.
	/// Only when the element amount is large enough will the hover layer used.
	/// </summary>
	[JsonPropertyName("hoverLayerThreshold")]
	[DefaultValue(3000)]
	public double? HoverLayerThreshold { get; set; } 

	/// <summary>
	/// Whether to use UTC in display.
	///   true : When axis.type is 'time' , ticks is determined according to UTC, and axisLabel and tooltip use UTC by default.
	///  false : When axis.type is 'time' , ticks is determined according to local time, and axisLabel and tooltip use local time by default.
	///   
	/// The default value of useUTC is false, for sake of considering:   In many cases, labels should be displayed in local time (whether the time is stored in server in local time or UTC).
	///  If user uses time string (like '2012-01-02') in data, it usually means local time if time zone is not specified.
	/// Time should be displayed in its original time zone by default.
	///   
	/// Notice: the setting only affects "display time", not "parse time".
	/// For how time value (like 1491339540396 , '2013-01-04' , ...) is parsed in echarts, see the time part in date .
	/// </summary>
	[JsonPropertyName("useUTC")]
	[DefaultValue(false)]
	public bool? UseUTC { get; set; } 

	/// <summary>
	/// Option array used in timeline .
	/// Each item of this array is an echarts option ( ECUnitOption ).
	/// </summary>
	[JsonPropertyName("options")]
	//TODO: Type Warning: array type 'options' in 'chartOptions' will be mapped to List<object>
	public List<object>? Options { get; set; } 

	/// <summary>
	/// See Responsive Mobile-End for details.
	/// </summary>
	[JsonPropertyName("media")]
	public List<ChartOptionsMedia>? Media { get; set; } 

	[JsonPropertyName("series")]
	public List<object>? Series { get; set; } 

}
