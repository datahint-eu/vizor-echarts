# Generator Improvement: Visual Summary

## The Problem

```
Current Flow (Messy):
┌─────────────────────────────────────────────────────────────────┐
│ MapType() - 100+ lines with nested conditions                  │
├─────────────────────────────────────────────────────────────────┤
│ if (enum) → check TypeCollection → silent fallback to string   │
│ if (array) → check items → fallback to List<object>            │
│ if (2-type pattern) → check 50+ specific cases                 │
│ if (...) → ... more patterns ...                               │
│ else → FALLBACK TO OBJECT + generate //TODO comment            │
└─────────────────────────────────────────────────────────────────┘
                            ↓
        ⚠️ Warnings scattered in console (lost)
        ⚠️ Type issues buried in generated code comments
        ⚠️ No central registry of what's supported
        ⚠️ Hard to add new patterns
        ⚠️ Developers don't know what's missing
```

## The Solution

```
Improved Flow (Clear & Extensible):
┌────────────────────────────────────────┐
│  TypePatternRegistry                   │
│  • Primitive types                     │
│  • Enum mappings (from TypeCollection) │
│  • Supported patterns (boolean,string) │
│  • Partially supported (enum,function) │
│  • Unsupported patterns                │
└────────────────────────────────────────┘
         ↑                        ↑
         │                        │
┌────────┴────────────────────────┴──────┐
│  DiagnosticCollector                   │
│  • Records all mapping decisions       │
│  • Categorizes by support level        │
│  • Groups by pattern for analysis      │
│  • Generates detailed report           │
└────────────────────────────────────────┘
         ↑
┌────────┴────────────────────────────────┐
│  Refactored MapType()                  │
│                                        │
│  if (single type) → MapSingleType()   │
│  if (known pattern) → return custom   │
│  if (partially supported) → typed acc │
│  else → diagnostic + smart fallback   │
│                                        │
│  Zero console noise ✓                 │
│  All decisions logged ✓               │
│  Easy to extend ✓                     │
└────────────────────────────────────────┘
         ↓
    Generated Code + Analysis Report
    • No //TODO comments (or minimal)
    • Type patterns documented
    • Actionable suggestions for unsupported
```

## Type Support Matrix

```
FULLY SUPPORTED (Map to Custom Types)
├─ Single primitives: string, number, boolean, object
├─ Color & Function: color → Color, function → JavascriptFunction  
├─ Known patterns:
│  ├─ number,boolean → NumberOrBool
│  ├─ boolean,string → BoolOrString
│  ├─ number,string → NumberOrString
│  ├─ array,number → NumberOrNumberArray
│  ├─ (13 more in Types/ folder)
│  └─ array,object (Grid/XAxis) → SingleOrArrayType<T>
│
PARTIALLY SUPPORTED (Typed Accessors Generated)
├─ enum,function → EnumOrFunctionType (obj? + typed getter/setter)
├─ Custom transforms (anyOf pattern)
│
UNSUPPORTED (Known Limitations)
├─ *,number (truly ambiguous) → object? + warning
├─ Date + 3 types (too many options) → object? + typed accessors
│ 
REQUIRES INVESTIGATION (New Discovery)
├─ array,enum,number → ??? (ShouldBe EnumOrNumberArray?)
├─ ... others discovered in analysis phase ...

```

## Implementation Timeline

