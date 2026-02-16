# Vizor.ECharts Improvement Plan

Collected improvement suggestions for future iterations. Organized by category with rationale and estimated impact.

## CI/CD & Build Automation

### Add GitHub Actions workflow
- **What**: Create `.github/workflows/` to run `dotnet build`, `dotnet pack -c Release`, and `npm install && gulp` on push/PR
- **Why**: Catch pack-mode failures early, ensure JS bundle stays in sync with C# changes, validate Release configuration works
- **Impact**: High (prevents build/deployment surprises)
- **Effort**: Medium (1–2 hours)

### Publish build artifacts
- **What**: Archive NuGet package and bundled JS artifacts in CI
- **Why**: Enable quick inspection of generated outputs, facilitate prerelease testing
- **Impact**: Medium (improves debug workflow)
- **Effort**: Low (30 mins)

---

## Testing & Quality

### Add component/integration tests for EChart interop
- **What**: Test `EChartBase` serialization paths, `ExternalDataSourceRef` resolution, JS invocation contract, and click event flow
- **Why**: Prevent regressions in options serialization, external data fetching, and Blazor↔JS boundary
- **Impact**: High (reduces maintenance burden over time)
- **Effort**: Medium–High (4–6 hours initial setup, ongoing)
- **Files to focus on**: 
  - [src/Vizor.ECharts/EChartBase.cs](src/Vizor.ECharts/EChartBase.cs) (serialization, lifecycle)
  - [src/Vizor.ECharts/Types/SeriesDataConverterFactory.cs](src/Vizor.ECharts/Types/SeriesDataConverterFactory.cs) (polymorphic data)
  - [src/Vizor.ECharts/Scripts/vizor-echarts.js](src/Vizor.ECharts/Scripts/vizor-echarts.js) (initChart, updateChart, fetchExternalData)

---

## Build Quality

### ✅ DONE: JavaScript code quality modernization
- **What**: Modernized [src/Vizor.ECharts/Scripts/vizor-echarts.js](src/Vizor.ECharts/Scripts/vizor-echarts.js) to ES6+ standards
- **Completed**:
  - All `var` → `const`/`let` with proper reassignment detection
  - All `==`/`!=` → `===`/`!==` (strict equality)
  - Fixed critical bug: undefined `url` variable → `item.url` 
  - ES6 method shorthand for all object methods
  - Arrow functions for callbacks
  - Template literals for string interpolation
  - Fixed memory leak: Added resize listener cleanup in `disposeChart()`
  - Added proper error handling with try-catch
- **Impact**: High (fixes memory leak, improves code quality and maintainability)
- **Browser target**: Modern browsers only (2017+; no IE11 without transpilation)

### Fix BL0005 warnings in sample files
- **What**: Address 3 compiler warnings in [src/Vizor.ECharts.Samples/Areas/Geo/UsaGeoMap.razor](src/Vizor.ECharts.Samples/Areas/Geo/UsaGeoMap.razor) (lines 197, 199) and [src/Vizor.ECharts.Samples/Areas/Misc/ParameterSetSampleChart.razor](src/Vizor.ECharts.Samples/Areas/Misc/ParameterSetSampleChart.razor) (line 83) about setting component parameter `Options` outside its component
- **Why**: Ensure clean build with zero warnings; clarify intent (intentional demo vs. anti-pattern)
- **Impact**: Low (quality signal)
- **Effort**: Low (30 mins)
- **Options**:
  1. Create local copy before mutation: `var localOptions = new ChartOptions { ... }; options = localOptions;`
  2. Add `@* BL0005 *@` suppression if these are intentional test cases demonstrating the capability
- **Note**: Review intent of each file before fixing; may be deliberate examples

---

## Code Maintenance

