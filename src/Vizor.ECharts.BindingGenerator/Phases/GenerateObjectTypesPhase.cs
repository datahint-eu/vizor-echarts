using System.Data;
using System.Text.Json;
using Vizor.ECharts.BindingGenerator.Types;

namespace Vizor.ECharts.BindingGenerator.Phases;

internal class GenerateObjectTypesPhase : BasePhase
{
	public GenerateObjectTypesPhase(TypeCollection typeCollection)
		: base(typeCollection)
	{
	}

	internal override void Run(JsonElement root)
	{
		if (root.TryGetProperty("properties", out var childProps))
		{
			foreach (JsonProperty childProp in childProps.EnumerateObject())
			{
				typeCollection.ChartOptions.Properties.Add(ParseProperty(typeCollection.ChartOptions, childProp));
			}
		}
	}
}
