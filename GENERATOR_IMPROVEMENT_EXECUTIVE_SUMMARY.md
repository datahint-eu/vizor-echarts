# Generator Improvement Plan - Executive Summary

## Problem Statement

The BindingGenerator currently has **scattered diagnostics** and **unmapped type patterns** that fall back to `object` or `string`:

- ⚠️ Warnings printed to console (not aggregated)
- ⚠️ Type issues buried in generated code `//TODO` comments  
- ⚠️ No central registry of supported vs. unsupported patterns
- ⚠️ Hard to add new type mappings (scattered across codebase)
- ⚠️ ~12 type patterns fall back to `object` (could have strong types)
- ⚠️ Developers don't know what's missing or why

## Solution Overview

A **4-phase, 4-week improvement** to create a **diagnostic-driven, registry-based** type mapping system:

```
Current (Chaotic)          →    Improved (Clear & Extensible)
├─ Warnings in console         ├─ DiagnosticCollector
├─ Scattered case statements   ├─ TypePatternRegistry
├─ Object fallbacks            ├─ Structured Reports
└─ Hard to maintain            └─ Easy to extend
```

## Key Deliverables

| Phase | Week | Deliverable | Impact |
|-------|------|------------|--------|
| **1: Foundation** | 1 | Diagnostic infrastructure (3 new classes) | Zero risk, non-blocking |
| **2: Refactor** | 2 | Clear MapType() decision tree | Medium risk, better maintainability |
| **3: Analysis** | 3 | Auto-generated pattern report | Non-blocking, informs priorities |
| **4: Close Gaps** | 4 | New custom types for high-priority patterns | Incremental, test-driven |

## Concrete Examples

### Before: Messy Diagnostics
```
[Console output - lost]
WARNING: enum type 'type' in 'crossStyle' with values 'solid,dashed,dotted' is not mapped
ERROR: Failed to map property 'type' in type 'crossStyle' with types 'array,enum,number'

[Generated code]
//TODO: Type Warning: array,enum,number type 'type' in 'crossStyle' is not mapped
public object? Type { get; set; }
```

### After: Clear Tracking
```
[DiagnosticReport.md - generated]
### array,enum,number (5 occurrences)
Examples: CrossStyle.type, ...
Suggestion: Create EnumOrNumberArray<T> custom type
Effort: 2-3 hours
Priority: High

[Generated code]
[JsonPropertyName("type")]
public EnumOrNumberArray<LineType>? Type { get; set; }  // ← Strong type!
```

## Architecture

```
TypePatternRegistry                   DiagnosticCollector
  ├─ Primitive types                    ├─ Records all decisions
  ├─ Supported patterns                 ├─ Groups by pattern
  ├─ Partially supported                ├─ Generates report
  └─ Truly unsupported                  └─ Tracks progress

          ↑                                    ↑
          └────────────┬─────────────────────┘
                       │
              Refactored MapType()
              (clear decision tree)
                       │
                       ↓
              Better generated code
              + Analysis reports
```

## Success Metrics

| Metric | Current | Target | When |
|--------|---------|--------|------|
| Diagnostic tracking | ❌ Console (lost) | ✅ Report-based | Week 3 |
| Code clarity (MapType) | ❌ 100+ complex lines | ✅ 60 lines, clear steps | Week 2 |
| Generator maintainability | ❌ Pattern scattered | ✅ Centralized registry | Week 1 |
| Unsupported patterns | ~12 | ~3-5 (acceptable) | Week 4 |
| Developers time to add pattern | ~30 min | ~10 min | Week 4 |

## Risk & Mitigation

| Risk | Mitigation |
|------|-----------|
| Refactoring breaks generation | Comprehensive tests before changes; keep fallback logic |
| Report shows more problems | Analysis data drives prioritization; not a blocker |
| Low adoption of new system | Clear guide + documentation; examples in code |

## Next Steps

1. ✅ **Approve plan** (this document)
2. 📋 **Start Phase 1** (Create diagnostic classes)
3. 🔄 **Weekly sync** on progress + learnings
4. 📊 **Generate report** (Week 3) - decide on custom type priorities
5. 🎯 **Close gaps** (Week 4) - implement high-impact patterns

