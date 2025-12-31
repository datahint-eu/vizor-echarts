using System.Text;

namespace Vizor.ECharts.BindingGenerator.Diagnostics;

/// <summary>
/// Collects and aggregates type mapping diagnostics from the generator.
/// Provides analysis and reporting on type mapping support coverage.
/// </summary>
internal class DiagnosticCollector
{
    private readonly List<TypeMappingDiagnostic> diagnostics = new();
    
    /// <summary>
    /// Record a successfully mapped type (supported)
    /// </summary>
    public void RecordSupported(string propertyPath, List<string> types, string mappedType)
    {
        diagnostics.Add(new TypeMappingDiagnostic
        {
            PropertyPath = propertyPath,
            Types = new List<string>(types),
            Level = DiagnosticLevel.Supported,
            Message = $"Mapped to strong type",
            GeneratedType = mappedType
        });
    }
    
    /// <summary>
    /// Record a partially supported type (falls back to object with typed accessors)
    /// </summary>
    public void RecordPartiallySupported(
        string propertyPath,
        List<string> types,
        string fallback,
        string suggestion)
    {
        diagnostics.Add(new TypeMappingDiagnostic
        {
            PropertyPath = propertyPath,
            Types = new List<string>(types),
            Level = DiagnosticLevel.PartiallySupported,
            Message = $"Falls back to {fallback} with typed accessors",
            GeneratedType = fallback,
            Suggestion = suggestion,
            Context = new Dictionary<string, string> { { "pattern", "typed_accessor" } }
        });
    }
    
    /// <summary>
    /// Record an unsupported type (falls back to object or downgraded type)
    /// </summary>
    public void RecordUnsupported(
        string propertyPath,
        List<string> types,
        string fallback = "object",
        string? suggestion = null)
    {
        diagnostics.Add(new TypeMappingDiagnostic
        {
            PropertyPath = propertyPath,
            Types = new List<string>(types),
            Level = DiagnosticLevel.Unsupported,
            Message = $"Falls back to {fallback}",
            GeneratedType = fallback,
            Suggestion = suggestion ?? "Investigate if a custom type is needed"
        });
    }
    
    /// <summary>
    /// Record a pattern that requires investigation
    /// </summary>
    public void RecordRequiresInvestigation(
        string propertyPath,
        List<string> types,
        string reason)
    {
        diagnostics.Add(new TypeMappingDiagnostic
        {
            PropertyPath = propertyPath,
            Types = new List<string>(types),
            Level = DiagnosticLevel.RequiresInvestigation,
            Message = reason,
            GeneratedType = "object"
        });
    }
    
    /// <summary>
    /// Generate a diagnostic report from collected data
    /// </summary>
    public DiagnosticReport GenerateReport()
    {
        return new DiagnosticReport(diagnostics.AsReadOnly());
    }
    
    /// <summary>
    /// Get all diagnostics collected so far
    /// </summary>
    public IReadOnlyList<TypeMappingDiagnostic> AllDiagnostics => diagnostics.AsReadOnly();
    
    /// <summary>
    /// Get summary counts
    /// </summary>
    public (int Supported, int Partial, int Unsupported, int Investigation, int Total) GetSummary()
    {
        return (
            diagnostics.Count(d => d.Level == DiagnosticLevel.Supported),
            diagnostics.Count(d => d.Level == DiagnosticLevel.PartiallySupported),
            diagnostics.Count(d => d.Level == DiagnosticLevel.Unsupported),
            diagnostics.Count(d => d.Level == DiagnosticLevel.RequiresInvestigation),
            diagnostics.Count
        );
    }
    
    /// <summary>
    /// Clear all collected diagnostics
    /// </summary>
    public void Clear() => diagnostics.Clear();
}

/// <summary>
/// Report generated from collected diagnostics
/// </summary>
internal class DiagnosticReport
{
    private readonly IReadOnlyList<TypeMappingDiagnostic> diagnostics;
    
    public DiagnosticReport(IReadOnlyList<TypeMappingDiagnostic> diagnostics)
    {
        this.diagnostics = diagnostics;
    }
    
    /// <summary>Statistics</summary>
    public int SupportedCount => diagnostics.Count(d => d.Level == DiagnosticLevel.Supported);
    public int PartiallyCount => diagnostics.Count(d => d.Level == DiagnosticLevel.PartiallySupported);
    public int UnsupportedCount => diagnostics.Count(d => d.Level == DiagnosticLevel.Unsupported);
    public int InvestigateCount => diagnostics.Count(d => d.Level == DiagnosticLevel.RequiresInvestigation);
    public int TotalCount => diagnostics.Count;
    
