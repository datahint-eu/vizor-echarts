using CommandLine.Text;
using CommandLine;

namespace Vizor.ECharts.BindingGenerator;

[Verb("typeinfo", HelpText = "Analyze type information")]
internal class GenerateTypeInfoOptions
{
	[Option(longName: "input", Required = true, HelpText = "Specify the input option.json file")]
	public string InputFile { get; set; } = default!;
}
