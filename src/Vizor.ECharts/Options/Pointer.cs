using System.ComponentModel;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

public partial class Pointer
{
    /// <summary>
    /// Whether to show the pointer.
    /// </summary>
    [JsonPropertyName("show")]
    [DefaultValue("true")]
    public bool? Show { get; set; }

    /// <summary>
    /// Since v5.2.0
    /// Whether to show the pointer above detail and title.
    /// </summary>
    [JsonPropertyName("showAbove")]
    [DefaultValue("true")]
    public bool? ShowAbove { get; set; }

    /// <summary>
    /// Since v5.0
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
    /// Since v5.0
    /// The offset position relative to the center of gauge chart.
    /// The first item of array is the horizontal offset; the second item of array is the vertical offset.
    /// It could be absolute value and also the percentage relative to the radius of gauge chart.
    /// </summary>
    [JsonPropertyName("offsetCenter")]
    [DefaultValue("0,0")]
    public NumberOrString[]? OffsetCenter { get; set; }

    /// <summary>
    /// The length of pointer which could be absolute value and also the percentage relative to radius .
    /// </summary>
    [JsonPropertyName("length")]
    [DefaultValue("60%")]
    public NumberOrString? Length { get; set; }

    /// <summary>
    /// The width of pointer.
    /// </summary>
    [JsonPropertyName("width")]
    [DefaultValue("6")]
    public double? Width { get; set; }

    /// <summary>
    /// Since v5.0
    /// Whether to keep aspect for icons in the form of path:// .
    /// </summary>
    [JsonPropertyName("keepAspect")]
    [DefaultValue("false")]
    public bool? KeepAspect { get; set; }

    /// <summary>
    /// The style of pointer.
    /// </summary>
    [JsonPropertyName("itemStyle")]
    public ItemStyle? ItemStyle { get; set; }
}