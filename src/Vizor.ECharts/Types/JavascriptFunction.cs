using System.Text.Json;
using System.Text.Json.Serialization;
using Vizor.ECharts.Internal;

namespace Vizor.ECharts;

[JsonConverter(typeof(JavascriptFunctionConverter))]
public class JavascriptFunction
{
    public JavascriptFunction(string function)
    {
        Function = function;
    }

    public string Function { get; }

    public static explicit operator JavascriptFunction(string function)
    {
        return new JavascriptFunction(function);
    }

    /// <summary>
    /// Implicit conversion from JavascriptFunction to string for property assignments.
    /// Returns the raw JavaScript function code.
    /// </summary>
    public static implicit operator string(JavascriptFunction jsFunc)
    {
        return jsFunc?.Function ?? "";
    }
}

public class JavascriptFunctionConverter : JsonConverter<JavascriptFunction>
{
    private static readonly JavascriptFunctionConverter instance = new();

    public override JavascriptFunction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for JavascriptFunction.");
    }

    public override void Write(Utf8JsonWriter writer, JavascriptFunction value, JsonSerializerOptions options)
    {
        writer.WriteRawValue(value.Function, skipInputValidation: true);
    }

    public static JavascriptFunctionConverter Instance => instance;
}