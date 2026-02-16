namespace Vizor.ECharts.BindingGenerator.Types;

internal class SeriesDataListType : IPropertyType
{
    private readonly IPropertyType genericArgument;

    public SeriesDataListType(IPropertyType genericArgument)
    {
        this.genericArgument = genericArgument;
    }

    public string Name => "array";

    public string DotNetType => $"SeriesDataList<{genericArgument.DotNetType}>";

    public string? TypeWarning { get; set; }
}
