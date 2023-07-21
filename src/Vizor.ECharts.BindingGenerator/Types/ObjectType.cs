using System.Diagnostics;
using System.Text.Json;
using System.Xml.Linq;

namespace Vizor.ECharts.BindingGenerator.Types;

internal class ObjectType : IPropertyType, IObjectType
{
	public ObjectType(OptionProperty? parent, string name, string typeGroup)
	{
		Parent = parent;
		Name = name;
		TypeGroup = typeGroup;
		DotNetType = Helper.ToClassName(name);
	}

    public ObjectType(OptionProperty? parent, string name, string dotNetType, string typeGroup)
    {
		Parent = parent;
		Name = name;
		DotNetType = dotNetType;
		TypeGroup = typeGroup;
	}

    public OptionProperty? Parent { get; }
	public string Name { get; }
	public string DotNetType { get; }

	public string TypeGroup { get; set; }

	public List<OptionProperty> Properties { get; } = new List<OptionProperty>();

	public string Path => Parent == null ? string.Empty : Parent.Path + "." + Name;

	public string? TypeWarning { get; set; }
}