## Files Created by This Plan

**Documentation** (this initiative):
- `doc/Generator_Improvement_Plan.md` (detailed specification)
- `doc/Generator_Improvement_Summary.md` (visual overview)
- `doc/Generator_Implementation_Guide.md` (code examples + how-to)
- `doc/TypePatternAnalysisReport.md` (auto-generated, Week 3)

**Code** (to be implemented):
- `src/Vizor.ECharts.BindingGenerator/Diagnostics/TypeMappingDiagnostic.cs`
- `src/Vizor.ECharts.BindingGenerator/Diagnostics/DiagnosticCollector.cs`
- `src/Vizor.ECharts.BindingGenerator/Types/TypePatternRegistry.cs`
- `src/Vizor.ECharts.Tests/Unit/Generator/TypePatternAnalysisTests.cs` (NEW)
- `src/Vizor.ECharts.Tests/Unit/Generator/DiagnosticCollectorTests.cs` (NEW)
- **Refactored**: `src/Vizor.ECharts.BindingGenerator/Phases/BasePhase.cs`

## Appendix: Example Report (Expected Output)

```markdown
# Type Pattern Analysis Report
Generated: 2025-12-31

## Summary
- Total properties analyzed: 1,247
- ✅ Fully supported: 1,195 (95.8%)
- ⚠️ Partially supported: 32 (2.6%)
- ❌ Unsupported: 15 (1.2%)
- 🔍 Requires investigation: 5 (0.4%)

## Top Unsupported Patterns (Sorted by Impact)

### 1. array,enum,number (5 properties)
**Current**: Falls to `object?`
**Priority**: HIGH - Blocks crossStyle rendering
**Solution**: Create `EnumOrNumberArray<T>`
**Examples**: CrossStyle.type, ParallelSeriesData.type

### 2. boolean,object (3 properties)
**Current**: Falls to `object?`
**Priority**: MEDIUM - Rare pattern
**Solution**: Keep as object? with typed accessors
**Examples**: ScatterSeries.symbolKeepAspect

### 3. date,number,string (2 properties)
**Current**: Falls to `NumberOrString`
**Priority**: LOW - Implicit datetime support works
**Status**: ACCEPTABLE (existing solution works)

## Recommendations
1. ✅ Implement `EnumOrNumberArray<T>` (high impact)
2. ✅ Add 3 missing enum mappings (low effort, high value)
3. ✅ Document 5 "truly unsupported" patterns for typed accessor pattern
4. 📋 Investigate 3 edge cases (schedule for next release)

## All Patterns by Category
[Comprehensive table with 200+ rows...]
```

---

## Questions & Answers

**Q: Why not just make everything `object`?**
A: Type safety is the value prop. Users lose intellisense/compile-time checking. This plan recovers ~95% type coverage.

**Q: How long does Phase 1 take?**
A: 2-3 days to create diagnostic infrastructure. Zero risk since it's purely additive.

**Q: What if there are too many unsupported patterns?**
A: The analysis (Week 3) will tell us. If >5%, we prioritize by usage frequency. Typed accessor pattern is always a fallback.

**Q: Can we do this incrementally?**
A: Yes! Each phase is independent:
- Phase 1 can run without Phase 2 (diagnostics-only mode)
- Phase 2 improves code but doesn't break anything (old fallback logic preserved)
- Phase 3 is pure analysis (no code generation changes)
- Phase 4 is incremental (add 1 custom type at a time)

**Q: Who benefits?**
- **Developers**: Clearer error messages, extensible system
- **Users**: Better type safety in generated code
- **Maintainers**: 10x easier to understand generator logic

---

## Related Documents

- [Generator_Improvement_Plan.md](Generator_Improvement_Plan.md) - Detailed technical specification
- [Generator_Improvement_Summary.md](Generator_Improvement_Summary.md) - Visual flowcharts and timeline
- [Generator_Implementation_Guide.md](Generator_Implementation_Guide.md) - Complete code examples
- [Manual_Implementation_Analysis.md](Manual_Implementation_Analysis.md) - Existing patterns baseline
