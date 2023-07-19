// AUTO GENERATED - DO NOT EDIT - All changes will be lost
// http://www.datahint.eu/


using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class MarkPointData
{
	/// <summary>
	/// Mark point name.
	/// </summary>
	[JsonPropertyName("name")]
	[DefaultValue("")]
	public string? Name { get; set; } 

	/// <summary>
	/// Special label types, are used to label maximum value, minimum value and so on.
	///  
	/// Options are:   'min' maximum value.
	///  'max' minimum value.
	///  'average' average value.
	/// </summary>
	[JsonPropertyName("type")]
	public MarkPointType? Type { get; set; } 

	/// <summary>
	/// Available when using type it is used to assign maximum value and minimum value in dimensions, it could be 0 (xAxis, radiusAxis), 1 (yAxis, angleAxis), and use the first value axis dimension by default.
	/// </summary>
	[JsonPropertyName("valueIndex")]
	public int? ValueIndex { get; set; } 

	/// <summary>
	/// Works only when type is assigned.
	/// It is used to state the dimension used to calculate maximum value or minimum value.
	/// It may be the direct name of a dimension, like x , or angle for line charts, or open , or close for candlestick charts.
	/// </summary>
	[JsonPropertyName("valueDim")]
	public string? ValueDim { get; set; } 

	/// <summary>
	/// Coordinates of the starting point or ending point, whose format depends on the coordinate of the series.
	/// It can be x , and y for rectangular coordinates , or radius , and angle for polar coordinates .
	///  
	/// Notice: For axis with axis.type  'category' :   If coord value is number , it represents index of axis.data .
	///  If coord value is string , it represents concrete value in axis.data .
	/// Please notice that in this case xAxis.data must not be written as [number, number, ...], but can only be written [string, string, ...].
	/// Otherwise it is not able to be located by markPoint / markLine.
	///   
	/// For example:  {
	///     xAxis: {
	///         type: 'category',
	///         data: ['5', '6', '9', '13', '19', '33']
	///         // As mentioned above, data should not be [5, 6, 9, 13, 19, 33] here.
	///     },
	///     series: {
	///         type: 'line',
	///         data: [11, 22, 33, 44, 55, 66],
	///         markPoint: { // markLine is in the same way.
	///             data: [{
	///                 coord: [5, 33.4], // The number 5 represents xAxis.data[5], that is, '33'.
	///                 // coord: ['5', 33.4] // The string '5' represents the '5' in xAxis.data.
	///             }]
	///         }
	///     }
	/// }
	/// </summary>
	[JsonPropertyName("coord")]
	public List<object>? Coord { get; set; } 

	/// <summary>
	/// X position according to container, in pixel.
	/// </summary>
	[JsonPropertyName("x")]
	[DefaultValue("0")]
	public double? X { get; set; } 

	/// <summary>
	/// Y position according to container, in pixel.
	/// </summary>
	[JsonPropertyName("y")]
	[DefaultValue("0")]
	public double? Y { get; set; } 

	/// <summary>
	/// Label value, which can be ignored.
	/// </summary>
	[JsonPropertyName("value")]
	public double? Value { get; set; } 

	/// <summary>
	/// Symbol of .
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
	[JsonPropertyName("symbol")]
	[DefaultValue("circle")]
	public Icon? Symbol { get; set; } 

	/// <summary>
	/// symbol size.
	/// It can be set to single numbers like 10 , or use an array to represent width and height.
	/// For example, [20, 10] means symbol width is 20 , and height is 10 .
	/// </summary>
	[JsonPropertyName("symbolSize")]
	public NumberOrNumberArray? SymbolSize { get; set; } 

	/// <summary>
	/// Rotate degree of  symbol.
	/// The negative value represents clockwise.
	/// Note that when symbol is set to be 'arrow' in markLine , symbolRotate value will be ignored, and compulsively use tangent angle.
	/// </summary>
	[JsonPropertyName("symbolRotate")]
	public double? SymbolRotate { get; set; } 

	/// <summary>
	/// Whether to keep aspect for symbols in the form of path:// .
	/// </summary>
	[JsonPropertyName("symbolKeepAspect")]
	[DefaultValue(false)]
	public bool? SymbolKeepAspect { get; set; } 

	/// <summary>
	/// Offset of  symbol relative to original position.
	/// By default, symbol will be put in the center position of data.
	/// But if symbol is from user-defined vector path or image, you may not expect symbol to be in center.
	/// In this case, you may use this attribute to set offset to default position.
	/// It can be in absolute pixel value, or in relative percentage value.
	///  
	/// For example, [0, '-50%'] means to move upside side position of symbol height.
	/// It can be used to make the arrow in the bottom to be at data position when symbol is pin.
	/// </summary>
	[JsonPropertyName("symbolOffset")]
	[DefaultValue("[0, 0]")]
	public double[]? SymbolOffset { get; set; } 

	/// <summary>
	/// Mark point style.
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("label")]
	public Label? Label { get; set; } 

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; } 

}
