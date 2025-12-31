# Copilot Instructions for vizor-echarts

## Project Overview
- **Purpose**: Blazor wrapper around Apache ECharts; main library targets .NET 10.
- **Structure**: src/Vizor.ECharts (core), src/Vizor.ECharts.Demo (Blazor server demo), src/Vizor.ECharts.Samples (area-based samples), src/Vizor.ECharts.Tests (unit tests via MSTest), src/Vizor.ECharts.BindingGenerator (code generation utility).

## Core Architecture & Interop Flow

### C# → JS Pipeline
[src/Vizor.ECharts/EChart.razor](src/Vizor.ECharts/EChart.razor) inherits from [src/Vizor.ECharts/EChartBase.cs](src/Vizor.ECharts/EChartBase.cs) and serializes `ChartOptions` to JSON, passing it via `IJSRuntime` interop to [src/Vizor.ECharts/Scripts/vizor-echarts.js](src/Vizor.ECharts/Scripts/vizor-echarts.js). JS functions called: `vizorECharts.initChart` (initial render), `updateChart` (options update), `attachClickEvent` (click handling).

### Chart Options Model
- `ChartOptions` is a partial shell ([src/Vizor.ECharts/ChartOptions.cs](src/Vizor.ECharts/ChartOptions.cs)).
- Actual option/series types in [src/Vizor.ECharts/Options](src/Vizor.ECharts/Options) and [src/Vizor.ECharts/Series](src/Vizor.ECharts/Series).
- **Most files auto-generated** from ECharts option.json; preserve `[JsonPropertyName]` attributes and property naming conventions.

### Series Typing & Polymorphic Data
- Each series implements `ISeries` with its `type` literal (e.g., [src/Vizor.ECharts/Series/Line/LineSeries.cs](src/Vizor.ECharts/Series/Line/LineSeries.cs)).
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
2. Delete `src/Vizor.ECharts/GenOptions` and `GenSeries` folders.
3. Run: `option-binding --input <path/to/option.json> --output src/Vizor.ECharts`
4. Fix any compile errors (generator isn't 100% perfect).
5. Merge hand-tuned overrides back in (search existing csproj for `<Compile Remove>` entries).

See [src/Vizor.ECharts.BindingGenerator/Readme.md](src/Vizor.ECharts.BindingGenerator/Readme.md) for details.

## Enum Mapping Convention
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

Feel free to propose additions if key workflows or patterns are missing.
