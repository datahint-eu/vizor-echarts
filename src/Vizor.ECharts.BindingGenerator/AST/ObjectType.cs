using System.Text.Json;

namespace Vizor.ECharts.BindingGenerator.AST;

internal class ObjectType : IPropertyType
{
	public ObjectType(string name)
	{
		Name = name;
	}

	public string Name { get; }

	public List<OptionProperty> Properties { get; } = new List<OptionProperty>();
}
