using System.Collections;

namespace Vizor.ECharts;

public class FunctionMap : IEnumerable<IFunction>
{
    private readonly List<IFunction> functions = new();

    public FunctionMap(IEnumerable<IFunction> functions)
    {
        this.functions.AddRange(functions);
    }

    public FunctionMap(params IFunction[] functions)
    {
        this.functions.AddRange(functions);
    }

    public void Add(IFunction function)
    {
        functions.Add(function);
    }

    public void AddJavascriptFunction(Guid functionId, string jsFunction)
    {
        var function = new JavascriptFunction(functionId, jsFunction);
        functions.Add(function);
    }

    public string MapFunctions(string json)
    {
        foreach (var function in functions)
        {
            json = function.MapFunction(json);
        }

        return json;
    }

    public IEnumerator<IFunction> GetEnumerator() => functions.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => functions.GetEnumerator();
}

public interface IFunction
{
    string MapFunction(string json);
}

public class JavascriptFunction : IFunction
{
    private readonly string search;
    private readonly string jsFunction;

    public JavascriptFunction(Guid functionId, string jsFunction)
    {
        search = '"' + functionId.ToString() + '"';
        this.jsFunction = jsFunction;
    }

    public string MapFunction(string json)
    {
        var index = json.IndexOf(search);

        if (index < 0)
            return json;

        return json[0..index] + jsFunction + json[(index + search.Length)..];
    }
}