### Modernize JS interop to ES6 modules
- **What**: Refactor [src/Vizor.ECharts/Scripts/vizor-echarts.js](src/Vizor.ECharts/Scripts/vizor-echarts.js) to use ES6 module exports; update [src/Vizor.ECharts/EChartBase.cs](src/Vizor.ECharts/EChartBase.cs) to use `IJSRuntime.InvokeAsync<IJSObjectReference>("import", "...")` pattern
- **Why**: Eliminate global `window.vizorECharts` namespace pollution; align with .NET 10 best practices; enable better tree-shaking and bundling
- **Impact**: Medium (cleaner architecture, follows modern conventions)
- **Effort**: Medium (2–3 hours: refactor JS exports, update C# import calls, test all chart types)
- **Steps**:
  1. Convert `vizor-echarts.js` to named exports (`export function initChart(...)`, etc.)
  2. Update `EChartBase.cs` to cache and reuse the module reference
  3. Update gulp bundling to preserve ES6 syntax
  4. Test with all demo/sample charts
- **Note**: Backwards compatible refactoring; no API changes needed

### Enforce generated-code boundaries
- **What**: Document that [src/Vizor.ECharts/Options](src/Vizor.ECharts/Options) and [src/Vizor.ECharts/Series](src/Vizor.ECharts/Series) are auto-generated; add regen checklist and helper script
- **Why**: Clarify that hand-edits in these folders may be lost on regeneration; streamline upgrade flow
- **Impact**: Medium (reduces confusion, guides future upgrades)
- **Effort**: Low (1 hour)
- **Outputs**:
  - Update [src/Vizor.ECharts.BindingGenerator/Readme.md](src/Vizor.ECharts.BindingGenerator/Readme.md) with upgrade steps
  - Create or enhance `scripts/regen-bindings.sh` (or PowerShell equivalent)
  - Add `.gitignore` pattern for regeneration artifacts

### Add .editorconfig for JS/TS
- **What**: Extend existing `.editorconfig` to cover `*.js` formatting (indentation, EOL, charset)
- **Why**: Reduce diffs and inconsistency in [src/Vizor.ECharts/Scripts/vizor-echarts.js](src/Vizor.ECharts/Scripts/vizor-echarts.js) before gulp bundling
- **Impact**: Low (quality-of-life)
- **Effort**: Low (30 mins)

---

## Developer Experience & Documentation

### Create minimal "hello chart" template
- **What**: Add a quick-start example or sample in [src/Vizor.ECharts.Samples](src/Vizor.ECharts.Samples) or README showing bare-minimum chart setup
- **Why**: Reduce time-to-first-chart, complement existing detailed samples
- **Impact**: Medium (improves onboarding)
- **Effort**: Low (1 hour)

### Document common pitfalls
- **What**: Add "FAQ" or "Common Pitfalls" section to README covering:
  - `ExternalDataSource` cannot be used inside options; use `ExternalDataSourceRef` instead
  - `dotnet pack` only works in Release configuration
  - Use `ChartGroup` for batch updating multiple charts
  - One `ExternalDataSource` instance per chart (do not reuse static instances)
- **Why**: Reduce support burden and debugging time for users
- **Impact**: Medium (self-serve troubleshooting)
- **Effort**: Low (1 hour)

### Expand Copilot instructions
- **What**: Update [.github/copilot-instructions.md](.github/copilot-instructions.md) with more examples or links to sample code
- **Why**: Help AI agents (and humans) quickly understand patterns
- **Impact**: Low (local benefit)
- **Effort**: Low (30 mins)

---

## Diagnostics & Debugging

### Add diagnostics pane (future)
- **What**: Optional UI component or debug overlay showing:
  - Serialized `chartOpts`, `mapOpts`, `fetchOpts` JSON
  - Cached fetch IDs and their data
  - Last initialization/update timestamps
- **Why**: Enable faster debugging without relying solely on console logs
- **Impact**: Medium (improves development experience)
- **Effort**: Medium–High (3–4 hours, may require demo refactoring)
- **Note**: Lower priority; consider after higher-impact items

---

## Priority Ranking

1. **High** (do first): CI/CD workflow, generated-code boundaries, common pitfalls doc
2. **Medium** (do soon): Component/integration tests, hello-chart template, .editorconfig for JS
3. **Low** (nice-to-have): Diagnostics pane, expanded Copilot instructions

---

## Tracking Template

When starting work, copy the relevant section and update with:

```
- [ ] Task description
  - **Start**: YYYY-MM-DD
  - **Status**: In Progress / Done
  - **PR/Branch**: (if applicable)
  - **Notes**: Any blockers or decisions
```
