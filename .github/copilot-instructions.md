# Copilot Instructions for vizor-echarts

## Project Overview
- **Purpose**: Blazor wrapper around Apache ECharts; main library targets .NET 10.
- **Structure**: src/Vizor.ECharts (core), src/Vizor.ECharts.Demo (Blazor server demo), src/Vizor.ECharts.Samples (area-based samples), src/Vizor.ECharts.Tests (unit tests via MSTest), src/Vizor.ECharts.BindingGenerator (code generation utility).
- **Documentation**: Detailed technical documentation is in the [doc/](doc/) folder, covering generator architecture, testing strategy, circular dependency solutions, memory profiling, and implementation guides.

## External References
Official Apache ECharts documentation and resources:
- **Examples Gallery**: https://echarts.apache.org/examples/en/index.html - Official ECharts examples (translate JavaScript to C#)
- **Cheat Sheet**: https://echarts.apache.org/en/cheat-sheet.html - Quick reference for common patterns
- **Option Documentation**: https://echarts.apache.org/en/option.html - Complete API reference for chart options
- **Tutorial**: https://echarts.apache.org/en/tutorial.html - In-depth guides (e.g., Dataset usage)
- **Online Editor**: https://echarts.apache.org/examples/en/editor.html - Test ECharts code snippets before translating to C#

## Core Architecture & Interop Flow

### C# → JS Pipeline
[src/Vizor.ECharts/EChart.razor](src/Vizor.ECharts/EChart.razor) inherits from [src/Vizor.ECharts/EChartBase.cs](src/Vizor.ECharts/EChartBase.cs) and serializes `ChartOptions` to JSON, passing it via `IJSRuntime` interop to [src/Vizor.ECharts/Scripts/vizor-echarts.js](src/Vizor.ECharts/Scripts/vizor-echarts.js). JS functions called: `vizorECharts.initChart` (initial render), `updateChart` (options update), `attachClickEvent` (click handling).

### Chart Options Model
- `ChartOptions` is a partial shell ([src/Vizor.ECharts/ChartOptions.cs](src/Vizor.ECharts/ChartOptions.cs)).
- Actual option/series types in [src/Vizor.ECharts/Options](src/Vizor.ECharts/Options) and [src/Vizor.ECharts/Series](src/Vizor.ECharts/Series).
- **Most files auto-generated** from ECharts option.json; preserve `[JsonPropertyName]` attributes and property naming conventions.

