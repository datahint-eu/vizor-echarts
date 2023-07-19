using System.Text.Json;
using Microsoft.Extensions.Logging.Console;
using Vizor.ECharts.BindingGenerator.Types;

namespace Vizor.ECharts.BindingGenerator.Phases;

internal class GenerateSeriesTypesPhase : BasePhase
{
	public GenerateSeriesTypesPhase(TypeCollection typeCollection)
		: base(typeCollection)
	{
	}

	internal override void Run(JsonElement root)
	{
		if (root.TryGetProperty("properties", out var childProps))
		{
			foreach (JsonProperty childProp in childProps.EnumerateObject())
			{
				// only handle the top level series property
				if (childProp.Name != "series")
					continue;

				typeCollection.ChartOptions.Properties.Add(ParseProperty(typeCollection.ChartOptions, childProp));
			}
		}
	}

	protected override void StoreType(ObjectType objectType)
	{
		if (objectType.Name.EndsWith("Series") || objectType.Name.EndsWith("SeriesData"))
		{
			typeCollection.AddSeriesType(objectType);
		}
		else
		{
			typeCollection.AddObjectType(objectType);
		}
	}

	protected override IPropertyType? ParseObjectType(string propName, JsonElement value, string dataPrefix)
	{
		//Console.WriteLine($"OBJECT {prop.Name}");

		if (value.TryGetProperty("anyOf", out var anyOfElement))
		{
			// generate child types
			foreach (JsonElement anyOfItemElement in anyOfElement.EnumerateArray())
			{
				var seriesType = GetSeriesType(anyOfItemElement);
				Console.WriteLine($"----------------- SERIES TYPE {seriesType}");
				_ = ParseObjectType(seriesType, anyOfItemElement, dataPrefix: seriesType);
			}

			return new SimpleType("object");
		}

		return base.ParseObjectType(propName, value, dataPrefix);
	}

	protected virtual string GetSeriesType(JsonElement anyOfItemElement)
	{
		if (!anyOfItemElement.TryGetProperty("properties", out var propertiesItem))
			throw new ArgumentException($"Could not determine properties element of series item");

		if (!propertiesItem.TryGetProperty("type", out var typeElem))
			throw new ArgumentException($"Could not determine type of series item");

		if (!typeElem.TryGetProperty("default", out var defaultElem))
			throw new ArgumentException($"Could not determine default type value of series item");

		// for example: in transform parent --> this must resolve to TransformFilter
		//"type": {
		//	"default": "'filter'",
		//  "description": "",
		//  "type": [ "string"  ]
		// }

		var seriesClass = Helper.ToClassName(defaultElem.GetString()!.Trim('\''));

		return seriesClass + "Series";
	}
}
