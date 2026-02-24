namespace Vizor.ECharts.BindingGenerator.Types;

/// <summary>
/// Central registry of type mapping patterns.
/// Provides a single source of truth for what type combinations are supported,
/// partially supported, or unsupported by the generator.
/// </summary>
internal class TypePatternRegistry
{
    private readonly TypeCollection typeCollection;
    
    /// <summary>
    /// Primitive types that map directly to simple C# types
    /// </summary>
    private static readonly Dictionary<string, string> PrimitiveTypes = new()
    {
        { "string", "string" },
        { "number", "double" },
        { "boolean", "bool" },
        { "object", "object" },
    };
    
    /// <summary>
    /// Fully supported 2-3 element union types (custom types with implicit conversions)
    /// Format: "type1,type2" → typeof(CustomType)
    /// </summary>
    private static readonly Dictionary<string, Type> SupportedPatterns = new()
    {
        { "boolean,number", typeof(NumberOrBool) },
        { "boolean,string", typeof(BoolOrString) },
        { "number,string", typeof(NumberOrString) },
        { "array,number", typeof(NumberOrNumberArray) },
        { "function,string", typeof(StringOrFunction) },
        { "function,number", typeof(NumberOrFunction) },
        { "function,object", typeof(ObjectOrFunction) },
        { "color,function", typeof(ColorOrFunction) },
        { "array,color", typeof(ColorArray) },
        { "array,number,string", typeof(NumberOrStringArray) },
        { "array,function,number", typeof(NumberArrayOrFunction) },
        { "function,number,string", typeof(NumberOrStringOrFunction) },
        // Vector types (new in ECharts 5.6.0) - all represent array of 2 elements
        { "array,vector", typeof(NumberOrNumberArray) },               // can be array or 2-element vector
        { "array,percentvector", typeof(NumberOrStringArray) },        // can be array or 2-element percentvector
        { "array,number,vector", typeof(NumberOrNumberArray) },        // number or array or vector
        // Icon types - Icon class handles both IconType enum and string URLs
        { "icon,string", typeof(Icon) },                               // icon type or string URL
        { "function,icon,string", typeof(StringOrFunction) },          // function or icon or string (treat as StringOrFunction)
        // Graph autoCurveness - boolean|number|array
        { "array,boolean,number", typeof(AutoCurveness) },             // bool OR number OR array (GraphSeries.autoCurveness)
        // StringArray - string or array of strings (general pattern, but some properties override this with specific types)
        { "array,string", typeof(StringArray) },                       // string OR string[] (e.g., symbol, seriesKey)
        // Rotation mode - boolean (auto-rotate), number (degrees), or string (like 'tangential')
        { "boolean,number,string", typeof(RotationMode) },             // label.rotate in bar series
        // DataZoom values - date string, number (timestamp), or percentage string
        { "date,number,string", typeof(DateOrNumberOrString) },        // DataZoom start/end/min/max
    };
    
    /// <summary>
    /// Patterns that need typed accessor generation (object? property with getters/setters)
    /// These patterns are too complex for a single union type but have a clear two-part solution
    /// </summary>
    private static readonly HashSet<string> PartiallySupportedPatterns = new()
    {
        "enum,function",      // e.g., FunnelSeries.sort - can be enum OR function
    };
    
    /// <summary>
    /// Patterns that are too ambiguous or complex for automation
    /// Keep as object? with documentation; use typed accessor pattern if needed
    /// </summary>
    private static readonly HashSet<string> TrulyUnsupportedPatterns = new()
    {
        "*,number",                                // itemGap - genuinely ambiguous
        "array,object",                            // dataset.source - array or object data source
        "array,percentvector",                     // offsetCenter, center (can be array or 2-element percentvector)
        "array,string",                            // symbol, position, etc. (can be array or string)
        "boolean,object",                          // emptyCircleStyle - boolean or object
        "color,number",                            // borderColorSaturation - color or saturation number (property-specific)
        "date,number,object,string",               // Too many variations
        "date,object,number,string",               // Too many variations (different order)
        "function,htmlelement,string",             // appendTo - function or HTMLElement or string selector
        "number,percentvector,string",             // symbolMargin - number OR array OR string (too complex)
        "prefix",                                  // timeline.label.rotate - unknown ECharts type (fallback to string)
    };

    
    public TypePatternRegistry(TypeCollection typeCollection)
    {
        this.typeCollection = typeCollection;
    }
    
