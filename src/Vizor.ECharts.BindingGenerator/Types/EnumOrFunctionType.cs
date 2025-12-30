namespace Vizor.ECharts.BindingGenerator.Types;

/// <summary>
/// Represents a type that can be either an enum or a JavascriptFunction.
/// Used for properties like FunnelSeries.Sort, SunburstSeries.Sort where ECharts accepts enum values OR custom functions.
/// Generates three properties: ObjectBackingField, EnumAccessor, and FunctionAccessor.
/// </summary>
internal class EnumOrFunctionType : IPropertyType
{
	public EnumOrFunctionType(string enumTypeName)
	{
		EnumTypeName = enumTypeName;
	}

	/// <summary>
	/// The name of the enum type (e.g., "FunnelSortOrder", "SortOrder")
	/// </summary>
	public string EnumTypeName { get; }

	/// <summary>
	/// Returns "EnumOrFunction" to identify this special type
	/// </summary>
	public string Name => "EnumOrFunction";

	/// <summary>
	/// The backing field type is always "object" to support both enum and function forms
	/// </summary>
	public string DotNetType => "object";

	public string? TypeWarning { get; set; }
}
