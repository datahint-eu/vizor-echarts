namespace Vizor.ECharts.BindingGenerator.Types;

internal class PrimitiveType : IPropertyType
{
	public PrimitiveType(Type mappedType)
	{
		MappedType = mappedType;

		if (mappedType == typeof(string))
		{
			DotNetType = "string";
		}
		else if (mappedType == typeof(double))
		{
			DotNetType = "double";
		}
		else if (mappedType == typeof(int))
		{
			DotNetType = "int";
		}
		else if (mappedType == typeof(bool))
		{
			DotNetType = "bool";
		}
		else
		{
			DotNetType = mappedType.Name;
		}
	}

	public string Name => MappedType.Name;

	public string DotNetType { get; }

	public Type MappedType { get; }
}