    /// <summary>
    /// Get unsupported patterns grouped and sorted by frequency
    /// </summary>
    public IEnumerable<IGrouping<string, TypeMappingDiagnostic>> UnsupportedPatterns()
    {
        return diagnostics
            .Where(d => d.Level == DiagnosticLevel.Unsupported)
            .GroupBy(d => string.Join(",", d.Types.OrderBy(t => t)))
            .OrderByDescending(g => g.Count());
    }
    
    /// <summary>
    /// Get all patterns grouped by type and sorted by frequency
    /// </summary>
    public IEnumerable<IGrouping<string, TypeMappingDiagnostic>> AllPatterns()
    {
        return diagnostics
            .GroupBy(d => string.Join(",", d.Types.OrderBy(t => t)))
            .OrderByDescending(g => g.Count());
    }
    
    /// <summary>
    /// Generate a markdown report
    /// </summary>
    public string ToMarkdown()
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("# Type Pattern Analysis Report");
        sb.AppendLine($"Generated: {DateTime.Now:yyyy-MM-dd HH:mm:ss}");
        sb.AppendLine();
        
        // Summary section
        sb.AppendLine("## Summary");
        sb.AppendLine($"- Total properties analyzed: {TotalCount}");
        sb.AppendLine($"- ✅ Fully supported: {SupportedCount} ({Percent(SupportedCount)}%)");
        sb.AppendLine($"- ⚠️ Partially supported: {PartiallyCount} ({Percent(PartiallyCount)}%)");
        sb.AppendLine($"- ❌ Unsupported: {UnsupportedCount} ({Percent(UnsupportedCount)}%)");
        sb.AppendLine($"- 🔍 Requires investigation: {InvestigateCount} ({Percent(InvestigateCount)}%)");
        sb.AppendLine();
        
        // Unsupported patterns section
        var unsupported = UnsupportedPatterns().ToList();
        if (unsupported.Any())
        {
            sb.AppendLine("## Unsupported Patterns (Sorted by Frequency)");
            sb.AppendLine();
            
            foreach (var group in unsupported)
            {
                var typeStr = group.Key;
                var count = group.Count();
                var examples = group.Take(3).ToList();
                
                sb.AppendLine($"### {typeStr} ({count} occurrences)");
                sb.AppendLine($"**Examples**: {string.Join(", ", examples.Select(e => e.PropertyPath))}");
                
                var suggestion = examples.FirstOrDefault()?.Suggestion;
                if (suggestion != null)
                    sb.AppendLine($"**Suggestion**: {suggestion}");
                
                sb.AppendLine();
            }
        }
        
        // Partially supported patterns
        var partial = diagnostics
            .Where(d => d.Level == DiagnosticLevel.PartiallySupported)
            .GroupBy(d => string.Join(",", d.Types.OrderBy(t => t)))
            .ToList();
        
        if (partial.Any())
        {
            sb.AppendLine("## Partially Supported Patterns (Typed Accessor Pattern)");
            sb.AppendLine();
            
            foreach (var group in partial)
            {
                var typeStr = group.Key;
                var count = group.Count();
                var examples = group.Take(3).ToList();
                
                sb.AppendLine($"### {typeStr} ({count} occurrences)");
                sb.AppendLine($"**Pattern**: object? with typed accessors");
                sb.AppendLine($"**Examples**: {string.Join(", ", examples.Select(e => e.PropertyPath))}");
                sb.AppendLine();
            }
        }
        
        // Investigation needed
        var investigation = diagnostics
            .Where(d => d.Level == DiagnosticLevel.RequiresInvestigation)
            .GroupBy(d => string.Join(",", d.Types.OrderBy(t => t)))
            .ToList();
        
        if (investigation.Any())
        {
            sb.AppendLine("## Patterns Requiring Investigation");
            sb.AppendLine();
            
            foreach (var group in investigation)
            {
                var typeStr = group.Key;
                var count = group.Count();
                var examples = group.Take(3).ToList();
                
                sb.AppendLine($"### {typeStr} ({count} occurrences)");
                sb.AppendLine($"**Examples**: {string.Join(", ", examples.Select(e => e.PropertyPath))}");
                sb.AppendLine($"**Note**: {examples.First().Message}");
                sb.AppendLine();
            }
        }
        
        return sb.ToString();
    }
    
    private double Percent(int count) => TotalCount > 0 ? Math.Round(100.0 * count / TotalCount, 1) : 0;
}
