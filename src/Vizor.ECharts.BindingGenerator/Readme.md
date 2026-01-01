# Remarks

This tool was used to generate 80-90% of the initial binding.
It is good enough to generate the bulk of the bindings, but the last bits and pieces are hand tuned.
So in general, you should never have to run this tool again.

## Hand-Tuned Overrides

Some generated types are intentionally maintained as hand-coded overrides outside the Generated folders:

### Example: Sankey Series
- **Generated**: `Series/Generated/Sankey/SankeySeriesLevels.cs` (plural) - auto-generated array wrapper
- **Hand-tuned**: `Series/Sankey/SankeySeriesLevel.cs` (singular) - manually maintained configuration type

When the generator runs:
1. It regenerates `Series/Generated/Sankey/SankeySeriesLevels.cs` (array/list type)
2. The hand-coded `Series/Sankey/SankeySeriesLevel.cs` remains unchanged
3. Both can coexist because they have different names (singular vs plural)

### Identifying Hand-Tuned Files
- **Auto-generated files**: Have `// AUTO GENERATED - DO NOT EDIT` header in `Generated/` subfolders
- **Hand-tuned files**: No `AUTO GENERATED` header, exist outside Generated folders (e.g., `Series/Sankey/*.cs`)
- Hand-tuned files are typically `partial class` that reference generated types

### Maintaining Hand-Tuned Files
- Hand-tuned files should be updated manually when option.json changes affect their properties
- They are NOT automatically updated by the generator
- Check git history to see which files were moved out and customized during development

# How to generate

 - Download the latest version of https://github.com/apache/echarts-doc
 - run `npm install --save-dev`
 - I had some errors during the install, forcing me to run `npm cache clear --force`
 - Run `npm run build`
 - This generates the file `echarts-website\en\documents\option.json`
 - Run the option-binding tool

Sometimes there is a catch-22: bugs in the generated types prevent the code from compiling, but you need to regenerate in order to fix the bugs.
In that case: simply delete the entire GenOptions and GenSeries folders before running the option-binding tool.

# Example

Run this tool with the following command line parameters

option-binding --input "C:\Users\Ben\Downloads\echarts-website\en\documents\option.json" --output "D:\Dev\VizorECharts\src\Vizor.ECharts"

typeinfo --input "C:\Users\Ben\Downloads\echarts-website\en\documents\option.json"