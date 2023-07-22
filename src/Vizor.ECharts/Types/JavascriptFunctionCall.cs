using System.Text.Json;
using System.Text.Json.Serialization;

namespace Vizor.ECharts;

[JsonConverter(typeof(JavascriptFunctionCallConverter))]
public class JavascriptFunctionCall
{
    public JavascriptFunctionCall(string function)
    {
        Function = function;
    }

    public string Function { get; }

    public static explicit operator JavascriptFunctionCall(string function)
    {
        return new JavascriptFunctionCall(function);
    }
}

public class JavascriptFunctionCallConverter : JsonConverter<JavascriptFunctionCall>
{
    private static readonly JavascriptFunctionCallConverter instance = new();

    public override JavascriptFunctionCall Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        throw new NotImplementedException("Deserialization is not implemented for JavascriptFunctionCall.");
    }

    public override void Write(Utf8JsonWriter writer, JavascriptFunctionCall value, JsonSerializerOptions options)
    {
        writer.WriteStartObject();
        writer.WriteString("type", "__vi-js-function-call");
        writer.WriteString("function", value.Function);
        writer.WriteEndObject();

        // see EChart SerializeOptions() why we need to do this
        SpecialObjectMapper.MarkUseJavascriptFunction(options);
    }

    public static JavascriptFunctionCallConverter Instance => instance;
}