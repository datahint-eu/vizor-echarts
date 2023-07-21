# Remarks

This tool was used to generate 80-90% of the initial binding.
It is good enough to generate the bulk of the bindings, but the last bits and pieces are hand tuned.
So in general, you should never have to run this tool again.

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