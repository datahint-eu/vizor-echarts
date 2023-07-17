namespace Vizor.ECharts.Options;

public interface IPositionOption
{
	/// <summary>
	/// Distance between title component and the left side of the container.
	/// left can be a pixel value like 20; it can also be a percentage value relative to container width like '20%'; and it can also be 'left', 'center', or 'right'.
	/// If the left value is set to be 'left', 'center', or 'right', then the component will be aligned automatically based on position.
	/// Default=auto
	/// </summary>
	string? Left { get; set; }

	/// <summary>
	///Distance between title component and the top side of the container.
	///top can be a pixel value like 20; it can also be a percentage value relative to container width like '20%'; and it can also be 'top', 'middle', or 'bottom'.
	///If the top value is set to be 'top', 'middle', or 'bottom', then the component will be aligned automatically based on position.
	/// Default=auto
	/// </summary>
	string? Top { get; set; }

	/// <summary>
	/// Distance between title component and the right side of the container.
	/// right can be a pixel value like 20; it can also be a percentage value relative to container width like '20%'.
	/// Adaptive by default.
	/// Default=auto
	/// </summary>
	string? Right { get; set; }

	/// <summary>
	/// Distance between title component and the bottom side of the container.
	/// bottom can be a pixel value like 20; it can also be a percentage value relative to container width like '20%'.
	/// Adaptive by default.
	/// Default=auto
	/// </summary>
	string? Bottom { get; set; }
}
