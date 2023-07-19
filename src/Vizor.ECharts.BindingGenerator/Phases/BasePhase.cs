using System.Diagnostics;
using System.Text.Json;
using Vizor.ECharts.BindingGenerator.Types;

namespace Vizor.ECharts.BindingGenerator.Phases;

internal abstract class BasePhase
{
	protected readonly TypeCollection typeCollection;

	public BasePhase(TypeCollection typeCollection)
	{
		this.typeCollection = typeCollection;
	}

	internal abstract void Run(JsonElement root);

	protected virtual void StoreType(ObjectType objectType)
	{
		typeCollection.AddObjectType(objectType);
	}

	protected virtual IPropertyType? ParseObjectType(string propName, JsonElement value, string dataPrefix)
	{
		//Console.WriteLine($"OBJECT {prop.Name}");

		// special handling for "data" elements
		if (propName == "data")
		{
			propName = dataPrefix + "Data";
		}

		// try looking up previously defined types with the same name
		if (typeCollection.TryGetObjectType(propName, out var objType))
		{
			//TODO: don't simply return the previous type, we need to compare if the values actually match
			return objType;
		}

		// create a new type
		objType = new ObjectType(propName);
		StoreType(objType);

		if (value.TryGetProperty("properties", out var childProps))
		{
			foreach (JsonProperty childProp in childProps.EnumerateObject())
			{
				//TODO: skip style_name for now
				if (childProp.Name == "<style_name>")
				{
					Console.WriteLine($"TODO --- {childProp.Name} property in {propName}");
					continue;
				}

				objType.Properties.Add(ParseProperty(objType, childProp));
			}
		}

		return objType;
	}

	protected virtual OptionProperty ParseProperty(ObjectType parentType, JsonProperty prop)
	{
		//Console.WriteLine($"PROPERTY {prop.Name}");

		var optProp = new OptionProperty()
		{
			ParentType = parentType,
			Name = prop.Name,
			PropertyName = Helper.ToClassName(prop.Name)
		};

		if (prop.Value.TryGetProperty("description", out var descProp))
		{
			optProp.Description = descProp.GetString();
		}

		if (prop.Value.TryGetProperty("type", out var typeProp))
		{
			optProp.AddTypes(Helper.ParsePropertyTypes(typeProp));
		}

		if (prop.Value.TryGetProperty("default", out var defaultProp))
		{
			optProp.Default = ParseDefault(defaultProp);
		}

		// always parse uiControl after type+default, since we might override certain values
		if (prop.Value.TryGetProperty("uiControl", out var uiControlProp))
		{
			if (uiControlProp.TryGetProperty("type", out var subTypeProp))
			{
				var subType = subTypeProp.GetString()?.ToLower();
				if (subType == "enum")
				{
					//"uiControl": {
					//	"default": "butt",
					//  "options": "butt,round,square",
					//  "type": "enum"
					//}

					// replace the 'string' type with 'enum'
					optProp.RemoveType("string");
					optProp.AddType("enum");

					if (uiControlProp.TryGetProperty("options", out var subOptionsProp))
					{
						optProp.EnumOptions = (subOptionsProp.GetString() ?? string.Empty).Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
					}
				}
				else if (subType == "color")
				{
					//"uiControl": {
					//	"default": "#fff",
					//  "type": "color"
					// }

					// replace 'string' 'object' type with 'color'
					optProp.RemoveType("string");
					optProp.RemoveType("object");
					optProp.AddType("color");
				}
				else if (!string.IsNullOrWhiteSpace(subType) && subType != "text")
				{
					optProp.AddType(subType);
				}
			}

			if (uiControlProp.TryGetProperty("default", out var subDefaultProp))
			{
				optProp.Default = subDefaultProp.GetString();
			}
		}

		if (prop.Value.TryGetProperty("items", out var itemsProp))
		{
			// items requires special handling
			// we need to define an item type, e.g. MediaItem and pass this to the MapType function
			// MapType can then generate List<MediaItem> instead of List<object>

			var itemName = parentType.Name + Helper.ToClassName(prop.Name);
			optProp.ItemType = ParseObjectType(itemName, itemsProp, dataPrefix: itemName);
		}

		// at this point we can decide how to map the type
		optProp.MappedType = MapType(parentType, optProp, prop);

		return optProp;
	}

