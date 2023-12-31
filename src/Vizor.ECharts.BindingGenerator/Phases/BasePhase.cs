﻿using System;
using System.Data;
using System.Diagnostics;
using System.Text.Json;
using Vizor.ECharts.BindingGenerator.Types;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Vizor.ECharts.BindingGenerator.Phases;

internal abstract class BasePhase
{
	protected readonly TypeCollection typeCollection;

	public BasePhase(TypeCollection typeCollection)
	{
		this.typeCollection = typeCollection;
	}

	internal abstract void Run(JsonElement root);

	protected virtual IPropertyType? ParseObjectType(OptionProperty parent, string propName, JsonElement value, string dataPrefix, string typeGroup)
	{
		//Console.WriteLine($"OBJECT {prop.Name}");

		// special handling for 'anyOf' arrays
		if (value.TryGetProperty("anyOf", out var anyOfElement))
		{
			// generate child types
			foreach (JsonElement anyOfItemElement in anyOfElement.EnumerateArray())
			{
				var anyOfType = GetAnyOfType(anyOfItemElement, propName);

				// special case
				if (anyOfType.Contains("xxx"))
					continue;

				//Console.WriteLine($"---anyOf {propName} {anyOfType}");
				_ = ParseObjectType(parent, anyOfType, anyOfItemElement, dataPrefix: anyOfType, typeGroup: propName);
			}

			return new SimpleType("object");
		}

		// special handling for "data" elements
		if (propName == "data")
		{
			propName = dataPrefix + "Data";
		}

		// special case
		if (propName == "<style_name>")
		{
			propName = "RichStyleName";
		}

		// create a new type --> we parse the type completely, so we can do a (deep) duplicate check
		var objType = new ObjectType(parent, propName, typeGroup);

		if (value.TryGetProperty("properties", out var childProps))
		{
			foreach (JsonProperty childProp in childProps.EnumerateObject())
			{
				objType.Properties.Add(ParseProperty(objType, childProp));
			}
		}

		typeCollection.TrackType(objType);

		// there are a lot of types that are 90% similar
		// we could generate a unique type for each, but in some cases that would result in 300 very silimar types
		// so merging seems to be the best option
		return typeCollection.MergeType(objType);
	}

	protected virtual OptionProperty ParseProperty(ObjectType parentType, JsonProperty prop)
	{
		//Console.WriteLine($"PROPERTY {prop.Name}");

		// special case
		var propName = prop.Name;
		if (propName == "<style_name>")
		{
			propName = "RichStyleName";
		}

		var optProp = new OptionProperty(parentType, propName, Helper.ToClassName(propName));

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
				else if (!string.IsNullOrWhiteSpace(subType))
				{
					if (subType != "text" && subType != "percent" && subType != "angle")
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

			var itemName = parentType.Name + Helper.ToClassName(propName);
			optProp.ItemType = ParseObjectType(optProp, itemName, itemsProp, dataPrefix: itemName, typeGroup: parentType.TypeGroup ?? "Options");
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
			str = str.Replace("\"", "").Replace("'", "");
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
					return ParseObjectType(optProp, prop.Name, prop.Value, dataPrefix: prop.Name, typeGroup: "Options");
				case "enum":
					// don't care that fontFamily/cursor isn't mapped, warn about all other unmapped types
					if (prop.Name != "fontFamily" && prop.Name != "cursor")
					{
						Console.WriteLine($"WARNING: enum type '{prop.Name}' in '{parent.Name}' with values '{string.Join(',', optProp.EnumOptions ?? Array.Empty<string>())}' is not mapped");
						return new SimpleType("string")
						{
							TypeWarning = $"enum type '{prop.Name}' in '{parent.Name}' with values '{string.Join(',', optProp.EnumOptions ?? Array.Empty<string>())}' is not mapped"
						};
					}
					return new SimpleType("string");
				case "string":
					return new SimpleType("string");
				case "number":
					// special case: we don't want to use double for indices
					if (prop.Name.Contains("index", StringComparison.InvariantCultureIgnoreCase))
						return new SimpleType("int");
					else
						return new SimpleType("double");
				case "boolean":
					return new SimpleType("bool");
				case "color":
					return new MappedCustomType(typeof(Color));
				case "function":
					return new MappedCustomType(typeof(Function));
				case "array":
					return typeCollection.MapArrayType(parent, optProp, prop);
				case "*":
					return new SimpleType("object");
			}
		}

