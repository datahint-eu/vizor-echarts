using System.Text.Json;
using System.Xml.Linq;
using Vizor.ECharts;

namespace Vizor.ECharts.BindingGenerator.AST;

internal class Parser
{
	private readonly Dictionary<string, Dictionary<string, MappedEnumType>> enumTypesMappedByName = new();

	private readonly Dictionary<string, ObjectType> generatedTypes = new();

	public Parser()
	{
		AddMappedEnumType(new MappedEnumType("align", typeof(HorizontalAlign)));
		AddMappedEnumType(new MappedEnumType("animationEasing", typeof(AnimationEasing)));
		AddMappedEnumType(new MappedEnumType("animationEasingUpdate", typeof(AnimationEasing)));
		AddMappedEnumType(new MappedEnumType("animationType", typeof(AnimationType)));
		AddMappedEnumType(new MappedEnumType("animationTypeUpdate", typeof(AnimationTypeUpdate)));
		AddMappedEnumType(new MappedEnumType("axisExpandTriggerOn", typeof(TriggerOn)));
		AddMappedEnumType(new MappedEnumType("axisPosition", typeof(TopOrBottom)));
		AddMappedEnumType(new MappedEnumType("axisSymbol", typeof(AxisSymbol)));
		AddMappedEnumType(new MappedEnumType("axisType", typeof(AxisType)));
		AddMappedEnumType(new MappedEnumType("blendMode", typeof(BlendMode)));
		AddMappedEnumType(new MappedEnumType("borderCap", typeof(LineCap)));
		AddMappedEnumType(new MappedEnumType("borderJoin", typeof(LineJoin)));
		AddMappedEnumType(new MappedEnumType("borderRadius", typeof(Radius)));
		AddMappedEnumType(new MappedEnumType("borderType", typeof(LineType)));
		AddMappedEnumType(new MappedEnumType("colorBy", typeof(ColorBy)));
		AddMappedEnumType(new MappedEnumType("emphasisBlurScope", typeof(EmphasisBlurScope)));
		AddMappedEnumType(new MappedEnumType("emphasisFocus", typeof(EmphasisFocus)));
		AddMappedEnumType(new MappedEnumType("fontStyle", typeof(FontStyle)));
		AddMappedEnumType(new MappedEnumType("fontWeight", typeof(FontWeight)));
		AddMappedEnumType(new MappedEnumType("horizontalAlign", typeof(HorizontalAlign)));
		AddMappedEnumType(new MappedEnumType("icon", typeof(Icon)));
		AddMappedEnumType(new MappedEnumType("legendType", typeof(LegendType)));
		AddMappedEnumType(new MappedEnumType("lineCoordinateSystem", typeof(LineCoordinateSystem)));
		AddMappedEnumType(new MappedEnumType("lineType", typeof(LineType)));
		AddMappedEnumType(new MappedEnumType("nameLocation", typeof(NameLocation)));
		AddMappedEnumType(new MappedEnumType("orient", typeof(Orient)));
		AddMappedEnumType(new MappedEnumType("orthogonalOrient", typeof(OrthogonalOrient)));
		AddMappedEnumType(new MappedEnumType("overflow", typeof(Overflow)));
		AddMappedEnumType(new MappedEnumType("padding", typeof(Padding)));
		AddMappedEnumType(new MappedEnumType("radius", typeof(Radius)));
		AddMappedEnumType(new MappedEnumType("selectedMode", typeof(SelectionMode)));
		AddMappedEnumType(new MappedEnumType("selector", typeof(Selector)));
		AddMappedEnumType(new MappedEnumType("seriesLayoutBy", typeof(SeriesLayoutBy)));
		AddMappedEnumType(new MappedEnumType("stackStrategy", typeof(StackStrategy)));
		AddMappedEnumType(new MappedEnumType("step", typeof(Step)));
		AddMappedEnumType(new MappedEnumType("textAlign", typeof(HorizontalAlign)));
		AddMappedEnumType(new MappedEnumType("textBorderType", typeof(LineType)));
		AddMappedEnumType(new MappedEnumType("textBorderRadius", typeof(Radius)));
		AddMappedEnumType(new MappedEnumType("textVerticalAlign", typeof(VerticalAlign)));
		AddMappedEnumType(new MappedEnumType("tooltipOrder", typeof(TooltipOrder)));
		AddMappedEnumType(new MappedEnumType("tooltipRenderMode", typeof(RenderMode)));
		AddMappedEnumType(new MappedEnumType("tooltipTrigger", typeof(TooltipTrigger)));
		AddMappedEnumType(new MappedEnumType("tooltipTriggerOn", typeof(TriggerOn)));
		AddMappedEnumType(new MappedEnumType("triggerOn", typeof(TriggerOn)));
		AddMappedEnumType(new MappedEnumType("treeLayout", typeof(TreeLayout)));
		AddMappedEnumType(new MappedEnumType("verticalAlign", typeof(VerticalAlign)));



		AddMappedEnumType(new MappedEnumType("type", typeof(LineType)), "lineStyle");
		AddMappedEnumType(new MappedEnumType("type", typeof(LegendType)), "legend");
		AddMappedEnumType(new MappedEnumType("type", typeof(ImageType)), "saveAsImage");
		AddMappedEnumType(new MappedEnumType("type", typeof(AxisPointer)), "axisPointer");

		AddMappedEnumType(new MappedEnumType("cap", typeof(LineCap)), "lineStyle", "crossStyle");
		AddMappedEnumType(new MappedEnumType("join", typeof(LineJoin)), "lineStyle", "crossStyle");

		AddMappedEnumType(new MappedEnumType("order", typeof(TooltipOrder)), "tooltip");
		AddMappedEnumType(new MappedEnumType("renderMode", typeof(RenderMode)), "tooltip");
		AddMappedEnumType(new MappedEnumType("trigger", typeof(TooltipTrigger)), "tooltip");

		AddMappedEnumType(new MappedEnumType("position", typeof(TopOrBottom)), "xAxis");
		AddMappedEnumType(new MappedEnumType("shape", typeof(RadarShape)), "radar");

		AddMappedEnumType(new MappedEnumType("selectorPosition", typeof(StartOrEnd)), "legend");
		AddMappedEnumType(new MappedEnumType("position", typeof(StartOrEnd)), "dayLabel");
		AddMappedEnumType(new MappedEnumType("position", typeof(StartOrEnd)), "monthLabel");
		AddMappedEnumType(new MappedEnumType("position", typeof(Position)), "yearLabel");
		AddMappedEnumType(new MappedEnumType("position", typeof(Position)), "controlStyle");
		AddMappedEnumType(new MappedEnumType("position", typeof(LeftOrRight)), "yAxis");
		AddMappedEnumType(new MappedEnumType("controlPosition", typeof(LeftOrRight)), "timeline");
		AddMappedEnumType(new MappedEnumType("layout", typeof(HorizontalOrVertical)), "parallel");
	}

