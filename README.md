# Vizor.ECharts

Blazor wrapper for [Apache ECharts](https://echarts.apache.org/en/index.html).

 - Supports .NET >= 6.0
 - Ships with echarts 5.4.3
 
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
			Trigger = TooltipTrigger.Item
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
				Radius = new PieRadius("50%"),
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

## Async data loading
TODO

## Remote data loading
TODO

## Javascript functions
TODO