# Vizor.ECharts

Blazor wrapper for [Apache ECharts](https://echarts.apache.org/en/index.html).

 - Supports .NET >= 6.0
 - Ships with echarts 5.4.3
 - `Apache-2.0` Licensed (same as echarts)
 - Lots of examples in the `Vizor.ECharts.Demo` project
 - Refer to the official echarts [cheat sheet](https://echarts.apache.org/en/cheat-sheet.html) for a quick introduction
 
The project currently is not yet production ready, it will be around September/October.
Small API changes will occur frequently until version >= 1.0.0 .
 
## How to include

1. Add a package reference to `Vizor.ECharts`
2. Add the following script to your `_Host.cshtml` file
```
<script src="_content/Vizor.ECharts/js/vizor-echarts-min.js"></script>
```
See the [example](https://github.com/datahint-eu/vizor-echarts/blob/main/src/Vizor.ECharts.Demo/Pages/_Host.cshtml) from the demo application.

## How to use

The bindings are nearly identical to the javascript/typescript version.
This makes it very easy to translate the examples from the official documentation to C#.

For example: [a simple pie chart](https://echarts.apache.org/examples/en/editor.html?c=pie-simple).

Add a using statement:
```
@using Vizor.ECharts;
```

Chart component in your .razor file:
```
<Vizor.ECharts.EChart Options="@options" Width="800px" Height="800px" />
```

Chart options in the code section of your razor file:
```
private ChartOptions options = new()
{
	Title = new()
	{
		Text = "Referer of a Website",
		Subtext = "Fake Data",
		Left = "center"
	},
	Tooltip = new()
	{
		Trigger = ECharts.TooltipTrigger.Item
	},
	Legend = new()
	{
		Orient = Orient.Vertical,
		Left = "left"
	},
	Series = new()
	{
		new PieSeries()
		{
			Name = "Access From",
			Radius = new CircleRadius("50%"),
			Data = new List<PieSeriesData>()
			{
				new() { Value = 1048, Name = "Search Engine" },
				new() { Value = 735, Name = "Direct" },
				new() { Value = 580, Name = "Email" },
				new() { Value = 484, Name = "Union Ads" },
				new() { Value = 300, Name = "Video Ads" },
			},
			Emphasis = new()
			{
				ItemStyle = new()
				{
					ShadowBlur = 10,
					ShadowOffsetX = 0,
					ShadowColor = Color.FromRGBA(0, 0, 0, 0.5)
				}
			}
		}
	}
};
```

See the [full C# code](https://github.com/datahint-eu/vizor-echarts/blob/main/src/Vizor.ECharts.Demo/Areas/Pie/PieSimple.razor).

## Data loading

Most examples that you will find online have very basic datasets.
However, in real life, data sets are often huge and come from various different sources.

Vizor.ECharts allows you to define data in 3 different ways:
1. Inside the ChartOptions, as demonstrated in most samples
2. Using async data sources in C#, allowing you to fetch data directly from the database
3. Using remote data sources (e.g.: REST API) fetched by the browser

### Async data loading

Specify the DataLoader parameter, this can be a sync or async function.
```
<Vizor.ECharts.EChart Options="@options" DataLoader="@LoadChartData" Width="800px" Height="800px" />
```

Typically in the data loader function you update the Series property. However, you can update any chart option.
```
private async Task LoadChartData()
{
	options.Series = ... ;
}
```

See [full example](https://github.com/datahint-eu/vizor-echarts/blob/main/src/Vizor.ECharts.Demo/Areas/Misc/DataLoaderSample.razor).

### Remote data loading

Any `Data` property of type `object?` accepts a `ExternalDataSource` allowing you to specify the external data source.

```
Data = new ExternalDataSource("https://example.com/api/data/sunburst_simple.json")
```
See [full example](https://github.com/datahint-eu/vizor-echarts/blob/main/src/Vizor.ECharts.Demo/Areas/Sunburst/SunburstSimple.razor).

It is also possible to provide a *simple* path expression to retrieve only a part of the external data:
```
Data = new ExternalDataSource("https://example.com/api/data/sankey_simple.json") { Path = "nodes" }
```

Additional credentials, headers, policies, ... can also be supplied.
See [ExternalDataSource class](https://github.com/datahint-eu/vizor-echarts/blob/main/src/Vizor.ECharts/Types/ExternalDataSource.cs) for more details.


## Javascript functions

ECharts sometimes allows you to assign custom functions instead of values.
This can be achieved with the `JavascriptFunction` class.
The class accepts a raw Javascript function that is evaluated in the browser.

For example:
```
Formatter = new JavascriptFunction("function (param) { return param.name + ' (' + param.percent * 2 + '%)'; }")
```

See [full example](https://github.com/datahint-eu/vizor-echarts/blob/main/src/Vizor.ECharts.Demo/Areas/Pie/PieHalfDoughnut.razor).

## Javascript function calls

Sometimes you want to calculate data dynamically in Javascript.
This can be done with the `JavascriptFunctionCall` class.
You can assign this to any chart option property accepting an `object`.

For example:
```
Data = new JavascriptFunctionCall(@"
	function getData() {
		const data = [[0, 0, 5], ..., [6, 23, 6]];
		return data.map(function (item) {
			return [item[1], item[0], item[2] || '-'];
		});
	}
")
```

## Updating charts

Chart options and/or data can be updated. For example: to show a never ending line chart, a temperature gauge, ... .

First store a reference to your chart.
```
<Vizor.ECharts.EChart @ref="chart" Options="@options" Width="800px" Height="800px" />
...
private Vizor.ECharts.EChart? chart;
```

Next modify the chart options.
Modified options have full support for Javascript functions and external data sources.
```
private async Task UpdateChartAsync()
{
	if (chart == null)
		return;

	// modify chart options
	
	await chart.UpdateAsync();
}
```

See [full example](https://github.com/datahint-eu/vizor-echarts/blob/main/src/Vizor.ECharts.Demo/Areas/Gauge/TempGauge.razor).


# Filing Bugs / Future Development

See [Issues](https://github.com/datahint-eu/vizor-echarts/issues) for a list of open tasks/bugs.

Please provide a runnable sample using the [ECharts Online Editor](https://echarts.apache.org/examples/en/editor.html) and a description of what is wrong with the C# mapping.