	public IReadOnlyDictionary<string, ObjectType> GeneratedTypes => generatedTypes;

	private void AddMappedEnumType(MappedEnumType mappedType, params string[]? specificObjectTypes)
	{
		if (!enumTypesMappedByName.TryGetValue(mappedType.Name, out var typeDict))
		{
			typeDict = new Dictionary<string, MappedEnumType>();
			enumTypesMappedByName.Add(mappedType.Name, typeDict);
		}

		if (specificObjectTypes == null || specificObjectTypes.Length == 0)
		{
			typeDict.Add("*", mappedType);
		}
		else
		{
			foreach (var specificType in specificObjectTypes)
			{
				typeDict.Add(specificType, mappedType);
			}
		}
	}

	public ObjectType ParseRoot(JsonElement value)
	{
		var objType = new ObjectType("chartOptions");

		if (value.TryGetProperty("properties", out var childProps))
		{
			foreach (JsonProperty childProp in childProps.EnumerateObject())
			{
				objType.Properties.Add(ParseProperty(objType, childProp));
			}
		}

		generatedTypes.Add("", objType); // we don't want to use the root type for lookup purposes
		return objType;
	}

	public OptionProperty ParseProperty(ObjectType parent, JsonProperty prop)
	{
		//Console.WriteLine($"PROPERTY {prop.Name}");

		var optProp = new OptionProperty()
		{
			Parent = parent,
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

		// at this point we can decide how to map the type
		optProp.MappedType = MapType(parent, optProp, prop);

		//TODO: items

		return optProp;
	}

	public ObjectType ParseObjectType(JsonProperty prop)
	{
		//Console.WriteLine($"OBJECT {prop.Name}");

		// try looking up previously defined types with the same name
		if (generatedTypes.TryGetValue(prop.Name, out var objType))
		{
			return objType;
		}

		// create a new type
		objType = new ObjectType(prop.Name);
		generatedTypes.Add(prop.Name, objType);

		if (prop.Value.TryGetProperty("properties", out var childProps))
		{
			foreach (JsonProperty childProp in childProps.EnumerateObject())
			{
				//TODO: skip data for now
				if (childProp.Name == "data")
					continue;

				//TODO:
				if (childProp.Name == "<style_name>")
					continue;


				objType.Properties.Add(ParseProperty(objType, childProp));
			}
		}

		return objType;
	}

	private static object? ParseDefault(JsonElement element)
	{
		return element.ValueKind switch
		{
			JsonValueKind.String => element.GetString()!.Trim('\''), // trim single quotes
			JsonValueKind.False => false,
			JsonValueKind.True => true,
			JsonValueKind.Number => element.GetDouble(),
			_ => null
		};
	}

	private IPropertyType? MapType(ObjectType parent, OptionProperty optProp, JsonProperty prop)
	{
		// sanity checks
		if (optProp.Types == null || optProp.Types.Count == 0)
			throw new ArgumentException($"JSON property '{prop.Name}' could not be mapped: no type info available");

		// first try mapping enum types by name
		if (enumTypesMappedByName.TryGetValue(prop.Name, out var typeDict))
		{
			// specific mapping for the parent type
			if (typeDict.TryGetValue(parent.Name, out var mappedEnumType))
				return mappedEnumType;

			// non-specific mapping for the parent type
			if (typeDict.TryGetValue("*", out mappedEnumType))
				return mappedEnumType;

			//TODO: sanity check for enum types
		}

		// matching based on types: simple first
		if (optProp.Types.Count == 1)
		{
			switch (optProp.Types[0])
			{
				case "object":
					return ParseObjectType(prop);
				case "enum":
					// don't care that font family isn't mapped, warn about all other unmapped types
					if (prop.Name != "fontFamily")
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
					Console.WriteLine($"WARNING: array type '{prop.Name}' in '{parent.Name}' will be mapped to List<object>");
					return new ArrayType();
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

		Console.WriteLine($"ERROR: Failed to map property '{prop.Name}' in type '{parent.Name}' with types '{string.Join(',', optProp.Types ?? Enumerable.Empty<string>())}'");
		//throw new ArgumentException($"Failed to map property '{prop.Name}' in type '{parent.Name}' with types '{string.Join(',', optProp.Types ?? Enumerable.Empty<string>())}'");

		return null;
	}
}
