// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Legend
{
	/// <summary>
	/// Type of legend.
	/// Optional values:   'plain' : Simple legend.
	/// (default)  'scroll' : Scrollable legend.
	/// It helps when too many legend items needed to be shown.
	///   
	/// See vertically scrollable legend or horizontally scrollable legend .
	///  
	/// When 'scroll' used, these options below can be used for detailed configuration:   legend.scrollDataIndex  legend.pageButtonItemGap  legend.pageButtonGap  legend.pageButtonPosition  legend.pageFormatter  legend.pageIcons  legend.pageIconColor  legend.pageIconInactiveColor  legend.pageIconSize  legend.pageTextStyle  legend.animation  legend.animationDurationUpdate
	/// </summary>
	[JsonPropertyName("type")]
	public LegendType? Type { get; set; } 

	/// <summary>
	/// Component ID, not specified by default.
	/// If specified, it can be used to refer the component in option or API.
	/// </summary>
	[JsonPropertyName("id")]
	public string? Id { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue("true")]
	public bool? Show { get; set; } 

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
	/// Distance between legend component and the left side of the container.
	///  
	/// left can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'left' , 'center' , or 'right' .
	///  
	/// If the left value is set to be 'left' , 'center' , or 'right' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("left")]
	[DefaultValue("auto")]
	public NumberOrString? Left { get; set; } 

	/// <summary>
	/// Distance between legend component and the top side of the container.
	///  
	/// top can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' ; and it can also be 'top' , 'middle' , or 'bottom' .
	///  
	/// If the top value is set to be 'top' , 'middle' , or 'bottom' , then the component will be aligned automatically based on position.
	/// </summary>
	[JsonPropertyName("top")]
	[DefaultValue("auto")]
	public NumberOrString? Top { get; set; } 

	/// <summary>
	/// Distance between legend component and the right side of the container.
	///  
	/// right can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("right")]
	[DefaultValue("auto")]
	public NumberOrString? Right { get; set; } 

	/// <summary>
	/// Distance between legend component and the bottom side of the container.
	///  
	/// bottom can be a pixel value like 20 ; it can also be a percentage value relative to container width like '20%' .
	///  
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("bottom")]
	[DefaultValue("auto")]
	public NumberOrString? Bottom { get; set; } 

	/// <summary>
	/// Width of legend component.
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("width")]
	[DefaultValue("auto")]
	public NumberOrString? Width { get; set; } 

	/// <summary>
	/// Height of legend component.
	/// Adaptive by default.
	/// </summary>
	[JsonPropertyName("height")]
	[DefaultValue("auto")]
	public NumberOrString? Height { get; set; } 

	/// <summary>
	/// The layout orientation of legend.
	///  
	/// Options:   'horizontal'  'vertical'
	/// </summary>
	[JsonPropertyName("orient")]
	[DefaultValue("horizontal")]
	public Orient? Orient { get; set; } 

	/// <summary>
	/// Legend marker and text aligning.
	/// By default, it automatically calculates from component location and orientation.
	/// When left value of this component is 'right', and the vertical layout ( orient is 'vertical'), it would be aligned to 'right'.
	///  
	/// Option:   'auto'  'left'  'right'
	/// </summary>
	[JsonPropertyName("align")]
	[DefaultValue("auto")]
	public HorizontalAlign? Align { get; set; } 

	/// <summary>
	/// legend space around content.
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
	/// The distance between each legend, horizontal distance in horizontal layout, and vertical distance in vertical layout.
	/// </summary>
	[JsonPropertyName("itemGap")]
	[DefaultValue("10")]
	public double? ItemGap { get; set; } 

	/// <summary>
	/// Image width of legend symbol.
	/// </summary>
	[JsonPropertyName("itemWidth")]
	[DefaultValue("25")]
	public double? ItemWidth { get; set; } 

	/// <summary>
	/// Image height of legend symbol.
	/// </summary>
	[JsonPropertyName("itemHeight")]
	[DefaultValue("14")]
	public double? ItemHeight { get; set; } 

	/// <summary>
	/// Legend item style.
	/// If its children have values as 'inherit' , the values are inherited from corresponding series options.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// Legend line style.
	/// If its children have values as 'inherit' , the values are inherited from corresponding series options.
	/// </summary>
	[JsonPropertyName("lineStyle")]
	public LineStyle? LineStyle { get; set; } 

	/// <summary>
	/// Rotation of the symbol, which can be number | 'inherit' .
	/// If it's 'inherit' , symbolRotate of the series will be used.
	/// </summary>
	[JsonPropertyName("symbolRotate")]
	[DefaultValue("inherit")]
	public NumberOrString? SymbolRotate { get; set; } 

	/// <summary>
	/// Formatter is used to format label of legend, which supports string template and callback function.
	///  
	/// Example:  // using string template, the template variable is legend name {name}
	/// formatter: 'Legend {name}'
	/// // using callback function
	/// formatter: function (name) {
	///     return 'Legend ' + name;
	/// }
	/// </summary>
	[JsonPropertyName("formatter")]
	public StringOrFunction? Formatter { get; set; } 

	/// <summary>
	/// Selected mode of legend, which controls whether series can be toggled displaying by clicking legends.
	/// It is enabled by default, and you may set it to be false to disable it.
	///  
	/// Besides, it can be set to 'single' or 'multiple' , for single selection and multiple selection.
	/// </summary>
	[JsonPropertyName("selectedMode")]
	[DefaultValue(true)]
	public SelectionMode? SelectedMode { get; set; } 

	/// <summary>
	/// Legend color when not selected.
	/// </summary>
	[JsonPropertyName("inactiveColor")]
	[DefaultValue("#ccc")]
	public Color? InactiveColor { get; set; } 

	/// <summary>
	/// Legend border color when not selected.
	/// </summary>
	[JsonPropertyName("inactiveBorderColor")]
	[DefaultValue("#ccc")]
	public Color? InactiveBorderColor { get; set; } 

	/// <summary>
	/// Legend border width when not selected.
	/// If it is 'auto' , the border width is set to be 2 if there is border width in the series, 0 elsewise.
	/// If it is 'inherit' , it always takes the border width of the series.
	/// </summary>
	[JsonPropertyName("inactiveBorderWidth")]
	[DefaultValue("#ccc")]
	public Color? InactiveBorderWidth { get; set; } 

	/// <summary>
	/// State table of selected legend.
	///  
	/// example:  selected: {
	///     // selected'series 1'
	///     'series 1': true,
	///     // unselected'series 2'
	///     'series 2': false
	/// }
	/// </summary>
	[JsonPropertyName("selected")]
	public Selected? Selected { get; set; } 

	/// <summary>
	/// Legend text style.
	/// </summary>
	[JsonPropertyName("textStyle")]
	public TextStyle? TextStyle { get; set; } 

	/// <summary>
	/// Tooltip configuration for legend tooltip, which is similar to tooltip .
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; } 

	/// <summary>
	/// Icon of the legend items.
	///  
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
	/// </summary>
	[JsonPropertyName("icon")]
	public Icon? Icon { get; set; } 

	/// <summary>
	/// Data array of legend.
	/// An array item is usually a name representing string.
	/// (If it is a pie chart , it could also be the name of a single data in the pie chart) of a series.
	/// Legend component would automatically calculate the color and icon according to series.
	/// Special string '' (null string) or '\n' (new line string) can be used for a new line.
	///  
	/// If data is not specified, it will be auto collected from series.
	/// For most of series, it will be collected from series.name or the dimension name specified by seriesName of series.encode .
	/// For some types of series like pie and funnel , it will be collected from the name field of series.data .
	///  
	/// If you need to set the style for a single item, you may also set the configuration of it.
	/// In this case, name attribute is used to represent name of series .
	///  
	/// Example:  data: [{
	///     name: 'series 1',
	///     // compulsorily set icon as a circle
	///     icon: 'circle',
	///     // set up the text in red
	///     textStyle: {
	///         color: 'red'
	///     }
	/// }]
	/// </summary>
	[JsonPropertyName("data")]
	public List<LegendData>? Data { get; set; } 

	/// <summary>
	/// Background color of legend, which is transparent by default.
	///   
	/// Color can be represented in RGB, for example 'rgb(128, 128, 128)' .
	/// RGBA can be used when you need alpha channel, for example 'rgba(128, 128, 128, 0.5)' .
	/// You may also use hexadecimal format, for example '#ccc' .
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	[DefaultValue("transparent")]
	public Color? BackgroundColor { get; set; } 

	/// <summary>
	/// Border color of legend.
	/// Support the same color format as backgroundColor.
	/// </summary>
	[JsonPropertyName("borderColor")]
	[DefaultValue("#ccc")]
	public Color? BorderColor { get; set; } 

	/// <summary>
	/// Border width of legend.
	/// </summary>
	[JsonPropertyName("borderWidth")]
	[DefaultValue("1")]
	public double? BorderWidth { get; set; } 

	/// <summary>
	/// The radius of rounded corner.
	/// Its unit is px.
	/// And it supports use array to respectively specify the 4 corner radiuses.
	///  
	/// For example:  borderRadius: 5, // consistently set the size of 4 rounded corners
	/// borderRadius: [5, 5, 0, 0] // (clockwise upper left, upper right, bottom right and bottom left)
	/// </summary>
	[JsonPropertyName("borderRadius")]
	[DefaultValue(0)]
	public Radius? BorderRadius { get; set; } 

	/// <summary>
	/// Size of shadow blur.
	/// This attribute should be used along with shadowColor , shadowOffsetX , shadowOffsetY to set shadow to component.
	///  
	/// For example:  {
	///     shadowColor: 'rgba(0, 0, 0, 0.5)',
	///     shadowBlur: 10
	/// }  
	/// Attention : This property works only if show: true is configured and backgroundColor is defined other than transparent .
	/// </summary>
	[JsonPropertyName("shadowBlur")]
	[DefaultValue("")]
	public double? ShadowBlur { get; set; } 

	/// <summary>
	/// Shadow color.
	/// Support same format as color .
	///  
	/// Attention : This property works only if show: true configured.
	/// </summary>
	[JsonPropertyName("shadowColor")]
	[DefaultValue("")]
	public Color? ShadowColor { get; set; } 

	/// <summary>
	/// Offset distance on the horizontal direction of shadow.
	///  
	/// Attention : This property works only if show: true configured.
	/// </summary>
	[JsonPropertyName("shadowOffsetX")]
	[DefaultValue("0")]
	public double? ShadowOffsetX { get; set; } 

	/// <summary>
	/// Offset distance on the vertical direction of shadow.
	///  
	/// Attention : This property works only if show: true configured.
	/// </summary>
	[JsonPropertyName("shadowOffsetY")]
	[DefaultValue("0")]
	public double? ShadowOffsetY { get; set; } 

	/// <summary>
	/// It works when legend.type is 'scroll' .
	///  
	/// dataIndex of the left top most displayed item.
	///  
	/// Although the scrolling of legend items can be controlled by calling setOption and specifying this property, we suggest that do not control legend in this way unless necessary ( setOption might be time-consuming), but just use action legendScroll to do that.
	///  
	/// See vertically scrollable legend or horizontally scrollable legend .
	/// </summary>
	[JsonPropertyName("scrollDataIndex")]
	[DefaultValue(0)]
	public int? ScrollDataIndex { get; set; } 

	/// <summary>
	/// It works when legend.type is 'scroll' .
	///  
	/// The gap between page buttons and page info text.
	///  
	/// See vertically scrollable legend or horizontally scrollable legend .
	/// </summary>
	[JsonPropertyName("pageButtonItemGap")]
	[DefaultValue(5)]
	public double? PageButtonItemGap { get; set; } 

	/// <summary>
	/// It works when legend.type is 'scroll' .
	///  
	/// The gap between page buttons and legend items.
	///  
	/// See vertically scrollable legend or horizontally scrollable legend .
	/// </summary>
	[JsonPropertyName("pageButtonGap")]
	public double? PageButtonGap { get; set; } 

	/// <summary>
	/// It works when legend.type is 'scroll' .
	///  
	/// The position of page buttons and page info.
	/// Optional values:   'start' : on the left or top.
	///  'end' : on the right or bottom.
	///   
	/// See vertically scrollable legend or horizontally scrollable legend .
	/// </summary>
	[JsonPropertyName("pageButtonPosition")]
	[DefaultValue("end")]
	public string? PageButtonPosition { get; set; } 

	/// <summary>
	/// It works when legend.type is 'scroll' .
	///  
	/// Page info formatter.
	/// It is '{current}/{total}' by default, where {current} is current page number (start from 1), and {total} is the total page number.
	///  
	/// If pageFormatter is a function, it should return a string.
	/// The parameters is:  {
	///     current: number
	///     total: number
	/// }  
	/// See vertically scrollable legend or horizontally scrollable legend .
	/// </summary>
	[JsonPropertyName("pageFormatter")]
	[DefaultValue("{current}/{total}")]
	public StringOrFunction? PageFormatter { get; set; } 

	/// <summary>
	/// It works when legend.type is 'scroll' .
	///  
	/// The icons of page buttons.
	/// </summary>
	[JsonPropertyName("pageIcons")]
	public PageIcons? PageIcons { get; set; } 

	/// <summary>
	/// It works when legend.type is 'scroll' .
	///  
	/// The color of page buttons.
	///  
	/// See vertically scrollable legend or horizontally scrollable legend .
	/// </summary>
	[JsonPropertyName("pageIconColor")]
	[DefaultValue("#2f4554")]
	public Color? PageIconColor { get; set; } 

	/// <summary>
	/// It works when legend.type is 'scroll' .
	///  
	/// The color of page buttons when they are inactive.
	///  
	/// See vertically scrollable legend or horizontally scrollable legend .
	/// </summary>
	[JsonPropertyName("pageIconInactiveColor")]
	[DefaultValue("#aaa")]
	public Color? PageIconInactiveColor { get; set; } 

	/// <summary>
	/// It works when legend.type is 'scroll' .
	///  
	/// The size of page buttons.
	/// It can be a number, or an array, like [10, 3] , represents [width, height] .
	///  
	/// See vertically scrollable legend or horizontally scrollable legend .
	/// </summary>
	[JsonPropertyName("pageIconSize")]
	[DefaultValue("15,15")]
	//TODO: Type Warning: Failed to map property 'pageIconSize' in type 'legend' with types 'array,number,vector'
	public object? PageIconSize { get; set; } 

	/// <summary>
	/// It works when legend.type is 'scroll' .
	///  
	/// The text style of page info.
	/// </summary>
	[JsonPropertyName("pageTextStyle")]
	public PageTextStyle? PageTextStyle { get; set; } 

	/// <summary>
	/// Whether to use animation when page scrolls.
	/// </summary>
	[JsonPropertyName("animation")]
	[DefaultValue("true")]
	public bool? Animation { get; set; } 

	/// <summary>
	/// Duration of the page scroll animation.
	/// </summary>
	[JsonPropertyName("animationDurationUpdate")]
	[DefaultValue("800")]
	public double? AnimationDurationUpdate { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

	/// <summary>
	/// Since v4.4.0   
	/// The selector button in the legend component.
	/// Currently, there are two types of button:   all : Select All  inverse : Inverse Selection   
	/// The selector button doesn't display by default, you need to enable it manually as follows.
	///  selector: [
	///     {
	///         type: 'all',
	///         // can be any title you like
	///         title: 'All'
	///     },
	///     {
	///         type: 'inverse',
	///         // can be any title you like
	///         title: 'Inv'
	///     }
	/// ]
	/// 
	/// // or
	/// selector: true
	/// 
	/// // or
	/// selector: ['all', 'inverse']
	/// </summary>
	[JsonPropertyName("selector")]
	[DefaultValue(false)]
	public Selector? Selector { get; set; } 

	/// <summary>
	/// Since v4.4.0   
	/// The text label style of the selector button, which is displayed by default.
	/// </summary>
	[JsonPropertyName("selectorLabel")]
	public SelectorLabel? SelectorLabel { get; set; } 

	/// <summary>
	/// Since v4.4.0   
	/// The position of the selector button, which can be placed at the end or start of the legend component, the corresponding values are 'end' and 'start' .
	/// By default, when the legend is laid out horizontally, the selector is placed at the end of it, and when the legend is laid out vertically, the selector is placed at the start of it.
	/// </summary>
	[JsonPropertyName("selectorPosition")]
	[DefaultValue("auto")]
	public StartOrEnd? SelectorPosition { get; set; } 

	/// <summary>
	/// Since v4.4.0   
	/// The gap between the selector button.
	/// </summary>
	[JsonPropertyName("selectorItemGap")]
	[DefaultValue("7")]
	public double? SelectorItemGap { get; set; } 

	/// <summary>
	/// Since v4.4.0   
	/// The gap between selector button and legend component.
	/// </summary>
	[JsonPropertyName("selectorButtonGap")]
	[DefaultValue("10")]
	public double? SelectorButtonGap { get; set; } 

}
