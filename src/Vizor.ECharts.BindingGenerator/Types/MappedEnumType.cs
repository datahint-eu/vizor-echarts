namespace Vizor.ECharts.BindingGenerator.Types;

internal class MappedEnumType : IPropertyType
{
	public MappedEnumType(string name, Type type)
	{
		Name = name;
		EnumType = type;
	}

	public string Name { get; }
	public Type EnumType { get; }

	public string DotNetType => EnumType.Name;
}
