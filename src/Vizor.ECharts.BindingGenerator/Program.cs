using CommandLine;
using Vizor.ECharts.BindingGenerator;

try
{
	Parser.Default.ParseArguments<GenerateOptionBindingOptions, GenerateTypeInfoOptions>(args)
		.MapResult(
			(GenerateOptionBindingOptions opts) => new GenerateOptionBindingTool().Run(opts),
			(GenerateTypeInfoOptions opts) => new GenerateTypeInfoTool().Run(opts),
			errs => HandleParseError(errs)
		);
}
catch (Exception ex)
{
	Console.WriteLine(ex.Message);
	Console.WriteLine(ex.StackTrace);
}

static int HandleParseError(IEnumerable<Error> errs)
{
	foreach (Error err in errs)
	{
		if (err is HelpRequestedError || err is NoVerbSelectedError || err is HelpVerbRequestedError)
			continue;

		Console.Error.WriteLine(err);
	}

	return 1;
}