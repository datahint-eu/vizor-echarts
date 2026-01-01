# Circular Dependency Solutions: Generator ↔ Vizor.ECharts

## Problem
The Generator project references Vizor.ECharts types (like `Detail`, `ChartOptions`), but Vizor.ECharts needs the Generator to create these types. This creates a circular dependency that prevents:
- Deleting generated files for clean regeneration
- Building the generator independently
- Running the generator as part of the build

## Current Solution (#3): Conditional Compilation (REVISED)
**Status**: CHALLENGING - SEE BELOW

Attempted approach: Use a `GENERATOR_BUILD` configuration flag to conditionally exclude generated files when the generator itself builds.

### Why This Doesn't Work:
- Generator needs `typeof()` references to hand-coded utility types: `Color`, `NumberOrString`, `JavascriptFunction`, etc.
- Cannot exclude generated files globally - hand-coded Series classes reference generated types (e.g., `Emphasis`, `Blur`, `Select`, `Label`)
- Some generated files are in mixed folders: `Series/Sankey/SankeySeriesLink.cs` is generated but `Series/Sankey/` folder contains hand-coded files
- Excluding by glob pattern `Series/Generated/**/*.cs` is not sufficient

### Why This Won't Work Even With More Specific Exclusions:
The core issue isn't about file location—it's that:
1. Hand-coded `SankeySeriesLevel.cs` references generated `Blur`, `Select`, `Emphasis`
2. Generator needs `typeof(Color)`, `typeof(NumberOrString)` to compile
3. These types come from Vizor.ECharts project
4. Creating "stubs" requires knowing exact signatures of generated types

**Verdict**: #3 alone is insufficient. Need #5 or #6 first.

---

## Future Solution (#6): Abstractions Assembly
**Status**: PLANNED FOR FUTURE

Create a lightweight abstractions layer that breaks the circular dependency architecturally.

### Architecture:
```
Vizor.ECharts.Abstractions (no dependencies)
├── ISeries interface
├── IDataZoom interface
├── Color, NumberOrString, JavascriptFunction types
└── Other core utility types

Vizor.ECharts.BindingGenerator → references Abstractions only
├── Generates code against Abstractions types
└── No dependency on generated Vizor.ECharts files

Vizor.ECharts → references Abstractions
├── Includes Abstractions types
├── Includes generated types
└── Clean build possible at any time
```

### Implementation Steps:
1. Create `src/Vizor.ECharts.Abstractions/Vizor.ECharts.Abstractions.csproj`
   - No NuGet dependencies
   - `<TargetFramework>net10.0</TargetFramework>`

2. Move core types to Abstractions:
   - `ISeries`, `IDataZoom` interfaces
   - `Color`, `NumberOrString` types
   - `JavascriptFunction`, `StringOrFunction` types
   - `SeriesData<T>`, `SeriesData<T,U>`, etc. generics
   - Other fundamental utility types

3. Update Generator to reference Abstractions:
   - Remove reference to Vizor.ECharts
   - Add reference to Vizor.ECharts.Abstractions
   - Update type mappings to use Abstractions types

4. Update Vizor.ECharts to reference Abstractions:
   - Add `<ProjectReference>` to Abstractions
   - Make Abstractions types public (re-export if needed)
   - Generated types inherit/use Abstractions types

5. NuGet packaging:
   - Abstractions packaged separately (lightweight dependency)
   - Main package includes both Abstractions + generated types

**Pros**: Architecturally clean, zero coupling, enables independent tooling  
**Cons**: Requires refactoring, more projects to maintain

---

## Future Solution (#4): Standalone dotnet Tool
**Status**: LONG-TERM GOAL

Publish the generator as a standalone `dotnet` global or local tool for complete decoupling.

### Architecture:
```
vizor-echarts-gen (standalone tool)
├── No reference to Vizor.ECharts
├── Takes option.json path as input
├── Generates C# files to output directory
└── Published as `dotnet tool`

Usage: dotnet vizor-gen --input option.json --output src/Vizor.ECharts
```

### Implementation Steps:
1. Create `tools/vizor-echarts-gen/` as standalone project
   - Copy generator core logic
   - Remove all Vizor.ECharts references
   - Pure code generation, no compilation

2. Create tool manifest:
   ```xml
   <PackageType>DotnetTool</PackageType>
   <ToolCommandName>vizor-gen</ToolCommandName>
   ```

3. Configuration:
   - Accept option.json path as CLI argument
   - Accept output directory as CLI argument
   - Optional: type mapping config file (JSON)

4. Publishing:
   - `dotnet pack -c Release` creates tool package
   - `dotnet tool install -g vizor-echarts-gen` for global install
   - Or use locally: `dotnet tool restore && dotnet vizor-gen ...`

5. Remove generator from main solution
   - Clean solution structure
   - Clear separation of concerns
   - Easier to version independently

6. Document in README:
   ```bash
   # Regenerate types when upgrading ECharts
   dotnet tool restore
   dotnet vizor-gen --input echart-options/5.6.0/option.json --output src/Vizor.ECharts
   ```

**Pros**: Maximum decoupling, professional tool experience, no build-time generation  
**Cons**: Extra project, requires manual run after option.json updates, more complex setup

---

## Recommended Approach: #5 (Git-Checked Generated Files) + #6 (Abstractions)
**Status**: RECOMMENDED NOW

### Short Term (#5 - Already True):
Generated files are already committed to git. Normal workflow:
```bash
dotnet build                                    # Works always (uses git-checked files)
dotnet run --project BindingGenerator           # Regenerates types (only on option.json changes)
```

**Advantage**: Zero bootstrapping issues, matches how most code generators work (OpenAPI, Protobuf, etc.)

### Medium Term (#6 - Build Foundation):
Once abstractions layer is ready:
```
Vizor.ECharts.Abstractions (core types, no deps)
├── ISeries, IDataZoom interfaces
├── Color, NumberOrString types
└── JavascriptFunction utilities

Generator → Abstractions (no Vizor.ECharts reference needed)
Main Library → Abstractions + Generated types
```

This enables #4 later if needed.

---

## Recommended Implementation Order

1. **Accept #5** (Current reality)
   - Generated files stay in git
   - Normal builds always work
   - Regenerate explicitly when upgrading ECharts
   - Document in README: `./regenerate-types.sh`

2. **Implement #6** (Abstractions Assembly)
   - Creates clean architectural boundary
   - Enables future #4 without rework
   - Takes ~2-3 hours
   - Backward compatible

3. **Optional: #4** (Standalone Tool)
   - Publish as dotnet global tool
   - Complete decoupling
   - Professional option for end-users
   - Implement after #6 is stable
