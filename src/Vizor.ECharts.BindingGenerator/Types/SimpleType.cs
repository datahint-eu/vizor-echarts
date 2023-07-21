namespace Vizor.ECharts.BindingGenerator.Types;

internal class SimpleType : IPropertyType
{
	public SimpleType(string mappedType)
	{
		Name = DotNetType = mappedType;
	}

	public string Name { get; }

	public string DotNetType { get; }

	public string? TypeWarning { get; set; }
}
