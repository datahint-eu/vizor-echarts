
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class ScatterSeriesData
{
	/// <summary>
	/// the name of data item.
	/// </summary>
	[JsonPropertyName("name")]
	public string? Name { get; set; }

	/// <summary>
	/// the value of data item.
	/// </summary>
	[JsonPropertyName("value")]
	public object? Value { get; set; }

	/// <summary>
	/// The groupID of this data item.
	/// groupID will be used to classify the data.
	/// </summary>
	[JsonPropertyName("groupId")]
	public string? GroupId { get; set; }

	/// <summary>
	/// Symbol of single data.
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
	/// single data symbol size.
	/// It can be set to single numbers like 10 , or use an array to represent width and height.
	/// For example, [20, 10] means symbol width is 20 , and height is 10 .
	/// </summary>
	[JsonPropertyName("symbolSize")]
	public NumberOrNumberArray? SymbolSize { get; set; }

	/// <summary>
	/// Rotate degree of single data symbol.
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
	/// Offset of single data symbol relative to original position.
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
	/// 
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
	/// the style setting about single data point(bubble).
	/// </summary>
	[JsonPropertyName("itemStyle")]
	public ItemStyle? ItemStyle { get; set; }

	/// <summary>
	/// Emphasis state of single data.
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Blur state of single data.
	/// </summary>
	[JsonPropertyName("blur")]
	public Blur? Blur { get; set; }

	/// <summary>
	/// Since v5.0.0   
	/// Select state of single data.
	/// </summary>
	[JsonPropertyName("select")]
	public Select? Select { get; set; }

	/// <summary>
	/// tooltip settings in this series data.
	/// </summary>
	[JsonPropertyName("tooltip")]
	public Tooltip? Tooltip { get; set; }

}