	protected virtual object? ParseDefault(JsonElement element)
	{
		return element.ValueKind switch
		{
			JsonValueKind.String => ParseDefaultAsString(element),
			JsonValueKind.False => false,
			JsonValueKind.True => true,
			JsonValueKind.Number => element.GetDouble(),
			_ => null
		};
	}

	protected virtual string ParseDefaultAsString(JsonElement element)
	{
		var str = element.GetString()!.Trim('\'', '"'); // trim single quotes

		// special handling for arrays
		if (str.StartsWith('['))
		{
			str = str.Replace("'", "");
		}

		return str;
	}

	protected virtual IPropertyType? MapType(ObjectType parent, OptionProperty optProp, JsonProperty prop)
	{
		// sanity checks
		if (optProp.Types == null || optProp.Types.Count == 0)
			throw new ArgumentException($"JSON property '{prop.Name}' could not be mapped: no type info available");

		// first try mapping enum types by name
		if (typeCollection.TryGetMappedEnumType(prop.Name, parent.Name, out var mappedEnumType))
			return mappedEnumType;

		// matching based on types: simple first
		if (optProp.Types.Count == 1)
		{
			switch (optProp.Types[0])
			{
				case "object":
					return ParseObjectType(prop.Name, prop.Value, dataPrefix: prop.Name);
				case "enum":
					// don't care that fontFamily/cursor isn't mapped, warn about all other unmapped types
					if (prop.Name != "fontFamily" && prop.Name != "cursor")
						Console.WriteLine($"WARNING: enum type '{prop.Name}' in '{parent.Name}' with values '{string.Join(',', optProp.EnumOptions ?? Array.Empty<string>())}' is not mapped");
					return new PrimitiveType(typeof(string));
				case "string":
					return new PrimitiveType(typeof(string));
				case "number":
					// special case: we don't want to use double for indices
					if (prop.Name.Contains("index", StringComparison.InvariantCultureIgnoreCase))
						return new PrimitiveType(typeof(int));
					else
						return new PrimitiveType(typeof(double));
				case "boolean":
					return new PrimitiveType(typeof(bool));
				case "color":
					return new MappedCustomType(typeof(Color));
				case "array":
					if (optProp.ItemType != null)
					{
						return new GenericListType(optProp.ItemType);
					}
					else
					{
						Console.WriteLine($"WARNING: array type '{prop.Name}' in '{parent.Name}' will be mapped to List<object>");
						return new ArrayType();
					}

			}
		}

		// complex matching
		if (optProp.Types.Count == 2)
		{
			switch (optProp.Types[0], optProp.Types[1])
			{
				case ("angle", "number"):
					return new PrimitiveType(typeof(double));
				case ("number", "string"):
					return new MappedCustomType(typeof(NumberOrString));
				case ("icon", "string"):
					return new MappedEnumType(prop.Name, typeof(Icon));
				case ("array", "string"):
					//TODO: 'symbol' --> not MappedEnumType ??
					return new MappedEnumType(prop.Name, typeof(Icon));
				case ("array", "number"):
					return new MappedCustomType(typeof(NumberOrNumberArray));
				case ("function", "string"):
					return new MappedCustomType(typeof(StringOrFunction));
				case ("function", "number"):
					return new MappedCustomType(typeof(NumberOrFunction));
			}
		}

		// even more complex matching
		if (optProp.Types is ["function", "number", "string"])
		{
			return new MappedCustomType(typeof(NumberOrStringOrFunction));
		}
		else if (optProp.Types is ["number", "percent", "string"])
		{
			return new MappedCustomType(typeof(NumberOrString));
		}

		Console.WriteLine($"ERROR: Failed to map property '{prop.Name}' in type '{parent.Name}' with types '{string.Join(',', optProp.Types ?? Enumerable.Empty<string>())}'");
		//throw new ArgumentException($"Failed to map property '{prop.Name}' in type '{parent.Name}' with types '{string.Join(',', optProp.Types ?? Enumerable.Empty<string>())}'");

		return null;
	}
}
