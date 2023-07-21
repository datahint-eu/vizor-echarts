# Vizor.ECharts

Blazor wrapper for [Apache ECharts](https://echarts.apache.org/en/index.html).

 - Supports .NET >= 6.0
 - Ships with echarts 5.4.3
 - `Apache-2.0` Licensed (same as echarts)
 - Lots of examples in the `Vizor.ECharts.Demo` project
 
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
TODO

### Remote data loading

Any `Data` property of type `object?` accepts a `ExternalDataSource` allowing you to specify the external data source.

```
Data = new ExternalDataSource("https://example.com/api/data/sunburst/simple")
```
See [full example](https://github.com/datahint-eu/vizor-echarts/blob/main/src/Vizor.ECharts.Demo/Areas/Sunburst/SunburstSimple.razor).


Additional credentials, headers, policies, ... can also be supplied. *feature in development*


## Javascript functions

ECharts sometimes allows you to assign custom functions instead of values.
This can be achieved with the JavascriptFunction class.
The class accepts a raw Javascript function that is evaluated in the browser.

For example:
```
Formatter = new JavascriptFunction("function (param) { return param.name + ' (' + param.percent * 2 + '%)'; }")
```

See [full example](https://github.com/datahint-eu/vizor-echarts/blob/main/src/Vizor.ECharts.Demo/Areas/Pie/PieHalfDoughnut.razor).

# Filing Bugs

Please provide a runnable sample using the [ECharts Online Editor](https://echarts.apache.org/examples/en/editor.html) and a description of what is wrong with the C# mapping.