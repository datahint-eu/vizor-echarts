namespace Vizor.ECharts.BindingGenerator.AST;

internal class PrimitiveType : IPropertyType
{
    public PrimitiveType(Type mappedType)
    {
		MappedType = mappedType;
	}

	public string Name => MappedType.Name;
	public Type MappedType { get; }
}
