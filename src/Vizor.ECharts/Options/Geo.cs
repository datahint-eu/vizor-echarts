
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Geo
{
	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; } 

	/// <summary>
	/// Whether to show the geo component.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue(true)]
	public bool? Show { get; set; } 

	/// <summary>
	/// Map name registered in registerMap .
	///  
	/// Use geoJSON  $.get('map/china_geo.json', function (chinaJson) {
	///     echarts.registerMap('china', {geoJSON: geoJson});
	///     var chart = echarts.init(document.getElementById('main'));
	///     chart.setOption({
	///         geo: [{
	///             map: 'china',
	///             ...
	///         }]
	///     });
	/// });  
	/// See also geoJSON hexbin .
	///  
	/// The demo above shows that ECharts can uses geoJSON format as map outline.
	/// You can use third-party geoJSON data (like maps ) and register them into ECharts.
	///  
	/// Use SVG  $.get('map/topographic_map.svg', function (svg) {
	///     echarts.registerMap('topo', {svg: svg});
	///     var chart = echarts.init(document.getElementById('main'));
	///     chart.setOption({
	///         geo: [{
	///             map: 'topo',
	///             ...
	///         }]
	///     });
	/// });  
	/// See also Flight Seatmap .
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
	/// Center of current view-port, in longitude and latitude by default.
	/// Use the projected coordinates if projection is set.
	///  
	/// Example:  center: [115.97, 29.71]  projection: {
	///     projection: (pt) => project(pt)
	/// },
	/// center: project([115.97, 29.71])
	/// </summary>
	[JsonPropertyName("center")]
	public NumberOrStringArray? Center { get; set; } 

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
	public double[]? BoundingCoords { get; set; } 

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
	/// Since v5.1.0   
	/// Map area style in blurred state.
	/// </summary>
	[JsonPropertyName("blur")]
	public Blur? Blur { get; set; } 

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
	public NumberOrStringArray? LayoutCenter { get; set; } 

	/// <summary>
	/// Size of map, see layoutCenter for more information.
	/// Percentage relative to screen width, and absolute pixel values are supported.
	/// </summary>
	[JsonPropertyName("layoutSize")]
	public NumberOrString? LayoutSize { get; set; } 

	/// <summary>
	/// Configure style for specified regions.
	/// For example:  regions: [{
	///     name: 'Guangdong',
	///     itemStyle: {
	///         areaColor: 'red',
	///         color: 'red'
	///     }
	/// }]  
	/// The region color can also be controlled by map series.
	/// See series-map.geoIndex .
	/// </summary>
	[JsonPropertyName("regions")]
	public List<GeoRegion>? Regions { get; set; } 

	/// <summary>
	/// Whether to ignore mouse events.
	/// Default value is false, for triggering and responding to mouse events.
	/// </summary>
	[JsonPropertyName("silent")]
	[DefaultValue(false)]
	public bool? Silent { get; set; } 

	/// <summary>
	/// Since v5.1.0   
	/// tooltip settings in the coordinate system component.
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

}
