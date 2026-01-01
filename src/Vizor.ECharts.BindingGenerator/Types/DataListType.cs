namespace Vizor.ECharts.BindingGenerator.Types;

/// <summary>
/// Represents a DataList{T} type for option data properties (Legend.Data, Axis.Data, etc.).
/// Enables implicit conversion from arrays to data lists.
/// </summary>
internal class DataListType : IPropertyType
{
    private readonly IPropertyType genericArgument;

    public DataListType(IPropertyType genericArgument)
    {
        this.genericArgument = genericArgument;
    }

    public string Name => "array";

    public string DotNetType => $"DataList<{genericArgument.DotNetType}>";

    public string? TypeWarning { get; set; }
}
