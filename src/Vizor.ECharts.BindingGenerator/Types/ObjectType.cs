using System.Text.Json;

namespace Vizor.ECharts.BindingGenerator.Types;

internal class ObjectType : IPropertyType, IObjectType
{
	public ObjectType(OptionProperty? parent, string name)
	{
		Parent = parent;
		Name = name;
		DotNetType = Helper.ToClassName(name);
	}

	public OptionProperty? Parent { get; }
	public string Name { get; }
	public string DotNetType { get; }

	public List<OptionProperty> Properties { get; } = new List<OptionProperty>();

	public string Path => Parent == null ? string.Empty : Parent.Path + "." + Name;
}
