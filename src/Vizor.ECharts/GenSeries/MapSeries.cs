// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class MapSeries
{
	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("map")]
	public string? Type { get; set; }  = "map";

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
	[DefaultValue("series")]
	public ColorBy? ColorBy { get; set; } 

	/// <summary>
	/// Map name registered in registerMap .
	///  
	/// Use geoJSON  $.get('map/china_geo.json', function (geoJson) {
	///     echarts.registerMap('china', {geoJSON: geoJson});
	///     var chart = echarts.init(document.getElementById('main'));
	///     chart.setOption({
	///         series: [{
	///             type: 'map',
	///             map: 'china',
	///             ...
	///         }]
	///     });
	/// });  
	/// See also USA Population Estimates .
	///  
	/// The demo above shows that ECharts can uses geoJSON format as map outline.
	/// You can use third-party geoJSON data (like maps ) and register them into ECharts.
	///  
	/// Use SVG  $.get('map/topographic_map.svg', function (svg) {
	///     echarts.registerMap('topo', {svg: svg});
	///     var chart = echarts.init(document.getElementById('main'));
	///     chart.setOption({
	///         series: [{
	///             type: 'map',
	///             map: 'topo',
	///             ...
	///         }]
	///     });
	/// });  
	/// See also Beef Cuts .
	///  
	/// The demo above shows that SVG format can be used in ECharts.
	/// See more info in SVG Base Map .
	/// </summary>
	[JsonPropertyName("map")]
	[DefaultValue("")]
	public string? Map { get; set; } 

	/// <summary>
	/// Whether to enable mouse zooming and translating.
	/// false by default.
	/// If either zooming or translating is wanted, it can be set to 'scale' or 'move' .
	/// Otherwise, set it to be true to enable both.
	/// </summary>
	[JsonPropertyName("roam")]
	[DefaultValue(false)]
	public Roam? Roam { get; set; } 

	/// <summary>
	/// Since v5.3.0   
	/// For custom map projection, at least two methods project , unproject should be provided to calculate the coordinates after projection and before projection respectively.
	///  
	/// For example, for the Mercator projection.
	///  series: {
	///     type: 'map',
	///     projection: {
	///         project: (point) => [point[0] / 180 * Math.PI, -Math.log(Math.tan((Math.PI / 2 + point[1] / 180 * Math.PI) / 2))],
	///         unproject: (point) => [point[0] * 180 / Math.PI, 2 * 180 / Math.PI * Math.atan(Math.exp(point[1])) - 90]
	///     }
	/// }  
	/// In addition to our own implementation of the projection formula, we can also use exists projection implementations provided by third-party libraries such as d3-geo .
	///  const projection = d3.geoConicEqualArea();
	/// // ...
	/// series: {
	///     type: 'map',
	///     projection: {
	///         project: (point) => projection(point),
	///         unproject: (point) => projection.invert(point)
	///     }
	/// }  
	/// Note: Custom projections are only useful when using GeoJSON as a data source.
	/// </summary>
	[JsonPropertyName("projection")]
	public Projection? Projection { get; set; } 

	/// <summary>
	/// Center of current view-port.
	/// It can be an arrary containing two number s in pixels or string s in percentage relative to the container width/height.
	/// string is supported from version 5.3.3 .
	///  
	/// Example:  center: [115.97, '30%']
	/// </summary>
	[JsonPropertyName("center")]
	public List<object>? Center { get; set; } 

	/// <summary>
	/// Used to scale aspect of geo.
	/// Will be ignored if projection is set.
	///  
	/// The final aspect is calculated by: geoBoundingRect.width / geoBoundingRect.height * aspectScale .
	/// </summary>
	[JsonPropertyName("aspectScale")]
	[DefaultValue(0.75)]
	public double? AspectScale { get; set; } 

	/// <summary>
	/// Two dimension array.
	/// Define coord of left-top, right-bottom in layout box.
	///  // A complete world map
	/// map: 'world',
	/// left: 0, top: 0, right: 0, bottom: 0,
	/// boundingCoords: [
	///     // [lng, lat] of left-top corner
	///     [-180, 90],
	///     // [lng, lat] of right-bottom corner
	///     [180, -90]
	/// ],
	/// </summary>
	[JsonPropertyName("boundingCoords")]
	public List<object>? BoundingCoords { get; set; } 

	/// <summary>
	/// Zoom rate of current view-port.
	/// </summary>
	[JsonPropertyName("zoom")]
	[DefaultValue(1)]
	public double? Zoom { get; set; } 

	/// <summary>
	/// Limit of scaling, with min and max .
	/// 1 by default.
	/// </summary>
	[JsonPropertyName("scaleLimit")]
	public ScaleLimit? ScaleLimit { get; set; } 

	/// <summary>
	/// Name mapping for customized areas.
	/// For example:  {
	///     'China' : '中国'
	/// }
	/// </summary>
	[JsonPropertyName("nameMap")]
	public NameMap? NameMap { get; set; } 

	/// <summary>
	/// Since v4.8.0   
	/// customized property key for GeoJSON feature.
	/// By default, 'name' is used as primary key to identify GeoJSON feature.
	/// For example:  {
	///     nameProperty: 'NAME', // key to connect following data point to GeoJSON region {"type":"Feature","id":"01","properties":{"NAME":"Alabama"}, "geometry": { ...
	/// }}
	///     data:[
	///         {name: 'Alabama', value: 4822023},
	///         {name: 'Alaska', value: 731449},
	///     ]
	/// }
	/// </summary>
	[JsonPropertyName("nameProperty")]
	[DefaultValue("name")]
	public string? NameProperty { get; set; } 

	/// <summary>
	/// Selected mode decides whether multiple selecting is supported.
	/// By default, false is used for disabling selection.
	/// Its value can also be 'single' for selecting single area, or 'multiple' for selecting multiple areas.
	/// </summary>
	[JsonPropertyName("selectedMode")]
	[DefaultValue(false)]
	public SelectionMode? SelectedMode { get; set; } 

	/// <summary>
	/// Text label of , to explain some data information about graphic item like value, name and so on.
	/// label is placed under itemStyle in ECharts 2.x.
	/// In ECharts 3, to make the configuration structure flatter, label is taken to be at the same level with itemStyle , and has emphasis as itemStyle does.
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// Graphic style of Map Area Border, emphasis is the style when it is highlighted, like being hovered by mouse, or highlighted via legend connect.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// Map area style in highlighted state.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

	/// <summary>
	/// Map area style in selected state.
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; } 

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
	/// Distance between  component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue("auto")]
	public NumberOrString? Left { get; set; } 

	/// <summary>
	/// Distance between  component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue("auto")]
	public NumberOrString? Top { get; set; } 

	/// <summary>
	/// Distance between  component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue("auto")]
	public NumberOrString? Right { get; set; } 

	/// <summary>
	/// Distance between  component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue("auto")]
	public NumberOrString? Bottom { get; set; } 

	/// <summary>
	/// layoutCenter and layoutSize provides layout strategy other than left/right/top/bottom/width/height .
	///  
	/// When using left/right/top/bottom/width/height , it is hard to put the map inside a box area with a fixed width-height ratio.
	/// In this case, layoutCenter attribute can be used to define the center position of map, and layoutSize can be used to define the size of map.
	/// For example:  layoutCenter: ['30%', '30%'],
	/// // If width-height ratio is larger than 1, then width is set to be 100.
	/// // Otherwise, height is set to be 100.
	/// // This makes sure that it will not exceed the area of 100x100
	/// layoutSize: 100  
	/// After setting these two values, left/right/top/bottom/width/height becomes invalid.
	/// </summary>
	[JsonPropertyName("layoutCenter")]
	public List<object>? LayoutCenter { get; set; } 

	/// <summary>
	/// Size of map, see layoutCenter for more information.
	/// Percentage relative to screen width, and absolute pixel values are supported.
	/// </summary>
	[JsonPropertyName("layoutSize")]
	public NumberOrString? LayoutSize { get; set; } 

	/// <summary>
	/// In default case, map series create exclusive geo component for themselves.
	/// But geoIndex can be used to specify an outer geo component , which can be shared with other series like pie .
	/// Moreover, the region color of the outer geo component can be controlled by the map series (via visualMap ).
	///  
	/// When geoIndex specified, series-map.map other style configurations like series-map.itemStyle will not work, but corresponding configurations in geo component will be used.
	///  
	/// For example:
	/// </summary>
	[JsonPropertyName("geoIndex")]
	public int? GeoIndex { get; set; } 

	/// <summary>
	/// Value of multiple series with the same map type can use this option to get a statistical value.
	///  
	/// Supported statistical methods:   'sum'  'average'  'max'  'min'
	/// </summary>
	[JsonPropertyName("mapValueCalculation")]
	[DefaultValue("sum")]
	public string? MapValueCalculation { get; set; } 

	/// <summary>
	/// Show the symbol in related area (dot of series symbol).
	/// Available when legend component exists.
	/// </summary>
	[JsonPropertyName("showLegendSymbol")]
	public bool? ShowLegendSymbol { get; set; } 

	/// <summary>
	/// When dataset is used, seriesLayoutBy specifies whether the column or the row of dataset is mapped to the series, namely, the series is "layout" on columns or rows.
	/// Optional values:   'column': by default, the columns of dataset are mapped the series.
	/// In this case, each column represents a dimension.
	///  'row'：the rows of dataset are mapped to the series.
	/// In this case, each row represents a dimension.
	///   
	/// Check this example .
	/// </summary>
	[JsonPropertyName("seriesLayoutBy")]
	[DefaultValue("column")]
	public SeriesLayoutBy? SeriesLayoutBy { get; set; } 

	/// <summary>
	/// If series.data is not specified, and dataset exists, the series will use dataset .
	/// datasetIndex specifies which dataset will be used.
	/// </summary>
	[JsonPropertyName("datasetIndex")]
	[DefaultValue(0)]
	public int? DatasetIndex { get; set; } 

	/// <summary>
	/// A groupID common to all data in the series.
	/// the groupID will be used to classify the data and determine how merge and split animations are performed in the universal transition animation.
	///  
	/// If you are using the dataset component to represent the data, it is recommended to use encode.itemGroupID to specify which dimension is encoded as the groupID.
	/// </summary>
	[JsonPropertyName("dataGroupId")]
	public string? DataGroupId { get; set; } 

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
	/// Since v5.0.0   
	/// Configuration of label guide line.
	/// </summary>
	[JsonPropertyName("labelLine")]
	public LabelLine? LabelLine { get; set; } 

	/// <summary>
	/// Data array of map series, which can be a single data value, like:  [12, 34, 56, 10, 23]  
	/// Or, if need extra dimensions for components like visualMap to map to graphic attributes like color, it can also be in the form of array.
	/// For example:  [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]  
	/// In this case, we can assgin the second value in each array item to visualMap component.
	///  
	/// More likely, we need to assign name to each data item, in which case each item should be an object:  [{
	///     // name of date item
	///     name: 'data1',
	///     // value of date item is 8
	///     value: 10
	/// }, {
	///     name: 'data2',
	///     value: 20
	/// }]  
	/// Each data item can be further customized:  [{
	///     name: 'data1',
	///     value: 10
	/// }, {
	///     // name of data item
	///     name: 'data2',
	///     value : 56,
	///     // user-defined label format that only useful for this data item
	///     label: {},
	///     // user-defined special itemStyle that only useful for this data item
	///     itemStyle:{}
	/// }]
	/// </summary>
	[JsonPropertyName("data")]
	public List<MapSeriesData>? Data { get; set; } 

	/// <summary>
	/// Mark point in a chart.
	/// </summary>
	[JsonPropertyName("markPoint")]
	public MarkPoint? MarkPoint { get; set; } 

	/// <summary>
	/// Use a line in the chart to illustrate.
	/// </summary>
	[JsonPropertyName("markLine")]
	public MarkLine? MarkLine { get; set; } 

	/// <summary>
	/// Used to mark an area in chart.
	/// For example, mark a time interval.
	/// </summary>
	[JsonPropertyName("markArea")]
	public MarkArea? MarkArea { get; set; } 

	/// <summary>
	/// Whether to ignore mouse events.
	/// Default value is false, for triggering and responding to mouse events.
	/// </summary>
	[JsonPropertyName("silent")]
	[DefaultValue(false)]
	public bool? Silent { get; set; } 

	/// <summary>
	/// Since v5.2.0   
	/// Configuration related to universal transition animation.
	///  
	/// Universal Transition provides the ability to morph between any series.
	/// With this feature enabled, each time setOption , transitions between series with the same id will be automatically associated with each other.
	///  
	/// One-to-many or many-to-one animations such as drill-down, aggregation, etc.
	/// can also be achieved by specifying groups of data such as encode.itemGroupId or dataGroupId .
	///  
	/// This can be enabled directly by configuring universalTransition: true in the series.
	/// It is also possible to provide an object for more detailed configuration.
	/// </summary>
	[JsonPropertyName("universalTransition")]
	public UniversalTransition? UniversalTransition { get; set; } 

	/// <summary>
	/// tooltip settings in this series.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

}
