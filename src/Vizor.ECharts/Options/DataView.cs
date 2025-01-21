
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class DataView
{
	/// <summary>
	/// Whether to show the tool.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue(true)]
	public bool? Show { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("title")]
	[DefaultValue("data view")]
	public string? Title { get; set; }

	/// <summary>
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
	/// The style setting of data view icon.
	/// Since icon label is displayed only when hovering on the icon, the label configuration options are available under emphasis .
	/// </summary>
	[JsonPropertyName("iconStyle")]
	public IconStyle? IconStyle { get; set; }

	/// <summary>
	/// 
	/// </summary>
	[JsonPropertyName("emphasis")]
	public Emphasis? Emphasis { get; set; }

	/// <summary>
	/// Whether it is read-only.
	/// </summary>
	[JsonPropertyName("readOnly")]
	[DefaultValue(false)]
	public bool? ReadOnly { get; set; }

	/// <summary>
	/// (option:Object) => HTMLDomElement|string  
	/// Define a function to present dataView.
	/// It is used to replace default textarea for richer data editing.
	/// It can return a DOM object, or an HTML string.
	/// </summary>
	[JsonPropertyName("optionToContent")]
	public JavascriptFunction? OptionToContent { get; set; }

	/// <summary>
	/// (container:HTMLDomElement, option:Object) => Object  
	/// When optionToContent is used, if you want to support refreshing chart after data changes, you need to implement the logic to merge options in this function.
	/// </summary>
	[JsonPropertyName("contentToOption")]
	public JavascriptFunction? ContentToOption { get; set; }

	/// <summary>
	/// There are 3 names in data view, which are ['data view', 'turn off' and 'refresh'] .
	/// </summary>
	[JsonPropertyName("lang")]
	[DefaultValue("[data view, turn off, refresh]")]
	public string[]? Lang { get; set; }

	/// <summary>
	/// Background color of the floating layer in data view.
	/// </summary>
	[JsonPropertyName("backgroundColor")]
	[DefaultValue("#fff")]
	public Color? BackgroundColor { get; set; }

	/// <summary>
	/// Background color of input area of the floating layer in data view.
	/// </summary>
	[JsonPropertyName("textareaColor")]
	[DefaultValue("#fff")]
	public Color? TextareaColor { get; set; }

	/// <summary>
	/// Border color of input area of the floating layer in data view.
	/// </summary>
	[JsonPropertyName("textareaBorderColor")]
	[DefaultValue("#333")]
	public Color? TextareaBorderColor { get; set; }

	/// <summary>
	/// Text color.
	/// </summary>
	[JsonPropertyName("textColor")]
	[DefaultValue("#000")]
	public Color? TextColor { get; set; }

	/// <summary>
	/// Button color.
	/// </summary>
	[JsonPropertyName("buttonColor")]
	[DefaultValue("#c23531")]
	public Color? ButtonColor { get; set; }

	/// <summary>
	/// Color of button text.
	/// </summary>
	[JsonPropertyName("buttonTextColor")]
	[DefaultValue("#fff")]
	public Color? ButtonTextColor { get; set; }

}