    /// <summary>
    /// Try to get a mapped type for a list of type specifications
    /// </summary>
    /// <param name="types">List of type names from option.json (e.g., ["enum", "number"])</param>
    /// <param name="parentName">Parent type context for enum resolution</param>
    /// <param name="mappedType">Output: the mapped C# type, or null if not found</param>
    /// <returns>True if a mapping was found</returns>
    public bool TryGetMappedType(
        List<string> types,
        string parentName,
        out IPropertyType? mappedType)
    {
        mappedType = null;
        
        if (types == null || types.Count == 0)
            return false;
        
        // Single type - check primitives and special types
        if (types.Count == 1)
        {
            var type = types[0];
            
            if (PrimitiveTypes.TryGetValue(type, out var primitiveType))
            {
                mappedType = new SimpleType(primitiveType);
                return true;
            }
            
            // Special cases
            if (type == "color")
            {
                mappedType = new MappedCustomType(typeof(Color));
                return true;
            }
            
            if (type == "function")
            {
                mappedType = new MappedCustomType(typeof(JavascriptFunction));
                return true;
            }
            
            // Enum is handled separately
            return false;
        }
        
        // Multi-type pattern - check supported unions
        if (types.Count >= 2)
        {
            var key = string.Join(",", types.OrderBy(t => t));
            
            if (SupportedPatterns.TryGetValue(key, out var customType))
            {
                mappedType = new MappedCustomType(customType);
                return true;
            }
        }
        
        return false;
    }
    
    /// <summary>
    /// Check if a pattern is partially supported (needs typed accessor pattern)
    /// </summary>
    public bool IsPartiallySupported(List<string> types)
    {
        if (types == null || types.Count == 0)
            return false;
        
        var key = string.Join(",", types.OrderBy(t => t));
        return PartiallySupportedPatterns.Contains(key);
    }
    
    /// <summary>
    /// Check if a pattern is known to be too complex for automation
    /// </summary>
    public bool IsTrulyUnsupported(List<string> types, out string reason)
    {
        reason = string.Empty;
        
        if (types == null || types.Count == 0)
            return false;
        
        var key = string.Join(",", types.OrderBy(t => t));
        
        if (TrulyUnsupportedPatterns.Contains(key))
        {
            reason = $"Pattern '{key}' is too ambiguous for strong typing. Use typed accessor pattern with object?.";
            return true;
        }
        
        return false;
    }
    
    /// <summary>
    /// Get all supported pattern keys for documentation purposes
    /// </summary>
    public IEnumerable<string> GetAllSupportedPatternKeys()
    {
        return SupportedPatterns.Keys.Concat(PartiallySupportedPatterns);
    }
    
    /// <summary>
    /// Generate a suggestion for mapping an unknown pattern
    /// </summary>
    public string? GenerateSuggestion(List<string> types, string? enumValues = null)
    {
        if (types == null || types.Count == 0)
            return null;
        
        var typeStr = string.Join(",", types.OrderBy(t => t));
        
        // For single unmapped enum, suggest enum mapping
        if (types.Count == 1 && types[0] == "enum" && enumValues != null)
        {
            return $"Add enum type mapping: AddMappedEnumType(new MappedEnumType(\"{{propName}}\", typeof(???)), \"{{parentName}}\");";
        }
        
        // For 2-element unions, suggest creating custom type
        if (types.Count == 2 && !types.Contains("*"))
        {
            var name = string.Join("Or", types.OrderBy(t => t).Select(t => Capitalize(t)));
            return $"Create custom union type: {name}<T> (see NumberOrString pattern for template)";
        }
        
        // For 3+ elements, suggest investigation
        if (types.Count >= 3)
        {
            return $"Pattern '{typeStr}' is complex - investigate if typed accessor pattern is appropriate";
        }
        
        return null;
    }
    
    private static string Capitalize(string s) =>
        s.Length > 0 ? char.ToUpper(s[0]) + s.Substring(1) : s;
}
