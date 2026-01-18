// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// ECharts Version: 6.0.0
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class MapSeries : ISeries
{
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
    /// <![CDATA[
    /// Since v5.2.0   
    /// The policy to take color from option.color .
    /// Valid values:   'series' : assigns the colors in the palette by series, so that all data in the same series are in the same color;  'data' : assigns colors in the palette according to data items, with each data item using a different color.
    /// ]]>
    /// </summary>
    [JsonPropertyName("colorBy")]
    [DefaultValue("series")]
    public ColorBy? ColorBy { get; set; } 

    /// <summary>
    /// <![CDATA[
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
    /// ]]>
    /// </summary>
    [JsonPropertyName("map")]
    [DefaultValue("")]
    public string? Map { get; set; } 

    /// <summary>
    /// <![CDATA[
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
    /// ]]>
    /// </summary>
    [JsonPropertyName("projection")]
    public Projection? Projection { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// center specifies which point on the source map should be placed at the center of the viewport (i.e., typically, the center of the canvas).
    ///  
    /// center is typically used in control or fetch the position of source map when roamming is performed.
    /// When roaming, the values in center and zoom will be modified correspondingly.
    ///  
    /// Notice: the values in center are based on the original layout coordinates, rather than the viewport (canvas) coordinates.
    /// If you intend to adjust the position and size of source map by viewport coordinates, use series-map.left / .right / .top / .bottom / .width / .height or series-map.layoutCenter / layoutSize .
    ///  
    /// center is in longitude and latitude by default.
    /// Use the projected coordinates if proejction is set.
    ///  
    /// Example:  // Place this [lng, lat] at the center of the viewport (canvas).
    /// center: [115.97, 29.71]  projection: {
    ///     projection: (pt) => project(pt)
    /// },
    /// center: project([115.97, 29.71])  
    /// A percentage string can also be used in center , like '30%' , based on the bounding rect(determined min/max latitude/longitude, or min/max projected coordinates if proejction is set).
    /// You can use '0%' to place the top or left of bounding rect to the center of the viewport (typically, canvas), or use '100%' to place the right or bottom to the center of the viewport, or use '50%' to place the entire source map at the the center of the viewport.
    /// For example:  center: [115, '30%']
    /// // Place the top of source map to the center of the viewport (canvas)
    /// center: [115, '0%']
    /// // Place the left of source map to the center of the viewport (canvas)
    /// center: ['0%', 13]
    /// // Place the bottom of source map to the center of the viewport (canvas)
    /// center: [115, '100%']
    /// // Place the right of source map to the center of the viewport (canvas)
    /// center: ['100%', 13]
    /// // Place source map at center of the viewport (canvas)
    /// center: ['50%', '50%']   
    /// The percentage string is introduced since v5.3.3 .
    /// It is initially based on canvas width/height.
    /// But that is not reasonable, and then changed to be based on the bounding rect since v6.0.0 .
    ///   
    /// See geo roam indicator example to understand the concept.
    /// ]]>
    /// </summary>
    [JsonPropertyName("center")]
    //TODO: Type Warning: array type 'center' in 'MapSeries' will be mapped to List<object>
    public List<object>? Center { get; set; } 

    /// <summary>
    /// Zoom rate of current viewport.
    ///  
    /// The value less than 1 indicates zooming out, while the value greater than 1 indicates zooming in.
    ///  
    /// When roaming , the values in center and zoom will be modified correspondingly.
    ///  
    /// See geo roam indicator example to understand the concept.
    /// </summary>
    [JsonPropertyName("zoom")]
    [DefaultValue(1)]
    public double? Zoom { get; set; } 

    /// <summary>
    /// Limit of zooming , with min and max .
    ///  
    /// The value less than 1 indicates zooming out, while the value greater than 1 indicates zooming in.
    /// </summary>
    [JsonPropertyName("scaleLimit")]
    public ScaleLimit? ScaleLimit { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Whether to enable mouse or touch roam (move and zoom).
    /// Optional values are:   false : roam is disabled.
    ///  'scale' or 'zoom' : zoom only.
    ///  'move' or 'pan' : move (translation) only.
    ///  true : both zoom and move (translation) are available.
    ///   
    /// When roaming, the values in center and zoom will be modified correspondingly.
    /// ]]>
    /// </summary>
    [JsonPropertyName("roam")]
    [DefaultValue(false)]
    public Roam? Roam { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Roaming can be triggered by mouse dragging or mouse wheel.
    ///  
    /// Options:   
    /// 'selfRect' :  
    /// The roaming can only be triggered on the bounding rect of the graphic elements.
    ///   
    /// 'global' :  
    /// If clip: true , the roaming can only be triggered at any position within the clipped area.
    /// Otherwise it can be triggered in canvas globally.
    ///    
    /// See geo roam indicator example to understand the concept.
    /// ]]>
    /// </summary>
    [JsonPropertyName("roamTrigger")]
    [DefaultValue("selfRect")]
    public string? RoamTrigger { get; set; } 

    /// <summary>
    /// Used to scale aspect of geo.
    /// It will be ignored if proejction is set.
    ///  
    /// The final calculated pixelWidth and pixelHeight of the map will satisfy pixelWidth / pixelHeight = lngSpan / latSpan * aspectScale (assume proejction is not specified, and preserveAspect is truthy).
    ///  
    /// If no proejction is applied, the latitudes and longitudes in GeoJSON are linearly mapped to pixel coordinates diarectly.
    /// aspectScale offers a simple way to visually compensates for the distortion caused by the fact that the longitudinal spacing shrinks as latitude increases.
    /// For example, an aspectScale can be roughly calculated as aspectScale = Math.cos(center_latitude * Maht.PI / 180) , which is similar to a sinusoidal projection.
    ///  
    /// See example .
    /// </summary>
    [JsonPropertyName("aspectScale")]
    [DefaultValue(0.75)]
    public double? AspectScale { get; set; } 

    /// <summary>
    /// <![CDATA[
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
    /// ]]>
    /// </summary>
    [JsonPropertyName("boundingCoords")]
    //TODO: Type Warning: array type 'boundingCoords' in 'MapSeries' will be mapped to List<object>
    public List<object>? BoundingCoords { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Name mapping for customized areas.
    /// For example:  {
    ///     'China' : '中国'
    /// }
    /// ]]>
    /// </summary>
    [JsonPropertyName("nameMap")]
    public NameMap? NameMap { get; set; } 

    /// <summary>
    /// <![CDATA[
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
    /// ]]>
    /// </summary>
    [JsonPropertyName("nameProperty")]
    [DefaultValue("name")]
    public string? NameProperty { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Selected mode decides whether multiple selecting is supported.
    /// By default, false is used for disabling selection.
    /// Its value can also be 'single' for selecting single area, or 'multiple' for selecting multiple areas.
    /// ]]>
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
    /// <![CDATA[
    /// Distance between map series and the left side of the container.
    ///  
    /// left can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
    ///  
    /// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    ///    
    /// Note: There are two rectangular layout approaches for series-map.
    /// You can use either one:   series-map.left / .right / .top / .bottom / .width / .height  series-map.layoutCenter / .layoutSize
    /// ]]>
    /// </summary>
    [JsonPropertyName("left")]
    [DefaultValue("auto")]
    public NumberOrString? Left { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between map series and the top side of the container.
    ///  
    /// top can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
    ///  
    /// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    ///    
    /// Note: There are two rectangular layout approaches for series-map.
    /// You can use either one:   series-map.left / .right / .top / .bottom / .width / .height  series-map.layoutCenter / .layoutSize
    /// ]]>
    /// </summary>
    [JsonPropertyName("top")]
    [DefaultValue("auto")]
    public NumberOrString? Top { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between map series and the right side of the container.
    ///  
    /// right can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    ///  
    /// Adaptive by default.
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    ///    
    /// Note: There are two rectangular layout approaches for series-map.
    /// You can use either one:   series-map.left / .right / .top / .bottom / .width / .height  series-map.layoutCenter / .layoutSize
    /// ]]>
    /// </summary>
    [JsonPropertyName("right")]
    [DefaultValue("auto")]
    public NumberOrString? Right { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Distance between map series and the bottom side of the container.
    ///  
    /// bottom can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    ///  
    /// Adaptive by default.
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    ///    
    /// Note: There are two rectangular layout approaches for series-map.
    /// You can use either one:   series-map.left / .right / .top / .bottom / .width / .height  series-map.layoutCenter / .layoutSize
    /// ]]>
    /// </summary>
    [JsonPropertyName("bottom")]
    [DefaultValue("auto")]
    public NumberOrString? Bottom { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Width of map series.
    /// Adaptive by default.
    ///  
    /// width can be a pixel value like 20 ; it can also be a percentage value relative to the container width like '20%' .
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    /// ]]>
    /// </summary>
    [JsonPropertyName("width")]
    [DefaultValue("auto")]
    public NumberOrString? Width { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Height of map series.
    /// Adaptive by default.
    ///  
    /// height can be a pixel value like 20 ; it can also be a percentage value relative to the container height like '20%' .
    ///   
    /// Note: If the graphic elements are unexpectedly distorted, see preserveAspect .
    /// ]]>
    /// </summary>
    [JsonPropertyName("height")]
    [DefaultValue("auto")]
    public NumberOrString? Height { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// layoutCenter and layoutSize can specify the rectangular area allocated to map series, where layoutCenter defines the center position of the area, and layoutSize defines the size of the area.
    /// For example:  layoutCenter: ['30%', '30%'],
    /// // If width-height ratio is larger than 1, then width is set to be 100.
    /// // Otherwise, height is set to be 100.
    /// // This makes sure that it will not exceed the area of 100x100
    /// layoutSize: 100  
    /// After setting these two values, left/right/top/bottom/width/height becomes invalid.
    ///   
    /// Note: There are two rectangular layout approaches for series-map.
    /// You can use either one:   series-map.left / .right / .top / .bottom / .width / .height  series-map.layoutCenter / .layoutSize
    /// ]]>
    /// </summary>
    [JsonPropertyName("layoutCenter")]
    //TODO: Type Warning: array type 'layoutCenter' in 'MapSeries' will be mapped to List<object>
    public List<object>? LayoutCenter { get; set; } 

    /// <summary>
    /// Size of map, see layoutCenter for more information.
    /// Percentage relative to container width/height, and absolute pixel values are supported.
    ///   
    /// Note: There are two rectangular layout approaches for series-map.
    /// You can use either one:   series-map.left / .right / .top / .bottom / .width / .height  series-map.layoutCenter / .layoutSize
    /// </summary>
    [JsonPropertyName("layoutSize")]
    public NumberOrString? LayoutSize { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// aspect ratio here refers to width / height .
    ///  
    /// "preserve aspect" refers whether to preserve the aspect ratio of the original bounding rect of the content to be rendered.
    ///  
    /// A rectangular area allocated to map series is determined by series-map.left / .right / .top / .bottom / .width / .height / .aspectScale .
    ///  
    /// But the aspect ratio of this rectangle may not match that of the content's original bounding rect, which may cause distortion.
    ///  
    /// Options of preserveAspect :   null / undefined / false (default): The original aspect ratio of the content will not be preserved, but stretched to fill the map series rectangular area , which may cause distortion.
    ///  'contain' / true : The original aspect ratio of the content is preserved; the bounding rect of the content are fully contained by the map series rectangular area , and scaled up as much as possible to meet the map series rectangular area .
    /// preserveAspectAlign and preserveAspectVerticalAlign can be used to adjust the position in this case.
    ///  'cover' : The original aspect ratio of the content is preserved; the bounding rect of the content covers the map series rectangular area , and scaled down as much as possible to meet the map series rectangular area .
    /// preserveAspectAlign and preserveAspectVerticalAlign can be used to adjust the position in this case.
    ///   
    /// Notice: When using layoutCenter and layoutSize , the aspect radio is always preserved, regardless of this preserveAspect .
    ///  
    /// See geo roam indicator example to understand the concept.
    /// ]]>
    /// </summary>
    [JsonPropertyName("preserveAspect")]
    [DefaultValue("false")]
    public BoolOrString? PreserveAspect { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Options: 'left' | 'right' | 'center' .
    ///  
    /// See preserveAspect .
    ///  
    /// See geo roam indicator example to understand the concept.
    /// ]]>
    /// </summary>
    [JsonPropertyName("preserveAspectAlign")]
    [DefaultValue("center")]
    //TODO: Type Warning: enum type 'preserveAspectAlign' in 'MapSeries' with values 'left,right,center' is not mapped
    public string? PreserveAspectAlign { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Options: 'top' | 'bottom' | 'middle' .
    ///  
    /// See preserveAspect .
    ///  
    /// See geo roam indicator example to understand the concept.
    /// ]]>
    /// </summary>
    [JsonPropertyName("preserveAspectVerticalAlign")]
    [DefaultValue("middle")]
    //TODO: Type Warning: enum type 'preserveAspectVerticalAlign' in 'MapSeries' with values 'top,bottom,middle' is not mapped
    public string? PreserveAspectVerticalAlign { get; set; } 

    /// <summary>
    /// Since v6.0.0   
    /// A rectangular area allocated to map series is determined by series-map.left / .right / .top / .bottom / .width / .height / .aspectScale .
    ///  
    /// clip specifies whether to hide the outside part of the map with respect to the allocated rect.
    ///  
    /// See example:  geo roam indicator .
    /// </summary>
    [JsonPropertyName("clip")]
    [DefaultValue(false)]
    public bool? Clip { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Specifies another coordinate system component on which this series-map is laid out.
    ///  
    /// Options:   
    /// 'geo'  
    /// Lay out based on a geographic coordinate system .
    /// When multiple geographic coordinate systems exist within an ECharts instance, the corresponding system should be specified using geoIndex or geoId .
    ///    
    /// Support for series and component layout on coordinate systems:  
    /// The leftmost column lists the series and components that will be laid out (coordinate systems themselves are also components), and the topmost row lists the coordinate systems that can be laid out on.
    ///      no coord sys  grid (cartesian2d)  polar  geo  singleAxis  radar  parallel  calendar  matrix      grid (cartesian2d)  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    polar  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    geo  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    singleAxis  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    calendar  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ❌  ❌    matrix  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ❌  ❌    series-line  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-bar  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-pie  ✅  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-scatter  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-effectScatter  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    series-radar  ❌  ❌  ❌  ❌  ❌  ✅  ❌  ❌ (✅ if via radar coord sys)  ❌ (✅ if via radar coord sys)    series-tree  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-treemap  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-sunburst  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-boxplot  ❌  ✅  ❌  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-candlestick  ❌  ✅  ❌  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-heatmap  ❌  ✅  ❌  ✅  ❌  ❌  ❌  ✅  ✅    series-map  ✅ (create a geo coord sys exclusively)  ❌  ❌  ✅  ❌  ❌  ❌  ✅  ✅    series-parallel  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ❌ (✅ if via parallel coord sys)  ❌ (✅ if via parallel coord sys)    series-lines  ❌  ✅  ✅  ✅  ✅  ❌  ❌  ❌ (✅ if via another coord sys like geo )  ❌ (✅ if via another coord sys like geo )    series-graph  ✅ (create a "view" coord sys exclusively)  ✅  ✅  ✅  ❌  ❌  ❌  ✅  ✅    series-sankey  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-funnel  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-gauge  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    series-pictorialBar  ❌  ✅  ✅  ❌  ❌  ❌  ❌  ❌ (✅ if via another coord sys like grid )  ❌ (✅ if via another coord sys like grid )    series-themeRiver  ❌  ❌  ❌  ❌  ✅  ❌  ❌  ❌ (✅ if via another coord sys like singleAxis )  ❌ (✅ if via another coord sys like singleAxis )    series-chord  ✅  ✅  ✅  ✅  ✅  ❌  ❌  ✅  ✅    title  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    legend  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    dataZoom  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    visualMap  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    toolbox  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    timeline  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅    thumbnail  ✅  ❌  ❌  ❌  ❌  ❌  ❌  ✅  ✅     
    /// See also series-map.coordinateSystemUsage .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coordinateSystem")]
    [DefaultValue("geo")]
    public string? CoordinateSystem { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// Specify how to lay out this series-map based on the specified coordinateSystem .
    ///  
    /// In most cases, there is no need to specify coordinateSystemUsage , unless the default behavior is unexpected.
    ///  
    /// Options:   
    /// 'data' :  
    /// Each data item of a series (e.g., each series.data[i] ) is laid out separately based on the specified coordinate system.
    /// Currently no non-series component supports coordinateSystemUsage: 'data' .
    ///   
    /// 'box' : (Not applicable in series-map )  
    /// The entire series or component is laid out as a whole based on the specified coordinate system - that is, the overall bounding rect or basic anchor point is calculated relative to the system.
    ///   For example, a grid component can be laid out in a matrix coordinate system or a calendar coordinate system , where its layout rectangle is calculated by the specified series-map.coords in that system.
    /// See example sparkline in matrix .
    ///  For example, a pie series or a chord series can be laid out in a geo coordinate system or a cartesian2d coordinate system , where the center is calculated by the specified series-pie.coords or series-pie.center in that system.
    /// See example pie in geo .
    ///     
    /// Only a few series support both coordinateSystemUsage: 'data' and coordinateSystemUsage: 'box' , such as series-graph , series-map .
    /// For examle, in this example (coordinateSystemUsage: 'data') , each node of a graph series is laid out on a matrix coordinate system, while in this example (coordinateSystemUsage: 'box') , the entire graph series is laid out within a matrix cell.
    ///  
    /// Most series only support coordinateSystemUsage: 'data' - such as series-line , series-bar , series-scatter , etc.
    /// Meanwhile, some series only support coordinateSystemUsage: 'box' - such as series-pie ( example: pie in geo ), series-tree , series-treemap , series-sankey , etc.
    ///  
    /// See also series-map.coordinateSystem .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coordinateSystemUsage")]
    [DefaultValue("data")]
    public string? CoordinateSystemUsage { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Since v6.0.0   
    /// When coordinateSystemUsage is 'box' , coord is used as the input to the coordinate system and calculate the layout rectangle or anchor point.
    ///  
    /// Examples: sparkline in matrix , grpah in matrix .
    ///   
    /// Note: when coordinateSystemUsage is 'data' , the input of coordinate system is series.data[i] rather than this coord .
    ///   
    /// The format this coord is defined by each coordinate system, and it's the same as the second parameter of chart.convertToPixel .
    /// ]]>
    /// </summary>
    [JsonPropertyName("coord")]
    public NumberOrStringArray? Coord { get; set; } 

    /// <summary>
    /// The index of the geographic coordinate system to base on.
    /// When mutiple geographic exist within an ECharts instance, use this to specify the corresponding geographic .
    ///  
    /// When geoIndex and geoId is not specified, map series creates an exclusive geo component for itself.
    /// geoIndex or geoId can be used to specify an outer geo component , which can be shared with other series like pie .
    /// Moreover, the region color of the outer geo component can be controlled by the map series (via visualMap ).
    ///  
    /// When geoIndex or geoId is specified, series-map.map other style configurations like series-map.itemStyle will not work, but corresponding configurations in geo component will be used.
    ///  
    /// See example : geo-choropleth-scatter
    /// </summary>
    [JsonPropertyName("geoIndex")]
    [DefaultValue(0)]
    public int? GeoIndex { get; set; } 

    /// <summary>
    /// The id of the geographic coordinate system to base on.
    /// When mutiple geographic exist within an ECharts instance, use this to specify the corresponding geographic .
    ///  
    /// When geoIndex and geoId is not specified, map series creates an exclusive geo component for itself.
    /// geoIndex or geoId can be used to specify an outer geo component , which can be shared with other series like pie .
    /// Moreover, the region color of the outer geo component can be controlled by the map series (via visualMap ).
    ///  
    /// When geoIndex or geoId specified, series-map.map other style configurations like series-map.itemStyle will not work, but corresponding configurations in geo component will be used.
    ///  
    /// See example : geo-choropleth-scatter
    /// </summary>
    [JsonPropertyName("geoId")]
    [DefaultValue("undefined")]
    public double? GeoId { get; set; } 

    /// <summary>
    /// <![CDATA[
    /// Value of multiple series with the same map type can use this option to get a statistical value.
    ///  
    /// Supported statistical methods:   'sum'  'average'  'max'  'min'
    /// ]]>
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
    /// <![CDATA[
    /// When dataset is used, seriesLayoutBy specifies whether the column or the row of dataset is mapped to the series, namely, the series is "layout" on columns or rows.
    /// Optional values:   'column': by default, the columns of dataset are mapped the series.
    /// In this case, each column represents a dimension.
    ///  'row'：the rows of dataset are mapped to the series.
    /// In this case, each row represents a dimension.
    ///   
    /// Check this example .
    /// ]]>
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
    /// A group ID assigned to all data items in the series.
    ///  
    /// This option has a lower priority than groupId , which means when groupId is specified for a certain data item the dataGroupId will be simply ignored for that data item.
    /// For more information, please see series.data.groupId .
    /// </summary>
    [JsonPropertyName("dataGroupId")]
    public string? DataGroupId { get; set; } 

    /// <summary>
    /// <![CDATA[
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
    /// ]]>
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
    /// <![CDATA[
    /// Data array of map series, which can be a single data value, like:  [12, 34, 56, 10, 23]  
    /// Or, if need extra dimensions for components like visualMap to map to graphic attributes like color, it can also be in the form of array.
    /// For example:  [[12, 14], [34, 50], [56, 30], [10, 15], [23, 10]]  
    /// In this case, we can assign the second value in each array item to visualMap component.
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
    /// ]]>
    /// </summary>
    [JsonPropertyName("data")]
    public object? Data { get; set; } 

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
    /// <![CDATA[
    /// Since v5.2.0   
    /// Configuration related to universal transition animation.
    ///  
    /// Universal Transition provides the ability to morph between any series.
    /// With this feature enabled, each time setOption , transitions between series with the same id will be automatically associated with each other.
    ///  
    /// One-to-many or many-to-one animations such as drill-down, aggregation, etc.
    /// can also be achieved by specifying data items' groupId and childGroupId .
    ///  
    /// This can be enabled directly by configuring universalTransition: true in the series.
    /// It is also possible to provide an object for more detailed configuration.
    /// ]]>
    /// </summary>
    [JsonPropertyName("universalTransition")]
    public UniversalTransition? UniversalTransition { get; set; } 

    /// <summary>
    /// tooltip settings in this series.
    /// </summary>
    [JsonPropertyName("tooltip")]
    public Tooltip? Tooltip { get; set; } 

}
