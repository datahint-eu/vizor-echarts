namespace Vizor.ECharts.BindingGenerator.AST;

internal class GenericListType : IPropertyType
{
	private readonly IPropertyType genericArgument;

	public GenericListType(IPropertyType genericArgument)
	{
		this.genericArgument = genericArgument;
	}

	public string Name => "array";

	public string DotNetType => $"List<{genericArgument.DotNetType}>";
}
