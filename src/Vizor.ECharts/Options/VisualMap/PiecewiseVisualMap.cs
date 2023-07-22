// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;
using Vizor.ECharts.Options.VisualMap;

namespace Vizor.ECharts;

public partial class PiecewiseVisualMap : IVisualMap
{
	/// <summary>
	/// Used to determine it is a piecewise visualMap component.
	/// </summary>
	[JsonPropertyName("type")]
	[DefaultValue("piecewise")]
	public string? Type { get; set; }  = "piecewise";

	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; } 

	/// <summary>
	/// Continuous data can be divide into pieces averagely according to splitNumber, that is, if splitNumber is 5, data will be sliced into 5 pieces.
	///  
	/// The range of continuous data should be defined by max and min .
	///  
	/// If visualMap-piecewise.pieces or visualMap-piecewise.categories is set up, the splitNumber will not be used any more.
	/// </summary>
	[JsonPropertyName("splitNumber")]
	[DefaultValue("5")]
	public double? SplitNumber { get; set; } 

	/// <summary>
	/// Used to customize how to slice continuous data, and some specific view style for some pieces.
	/// For instance:  pieces: [
	///     // Range of a piece can be specified by property min and max,
	///     // where min will be set as -Infinity if ignored,
	///     // and max will be set as Infinity if ignored.
	///     {min: 1500},
	///     {min: 900, max: 1500},
	///     {min: 310, max: 1000},
	///     {min: 200, max: 300},
	///     // Label of the piece can be specified.
	///     {min: 10, max: 200, label: '10 to 200 (custom label) '},
	///     // Color of the piece can be specified.
	///     {value: 123, label: '123 (custom special color) ', color: 'grey'},
	///     {max: 5}
	/// ]  
	/// These visual channel can be customized in each piece:   symbol : Type of symbol.
	///  symbolSize : Symbol size.
	///  color : Symbol color.
	///  colorAlpha : Symbol alpha channel.
	///  opacity : Opacity of symbol and others (like labels).
	///  colorLightness : Lightness in HSL .
	///  colorSaturation : Saturation in HSL .
	///  colorHue : Hue in HSL .
	///   
	/// (Notes: In ECharts2, pieces is called splitList , which is retained in ECharts3 for compatibility.
	/// But pieces is recommended.)  
	/// You would realize the sequence in pieces by a simple trial.
	/// See more detailed rules in visualMap.inverse .
	/// </summary>
	[JsonPropertyName("pieces")]
	public List<VisualMapPiece>? Pieces { get; set; } 

	/// <summary>
	/// When dataValues in series.data (specified by visualMap-piecewise.dimension ) are discrete (or also known as category data or enumerable data), and we intend to perform Table Mapping from dataValue to visual channels, categories is used to describe the entire enumeration of data.
	/// For instance:  categories: [
	///     'Demon Hunter', 'Blademaster', 'Death Knight', 'Warden', 'Paladin'
	/// ],  
	/// Sample  
	/// You would realize the sequence in categories by a simple trial.
	/// See more detailed rules in visualMap.inverse .
	/// </summary>
	[JsonPropertyName("categories")]
	//TODO: Type Warning: array type 'categories' in 'PiecewiseVisualMap' will be mapped to List<object>
	public List<object>? Categories { get; set; } 

	/// <summary>
	/// Specify the min dataValue for the visualMap component.
	/// [visualMap.min, visualMax.max] make up the domain of viusul mapping.
	///  
	/// In CONTINUOUS-CUSTOMIZED mode (i.e., visualMap-piecewise.pieces is used) or CATEGORY mode (i.e., visualMap-piecewise.categories is used), max and min doesn't need to be specified.
	///  
	/// In CONTINUOUS-AVERAGE mode (i.e., visualMap-piecewise.splitNumber is used), they should be specified explicitly, and be [0, 200] by default, but not dataMin and dataMax in series.data.
	/// </summary>
	[JsonPropertyName("min")]
	public double? Min { get; set; } 

	/// <summary>
	/// Specify the max dataValue for the visualMap component.
	/// [visualMap.min, visualMax.max] make up the domain of viusul mapping.
	///  
	/// In CONTINUOUS-CUSTOMIZED mode (i.e., visualMap-piecewise.pieces is used) or CATEGORY mode (i.e., visualMap-piecewise.categories is used), max and min doesn't need to be specified.
	///  
	/// In CONTINUOUS-AVERAGE mode (i.e., visualMap-piecewise.splitNumber is used), they should be specified explicitly, and be [0, 200] by default, but not dataMin and dataMax in series.data.
	/// </summary>
	[JsonPropertyName("max")]
	public double? Max { get; set; } 

	/// <summary>
	/// This option works when type is piecewise and min / max / splitNumber are set.
	///  
	/// If it is set as true , an extra piece labeled with "< min" will show.
	/// </summary>
	[JsonPropertyName("minOpen")]
	public bool? MinOpen { get; set; } 

	/// <summary>
	/// This option works when type is piecewise and min / max / splitNumber are set.
	///  
	/// If it is set as true , an extra piece labeled with "> max" will show.
	/// </summary>
	[JsonPropertyName("maxOpen")]
	public bool? MaxOpen { get; set; } 

	/// <summary>
	/// Selected Mode could be:   'multiple' (multiple selection).
	///  'single' (single selection).
	///  true (single selection) since version 5.3.3 .
	///  false (no selection) since version 5.3.3 .
	/// </summary>
	[JsonPropertyName("selectedMode")]
	[DefaultValue("multiple")]
	public SelectionMode? SelectedMode { get; set; } 

	/// <summary>
	/// Whether to inverse the layout of visualMap component.
	///   
	/// In CONTINUOUS-AVERAGE mode (i.e., visualMap-piecewise.splitNumber is used), the rule of data layout is the same as visualMap-continuous.inverse .
	///   
	/// In CONTINUOUS-CUSTOMIZED mode (i.e., visualMap-piecewise.pieces is used) or CATEGORY mode (i.e., visualMap-piecewise.categories is used), the layout of each piece is determined by the their order in the definition of pieces or categories , namely:   
	/// When inverse is false :   
	/// When visualMap.orient is 'vertical' , pieces[0] or categories[0] correspond to upward side.
	///   
	/// When visualMap.orient is 'horizontal' , pieces[0] or categories[0] correspond to left side.
	///     
	/// When inverse is true , the results are opposite to above.
	///      
	/// If you just have a try, you'll know it is not so complicated.
	/// </summary>
	[JsonPropertyName("inverse")]
	[DefaultValue(false)]
	public bool? Inverse { get; set; } 

	/// <summary>
	/// The decimal precision of label, defaults to be 0 (no decimals).
	///   
	/// In CONTINUOUS-AVERAGE mode (i.e., visualMap-piecewise.splitNumber is used), the rule of data layout is the same as visualMap-continuous.inverse , decimal percision auto adapts to series.data.
	///   
	/// In CONTINUOUS-CUSTOMIZED mode (i.e., visualMap-piecewise.pieces is used) or CATEGORY mode (i.e., visualMap-piecewise.categories is used), decimal percision defaults to be 0 (no decimals):
	/// </summary>
	[JsonPropertyName("precision")]
	public double? Precision { get; set; } 

	/// <summary>
	/// The width of each graphical element that represents a piece.
	/// </summary>
	[JsonPropertyName("itemWidth")]
	[DefaultValue("20")]
	public double? ItemWidth { get; set; } 

	/// <summary>
	/// The height of each graphical element that represents a piece.
	/// </summary>
	[JsonPropertyName("itemHeight")]
	[DefaultValue("14")]
	public double? ItemHeight { get; set; } 

	/// <summary>
	/// The layout relationship between the graphical elements for pieces and their labels.
	/// Possible values are:   'auto' Decide automatically.
	///  'left' The graphical elements for pieces are on the left and their labels are on the right.
	///  'right' The graphical elements for pieces are on the right and their labels are on the left.
	/// </summary>
	[JsonPropertyName("align")]
	[DefaultValue("auto")]
	public HorizontalAlign? Align { get; set; } 

	/// <summary>
	/// The label text on both ends, such as ['High', 'Low'] .
	/// Sample .
	///  
	/// You can understand the order of items in text array just by a simple trial.
	/// See visualMap.inverse .
	///  
	/// The rule, that labels will not show when text is use, is retained for compatibility with ECharts2.
	/// </summary>
	[JsonPropertyName("text")]
	//TODO: Type Warning: array type 'text' in 'PiecewiseVisualMap' will be mapped to List<object>
	public List<object>? Text { get; set; } 

	/// <summary>
	/// The distance between the ends of the graphical elements for pieces and the labels, with unit px.
	/// See visualMap-piecewise.text
	/// </summary>
	[JsonPropertyName("textGap")]
	[DefaultValue("10")]
	public double? TextGap { get; set; } 

	/// <summary>
	/// Whether to show label of each item.
	/// By default, label will not be shown when visualMap-piecewise.text used, otherwise label will be shown.
	/// </summary>
	[JsonPropertyName("showLabel")]
	public bool? ShowLabel { get; set; } 

	/// <summary>
	/// Its the distance between each two graphical elements for pieces.
	/// The unit is px.
	/// </summary>
	[JsonPropertyName("itemGap")]
	[DefaultValue("10")]
	//TODO: Type Warning: Failed to map property 'itemGap' in type 'PiecewiseVisualMap' with types '*,number'
	public object? ItemGap { get; set; } 

	/// <summary>
	/// Default symbol (the shape of graphical element).
	/// Possible values are:  
	/// 'circle' , 'rect' , 'roundRect' , 'triangle' , 'diamond' , 'pin' , 'arrow' , 'none'  
	/// The setting of visual channel symbol can refer to visualMap-piecewise.inRange and visualMap-piecewise.outOfRange .
	///  
	/// When they are not specified, itemSymbol is adopted as the default value (but just used in visualMap component itself, not in chart).
	/// </summary>
	[JsonPropertyName("itemSymbol")]
	[DefaultValue("roundRect")]
	public string? ItemSymbol { get; set; } 

	/// <summary>
	/// Whether to show visualMap-piecewise component.
	/// If set as false , visualMap-piecewise component will not show, but it can still perform visual mapping from dataValue to visual channel in chart.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue(true)]
	public bool? Show { get; set; } 

	/// <summary>
	/// Specify which dimension should be used to fetch dataValue from series.data , and then map them to visual channel.
	///  
	/// series.data can be regarded as a two-dimensional array, for instance:  [
	///     [12, 23, 43],
	///     [12, 23, 43],
	///     [43, 545, 65],
	///     [92, 23, 33]
	/// ]  
	/// Each column of the above array is regarded as a dimension .
	/// For example, when property dimension is set to 1, the second column (i.e., 23, 23, 545, 23) is chosen to perform visual mapping.
	///  
	/// Use the last dimension of data by default.
	/// </summary>
	[JsonPropertyName("dimension")]
	public NumberOrString? Dimension { get; set; } 

	/// <summary>
	/// Specify visual mapping should be performed on which series, from which series.data is fetched.
	///  
	/// All series are used by default.
	/// </summary>
	[JsonPropertyName("seriesIndex")]
	public NumberOrNumberArray? SeriesIndex { get; set; } 

	/// <summary>
	/// hoverLink enable highlight certain graphical elements of chart when mouse hovers on some place of visualMap component that is coresponding to those graphical elements by visual mapping.
	///  
	/// Inversely, when mouse hovers a graphical element of chart, its value label will be displayed on its corresponding position in visualMap .
	/// </summary>
	[JsonPropertyName("hoverLink")]
	[DefaultValue(true)]
	public bool? HoverLink { get; set; } 

	/// <summary>
	/// Define visual channels that will mapped from dataValues that are in selected range .
	/// User can interact with visualMap component and make a seleced range by mouse or touch.
	///   symbol : Type of symbol.
	///  symbolSize : Symbol size.
	///  color : Symbol color.
	///  colorAlpha : Symbol alpha channel.
	///  opacity : Opacity of symbol and others (like labels).
	///  colorLightness : Lightness in HSL .
	///  colorSaturation : Saturation in HSL .
	///  colorHue : Hue in HSL .
	///   
	/// inRange could customize visual channels both in series (by visualMap-piecewise.seriesIndex ) and in visualMap-piecewise itself.
	///  
	/// For instance, if a visualMap-piecewise component is used on a scatter chart, the mapping approach from data to color (or symbol , size , ...) can be both customized in the scatter chart and visualMap-piecewise component itself.
	/// See the code as following:  visualMap: [
	///     {
	///         ...,
	///         // Define visual channels both in target series and visualMap-piecewise component itself:
	///         inRange: {
	///             color: ['#121122', 'rgba(3,4,5,0.4)', 'red'],
	///             symbolSize: [30, 100]
	///         }
	///     }
	/// ]  
	/// If you want to define visual channels for target series and visualMap-piecewise component separately, you should do as follows:  visualMap: [
	///     {
	///         ...,
	///         // Define visual channels only for target series.
	///         target: {
	///             inRange: {
	///                 color: ['#121122', 'rgba(3,4,5,0.4)', 'red'],
	///                 symbolSize: [60, 200]
	///             }
	///         },
	///         // Define visual channels only for visualMap-piecewise component.
	///         controller: {
	///             inRange: {
	///                 symbolSize: [30, 100]
	///             }
	///         }
	///     }
	/// ]  
	/// Or define as follows:  visualMap: [
	///     {
	///         ...,
	///         // Define visual channels for both target series and visualMap-piecewise component.
	///         inRange: {
	///             color: ['#121122', 'rgba(3,4,5,0.4)', 'red'],
	///             symbolSize: [60, 200]
	///         },
	///         // Define visual channels only for visualMap-piecewise component, which
	///         // will overlap the properties with the same name in the above common
	///         // definition.
	/// (symbolSize is overlapped by [30, 100] while color
	///         // keeps the original value)
	///         controller: {
	///             inRange: {
	///                 symbolSize: [30, 100]
	///             }
	///         }
	///     }
	/// ]  
	/// 
	///   
	/// ✦ About visual channels ✦   
	/// Various visual channels (such as color 、 symbolSize and ect.) can be defined in inRange at the same time and all of them will be apopted.
	///   
	/// Basically visual channels opacity is recommended, rather than colorAlpha .
	/// The former controls the transparency of both graphical element and its attachments (like label), whereas the latter only controls the transparency of graphical element.
	///   
	/// There are two approaches of visual mapping supported: 'Linear Mapping' and 'Table Mapping'.
	///    
	/// 
	///   
	/// ✦ Linear Mapping to visual channel ✦  
	/// Linear Mapping means that linear calculation will be performed on each dataValue (value of series.data), mapping them from the domain of [visaulMap.min, visualMap.max] to a given range of [visual value 1, visual value 2] and obtaining a final value (say visual value) for visual channel rendering.
	///  
	/// For instance, [visualMap.min, visualMap.max] is set to be [0, 100] , and there is series.data: [50, 10, 100] .
	/// We intend to map them to an opacity range [0.4, 1] , by which the size of value can be demostrated by the transparency of graphical elements.
	/// visualMap component will then linear calculate them and get opacity values [0.7, 0.44, 1] , cooresponding to each dataValue.
	///  
	/// We can also set the visual range inversely, such as opacity: [1, 0.4] , and the final mapping result for the given series.data above will be [0.7, 0.96, 0.4] .
	///  
	/// Notice: [visualMap.min, visualMap.max] should be set manually and is [0, 100] by default, but not dataMin and dataMax in series.data.
	///  
	/// How to configure visualMap component to do Linear Mapping?   
	/// When use visualMap-continuous , or   
	/// When use visualMap-piecewise and visualMap-piecewise.categories is not used.
	///    
	/// About the value of visual channel (visual value):   
	/// Basically Array is used to express the range of visual value, e.g., color: ['#333', '#777'] .
	///   
	/// Single number or single string can also be used, which will be converted to an Array by visualMap component.
	/// e.g.: opacity: 0.4 will be converted to opacity: [0.4, 0.4] , color: '#333' will be converted to color: ['#333', '#333'] .
	///   
	/// For visual channel symbolSize , opacity , colorAlpha , colorLightness , colorSaturation , colorHue , the range of visual value is always in the form of: [visual value of visualMap.min, visual value of visualMap.max] .
	/// For example, colorLightness: [0.8, 0.2] means that the dataValue in series.data that equals to visualMap.min (if any) will be mapped to lightness 0.8 , and the dataValue that equals to visualMap.max (if any) will be mapped to lightness 0.2 , and other dataValues will be mapped by the linear calculateion based on the domain of [visualMap.min, visualMap.max] and the range of [0.8, 0.2] .
	///   
	/// For visual channel color , array is used, like: ['#333', '#78ab23', 'blue'] , which means a color ribbon is formed based on the three color stops, and dataValues will be mapped to the ribbon.
	/// Specifically, the dataValue that equals to visualMap.min will be mapped onto '#333' , the dataValue that equals to visualMap.max will be mapped onto 'blue' , and other dataValues will be piecewisely interpolated to get the final color.
	///   
	/// For visual channel symbol , array is used, like: ['circle', 'rect', 'diamond'] , where the dataValue that equals to visualMap.min will be mapped onto 'circle' , the dataValue that equals to visualMap.max will be mapped onto 'diamond' , and other dataValues will be caculated based on the numerical distance to visualMax.min and to visualMap.max , and mapped onto one of 'circle' , 'rect' , 'diamond' .
	///    
	/// About the possible value range of visual value:   
	/// opacity 、 colorAlpha 、 colorLightness 、 colorSaturation 、 visual value  
	/// possible value range is [0, 1] .
	///   
	/// colorHue ：  
	/// possible value range is [0, 360] .
	///   
	/// color ：  
	/// color can use RGB expression, like 'rgb(128, 128, 128)' , or RGBA expression, like 'rgba(128, 128, 128, 0.5)' , or Hex expression, like '#ccc'.
	///   
	/// symbol ：    
	/// Icon types provided by ECharts includes  
	/// 'circle' , 'rect' , 'roundRect' , 'triangle' , 'diamond' , 'pin' , 'arrow' , 'none'  
	/// It can be set to an image with 'image://url' , in which URL is the link to an image, or dataURI of an image.
	///  
	/// An image URL example:  'image://http://example.website/a/b.png' 
	/// A dataURI example:  'image://data:image/gif;base64,R0lGODlhEAAQAMQAAORHHOVSKudfOulrSOp3WOyDZu6QdvCchPGolfO0o/XBs/fNwfjZ0frl3/zy7////wAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAAACH5BAkAABAALAAAAAAQABAAAAVVICSOZGlCQAosJ6mu7fiyZeKqNKToQGDsM8hBADgUXoGAiqhSvp5QAnQKGIgUhwFUYLCVDFCrKUE1lBavAViFIDlTImbKC5Gm2hB0SlBCBMQiB0UjIQA7' 
	/// Icons can be set to arbitrary vector path via 'path://' in ECharts.
	/// As compared with a raster image, vector paths prevent jagging and blurring when scaled, and have better control over changing colors.
	/// The size of the vector icon will be adapted automatically.
	/// Refer to SVG PathData for more information about the format of the path.
	/// You may export vector paths from tools like Adobe  
	/// For example:  'path://M30.9,53.2C16.8,53.2,5.3,41.7,5.3,27.6S16.8,2,30.9,2C45,2,56.4,13.5,56.4,27.6S45,53.2,30.9,53.2z M30.9,3.5C17.6,3.5,6.8,14.4,6.8,27.6c0,13.3,10.8,24.1,24.101,24.1C44.2,51.7,55,40.9,55,27.6C54.9,14.4,44.1,3.5,30.9,3.5z M36.9,35.8c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H36c0.5,0,0.9,0.4,0.9,1V35.8z M27.8,35.8 c0,0.601-0.4,1-0.9,1h-1.3c-0.5,0-0.9-0.399-0.9-1V19.5c0-0.6,0.4-1,0.9-1H27c0.5,0,0.9,0.4,0.9,1L27.8,35.8L27.8,35.8z' 
	/// 
	///   
	/// ✦ Table Mapping to visual channel ✦  
	/// Table Mapping could be used when dataValue (values in series.data, specified by visualMap.dimension ) is enumerable and we intend to map them to visual value by looking up a given table.
	///  
	/// For instance, in a visualMap-piecewise component, visualMap-piecewise.categories is set to ['Demon Hunter', 'Blademaster', 'Death Knight', 'Warden', 'Paladin'] .
	/// And there is series.data: ['Demon Hunter', 'Death Knight', 'Warden', 'Paladin'] .
	/// Then we can establish the lookup rule for color: color: {'Warden': 'red', 'Demon Hunter': 'black'} , by which the visualMap component will map dataValue to color .
	///  
	/// How to configure visualMap component to do Table Mapping ?  
	/// When use visualMap-piecewise and visualMap-piecewise.categories is set.
	///  
	/// About the value of visual channel (visual value):  
	/// Generally Object or Array is used, for instance:  visualMap: {
	///     type: 'piecewise',
	///     // categories defines the items that to be displayed in visualMap-piecewise component.
	///     categories: [
	///         'Demon Hunter', 'Blademaster', 'Death Knight', 'Warden', 'Paladin'
	///     ],
	///     inRange: {
	///         // visual value can be an Object：
	///         color: {
	///             'Warden': 'red',
	///             'Demon Hunter': 'black',
	///             '': 'green' // Blank string means that except 'Warden' and 'Demon Hunter',
	///                         // all other dataValues should be mapped to 'green'.
	///         }
	///         // visual value can also be a single value,
	///         // means that all dataValues should be mapped to the value.
	///         color: 'green',
	///         // visual value can also be a array, with the same length
	///         // as the array of categories and one-one mapping onto it.
	///         color: ['red', 'black', 'green', 'yellow', 'white']
	///     }
	/// }  
	/// Example  
	/// ✦ How to modity configurations of vsiual encoding? ✦  
	/// If you want to modify the configurations of visual encoding after chart been rendered (by invoke setOption to set the initial option ), setOption can be used again to modify configurations of visual encoding.
	/// For instance:  chart.setOption({
	///     visualMap: {
	///         inRange: {color: ['red', 'blue']}
	///     }
	/// });  
	/// Notice:   
	/// These visualMap properties (i.e.
	/// inRange , outOfRange , target , controller ) do not support "merge", that is, anyone among them is modified when use setOption again, all of the original values of them will not be kept but erased.
	/// The "merge" brings complication in implemnentation and understanding, whereas "erase all" normalize the practise: once you want to modify some visual values, you should pass all of them to setOption , no matter they are to be changed.
	///   
	/// This way, getOption() -> modify the gotten option -> setOption(modified option) , is strongly not recommended , for instance:    // Not recommended approach, regardless of its correctness:
	/// 
	/// var option = chart.getOption(); // Get the entire option.
	/// option.visualMap.inRange.color = ['red', 'blue']; // modify color, which is what you want.
	/// 
	/// // You have to modify those two properties, otherwise you will not get what you want.
	/// option.visualMap.target.inRange.color = ['red', 'blue'];
	/// option.visualMap.controller.inRange.color = ['red', 'blue'];
	/// 
	/// chart.setOption(option); // set the modified option back.
	/// // You should not use this approach, but use the
	/// // approach demostrated before this example.
	///  
	/// Notice: There is default color ['#f6efa6', '#d88273', '#bf444c'] in inRange if you not set inRange .
	/// If you dont want it, set inRange: {color: null} to disable it.
	/// </summary>
	[JsonPropertyName("inRange")]
	public InRange? InRange { get; set; } 

	/// <summary>
	/// Define visual channels that will mapped from dataValues that are out of selected range .
	/// User can interact with visualMap component and make a seleced range by mouse or touch.
	///  
	/// See available configurations in visualMap-piecewise.inRange
	/// </summary>
	[JsonPropertyName("outOfRange")]
	public OutOfRange? OutOfRange { get; set; } 

	/// <summary>
	/// Property inRange and outOfRange can be set within property controller , which means those inRange and outOfRange are only used on the controller ( visualMap component itself), but are not used on chart (series).
	/// This property is useful in some scenarios when the view of controller needs to be customized in detail.
	/// </summary>
	[JsonPropertyName("controller")]
	public Controller? Controller { get; set; } 

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
	[DefaultValue(4)]
	public double? Z { get; set; } 

	/// <summary>
	/// Distance between visualMap  component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue(0)]
	public NumberOrString? Left { get; set; } 

	/// <summary>
	/// Distance between visualMap  component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue("auto")]
	public NumberOrString? Top { get; set; } 

	/// <summary>
	/// Distance between visualMap  component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue("auto")]
	public NumberOrString? Right { get; set; } 

	/// <summary>
	/// Distance between visualMap  component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue(0)]
	public NumberOrString? Bottom { get; set; } 

	/// <summary>
	/// How to layout the visualMap component, 'horizontal' or 'vertical' .
	/// </summary>
	[JsonPropertyName("orient")]
	[DefaultValue("vertical")]
	public Orient? Orient { get; set; } 

	/// <summary>
	/// visualMap-piecewise space around content.
	/// The unit is px.
	/// Default values for each position are 5.
	/// And they can be set to different values with left, right, top, and bottom.
	///  
	/// Examples:  // Set padding to be 5
	/// padding: 5
	/// // Set the top and bottom paddings to be 5, and left and right paddings to be 10
	/// padding: [5, 10]
	/// // Set each of the four paddings seperately
	/// padding: [
	///     5,  // up
	///     10, // right
	///     5,  // down
	///     10, // left
	/// ]
	/// </summary>
	[JsonPropertyName("padding")]
	[DefaultValue(5)]
	public Padding? Padding { get; set; } 

	/// <summary>
	/// background color of visualMap component.
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	[DefaultValue("rgba(0,0,0,0)")]
	public Color? BackgroundColor { get; set; } 

	/// <summary>
	/// border color of visualMap component.
	/// </summary>
	[JsonPropertyName("borderColor")]
	[DefaultValue("#ccc")]
	public Color? BorderColor { get; set; } 

	/// <summary>
	/// border width of visualMap component, with unit: px.
	/// </summary>
	[JsonPropertyName("borderWidth")]
	[DefaultValue(0)]
	public double? BorderWidth { get; set; } 

	/// <summary>
	/// This property remains only for compatibility with ECharts2, and is not recommended in ECharts3.
	/// It is recommended to configure color in visualMap-piecewise.inRange , or visualMap-piecewise.outOfRange if needed.
	///  
	/// If you persist in using it, the following issue should be noticed: the sequence of dataValues that are mapped to colorValues in property color is from large to small , whereas that in visualMap-piecewise.inRange or visualMap-piecewise.outOfRange is from small to large .
	/// </summary>
	[JsonPropertyName("color")]
	[DefaultValue("[#bf444c, #d88273, #f6efa6]")]
	//TODO: Type Warning: array type 'color' in 'PiecewiseVisualMap' will be mapped to List<object>
	public List<object>? Color { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("textStyle")]
	public object? TextStyle { get; set; } 

	/// <summary>
	/// the formatter tool for label.
	///   
	/// If it was set as a string , it refers to a template, for instance: aaaa{value}bbbb{value2} , where {value} and {value2} represents the current selected range of dataValues.
	///   
	/// If it was set as a Function , it refers to a callback function, for instance:    formatter: function (value, value2) {
	///     return 'aaaa' + value + 'bbbb' + value2;
	/// }
	/// </summary>
	[JsonPropertyName("formatter")]
	public StringOrFunction? Formatter { get; set; } 

}