```
Week 1: Foundation
┌─────────────────────────────────────┐
│ Create diagnostic infrastructure    │  Minimal risk
│ • DiagnosticCollector              │  No changes to generation
│ • TypeMappingDiagnostic            │  Non-blocking
│ • TypePatternRegistry              │
└─────────────────────────────────────┘
         ↓
Week 2: Refactor
┌─────────────────────────────────────┐
│ Restructure MapType()               │  Medium risk
│ • Extract single-type branch        │  Need comprehensive tests
│ • Extract enum branch               │  Keep old logic as fallback
│ • Extract union pattern branch      │
│ • Add diagnostic calls              │
└─────────────────────────────────────┘
         ↓
Week 3: Analysis
┌─────────────────────────────────────┐
│ Generate pattern report             │  No generation impact
│ • Run on real option.json          │  Pure analysis
│ • Group patterns by category        │  Informs next steps
│ • Suggest improvements              │
└─────────────────────────────────────┘
         ↓
Week 4: Close Gaps
┌─────────────────────────────────────┐
│ Implement high-priority patterns    │  Incremental
│ • New custom types                  │  Add one at a time
│ • Additional enum mappings          │  Test each addition
│ • Typed accessor patterns           │  Document in guide
└─────────────────────────────────────┘
```

## Diagnostic Report Example

```markdown
# Type Pattern Analysis Report
Generated: 2025-12-31

## Summary
- Total properties analyzed: 1,247
- Fully supported: 1,195 (95.8%)
- Partially supported: 32 (2.6%)
- Unsupported (needs investigation): 15 (1.2%)
- Truly unsupported (acceptable): 5 (0.4%)

## Unsupported Patterns Requiring Action

### 1. array,enum,number (5 occurrences)
**Examples**: crossStyle.type, ...
**Current behavior**: Falls to object
**Suggestion**: Create EnumOrNumberArray<T> custom type
**Effort**: 2-3 hours
**Priority**: High (blocks crossStyle rendering)

### 2. [other patterns...]

## Mapping Reference
- Fully supported: 85 distinct patterns
- Known 2-3 type unions: 47 patterns
- Single types: 38 patterns
```

## Key Files Structure

```
src/Vizor.ECharts.BindingGenerator/
├── Phases/
│   └── BasePhase.cs (refactored - clearer decision tree)
├── Diagnostics/ (NEW)
│   ├── TypeMappingDiagnostic.cs
│   ├── DiagnosticCollector.cs
│   └── DiagnosticReport.cs
├── Types/
│   ├── TypePatternRegistry.cs (NEW - centralized patterns)
│   ├── IPropertyType.cs (no change)
│   └── [existing types]
│
src/Vizor.ECharts.Tests/
└── Unit/Generator/
    ├── TypePatternAnalysisTests.cs (NEW)
    ├── DiagnosticCollectorTests.cs (NEW)
    └── ManualImplementationAnalysisTests.cs (unchanged)

doc/
├── Generator_Improvement_Plan.md (THIS FILE - detailed plan)
├── TypePatternAnalysisReport.md (AUTO-GENERATED - results)
└── TypePatternsGuide.md (HOW-TO - add new patterns)
```

## Success Metrics

| Metric | Current | Target | Status |
|--------|---------|--------|--------|
| Types falling back to `object` | ~12 | ~3 | ⏳ Pending |
| `object?` properties with typed accessors | Unknown | 100% | ⏳ Pending |
| Generation diagnostics clarity | Low (warnings scattered) | High (report-based) | ⏳ Pending |
| Time to add new pattern | 30+ min (find code) | 10 min (follow guide) | ⏳ Pending |
| Unsupported patterns documented | No | Yes (analysis report) | ⏳ Pending |

## Risk Assessment

| Risk | Likelihood | Impact | Mitigation |
|------|------------|--------|-----------|
| Refactor breaks existing generation | Medium | High | Comprehensive unit tests first |
| Analysis shows too many unsupported | Low | Medium | Plan fallback typed accessor gen |
| Developers don't adopt new system | Low | Low | Clear guide + examples |
| Performance regression (diagnostics) | Low | Low | Profile; diagnostic collection is O(n) |

## Expected Outcomes

✅ **Clear visibility** into type support status
✅ **Actionable diagnostics** (report tells you exactly what to do)
✅ **Maintainable code** (decision tree instead of giant switch)
✅ **Extensible pattern system** (add new custom type → 1 line in registry)
✅ **Future-proof** (ready for ECharts upgrades)
✅ **Zero fallback surprises** (all decisions logged and reported)