### Series Typing & Polymorphic Serialization
- Each series implements `ISeries` interface (auto-generated in [src/Vizor.ECharts/Series/Generated/ISeries.cs](src/Vizor.ECharts/Series/Generated/ISeries.cs)).
- Uses **[.NET 10 polymorphic serialization](https://learn.microsoft.com/en-us/dotnet/standard/serialization/system-text-json/polymorphism)**: `[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]` on ISeries interface, with `[JsonDerivedType]` attributes for each series type (e.g., `LineSeries`, `BarSeries`).
- **No explicit Type property** in series classes—discriminator added automatically by serializer during JSON output.
- Same pattern applies to `IDataZoom` ([src/Vizor.ECharts/Options/DataZoom/Generated/IDataZoom.cs](src/Vizor.ECharts/Options/DataZoom/Generated/IDataZoom.cs)) with `InsideDataZoom` and `SliderDataZoom`.
- Polymorphic series data handled by [src/Vizor.ECharts/Types/SeriesDataConverterFactory.cs](src/Vizor.ECharts/Types/SeriesDataConverterFactory.cs).
- `SeriesData<T>`, `SeriesData<T,U>`, and `SeriesData<T,U,V>` generics serialize correctly via factory pattern.

## Data Loading Patterns

### Server-side (C#)
Use the `DataLoader` callback parameter on `EChart` component—invoked during render to populate options asynchronously.

### Browser-side (JS fetch)
Use `ExternalDataSource` ([src/Vizor.ECharts/Types/ExternalDataSource.cs](src/Vizor.ECharts/Types/ExternalDataSource.cs)) to define fetch URLs, optional path extraction, and `afterLoad` JS functions. **Inside options objects, reference via `ExternalDataSourceRef`** (not `ExternalDataSource`). Cached fetches accessible via `window.vizorECharts.getDataSource(fetchId)`.

### JS Functions in Options
Wrap raw JavaScript as `JavascriptFunction` ([src/Vizor.ECharts/Types/JavascriptFunction.cs](src/Vizor.ECharts/Types/JavascriptFunction.cs)); converter outputs raw function text for JS `eval`.

## Multi-Chart Coordination
Use `ChartGroup` ([src/Vizor.ECharts/ChartGroup.cs](src/Vizor.ECharts/ChartGroup.cs)) to synchronize updates across multiple charts via `UpdateAsync`.

## JSON Serialization & Performance
- **Cached serializer options by default** (`CacheJsonSerializerOptions=true`); reuse across all charts for memory efficiency (see Meziantou post linked in EChartBase comments).
- camelCase JSON convention via shared serializer.
- Custom `JsonConverters` parameter: use consistently or disable caching.

## Build & Test Workflows

### .NET Build & Run
- **Build all**: `dotnet build src/Vizor.ECharts.Demo.sln`
- **Run demo**: `dotnet run --project src/Vizor.ECharts.Demo/Vizor.ECharts.Demo.csproj`
- **Run tests**: `dotnet test --project src/Vizor.ECharts.Tests/Vizor.ECharts.Tests.csproj` (MSTest framework)
- **Pack NuGet**: `dotnet pack -c Release` (Release required; fails in Debug via csproj target). Package includes README and wwwroot assets.

### JS Build & Development
In `src/Vizor.ECharts`:
- `npm install` → install echarts & gulp toolchain
- `gulp` (or `gulp buildJs`) → minify vizor-echarts.js to wwwroot/js
- `gulp buildJsBundle` → bundle echarts + echarts-stat + vizor-echarts
- `gulp clean` → remove output files
Bundled JS (`vizor-echarts-bundle.js`) ships with package for no-dependency deployments.

### Debug Logging
DEBUG builds auto-enable `vizorECharts.changeLogging(true)`, logging serialized options & fetches to console. Use browser DevTools to inspect actual data sent/received.

## Resource Lifecycle
- **`DisposeAsync`** on `EChartBase`: removes from groups, clears cached serializer, calls `vizorECharts.disposeChart` (drops cached external data).
- **`ClearAsync`**: reset chart without disposing.

## Code Generation & Option.json Upgrades

**Rarely rerun generator.** Only when upgrading ECharts major version:
1. Build echarts-doc repo (`npm run build` → generates option.json).
2. Delete `src/Vizor.ECharts/Options/Generated` and `src/Vizor.ECharts/Series/Generated` folders.
3. Run: `dotnet run --project src/Vizor.ECharts.BindingGenerator -- option-binding --input <path/to/option.json> --output src/Vizor.ECharts`
4. **Polymorphic interfaces auto-generated**: Generator creates `ISeries.cs` and `IDataZoom.cs` in their respective Generated folders with .NET 10 `[JsonPolymorphic]`/`[JsonDerivedType]` attributes. Discriminators extracted from type property defaults in option.json.
5. Fix any compile errors (generator isn't 100% perfect).
6. **Hand-tuned overrides remain unchanged**: Files like `Series/Sankey/SankeySeriesLevel.cs` (outside Generated folders) are manually maintained and will NOT be regenerated. These are intentional architectural customizations.
7. Verify hand-tuned files still compile against newly generated types. Update manually if needed.

**Option.json Locations**:
- **Current version (5.6.0)**: [src/Vizor.ECharts.BindingGenerator/echart-options/5.6.0/option.json](src/Vizor.ECharts.BindingGenerator/echart-options/5.6.0/option.json)
- **Future version (6.0.0)**: Will be added to `src/Vizor.ECharts.BindingGenerator/echart-options/6.0.0/option.json` when upgrading
- **Source**: Generated from https://github.com/apache/echarts-doc repository by running `npm run build`
- **Version tracking**: Generator automatically extracts version from input path (e.g., "5.6.0" from "echart-options/5.6.0/option.json") and includes it in generated file headers

See [src/Vizor.ECharts.BindingGenerator/Readme.md](src/Vizor.ECharts.BindingGenerator/Readme.md) for details on identifying and maintaining hand-tuned files.

## Hand-Tuned Overrides Pattern

Some generated types are intentionally customized and maintained outside the Generated folders:

### Structure
- **Auto-generated**: `Series/Generated/Sankey/SankeySeriesLevels.cs` (in Generated subfolder, has "AUTO GENERATED" header)
- **Hand-tuned**: `Series/Sankey/SankeySeriesLevel.cs` (outside Generated, manually maintained, typically partial class)

### How to Identify
- Files WITH `// AUTO GENERATED - DO NOT EDIT` header in `Options/Generated/` or `Series/Generated/` → regenerated automatically
- Files WITHOUT header, located outside Generated folders → hand-maintained overrides

### When Hand-Tuning is Necessary
- API improvements or naming changes (e.g., singular vs. plural for clarity)
- Custom type conversions or serialization logic
- Architectural customizations that differ from option.json

### Maintenance Requirement
- Hand-tuned files are **NOT automatically updated** by the generator
- Must manually update when underlying generated types change
- Verify compilation after running generator on new option.json
Global enum mappings in [src/Vizor.ECharts.BindingGenerator/Types/TypeCollection.cs](src/Vizor.ECharts.BindingGenerator/Types/TypeCollection.cs) `AddMappedEnumType` calls. When a JSON property name maps to multiple possible enums (e.g., `"type"` can be `LineType` or `LegendType` depending on parent object), specify parent type as context: `AddMappedEnumType(new(...), "lineStyle")`.

## Testing Patterns
- Snapshot tests in [src/Vizor.ECharts.Tests/Unit/Serialization](src/Vizor.ECharts.Tests/Unit/Serialization).
- Use `ChartOptionsBuilder` helpers and `SnapshotHelper.AssertJsonSnapshot` for serialization validation.
- Test custom converters in Converters/ subfolder.

## Key Conventions
- **One `ExternalDataSource` per chart** (avoid static instances).
- **Render mode** defaults to SVG; set `Renderer = ChartRenderer.Canvas` if needed.
- **Theme** optional; null renders with default theme.
- **Click events** attached via `vizorECharts.attachClickEvent` → calls `HandleChartClick` on component.
- **Interop contract**: JS expects JSON strings for options/maps/fetchOpts. Null options show loading spinner only.

## Additional Documentation
For detailed technical documentation, see files in the [doc/](doc/) folder:
- **Circular_Dependency_Solutions.md** - Generator ↔ Vizor.ECharts circular dependency discussion and future abstractions layer plan
- **Generator_Implementation_Guide.md** - Code examples for generator improvements
- **Generator_Improvement_Plan.md** - Detailed specification for type mapping improvements
- **GENERATOR_IMPROVEMENT_EXECUTIVE_SUMMARY.md** - High-level generator improvement overview
- **Manual_Implementation_Analysis.md** - Analysis of existing type patterns
- **Testing_Strategy.md** - Test infrastructure and patterns
- **Memory_Profiling.md** - Performance optimization guidance
- **Node_Build_Toolchain.md** - JS build process documentation
- **VizorECharts_JS_Interop.md** - JavaScript interop architecture

Feel free to propose additions if key workflows or patterns are missing.
