namespace Vizor.ECharts.BindingGenerator.AST;

internal class OptionProperty
{
	private readonly List<string> types = new();

	public required ObjectType Parent { get; set; }

	public required string Name { get; set; }

	public required string PropertyName { get; set; }

	public string? Description { get; set; }

	public IReadOnlyList<string> Types => types;

	public object? Default { get; set; }

	public string[]? EnumOptions { get; set; }

	public IPropertyType? MappedType { get; set; }

	public IPropertyType? ItemType { get; set; }

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
