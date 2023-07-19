namespace Vizor.ECharts.BindingGenerator.Types;

internal class ObjectListType : IPropertyType
{
	public ObjectListType()
	{
	}

	public string Name => "array";

	public string DotNetType => "List<object>";
}
