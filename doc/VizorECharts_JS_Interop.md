# vizor-echarts.js: JavaScript Interop Layer

## Overview

`vizor-echarts.js` is the core JavaScript bridge between Blazor/C# and Apache ECharts. It handles chart lifecycle, data fetching, event routing, and map registration. This file is served as part of the wwwroot bundle and loaded via `vizor-echarts-bundle-min.js` or `vizor-echarts-min.js` in the HTML host page.

**Location**: [src/Vizor.ECharts/Scripts/vizor-echarts.js](../src/Vizor.ECharts/Scripts/vizor-echarts.js)  
**Built by**: Gulp tasks in [src/Vizor.ECharts/gulpfile.js](../src/Vizor.ECharts/gulpfile.js)  
**Output**: `wwwroot/js/vizor-echarts.js` and `wwwroot/js/vizor-echarts-bundle.js`

---

## Data Flow

### Initialization (first render)

```
C# [EChart.razor]
  ├─ Options serialized to JSON (camelCase)
  ├─ JSRuntime.InvokeVoidAsync("vizorECharts.initChart", id, theme, initOptions, chartOpts, mapOpts, fetchOpts)
  │
JS [vizor-echarts.js]
  ├─ Fetch external data (if fetchOpts provided)
  ├─ Register maps (if mapOpts provided)
  ├─ Parse chartOpts JSON with eval()
  ├─ echarts.init() and chart.setOption()
  └─ Return control to Blazor
```

### Update (options changed)

```
C# [EChart.razor]
  ├─ chart.UpdateAsync() called
  ├─ Options modified, serialized to JSON
  ├─ JSRuntime.InvokeVoidAsync("vizorECharts.updateChart", id, chartOpts, mapOpts, fetchOpts)
  │
JS [vizor-echarts.js]
  ├─ Fetch external data (if needed)
  ├─ Register maps (if needed)
  ├─ Parse chartOpts JSON with eval()
  ├─ chart.setOption() (merges with existing)
  └─ Return control to Blazor
```

### Event (click on chart)

```
JS [vizor-echarts.js - attachClickEvent]
  ├─ chart.on('click', callback)
  ├─ Sanitize event data (remove circular refs)
  ├─ objRef.invokeMethodAsync('HandleChartClick', params)
  │
C# [EChartBase.cs]
  └─ [JSInvokable] HandleChartClick(EventParams) processes event
```

---

## API Reference

### Global Object: `window.vizorECharts`

All functions are accessed via `window.vizorECharts.*` from C# interop calls.

#### Storage

```javascript
charts: Map              // Map<chartId, echarts.ECharts instance>
dataSources: Map        // Map<fetchId, fetched data object>
logging: boolean        // Debug flag (toggled in DEBUG builds)
```

---

### Chart Lifecycle Functions

#### `initChart(id, theme, initOptions, chartOptions, mapOptions, fetchOptions)`

**Purpose**: Initialize a new echarts instance and render it with options.

**Parameters**:
- `id` (string): Unique chart container element ID
- `theme` (string | null): ECharts theme name (e.g., "dark", "light", or null for default)
- `initOptions` (JSON string): echarts.init() configuration; parsed with `JSON.parse()`
  - Example: `{"renderer":"svg","width":"auto","height":"400px"}`
- `chartOptions` (JSON string | null): Chart options; parsed with `eval()` to support raw JS functions
  - If null, chart shows loading spinner only
- `mapOptions` (JSON string | null): GeoJSON/SVG map definitions
- `fetchOptions` (JSON string | null): External data source fetch commands