		// complex matching
		if (optProp.Types.Count == 2)
		{
			switch (optProp.Types[0], optProp.Types[1])
			{
				case ("boolean", "number"):
					return new MappedCustomType(typeof(NumberOrBool));
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
				case ("function", "object"):
					return new MappedCustomType(typeof(ObjectOrFunction));
				case ("array", "percentvector"):
				case ("array", "vector"):
					return new SimpleType("double[]");
				case ("array", "color"):
					return new MappedCustomType(typeof(ColorArray));
				case ("color", "function"):
					return new MappedCustomType(typeof(ColorOrFunction));
				case ("color", "number"): // specific case for borderColorSaturation
					return new SimpleType("double");
			}
		}

		// even more complex matching
		if (optProp.Types is ["function", "number", "string"])
		{
			return new MappedCustomType(typeof(NumberOrStringOrFunction));
		}
		else if (optProp.Types is ["function", "icon", "string"])
		{
			return new MappedCustomType(typeof(StringOrFunction));
		}
		else if (optProp.Types is ["date", "number", "string"])
		{
			return new MappedCustomType(typeof(NumberOrString)); // has implicit datetime support
		}
		else if (optProp.Types is ["array", "function", "number"])
		{
			return new MappedCustomType(typeof(NumberArrayOrFunction));
		}
		else if (optProp.Types is ["array", "number", "vector"])
		{
			return new MappedCustomType(typeof(NumberArray));
		}

		// give additional enum warning if any of the types is an enum
		var typeList = string.Join(',', optProp.Types ?? Enumerable.Empty<string>());
		if (optProp.Types?.Contains("enum") ?? false)
		{
			Console.WriteLine($"WARNING: {typeList} type '{prop.Name}' in '{parent.Name}' with values '{string.Join(',', optProp.EnumOptions ?? Array.Empty<string>())}' is not mapped");
		}

		Console.WriteLine($"ERROR: Failed to map property '{prop.Name}' in type '{parent.Name}' with types '{typeList}'");
		//throw new ArgumentException($"Failed to map property '{prop.Name}' in type '{parent.Name}' with types '{string.Join(',', optProp.Types ?? Enumerable.Empty<string>())}'");

		return new SimpleType("object")
		{
			TypeWarning = $"Failed to map property '{prop.Name}' in type '{parent.Name}' with types '{typeList}'"
		};
	}

	protected bool CompareType(ObjectType lookupType, ObjectType objType)
	{
		var propNamesA = GetPropertyList(lookupType);
		var propNamesB = GetPropertyList(objType);

		if (propNamesA != propNamesB)
		{
			Console.WriteLine($"!!! Type compare error: {lookupType.Name}");
			Console.WriteLine($"\tA: {propNamesA}");
			Console.WriteLine($"\tB: {propNamesB}");

			//TODO return false;
		}

		return true;
	}

	protected string GetPropertyList(ObjectType objectType)
	{
		var names = objectType.Properties.Select(p => p.Name).ToList();
		names.Sort();
		return string.Join(",", names);
	}

	protected virtual string GetAnyOfType(JsonElement anyOfItemElement, string postfix)
	{
		if (!anyOfItemElement.TryGetProperty("properties", out var propertiesItem))
			throw new ArgumentException($"Could not determine properties element of {postfix} item");

		if (!propertiesItem.TryGetProperty("type", out var typeElem))
			throw new ArgumentException($"Could not determine type of {postfix} item");

		if (!typeElem.TryGetProperty("default", out var defaultElem))
			throw new ArgumentException($"Could not determine default type value of {postfix} item");

		// for example: in transform parent --> this must resolve to TransformFilter
		//"type": {
		//	"default": "'filter'",
		//  "description": "",
		//  "type": [ "string"  ]
		// }

		var cls = Helper.ToClassName(defaultElem.GetString()!.Trim('\''));

		return cls + postfix;
	}
}
