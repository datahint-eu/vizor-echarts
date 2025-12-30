# Testing Strategy for Vizor.ECharts

## Overview

This document defines the testing approach for the Vizor.ECharts library, with immediate focus on **Tier 1 (Unit Tests)** and **Tier 2 (Snapshot Tests)** to establish a reliable baseline before upgrading to ECharts 6.

## Test Framework Selection

**Framework: MSTest (Microsoft.VisualStudio.TestPlatform)**

### Rationale
- **Official Microsoft platform**: Aligns with .NET 10 ecosystem and long-term support
- **Rich built-in assertions**: `Assert` class covers all common patterns without external dependencies
- **Excellent VS integration**: Deep Test Explorer support, integrated debugger, test UI
- **Snapshot support**: Can implement custom snapshot testing without third-party libraries
- **CI/CD ready**: First-class GitHub Actions support via `dotnet test`

### Constraints
- No third-party assertion libraries (e.g., FluentAssertions, Shouldly)
- No third-party snapshot libraries (e.g., Verify, Snapshooter)
- Custom snapshot implementation required

## Project Structure

```
src/Vizor.ECharts.Tests/
├── Vizor.ECharts.Tests.csproj
├── TestFixtures/
│   ├── ChartOptionsBuilder.cs        # Fluent builders for common chart configs
│   ├── SeriesDataFixtures.cs         # Test data generators
│   └── SnapshotHelper.cs             # Custom snapshot management
├── Unit/
│   ├── Serialization/
│   │   ├── ChartOptionsSerializationTests.cs
│   │   ├── SeriesDataConverterFactoryTests.cs
│   │   ├── JavascriptFunctionSerializationTests.cs
│   │   └── ExternalDataSourceRefTests.cs
│   ├── Converters/
│   │   ├── EnumConverterTests.cs
│   │   └── CustomConverterTests.cs
│   └── Types/
│       └── ExternalDataSourceTests.cs
├── Snapshots/
│   ├── ChartOptionsSerializationTests/
│   │   ├── SerializesLineChartWithBasicOptions.json
│   │   ├── SerializesBarChartWithMultipleSeries.json
│   │   └── SerializesScatterWithExternalData.json
│   └── SeriesDataConverterFactoryTests/
│       ├── HandlesPolymorphicSeriesData.json
│       └── ...
└── Usings.cs                         # Global using declarations
```

## Tier 1: Unit Tests (Serialization & Converters)

### Scope
Test the C# → JSON serialization pipeline: verify that chart options serialize correctly with custom converters, handling polymorphic data, enum values, and JavaScript functions.

### Test Categories

#### 1.1 ChartOptions Serialization
**File**: `Unit/Serialization/ChartOptionsSerializationTests.cs`

**Tests**:
- Basic options with title, grid, legend
- Multiple series with different types (line, bar, scatter)
- Enum properties serialize to camelCase (e.g., `Orient.Vertical` → `"vertical"`)
- Null options do not break serialization
- xAxis, yAxis with label formatters (JavaScript functions)
- Tooltip formatter (JavaScript function as string)

**Expected Outcomes**:
```csharp
[TestMethod]
public void SerializesLineChartWithBasicOptions()
{
    // Arrange
    var options = new ChartOptions
    {
        Title = new() { Text = "Test Chart" },
        Grid = new() { Left = "10%", Right = "10%" },
        XAxis = new() { Type = AxisType.Category },
        YAxis = new() { Type = AxisType.Value }
    };

    // Act
    string json = JsonSerializer.Serialize(options, EChartBase.GetJsonSerializerOptions());

    // Assert
    Assert.IsNotNull(json);
    Assert.IsTrue(json.Contains("\"title\""));
    Assert.IsTrue(json.Contains("\"Test Chart\""));
    Assert.IsTrue(json.Contains("\"xAxis\""));
}
```

#### 1.2 SeriesDataConverterFactory (Polymorphic Data)
**File**: `Unit/Serialization/SeriesDataConverterFactoryTests.cs`

**Tests**:
- `SeriesData<double>` (numeric values)
- `SeriesData<object>` with mixed types (arrays, objects, primitives)
- Arrays of series data objects (e.g., `List<SeriesData<object>>`)
- Nested data structures (scatter with coordinates as `[x, y]` arrays)
- Custom data objects (e.g., `BarSeriesData` with `Name` and `Value`)

**Critical**: This converter handles polymorphic data for multiple chart types; correctness is prerequisite for type upgrade.

#### 1.3 JavascriptFunction Serialization
**File**: `Unit/Serialization/JavascriptFunctionSerializationTests.cs`

**Tests**:
- Function stored as raw JavaScript string in JSON
- Multi-line function bodies preserved
- Template literals and arrow functions handled
- Null/empty function validation

