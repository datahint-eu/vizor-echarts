namespace Vizor.ECharts.BindingGenerator.AST;

internal class ArrayType : IPropertyType
{
	public ArrayType()
	{
	}

	public string Name => "array";

	public string DotNetType => "List<object>";
}