**Behavior**:
1. Create echarts instance: `echarts.init(document.getElementById(id), theme, JSON.parse(initOptions))`
2. Add window resize listener to auto-resize chart
3. Store chart in `charts` map
4. Show loading animation
5. Fetch external data if `fetchOptions` provided
6. Register maps if `mapOptions` provided
7. Parse and set chart options: `chart.setOption(eval('(' + chartOptions + ')'))`
8. Hide loading animation
9. Return immediately (no await needed from C#)

**Throws**: If element with ID not found or echarts library not loaded.

---

#### `updateChart(id, chartOptions, mapOptions, fetchOptions)`

**Purpose**: Update an existing chart's options and re-render.

**Parameters**:
- `id` (string): Chart ID to update
- `chartOptions` (JSON string): Updated options
- `mapOptions` (JSON string | null): Map updates (optional)
- `fetchOptions` (JSON string | null): External data updates (optional)

**Behavior**:
1. Retrieve chart from `charts` map
2. Fetch external data if needed
3. Register maps if needed
4. Parse and merge options: `chart.setOption(eval('(' + chartOptions + ')'))`
5. Hide loading animation
6. Return immediately

**Note**: Unlike `initChart`, this uses `setOption()` which merges with existing options (partial updates supported).

---

#### `clearChart(id)`

**Purpose**: Clear chart content without disposing echarts instance.

**Parameters**:
- `id` (string): Chart ID

**Behavior**:
- `chart.clear()` removes all series/elements but keeps the instance alive
- Useful for resetting data while preserving chart state

---

#### `disposeChart(id)`

**Purpose**: Fully cleanup: dispose echarts instance, remove cached entries, free external data.

**Parameters**:
- `id` (string): Chart ID

**Behavior**:
1. Retrieve chart from `charts` map
2. Cleanup linked data sources: iterate `chart.__dataSources` array and delete from `dataSources` map
3. `echarts.dispose(chart)` (echarts cleanup)
4. Remove chart from `charts` map
5. Called on C# `DisposeAsync()` to prevent memory leaks

---

### External Data Handling

#### `fetchExternalData(chart, fetchOptions)`

**Purpose**: Async fetch external data from URLs with optional path extraction and post-processing.

**Parameters**:
- `chart` (echarts.ECharts): Chart instance (to attach data source tracking)
- `fetchOptions` (JSON string): Serialized array of fetch commands

**Fetch Command Format** (one per `ExternalDataSource`):
```javascript
{
  "id": "unique-fetch-id",
  "url": "https://example.com/data.json",
  "fetchAs": "json",           // "json" or "string"
  "path": "nodes.data",        // optional dot-notation path
  "afterLoad": "function(...){...}",  // optional JS function as string
  "options": { ... }           // optional fetch() options (headers, etc.)
}
```

**Behavior**:
1. Initialize `chart.__dataSources = []` array to track this chart's fetches
2. For each fetch command:
   a. Fetch URL with provided options
   b. Parse response as JSON or text based on `fetchAs`
   c. If `path` provided, extract nested property via `evaluatePath()`
   d. If `afterLoad` provided, `eval()` and invoke on data
   e. Store result in `dataSources` map with fetch ID
   f. Track fetch ID in `chart.__dataSources`
3. Logging (if enabled): log each fetch and result

**Error Handling**: Catches and logs errors in path evaluation and afterLoad execution; data remains undefined if errors occur.

---

#### `evaluatePath(data, pathExpression)`

**Purpose**: Extract nested data using dot-notation path (simple alternative to JsonPath).

**Parameters**:
- `data` (object): Root data object
- `pathExpression` (string): Dot-separated path (e.g., `"nodes.items[0]"`)

**Behavior**:
1. Split path by `.`
2. Traverse object properties sequentially
3. Return final value or undefined if any segment missing

**Example**:
```javascript
evaluatePath({ nodes: { data: [1,2,3] } }, "nodes.data")
// Returns: [1, 2, 3]
```

**Limitations**: Does not support array indexing or complex JsonPath syntax (e.g., `[0]` not parsed).

---

### Map Registration

#### `registerMaps(chart, mapOptions)`

**Purpose**: Register GeoJSON or SVG maps for geo/map chart types.

**Parameters**:
- `chart` (echarts.ECharts): Chart instance
- `mapOptions` (JSON string): Serialized array of map definitions

**Map Definition Format**:
```javascript
{
  "type": "geoJSON",              // or "svg"
  "mapName": "usa",
  "geoJSON": { ... },             // if type="geoJSON"
  "svg": "<svg>...</svg>",        // if type="svg"
  "specialAreas": { ... }         // optional
}
```

**Behavior**:
1. For each map definition, call appropriate echarts registration:
   - `echarts.registerMap(mapName, { geoJSON, specialAreas })`
   - `echarts.registerMap(mapName, { svg })`
2. Logging: log each registered map

---

### Event Handling

#### `attachClickEvent(id, objRef)`

**Purpose**: Attach click listener and route events back to C# via JSInterop.

**Parameters**:
- `id` (string): Chart ID
- `objRef` (DotNetObjectReference): C# component reference for callback

**Behavior**:
1. Retrieve chart from `charts` map
2. Register click listener: `chart.on('click', callback)`
3. In callback:
   a. Sanitize params object:
      - Delete `params.encode` (function, cannot serialize)
      - Delete `params.event` (DOM event, cannot serialize)
   b. Invoke C# JSInvokable: `objRef.invokeMethodAsync('HandleChartClick', params)`
   c. Logging: log click event data

**Sanitization**: Critical for preventing circular reference errors during serialization to .NET.

---

### Debug & Access Functions

#### `changeLogging(bool)`

**Purpose**: Toggle console logging of serialized data and fetches.

**Parameters**:
- `bool` (boolean): Enable/disable logging

**Behavior**: Sets `vizorECharts.logging` flag. When true, console logs are printed during:
- Chart initialization/updates
- External data fetches
- Map registration
- Click events

**Usage**: Called automatically in DEBUG builds; can be toggled manually in browser console.

---

#### `getChart(id)`

**Purpose**: Retrieve echarts instance by ID for debugging.

**Parameters**:
- `id` (string): Chart ID

**Returns**: echarts.ECharts instance or undefined if not found

**Usage**: `window.vizorECharts.getChart('my-chart')` in browser console

---

#### `getDataSource(fetchId)`

**Purpose**: Retrieve cached external data by fetch ID for debugging.

**Parameters**:
- `fetchId` (string): Fetch command ID

**Returns**: Fetched data object or undefined if not found

**Usage**: Called internally by `ExternalDataSourceRefConverter` to inject data into options. Can also use in browser console to inspect cached data.

---

## Code Quality & Modernization (Updated)

### ES6 Standards

As of the latest update, `vizor-echarts.js` is fully modernized to ES6+ standards:
- **Const/Let**: All variables use `const` by default, `let` only for reassignments
- **Strict Equality**: All comparisons use `===` and `!==` (no loose equality)
- **Arrow Functions**: Callbacks use arrow function syntax
- **Template Literals**: String interpolation with backticks instead of concatenation
- **Method Shorthand**: Object methods use ES6 shorthand (`methodName(params) { }` instead of `methodName: function(params) { }`)
- **Async/Await**: Promise handling explicit and readable

**Browser Support**: Modern browsers only (2017+, Chrome 51+, Firefox 54+, Safari 10+). No IE11 support without transpilation.

### Memory Leak Fix

Resize listener cleanup was implemented to prevent memory leaks:
- Resize handlers stored on chart instances: `chart.__resizeHandler = resizeHandler`
- Properly removed in `disposeChart()` via `window.removeEventListener()`
- Prevents accumulation of zombie event listeners when charts are created/disposed repeatedly

---

## Internal Data Structures

### `chart.__resizeHandler` (Function reference)

**Purpose**: Store reference to resize event listener for cleanup on disposal.

**Lifecycle**:
- Set in `initChart()` when listener is registered
- Used in `disposeChart()` to remove the listener
- Prevents memory leak from accumulated event listeners

### `chart.__dataSources` (Array of string)

**Purpose**: Track which external data fetches are linked to a chart.

**Lifecycle**:
- Initialized in `fetchExternalData()` when first called
- Each fetch ID added to this array
- On `disposeChart()`, all data sources in this array are deleted from `dataSources` map

**Why**: Enables cleanup without orphaning cached data when chart is disposed.

---

## Usage Example

### From C# (EChart.razor)

```csharp
// Serialize options to JSON
var chartOpts = JsonSerializer.Serialize(options, jsonOpts);
var fetchOpts = JsonSerializer.Serialize(new[] { new FetchCommand(externalDataSource) });

// Invoke JavaScript
await JSRuntime.InvokeVoidAsync("vizorECharts.initChart", 
    id: "my-chart",
    theme: "light",
    initOptions: JsonSerializer.Serialize(new { renderer = "svg", width = "auto", height = "400px" }),
    chartOptions: chartOpts,
    mapOptions: null,
    fetchOptions: fetchOpts
);
```

### From JavaScript (Console)

```javascript
// Check if chart exists
window.vizorECharts.getChart('my-chart')

// Enable logging
window.vizorECharts.changeLogging(true)

// Retrieve cached external data
window.vizorECharts.getDataSource('my-fetch-id')

// Manually dispose
window.vizorECharts.disposeChart('my-chart')
```

---

## Build & Bundling

### Gulp Tasks

| Task | Output | Includes |
|------|--------|----------|
| `gulp buildJs` | `wwwroot/js/vizor-echarts.js` (minified) | vizor-echarts.js only |
| `gulp buildJsBundle` | `wwwroot/js/vizor-echarts-bundle.js` (minified) | echarts + echarts-stat + vizor-echarts.js |
| `gulp` (default) | Both tasks | Both outputs |

### How it's loaded

In HTML host page (`_Host.cshtml` or `_Layout.cshtml`):
```html
<!-- Option 1: Include bundle (echarts included) -->
<script src="_content/Vizor.ECharts/js/vizor-echarts-bundle-min.js"></script>

<!-- Option 2: Include wrapper + load echarts separately -->
<script src="echarts.min.js"></script>
<script src="_content/Vizor.ECharts/js/vizor-echarts-min.js"></script>
```

---

## Debugging Tips

### Enable console logging in production

Open browser console and run:
```javascript
window.vizorECharts.changeLogging(true)
```

Then perform chart operations to see serialized JSON and fetch commands logged.

### Inspect active charts

```javascript
// List all active chart IDs
Array.from(window.vizorECharts.charts.keys())

// Get specific chart
const chart = window.vizorECharts.getChart('my-chart')
chart.getOption()  // See current rendered options
```

### Inspect cached external data

```javascript
// List all cached data fetch IDs
Array.from(window.vizorECharts.dataSources.keys())

// Retrieve specific fetch
window.vizorECharts.getDataSource('my-fetch-id')
```

---

## Performance Considerations

### Chart Disposal

Always call `chart.DisposeAsync()` in C# to invoke `disposeChart()`, which:
- Removes echarts instance from DOM
- Clears cached data
- Prevents memory leaks with long-running applications

### eval() Usage

The code uses `eval()` to parse chart options and execute `afterLoad` functions. This is intentional:
- Allows raw JavaScript function properties in options (e.g., custom formatters)
- Only executes trusted, server-generated JSON
- Alternative (safer but less flexible): pre-compile functions on C# side

### Data Source Caching

Fetched data is cached in `dataSources` map for performance (avoids re-fetching if multiple chart updates reference same data). Cached data is **not automatically cleared**—relies on `disposeChart()` cleanup.

---

## Future Improvements

See [IMPROVEMENTS.md](../IMPROVEMENTS.md):

### ✅ DONE: JavaScript Code Quality Modernization
- Full ES6+ modernization of `vizor-echarts.js` completed
- Memory leak in resize listeners fixed
- Strict equality and const/let throughout

### Next Priority: ES6 Module Migration
- **Goal**: Replace global `window.vizorECharts` with named exports and dynamic imports
- **Why**: Reduces namespace pollution, enables better tree-shaking, aligns with .NET 10 best practices
- **Details**: See [Modernize JS interop to ES6 modules](../IMPROVEMENTS.md#modernize-js-interop-to-es6-modules)

### Other Improvements
- CI/CD automation for build/pack validation
- Component/integration testing for interop flows
- Generated-code boundaries documentation
- Common pitfalls guide in README

---

## Related Files

- **C# Interop**: [src/Vizor.ECharts/EChartBase.cs](../src/Vizor.ECharts/EChartBase.cs)
- **Razor Component**: [src/Vizor.ECharts/EChart.razor](../src/Vizor.ECharts/EChart.razor)
- **External Data Types**: [src/Vizor.ECharts/Types/ExternalDataSource.cs](../src/Vizor.ECharts/Types/ExternalDataSource.cs), [ExternalDataSourceRef.cs](../src/Vizor.ECharts/Types/ExternalDataSourceRef.cs)
- **Serialization**: [src/Vizor.ECharts/Internal/FetchCommand.cs](../src/Vizor.ECharts/Internal/FetchCommand.cs)
- **Build**: [src/Vizor.ECharts/gulpfile.js](../src/Vizor.ECharts/gulpfile.js)
