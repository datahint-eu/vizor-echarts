namespace Vizor.ECharts.BindingGenerator.Types;

internal class OptionProperty
{
    public OptionProperty(ObjectType? parentType, string name, string propertyName)
    {
		ParentType = parentType;
		Name = name;
		PropertyName = propertyName;
	}

    private readonly List<string> types = new();

	public ObjectType? ParentType { get; }
	public string Name { get; set; }

	public string PropertyName { get; set; }

	public string? Description { get; set; }

	public IReadOnlyList<string> Types => types;

	public object? Default { get; set; }

	public string[]? EnumOptions { get; set; }

	public IPropertyType? MappedType { get; set; }

	public IPropertyType? ItemType { get; set; }

	public string Path => ParentType == null ? string.Empty : ParentType.Path;

	public void RemoveType(string name)
	{
		types.RemoveAll(item => item == name);
	}

	public void AddType(string name)
	{
		if (!types.Contains(name))
		{
			types.Add(name);
			types.Sort();
		}
	}

	public void AddTypes(IEnumerable<string> names)
	{
		foreach (var name in names)
		{
			if (!types.Contains(name))
			{
				types.Add(name);
			}
		}

		types.Sort();
	}
}
