namespace Vizor.ECharts.BindingGenerator.AST;

internal class MappedEnumType : IPropertyType
{
	public MappedEnumType(string name, Type type)
	{
		Name = name;
	}

	public string Name { get; }
}
