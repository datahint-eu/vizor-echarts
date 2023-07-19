using Vizor.ECharts.Enums;
using Vizor.ECharts.Types;

namespace Vizor.ECharts.Options;

public class Tooltip
{
	/// <summary>
	/// Whether to show the tooltip component. Including tooltip floating layer and axisPointer.
	/// </summary>
	public bool? Show { get; set; }

	/// <summary>
	/// Type of triggering.
	/// </summary>
	public TooltipTrigger? Trigger { get; set; }

	//TODO: AxisPointer

	/// <summary>
	/// Whether to show the tooltip floating layer, whose default value is true.
	/// It should be configurated to be false, if you only need tooltip to trigger the event or show the axisPointer without content.
	/// Default = true
	/// </summary>
	public bool? ShowContent { get; set; }

	/// <summary>
	/// Whether to show tooltip content all the time.
	/// By default, it will be hidden after some time. It can be set to be true to preserve displaying.
	/// </summary>
	public bool? AlwaysShowContent { get; set; }

	/// <summary>
	/// Conditions to trigger tooltip. Default = mousemove|click
	/// </summary>
	public TooltipTriggerOn? TriggerOn { get; set; }

	/// <summary>
	/// Delay time for showing tooltip, in ms.
	/// No delay by default, and it is not recommended to set. Only valid when triggerOn is set to be
	/// </summary>
	public double? ShowDelay { get; set; }

	/// <summary>
	/// Delay time for hiding tooltip, in ms. It will be invalid when alwaysShowContent is true.
	/// Default = 100 ms
	/// </summary>
	public double? HideDelay { get; set; }

	/// <summary>
	/// Whether mouse is allowed to enter the floating layer of tooltip, whose default value is false. If you need to interact in the tooltip like with links or buttons, it can be set as true.
	/// Default = true
	/// </summary>
	public bool? Enterable { get; set; }

	/// <summary>
	/// Render mode for tooltip. By default, it is set to be 'html' so that extra DOM element is used for tooltip. It can also set to be 'richText' so that the tooltip will be rendered inside Canvas.
	/// This is very useful for environments that don't have DOM, such as Wechat applications.
	/// Default = html
	/// </summary>
	public TooltipRenderMode? RenderMode { get; set; }

	/// <summary>
	/// Whether confine tooltip content in the view rect of chart instance.
	/// Useful when tooltip is cut because of 'overflow: hidden' set on outer dom of chart instance, or because of narrow screen on mobile.
	/// </summary>
	public bool? Confine { get; set; }

	/// <summary>
	/// Whether to append the tooltip DOM element as a child of the <body> of the HTML page, when using renderMode 'html'.
	/// Default = false
	/// </summary>
	public bool? AppendToBody { get; set; }

	/// <summary>
	/// Specify the classes for the tooltip root DOM. (Only works in html render mode).
	/// </summary>
	public string? ClassName { get; set; }

	/// <summary>
	/// he transition duration of tooltip's animation, in SECONDS. When it is set to be 0, it would move closely with the mouse.
	/// Default = 0.4 s
	/// </summary>
	public double? TransitionDuration { get; set; }

	//TODO: Position

	//TODO: Formatter, ValueFormatter

	/// <summary>
	/// The background color of tooltip's floating layer.
	/// Default = 'rgba(50,50,50,0.7)'
	/// </summary>
	public Color? BackgroundColor { get; set; }

	/// <summary>
	/// The border color of tooltip's floating layer.
	/// Default = '#333'
	/// </summary>
	public Color? BorderColor { get; set; }

	/// <summary>
	/// The border width of tooltip's floating layer.
	/// </summary>
	public double? BorderWidth { get; set; }

	/// <summary>
	/// The floating layer of tooltip space around content. The unit is px.
	/// Default values for each position are 5. And they can be set to different values with left, right, top, and bottom.
	/// </summary>
	public Padding? Padding { get; set; }

	/// <summary>
	/// The text syle of tooltip's floating layer.
	/// </summary>
	public TextStyle? TextStyle { get; set; }

	/// <summary>
	/// Extra CSS style for floating layer.
	/// </summary>
	public string? ExtraCssText { get; set; }

	/// <summary>
	/// Tooltip order for multiple series. Defaults is 'seriesAsc'.
	/// </summary>
	public TooltipOrder? Order { get; set; }
}