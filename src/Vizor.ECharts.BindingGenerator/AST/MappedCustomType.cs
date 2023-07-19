namespace Vizor.ECharts.BindingGenerator.AST;

internal class MappedCustomType : IPropertyType
{
	public MappedCustomType(Type customType)
	{
		CustomType = customType;
	}

	public string Name => CustomType.Name;

	public string DotNetType => CustomType.Name;

	public Type CustomType { get; }
}
