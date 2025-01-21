
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Effect
{
	/// <summary>
	/// Whether to show special effect.
	/// </summary>
	[JsonPropertyName("show")]
	[DefaultValue(false)]
	public bool? Show { get; set; }

	/// <summary>
	/// The duration of special effect, which unit is second.
	/// </summary>
	[JsonPropertyName("period")]
	[DefaultValue(4)]
	public double? Period { get; set; }

	/// <summary>
	/// Effect animation delay.
	/// Can be number or callback function.
	/// </summary>
	[JsonPropertyName("delay")]
	public NumberOrFunction? Delay { get; set; }

	/// <summary>
	/// If symbol movement of special effect has a constant speed, which unit is pixel per second.
	/// period will be ignored if constantSpeed is larger than 0.
	/// </summary>
	[JsonPropertyName("constantSpeed")]
	[DefaultValue(0)]
	public double? ConstantSpeed { get; set; }

	/// <summary>
	/// The symbol of special effect.
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
	/// The above example uses a custom path of plane shape.
	///  
	/// Tip: Ahe angle of symbol changes as the tangent of track changes.
	/// If you use a custom path, you should make sure that the path shape are upward oriented.
	/// It would ensure that the symbol will always move toward the right moving direction when the symbol moves along the track.
	/// </summary>
	[JsonPropertyName("symbol")]
	[DefaultValue("circle")]
	public string? Symbol { get; set; }

	/// <summary>
	/// The symbol size of special effect, which could be set as single number such as 10 .
	/// What's more, arrays could be used to decribe the width and height respectively.
	/// For instance, [20, 10] indicates 20 for width and 10 for height.
	/// </summary>
	[JsonPropertyName("symbolSize")]
	[DefaultValue(3)]
	public NumberOrNumberArray? SymbolSize { get; set; }

	/// <summary>
	/// The color of special effect symbol, which defaults to be same with lineStyle.color .
	/// </summary>
	[JsonPropertyName("color")]
	public Color? Color { get; set; }

	/// <summary>
	/// The length of trail of special effect.
	///  The values from 0 to 1 could be set.
	/// Trail would be longer as the the value becomes larger.
	/// </summary>
	[JsonPropertyName("trailLength")]
	[DefaultValue(0.2)]
	public double? TrailLength { get; set; }

	/// <summary>
	/// Whether to loop the special effect animation.
	/// </summary>
	[JsonPropertyName("loop")]
	[DefaultValue(true)]
	public bool? Loop { get; set; }

	/// <summary>
	/// Since v5.4.0   
	/// Whether to go back when the animation reach the end.
	/// </summary>
	[JsonPropertyName("roundTrip")]
	[DefaultValue(false)]
	public bool? RoundTrip { get; set; }

}