**Expected JSON**:
```json
{
  "tooltip": {
    "formatter": "function(params) { return params[0].name + ': ' + params[0].value; }"
  }
}
```

#### 1.4 Enum Converters
**File**: `Unit/Converters/EnumConverterTests.cs`

**Tests**:
- `Orient.Vertical` → `"vertical"` (lowercase)
- `AxisType.Category` → `"category"`
- `AxisPointerType.Line` → `"line"`
- Unknown enum values handled gracefully (or throw with clear message)
- DefaultValue attributes respected (e.g., `AxisType.Value` not serialized if it's default)

#### 1.5 ExternalDataSourceRef Serialization
**File**: `Unit/Serialization/ExternalDataSourceRefTests.cs`

**Tests**:
- Reference serializes as `{ "fetchId": "ref_12345" }`
- Fetch ID generation is deterministic or consistent
- Multiple references to same `ExternalDataSource` create consistent IDs

### Test Data Organization

**Fixtures** (`TestFixtures/`):

```csharp
// ChartOptionsBuilder.cs
public class ChartOptionsBuilder
{
    public static ChartOptions LineChartBasic() => new()
    {
        Title = new() { Text = "Line Chart" },
        XAxis = new() { Type = AxisType.Category, Data = new() { "A", "B", "C" } },
        YAxis = new() { Type = AxisType.Value },
        Series = new() { new LineSeries { Data = new(new[] { 10, 20, 30 }) } }
    };

    public static ChartOptions BarChartMultipleSeries() => new()
    {
        // ...
    };
}

// SeriesDataFixtures.cs
public static class SeriesDataFixtures
{
    public static SeriesData<double> NumericData() => 
        new(new[] { 10.5, 20.3, 15.8 });

    public static List<object> MixedData() => 
        new() { 10, "text", true, new[] { 1, 2 } };
}
```

### Snapshot Testing Pattern (Custom Implementation)

**File**: `TestFixtures/SnapshotHelper.cs`

```csharp
public static class SnapshotHelper
{
    public static void AssertJsonSnapshot(
        object actual, 
        string testName,
        string methodName,
        [CallerFilePath] string filePath = "")
    {
        // 1. Serialize actual
        string json = JsonSerializer.Serialize(actual, EChartBase.GetJsonSerializerOptions());
        
        // 2. Normalize both (parse and re-serialize to ensure consistent formatting)
        var actualDoc = JsonDocument.Parse(json);
        string normalizedActual = JsonSerializer.Serialize(
            actualDoc.RootElement, 
            new JsonSerializerOptions { WriteIndented = true });
        
        // 3. Build snapshot path: __snapshots__/ClassName.TestMethodName.json
        string snapshotDir = Path.Combine(
            Path.GetDirectoryName(filePath)!, 
            "__snapshots__", 
            Path.GetFileNameWithoutExtension(filePath));
        Directory.CreateDirectory(snapshotDir);
        
        string snapshotPath = Path.Combine(snapshotDir, $"{methodName}.json");
        
        // 4. Compare or write
        if (File.Exists(snapshotPath))
        {
            string expected = File.ReadAllText(snapshotPath);
            var expectedDoc = JsonDocument.Parse(expected);
            
            // Deep equality check on JSON documents
            bool areEqual = JsonDocument.Parse(normalizedActual)
                .RootElement.ValueEquals(expectedDoc.RootElement);
            
            Assert.IsTrue(areEqual, 
                $"Snapshot mismatch. Expected:\n{expected}\n\nActual:\n{normalizedActual}");
        }
        else
        {
            // First run: write snapshot
            File.WriteAllText(snapshotPath, normalizedActual);
        }
    }
}
```

**Usage in Test**:
```csharp
[TestMethod]
public void SerializesLineChartWithBasicOptions()
{
    var options = ChartOptionsBuilder.LineChartBasic();
    SnapshotHelper.AssertJsonSnapshot(options, "ChartOptionsSerializationTests", nameof(SerializesLineChartWithBasicOptions));
}
```

---

## Tier 2: Snapshot Tests (Complex Chart Types)

### Scope
Verify complete JSON output for representative chart configurations; establish baseline before ECharts 6 upgrade.

### Test File
**File**: `Unit/Serialization/ChartTypesSnapshotTests.cs`

### Test Coverage

| Chart Type | Test Name | Snapshot |
|------------|-----------|----------|
| Line | SerializesLineChartWithMultipleSeries | LineChart_MultipleSeries.json |
| Bar | SerializesBarChartWithStacking | BarChart_Stacking.json |
| Scatter | SerializesScatterChartWithColorScale | ScatterChart_ColorScale.json |
| Pie | SerializesPieChartWithLabel | PieChart_Label.json |
| Gauge | SerializesGaugeChart | GaugeChart.json |
| Heatmap | SerializesHeatmapWithDataZoom | Heatmap_DataZoom.json |

### Example: Line Chart Snapshot

**Test**:
```csharp
[TestMethod]
public void SerializesLineChartWithMultipleSeries()
{
    // Arrange
    var options = new ChartOptions
    {
        Title = new() { Text = "Sales by Quarter", Left = "center" },
        Legend = new() { Data = new() { "Q1", "Q2", "Q3" } },
        Grid = new() { Top = "15%", ContainLabel = true },
        XAxis = new() 
        { 
            Type = AxisType.Category, 
            Data = new() { "Jan", "Feb", "Mar" } 
        },
        YAxis = new() { Type = AxisType.Value },
        Series = new()
        {
            new LineSeries 
            { 
                Name = "Q1", 
                Data = new(new[] { 100, 120, 110 }),
                Smooth = true,
                Symbol = "circle"
            },
            new LineSeries 
            { 
                Name = "Q2", 
                Data = new(new[] { 150, 140, 160 }),
                Smooth = true,
                Symbol = "square"
            }
        }
    };

    // Act & Assert
    SnapshotHelper.AssertJsonSnapshot(
        options, 
        "ChartTypesSnapshotTests", 
        nameof(SerializesLineChartWithMultipleSeries));
}
```

**Expected Snapshot** (`__snapshots__/ChartTypesSnapshotTests/SerializesLineChartWithMultipleSeries.json`):
```json
{
  "title": {
    "text": "Sales by Quarter",
    "left": "center"
  },
  "legend": {
    "data": ["Q1", "Q2", "Q3"]
  },
  "grid": {
    "top": "15%",
    "containLabel": true
  },
  "xAxis": {
    "type": "category",
    "data": ["Jan", "Feb", "Mar"]
  },
  "yAxis": {
    "type": "value"
  },
  "series": [
    {
      "type": "line",
      "name": "Q1",
      "data": [100, 120, 110],
      "smooth": true,
      "symbol": "circle"
    },
    {
      "type": "line",
      "name": "Q2",
      "data": [150, 140, 160],
      "smooth": true,
      "symbol": "square"
    }
  ]
}
```

### Snapshot Management

**CLI Flag** (optional, for regeneration after intentional changes):
```bash
UPDATE_SNAPSHOTS=true dotnet test
```

**Snapshot Directory**: `src/Vizor.ECharts.Tests/__snapshots__/`  
**Organization**: One folder per test class, files named `{TestMethodName}.json`

---

## Test Naming Conventions

**Pattern**: `{Describes what is being tested}_{Conditions or variants}`

Examples:
- ✅ `SerializesLineChartWithBasicOptions`
- ✅ `HandlesPolymorphicSeriesDataWithMixedTypes`
- ✅ `EnumConverterSerializesOrientVerticalToLowercase`
- ✅ `ExternalDataSourceRefGeneratesConsistentFetchId`

---

## Assertion Best Practices

**MSTest Guidelines** (no third-party libraries):

1. **Object comparison**: `Assert.AreEqual(expected, actual, message)`
2. **JSON comparison**: Parse with `JsonDocument` for structure validation
3. **Collection comparison**: `CollectionAssert.AreEqual(expected, actual)`
4. **String checks** (MSTEST0037):
   - ✅ Use `Assert.Contains(substring, actualString)` 
   - ✅ Use `Assert.DoesNotContain(substring, actualString)`
   - ❌ Avoid `Assert.IsTrue(str.Contains(...))` or `Assert.IsFalse(str.Contains(...))`
5. **Null checks**: `Assert.IsNull()` / `Assert.IsNotNull()`
6. **Boolean checks**: `Assert.IsTrue()` / `Assert.IsFalse()` (but prefer specific assertions when available)

**Example**:
```csharp
// Good
Assert.Contains("\"type\":\"line\"", json);
Assert.DoesNotContain("\"series\"", json);

// Avoid (triggers MSTEST0037 warning)
Assert.IsTrue(json.Contains("\"type\":\"line\""));
Assert.IsFalse(json.Contains("\"series\""));
```

---

## Test Data Isolation & Reusability

### Principles
1. **No shared state**: Each test creates fresh objects
2. **Builder pattern**: Use fluent builders for common configs (see `ChartOptionsBuilder`)
3. **Fixtures**: Centralize test data generators in `TestFixtures/`
4. **No side effects**: Tests must not modify global state (e.g., `JsonSerializerOptions` cache)

### Key Consideration: JsonSerializerOptions Caching
**Note**: `EChartBase.CacheJsonSerializerOptions` defaults to `true`. Tests must verify:
1. Same options instance used across multiple serializations
2. Cache invalidation works correctly if options change
3. Concurrent tests don't pollute cache

**Test Example**:
```csharp
[TestMethod]
public void UsesCachedJsonSerializerOptions()
{
    var options1 = EChartBase.GetJsonSerializerOptions();
    var options2 = EChartBase.GetJsonSerializerOptions();
    
    Assert.AreSame(options1, options2, "Options should be cached");
}
```

---

## Converter Testing Guidelines

### SeriesDataConverterFactory (Most Critical)

This converter determines how polymorphic data in chart series is serialized. Correctness is essential before upgrading ECharts versions.

**Test Patterns**:

```csharp
[TestMethod]
public void HandlesNumericSeriesData()
{
    var data = new SeriesData<double>(new[] { 10.5, 20.3, 15.8 });
    string json = JsonSerializer.Serialize(data, EChartBase.GetJsonSerializerOptions());
    Assert.AreEqual("[10.5,20.3,15.8]", json.Replace(" ", ""));
}

[TestMethod]
public void HandlesObjectArrayData()
{
    var data = new List<object> 
    { 
        new[] { 10, 20 },  // Scatter point [x, y]
        new[] { 30, 40 },
        new Dictionary<string, object> { { "value", 50 } }  // Custom data object
    };
    
    string json = JsonSerializer.Serialize(data, EChartBase.GetJsonSerializerOptions());
    Assert.IsTrue(json.Contains("\"value\""));
}

[TestMethod]
public void HandlesMixedTypesList()
{
    var data = new List<object> { 100, "text", true, null };
    string json = JsonSerializer.Serialize(data, EChartBase.GetJsonSerializerOptions());
    var doc = JsonDocument.Parse(json);
    Assert.AreEqual(4, doc.RootElement.GetArrayLength());
}
```

---

## CI/CD Integration

### GitHub Actions Addition

Update `.github/workflows/build.yml`:

```yaml
- name: Run tests (Tier 1 & 2)
  run: dotnet test src/Vizor.ECharts.Tests/Vizor.ECharts.Tests.csproj --logger=trx --results-directory=test-results --verbosity normal

- name: Upload test results
  if: always()
  uses: actions/upload-artifact@v3
  with:
    name: test-results
    path: test-results
```

**Test Execution**:
```bash
# Local
dotnet test src/Vizor.ECharts.Tests/

# With detailed output
dotnet test src/Vizor.ECharts.Tests/ --verbosity detailed

# TRX report for CI
dotnet test src/Vizor.ECharts.Tests/ --logger=trx
```

---

## Edge Cases & Special Considerations

### 1. Null Handling
- `ChartOptions` with all null properties should serialize to `{}`
- Series with null data should not crash
- Optional properties should not appear in JSON if null (use `[JsonIgnore]` if needed)

### 2. DefaultValue Attributes
- Properties marked with `[DefaultValue]` should be omitted from JSON if they match default
- Test that defaults are respected in serialization

### 3. Enum Camelcase
- All enum values must serialize to camelCase (e.g., `AxisType.Category` → `"category"`)
- Test both enum and string property assignments

### 4. JavaScript Functions
- Raw JavaScript in `JavascriptFunction` must not be double-escaped
- Multi-line functions with template literals must be preserved as-is
- Test that `eval()` would succeed on the output (without actually calling eval)

### 5. External Data References
- Multiple `ExternalDataSourceRef` instances referencing the same fetch ID should produce identical JSON
- Circular reference in `ExternalDataSource` (e.g., data source referencing itself) should be detected or handled

---

## Limitations & Future Enhancements

### Current Constraints
- **No UI assertions**: Tier 1-2 only test serialization, not rendering
- **No third-party helpers**: All snapshot logic is custom
- **Manual baseline updates**: No `--update-snapshots` flag like other frameworks (can add via environment variable)

### Future Tiers (Out of Scope for This Doc)
- **Tier 3**: Mock JS Interop (verify C# → JS contract)
- **Tier 4**: E2E with Browser (Playwright, actual rendering in Demo app)

---

## Success Criteria

✅ **Tier 1 Complete** when:
- All converters have unit tests with 90%+ coverage
- Serialization tests pass for all major chart types
- Edge cases (null, defaults, functions) covered

✅ **Tier 2 Complete** when:
- Snapshot baselines established for 6+ chart types
- JSON output inspected and validated as correct ECharts format
- Snapshots committed to repo as golden source

✅ **Ready for ECharts 6** when:
- All Tier 1 + 2 tests pass on current ECharts 5.6.0
- Snapshots can be regenerated to 6.x output
- Breaking changes identified via snapshot diffs

---

## References

- [MSTest Documentation](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)
- [JsonDocument API](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.jsondocument)
- [Custom JSON Converters in System.Text.Json](https://learn.microsoft.com/en-us/dotnet/api/system.text.json.serialization.jsonconverter)
- ECharts 5.6.0 Schema: https://echarts.apache.org/en/option.html
