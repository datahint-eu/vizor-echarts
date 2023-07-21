namespace Vizor.ECharts.BindingGenerator.Types;

internal class MappedCustomType : IPropertyType
{
	public MappedCustomType(Type customType)
	{
		CustomType = customType;
	}

	public string Name => CustomType.Name;

	public string DotNetType => CustomType.Name;

	public Type CustomType { get; }

	public string? TypeWarning { get; set; }
}
