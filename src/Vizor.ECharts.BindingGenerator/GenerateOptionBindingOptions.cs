using CommandLine.Text;
using CommandLine;

namespace Vizor.ECharts.BindingGenerator;

[Verb("option-binding", HelpText = "Generate C# code based on Apache ECharts documentation")]
internal class GenerateOptionBindingOptions
{
	[Option(longName: "input", Required = true, HelpText = "Specify the input option.json file")]
	public string InputFile { get; set; } = default!;

	[Option(longName: "output", Required = true, HelpText = "Specify the directory where to generate the code")]
	public string OutputDirectory { get; set; } = default!;
}
