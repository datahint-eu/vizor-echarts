namespace Vizor.ECharts.BindingGenerator.Types;

/// <summary>
/// Represents a type that can be either a single object or an array of objects.
/// Used for properties like Grid, XAxis, YAxis where ECharts accepts both single and array forms.
/// Generates three properties: ObjectBackingField, SingleAccessor, and ListAccessor.
/// </summary>
internal class SingleOrArrayType : IPropertyType
{
    public SingleOrArrayType(string innerTypeName)
    {
        InnerTypeName = innerTypeName;
    }

    /// <summary>
    /// The name of the inner type (e.g., "Grid", "XAxis", "YAxis")
    /// </summary>
    public string InnerTypeName { get; }

    /// <summary>
    /// Returns "SingleOrArray" to identify this special type
    /// </summary>
    public string Name => "SingleOrArray";

    /// <summary>
    /// The backing field type is always "object" to support both single and array forms
    /// </summary>
    public string DotNetType => "object";

    public string? TypeWarning { get; set; }
}
