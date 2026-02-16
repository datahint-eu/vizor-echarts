namespace Vizor.ECharts.BindingGenerator.Diagnostics;

/// <summary>
/// Severity level for type mapping diagnostic.
/// </summary>
internal enum DiagnosticLevel
{
    /// <summary>Fully supported with strong type (e.g., NumberOrString, Color)</summary>
    Supported,
    
    /// <summary>Falls back to object? with typed accessors (e.g., EnumOrFunction pattern)</summary>
    PartiallySupported,
    
    /// <summary>Falls back to object or downgraded type (e.g., unmapped enum → string)</summary>
    Unsupported,
    
    /// <summary>New pattern not yet analyzed - requires investigation</summary>
    RequiresInvestigation
}

/// <summary>
/// Diagnostic record for a single property type mapping decision.
/// </summary>
internal class TypeMappingDiagnostic
{
    /// <summary>
    /// Full property path (e.g., "CrossStyle.type" or "FunnelSeries.sort")
    /// </summary>
    public string PropertyPath { get; set; } = string.Empty;
    
    /// <summary>
    /// List of type options from option.json (e.g., ["enum", "number", "array"])
    /// </summary>
    public List<string> Types { get; set; } = new();
    
    /// <summary>
    /// Support level of this mapping
    /// </summary>
    public DiagnosticLevel Level { get; set; }
    
    /// <summary>
    /// Descriptive message about the mapping
    /// </summary>
    public string Message { get; set; } = string.Empty;
    
    /// <summary>
    /// Actionable suggestion for improvement (e.g., "Create EnumOrNumberArray<T>")
    /// </summary>
    public string? Suggestion { get; set; }
    
    /// <summary>
    /// Additional context information
    /// Key examples: "enum_values", "mapped_type", "reason", "fallback_type"
    /// </summary>
    public Dictionary<string, string> Context { get; set; } = new();
    
    /// <summary>
    /// The mapped C# type that was generated
    /// </summary>
    public string? GeneratedType { get; set; }
    
    public override string ToString()
    {
        var typeStr = string.Join(",", Types);
        var level = Level.ToString();
        return $"[{level}] {PropertyPath}: {typeStr} → {GeneratedType ?? "object"} ({Message})";
    }
}
