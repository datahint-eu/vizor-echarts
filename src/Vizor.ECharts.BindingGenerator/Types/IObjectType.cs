namespace Vizor.ECharts.BindingGenerator.Types;

internal interface IObjectType : IPropertyType
{
	List<OptionProperty> Properties { get; }

	string Path { get; }
}