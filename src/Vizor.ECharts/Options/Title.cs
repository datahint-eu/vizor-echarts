using System.Text.Json.Serialization;

namespace Vizor.ECharts.Options;

/// <summary>
/// 
/// See https://echarts.apache.org/en/option.html#title
/// </summary>
public class Title
	: IOption
	, IPositionOption
	, IBorderOption
	, IShadowOption
	, IZOption
	, IPaddingOption
{
	/// <inheritdoc />
	public string? Id { get; set; }

	/// <inheritdoc />
	public bool? Show { get; set; } = true;

	/// <summary>
	/// The main title text, supporting for \n for newlines.
	/// </summary>
	public string Text { get; set; } = string.Empty;

	/// <summary>
	/// The hyper link of main title text.
	/// </summary>
	public string? Link { get; set; }

	/// <summary>
	/// Open the hyper link of main title in specified tab.
	/// 'self' opening it in current tab
	/// 'blank' [default] opening it in a new tab
	/// </summary>
	public string? Target { get; set; }

	public TextStyle? TextStyle { get; set; }

	/// <summary>
	/// Subtitle text, supporting for \n for newlines.
	/// </summary>
	[JsonPropertyName("subtext")]
	public string? SubText { get; set; }

	/// <summary>
	/// The hyper link of subtitle text.
	/// </summary>
	[JsonPropertyName("sublink")]
	public string? SubLink { get; set; }

	/// <summary>
	/// Open the hyper link of subtitle in specified tab.
	/// 'self' opening it in current tab
	/// 'blank' [default] opening it in a new tab
	/// </summary>
	[JsonPropertyName("subtarget")]
	public string? SubTarget { get; set; }

	[JsonPropertyName("subtextStyle")]
	public TextStyle? SubTextStyle { get; set; }

	/// <summary>
	/// The horizontal align of the component (including "text" and "subtext").
	/// Default = auto
	/// </summary>
	public HAlign? TextAlign { get; set; }

	/// <summary>
	/// The vertical align of the component (including "text" and "subtext").
	/// Default = auto
	/// </summary>
	public VAlign? TextVerticalAlign { get; set; }

	/// <summary>
	/// Set this to true to enable triggering events
	/// </summary>
	public bool TriggerEvent { get; set; }

	/// <inheritdoc />
	public Padding? Padding { get; set; }

	/// <summary>
	/// The gap between the main title and subtitle.
	/// Default=10
	/// </summary>
	public double? ItemGap { get; set; }


	/// <inheritdoc />
	[JsonPropertyName("zlevel")]
	public double? ZLevel { get; set; }

	/// <inheritdoc />
	public double? Z { get; set; }


	/// <inheritdoc />
	public string? Left { get; set; }

	/// <inheritdoc />
	public string? Top { get; set; }

	/// <inheritdoc />
	public string? Right { get; set; }

	/// <inheritdoc />
	public string? Bottom { get; set; }

	/// <summary>
	/// Background color of title, which is transparent by default.
	/// See Color class.
	/// </summary>
	public Color? BackgroundColor { get; set; }

	/// <inheritdoc />
	public Color? BorderColor { get; set; }

	/// <inheritdoc />
	public double? BorderWidth { get; set; }

	/// <inheritdoc />
	public Radius? BorderRadius { get; set; }

	/// <inheritdoc />
	public double? ShadowBlur { get; set; }

	/// <inheritdoc />
	public Color? ShadowColor { get; set; }

	/// <inheritdoc />
	public double? ShadowOffsetX { get; set; }

	/// <inheritdoc />
	public double? ShadowOffsetY { get; set; }
}
