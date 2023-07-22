# DotNet callback functions

For example:
```
[JSInvokable("FormatLabel")]
private string FormatLabel(dynamic item)
{
	return $"{item.Name} ({item.percent * 2}%)";
}
```

Challenges:
 - A lot of variations to support: instance <> static, `Task<T>` vs `T` vs `dynamic` return type
 - There are functions with multiple parameters: we need a way to detect this dynamically


# Chart data loaders

In real life, we might want to bind filters to charts, for example: to select the date range, select an interval, specify other filters, ... .
Data also tends to come from a database.
So we need a way to retrieve data in a very generic way, allowing the implementer full flexibility.

Proposed API:
```
// when using multiple data loaders
[Parameter]
public List<Task>? DataLoaders { get; set; }

// when only using 1 data loader
// if both DataLoader+DataLoaders are specified, DataLoader is executed first
[Parameter]
public Task? DataLoader { get; set; }
```

The task would be responsible to modify the ChartOptions in C#. After all data loaders are executed, the serialized ChartOptions are sent to JS.

# Smaller tasks

 - optimize the processObject function to not use recursive await's, instead: first list all replacements to be done and await what is needed
 - Allow updating charts using data binding (OnParameterSetAsync), demo with line -> bar transition
 - Sanitize the documentation (imported from the official docs using a script, not everything might be .NET relevant)
 - Review/rename some auto generated classes (e.g.: DataData, ...)
 - Fix all remaining TODO's left over by the initial auto generation script (mostly type mappings of combined types)
 - Fix rich/<style_name> serialization
 - Split XxxSeriesData additional properties into XxxSeriesDataOptions class ? --> less memory use for huge datasets
 - Split all demo charts into separate components, so we can show them more easily on the future documentation website
 - Packaging
 - More examples

# Other

- add this library to awesome-blazor + awesome-echarts
