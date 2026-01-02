using System.Data;
using System.Text.Json;
using Vizor.ECharts.BindingGenerator.Diagnostics;
using Vizor.ECharts.BindingGenerator.Types;

namespace Vizor.ECharts.BindingGenerator.Phases;

internal abstract class BasePhase
{
    protected readonly TypeCollection typeCollection;
    protected readonly DiagnosticCollector diagnosticCollector;
    protected readonly TypePatternRegistry patternRegistry;

    /// <summary>
    /// Properties that can accept either a single object or an array of objects
    /// in ECharts, even though option.json only marks them as type: ["Object"].
    /// These properties support multiple instances (e.g., multiple grids, multiple axes).
    /// </summary>
    protected static readonly HashSet<string> MultiInstanceProperties = new(StringComparer.OrdinalIgnoreCase)
    {
        "grid",
        "xAxis",
        "yAxis",
        "dataset",
        "calendar",
        "dataZoom",
        "visualMap",
        "parallel",
        "singleAxis"
    };

    public BasePhase(TypeCollection typeCollection)
    {
        this.typeCollection = typeCollection;
        this.diagnosticCollector = new DiagnosticCollector();
        this.patternRegistry = new TypePatternRegistry(typeCollection);
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

        // special case: all *AxisData types are identical, use shared AxisData
        if (propName.EndsWith("AxisData") && (propName == "xAxisData" || propName == "yAxisData" || 
                                               propName == "angleAxisData" || propName == "radiusAxisData" ||
                                               propName == "parallelAxisData" || propName == "singleAxisData"))
        {
            // Return the shared AxisData type instead of creating separate ones
            return typeCollection.GetOrCreateSharedType("AxisData", "Options");
        }

        // special case: ParallelAxisDefaultData is identical to AxisData
        if (propName == "parallelAxisDefaultData")
        {
            return typeCollection.GetOrCreateSharedType("AxisData", "Options");
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

            // Singularize the property name for array items: "links" -> "link", "levels" -> "level"
            var singularPropName = propName.Singularize();
            var itemName = parentType.Name + Helper.ToClassName(singularPropName);
            if (propName != singularPropName)
                Console.WriteLine($"DEBUG: Singularized '{propName}' -> '{singularPropName}' for type '{itemName}'");
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

        var propertyPath = $"{parent.Name}.{prop.Name}";
        var types = optProp.Types.OrderBy(t => t).ToList();

        // Special case: property-specific custom type mappings
        if (prop.Name == "position" && parent.Name == "tooltip" && string.Join(",", types) == "array,string")
        {
            var tooltipPosType = new MappedCustomType(typeof(TooltipPosition));
            diagnosticCollector.RecordSupported(propertyPath, types, tooltipPosType.DotNetType);
            return tooltipPosType;
        }

        // Special case: Detail.Width and Detail.Height should accept both numbers and percentage strings
        if ((prop.Name == "width" || prop.Name == "height") && parent.DotNetType == "Detail")
        {
            var numberOrStringType = new MappedCustomType(typeof(NumberOrString));
            diagnosticCollector.RecordSupported(propertyPath, types, numberOrStringType.DotNetType);
            return numberOrStringType;
        }

        // Special case: dimension property accepts both numeric dimension indices and string dimension names
        // ECharts examples show usage like: dimension: 1, dimension: 2 (numeric) or dimension: 'sales', dimension: 'profit' (string)
        if (prop.Name == "dimension" && string.Join(",", types) == "string")
        {
            var numberOrStringType = new MappedCustomType(typeof(NumberOrString));
            diagnosticCollector.RecordSupported(propertyPath, types, numberOrStringType.DotNetType);
            return numberOrStringType;
        }

        // Special case: Axis type property should use AxisType enum
        if (prop.Name == "type" && (parent.Name == "xAxis" || parent.Name == "yAxis" || 
                                     parent.Name == "angleAxis" || parent.Name == "radiusAxis" ||
                                     parent.Name == "parallelAxis" || parent.Name == "singleAxis" ||
                                     parent.Name == "parallelAxisDefault"))
        {
            if (typeCollection.TryGetMappedEnumType("axisType", parent.Name, out var axisTypeEnum) && axisTypeEnum != null)
            {
                diagnosticCollector.RecordSupported(propertyPath, types, axisTypeEnum.DotNetType);
                return axisTypeEnum;
            }
        }

        // first try mapping enum types by name
        // BUT: if this is an enum+function pattern, skip this and let the complex matching handle it
        bool isEnumAndFunction = types.Contains("enum") && types.Contains("function");
        if (!isEnumAndFunction && typeCollection.TryGetMappedEnumType(prop.Name, parent.Name, out var mappedEnumType) && mappedEnumType != null)
        {
            diagnosticCollector.RecordSupported(propertyPath, types, mappedEnumType.DotNetType);
            return mappedEnumType;
        }
        // detect single-or-array pattern (Grid, XAxis, YAxis, etc.)
        // These properties accept either a single object or an array of objects
        if (IsArrayAndObject(optProp))
        {
            IPropertyType? innerType = null;

            // For known multi-instance properties without ItemType, create it from the property itself
            if (optProp.ItemType == null && 
                MultiInstanceProperties.Contains(prop.Name) &&
                (optProp.ParentType == null || 
                 string.IsNullOrEmpty(optProp.ParentType.Name) ||
                 optProp.ParentType.Name == "ChartOptions" ||
                 optProp.ParentType.Name == "option"))
            {
                // The object type should already exist or will be created by ParseObjectType
                // Use the property's own object definition as the inner type
                innerType = ParseObjectType(optProp, prop.Name, prop.Value, dataPrefix: prop.Name, typeGroup: "Options");
                optProp.ItemType = innerType;
            }
            else
            {
                innerType = optProp.ItemType;
            }

            if (innerType is IObjectType objType)
            {
                var singleOrArrayType = new SingleOrArrayType(objType.DotNetType);
                diagnosticCollector.RecordSupported(propertyPath, types, $"SingleOrArrayType<{objType.DotNetType}>");
                return singleOrArrayType;
            }
        }
        // matching based on types: simple first
        if (optProp.Types.Count == 1)
        {
            IPropertyType? result = null;
            
            // Special case: parallelAxis is defined as Object in option.json but should be List<ParallelAxis>
            if (prop.Name == "parallelAxis" && parent.DotNetType == "ChartOptions")
            {
                // Create the ParallelAxis object type if needed
                var parallelAxisType = ParseObjectType(optProp, prop.Name, prop.Value, dataPrefix: prop.Name, typeGroup: "Options");
                if (parallelAxisType is ObjectType objType)
                {
                    result = new GenericListType(objType);
                    diagnosticCollector.RecordSupported(propertyPath, types, $"List<{objType.DotNetType}>");
                    return result;
                }
            }
            
            // Special case: children property in TreemapSeriesData should be List<TreemapSeriesData>
            if (prop.Name == "children" && parent.DotNetType == "TreemapSeriesData")
            {
                // Return a list of the parent type (recursive structure)
                result = new GenericListType(parent);
                diagnosticCollector.RecordSupported(propertyPath, types, $"List<{parent.DotNetType}>");
                return result;
            }
            
            // Special case: layoutCenter in Geo should be NumberOrStringArray
            if (prop.Name == "layoutCenter" && parent.DotNetType == "Geo")
            {
                result = new MappedCustomType(typeof(NumberOrStringArray));
                diagnosticCollector.RecordSupported(propertyPath, types, "NumberOrStringArray");
                return result;
            }
            
            // Special case: data property in TreeSeries should remain as object? for flexibility
            if (prop.Name == "data" && parent.DotNetType == "TreeSeries")
            {
                result = new SimpleType("object");
                diagnosticCollector.RecordSupported(propertyPath, types, "object");
                return result;
            }
            
            // Special case: transform property in Dataset should be SingleOrArrayType<IDatasetTransform>
            if (prop.Name == "transform" && parent.DotNetType == "Dataset")
            {
                result = new SingleOrArrayType("IDatasetTransform");
                diagnosticCollector.RecordSupported(propertyPath, types, "SingleOrArrayType<IDatasetTransform>");
                return result;
            }
            
            // Special case: value property in RadarSeriesData should accept array or single value
            if (prop.Name == "value" && parent.DotNetType == "RadarSeriesData")
            {
                result = new SimpleType("object");
                diagnosticCollector.RecordSupported(propertyPath, types, "object");
                return result;
            }
            
            // Special case: type property in MagicType should be string[]? for chart type names
            if (prop.Name == "type" && parent.DotNetType == "MagicType")
            {
                result = new SimpleType("string[]");
                diagnosticCollector.RecordSupported(propertyPath, types, "string[]");
                return result;
            }
            
            // Special case: rotate property in Label should be NumberOrString? for rotation values or "radial"
            if (prop.Name == "rotate" && parent.DotNetType == "Label")
            {
                result = new MappedCustomType(typeof(NumberOrString));
                diagnosticCollector.RecordSupported(propertyPath, types, "NumberOrString");
                return result;
            }
            
            // Special case: pieces property in PiecewiseVisualMap should be List<VisualMapPiece>?
            if (prop.Name == "pieces" && parent.DotNetType == "PiecewiseVisualMap")
            {
                result = new GenericListType(new SimpleType("VisualMapPiece"));
                diagnosticCollector.RecordSupported(propertyPath, types, "List<VisualMapPiece>");
                return result;
            }
            
            // Special case: links and categories in GraphSeries should be object? for List<T> or ExternalDataSourceRef
            if ((prop.Name == "links" && parent.DotNetType == "GraphSeries") ||
                (prop.Name == "categories" && parent.DotNetType == "GraphSeries"))
            {
                result = new SimpleType("object");
                diagnosticCollector.RecordSupported(propertyPath, types, "object");
                return result;
            }
            
            // Special case: links in SankeySeries should be object? for List<T>, array, or ExternalDataSourceRef
            if (prop.Name == "links" && parent.DotNetType == "SankeySeries")
            {
                result = new SimpleType("object");
                diagnosticCollector.RecordSupported(propertyPath, types, "object");
                return result;
            }
            
            switch (optProp.Types[0])
            {
                case "object":
                    result = ParseObjectType(optProp, prop.Name, prop.Value, dataPrefix: prop.Name, typeGroup: "Options");
                    break;
                case "string":
                    result = new SimpleType("string");
                    break;
                case "number":
                    // special case: we don't want to use double for indices
                    result = prop.Name.Contains("index", StringComparison.InvariantCultureIgnoreCase)
                        ? new SimpleType("int")
                        : new SimpleType("double");
                    break;
                case "boolean":
                    result = new SimpleType("bool");
                    break;
                case "color":
                    result = new MappedCustomType(typeof(Color));
                    break;
                case "function":
                    result = new MappedCustomType(typeof(JavascriptFunction));
                    break;
                case "array":
                    result = typeCollection.MapArrayType(parent, optProp, prop);
                    break;
                case "*":
                    result = new SimpleType("object");
                    break;
                case "percentvector":
                case "vector":
                    // percentvector: array of 2 elements (number or percent string)
                    // vector: array of 2 elements (numbers)
                    result = new SimpleType("double[]");
                    break;
                case "enum":
                    // don't care that fontFamily/cursor isn't mapped, warn about all other unmapped types
                    if (prop.Name != "fontFamily" && prop.Name != "cursor")
                    {
                        Console.WriteLine($"WARNING: enum type '{prop.Name}' in '{parent.Name}' with values '{string.Join(',', optProp.EnumOptions ?? Array.Empty<string>())}' is not mapped");
                        diagnosticCollector.RecordUnsupported(
                            propertyPath,
                            types,
                            "string",
                            patternRegistry.GenerateSuggestion(types, string.Join(',', optProp.EnumOptions ?? Array.Empty<string>())));
                        return new SimpleType("string")
                        {
                            TypeWarning = $"enum type '{prop.Name}' in '{parent.Name}' with values '{string.Join(',', optProp.EnumOptions ?? Array.Empty<string>())}' is not mapped"
                        };
                    }
                    result = new SimpleType("string");
                    break;
            }
            
            if (result != null)
            {
                var resultType = result switch
                {
                    SimpleType st => st.DotNetType,
                    MappedCustomType mct => mct.DotNetType,
                    IObjectType ot => ot.DotNetType,
                    _ => "object"
                };
                diagnosticCollector.RecordSupported(propertyPath, types, resultType);
                return result;
            }
        }

        // complex matching - use pattern registry
        if (optProp.Types.Count >= 2)
        {
            // Special case: enum+function pattern - generate EnumOrFunctionType with typed accessors
            if (types.Contains("enum") && types.Contains("function"))
            {
                if (typeCollection.TryGetMappedEnumType(prop.Name, parent.DotNetType, out var enumType) && enumType != null)
                {
                    var result = new EnumOrFunctionType(enumType.DotNetType);
                    diagnosticCollector.RecordPartiallySupported(
                        propertyPath,
                        types,
                        $"EnumOrFunctionType<{enumType.DotNetType}>",
                        "Uses typed accessor pattern");
                    return result;
                }
                else
                {
                    Console.WriteLine($"WARNING: Could not resolve enum type for '{prop.Name}' in '{parent.DotNetType}' with enum+function pattern");
                    diagnosticCollector.RecordUnsupported(
                        propertyPath,
                        types,
                        "object",
                        "Could not resolve enum type - consider adding enum mapping");
                    return new SimpleType("object")
                    {
                        TypeWarning = $"enum,function type '{prop.Name}' in '{parent.DotNetType}' could not resolve enum type"
                    };
                }
            }
            
            // Try pattern registry lookup
            if (patternRegistry.TryGetMappedType(types, parent.Name, out var mappedTypeObj))
            {
                // Use the type directly from pattern registry
                if (mappedTypeObj != null)
                {
                    var resultType = mappedTypeObj switch
                    {
                        SimpleType st => st.DotNetType,
                        MappedCustomType mct => mct.DotNetType,
                        MappedEnumType met => met.DotNetType,
                        _ => "object"
                    };
                    diagnosticCollector.RecordSupported(propertyPath, types, resultType);
                    return mappedTypeObj;
                }
            }
            
            // Check if partially supported
            if (patternRegistry.IsPartiallySupported(types))
            {
                Console.WriteLine($"INFO: Partially supported pattern '{string.Join(',', types)}' for '{propertyPath}' - using object");
                diagnosticCollector.RecordPartiallySupported(
                    propertyPath,
                    types,
                    "object",
                    patternRegistry.GenerateSuggestion(types) ?? "Consider implementing typed accessor pattern");
                return new SimpleType("object")
                {
                    TypeWarning = $"Partially supported pattern '{string.Join(',', types)}' for '{prop.Name}'"
                };
            }
        }

        // Fallback: unsupported pattern
        var typeList = string.Join(',', optProp.Types ?? Enumerable.Empty<string>());
        if (optProp.Types?.Contains("enum") ?? false)
        {
            Console.WriteLine($"WARNING: {typeList} type '{prop.Name}' in '{parent.Name}' with values '{string.Join(',', optProp.EnumOptions ?? Array.Empty<string>())}' is not mapped");
            diagnosticCollector.RecordUnsupported(
                propertyPath,
                types,
                "object",
                patternRegistry.GenerateSuggestion(types, string.Join(',', optProp.EnumOptions ?? Array.Empty<string>())));
        }
        else
        {
            Console.WriteLine($"ERROR: Failed to map property '{prop.Name}' in type '{parent.Name}' with types '{typeList}'");
            diagnosticCollector.RecordUnsupported(
                propertyPath,
                types,
                "object",
                patternRegistry.GenerateSuggestion(types));
        }

        return new SimpleType("object")
        {
            TypeWarning = $"Failed to map property '{prop.Name}' in type '{parent.Name}' with types '{typeList}'"
        };
    }
    
    /// <summary>
    /// Generate a diagnostic report after processing
    /// </summary>
    public DiagnosticReport GenerateDiagnosticReport()
    {
        return diagnosticCollector.GenerateReport();
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

    /// <summary>
    /// Detects if a property accepts both array and object types (e.g., Grid, XAxis, YAxis).
    /// Returns true if:
    /// 1. The property explicitly has both "array" and "object" types in option.json, OR
    /// 2. The property is in the known MultiInstanceProperties list and has type "object"
    /// </summary>
    protected bool IsArrayAndObject(OptionProperty optProp)
    {
        // Explicit array+object declaration in option.json
        if (optProp.Types != null &&
            optProp.Types.Contains("array") &&
            optProp.Types.Contains("object") &&
            optProp.Types.Count == 2)
        {
            return true;
        }

        // Known multi-instance properties that option.json marks as only "object"
        // but actually accept arrays in ECharts
        if (optProp.Types != null &&
            optProp.Types.Count == 1 &&
            optProp.Types[0] == "object" &&
            MultiInstanceProperties.Contains(optProp.Name))
        {
            // Check if this is a top-level property in ChartOptions
            // ParentType might be null during initial parsing, so we also check if ParentType.Name is null/empty
            if (optProp.ParentType == null || 
                string.IsNullOrEmpty(optProp.ParentType.Name) ||
                optProp.ParentType.Name == "ChartOptions" ||
                optProp.ParentType.Name == "option")
            {
                return true;
            }
        }

        return false;
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
