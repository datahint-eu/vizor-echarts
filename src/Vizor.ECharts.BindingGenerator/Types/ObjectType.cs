using System.Text.Json;

namespace Vizor.ECharts.BindingGenerator.Types;

internal class ObjectType : IPropertyType
{
	public ObjectType(string name)
	{
		Name = name;
		DotNetType = Helper.ToClassName(name);
	}

	public string Name { get; }

	public string DotNetType { get; }

	public List<OptionProperty> Properties { get; } = new List<OptionProperty>();
}
