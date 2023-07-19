using System.Net;
using System.Text;
using HtmlAgilityPack;
using Microsoft.Extensions.Primitives;

namespace Vizor.ECharts.BindingGenerator.Generators;

internal sealed class CSharpCodeWriter : IDisposable
{
	private readonly StreamWriter writer;

	private int indentLevel = 0;
	private bool currentLineIsIndented = false;

	private readonly int indentCharCount = 1;
	private readonly char indentChar = '\t';

	internal CSharpCodeWriter(string filename)
	{
		// check if the output directory exists
		var dir = Path.GetDirectoryName(filename);
		if (!string.IsNullOrEmpty(dir) && !Directory.Exists(dir))
			Directory.CreateDirectory(dir);

		writer = new StreamWriter(filename);
		Filename = filename;
	}

	public string Filename { get; }

	public void WriteNotice()
	{
		writer.WriteLine("// AUTO GENERATED - DO NOT EDIT - All changes will be lost");
		writer.WriteLine("// http://www.datahint.eu/");
		writer.WriteLine();
	}

	public void WriteNamespace(string ns)
	{
		writer.WriteLine($"namespace {ns};");
	}

	public void WriteUsing(string ns)
	{
		writer.WriteLine($"using {ns};");
	}

	public void WriteGlobalUsing(string ns)
	{
		writer.WriteLine($"global using {ns};");
	}

	public void EmptyLine()
	{
		writer.WriteLine();
		currentLineIsIndented = false;
	}

	public void WriteLine(string line)
	{
		if (indentLevel > 0 && !currentLineIsIndented)
		{
			writer.Write(new string(indentChar, indentLevel * indentCharCount));
		}

		writer.WriteLine(line);
		currentLineIsIndented = false;
	}

	public void Write(string str)
	{
		if (indentLevel > 0 && !currentLineIsIndented)
		{
			writer.Write(new string(indentChar, indentLevel * indentCharCount));
			currentLineIsIndented = true;
		}

		writer.Write(str);
	}

	public void IndentMore()
	{
		++indentLevel;
	}

	public void IndentLess()
	{
		--indentLevel;
		if (indentLevel < 0)
			throw new InvalidOperationException("Indent mismatch");
	}

	public void Dispose()
	{
		writer.Dispose();
		GC.SuppressFinalize(this);
	}

	public void OpenBrace()
	{
		WriteLine("{");
		IndentMore();
	}

	public void CloseBrace()
	{
		IndentLess();
		WriteLine("}");
	}

	public void WriteClassDeclaration(string className, params string[] baseNames)
	{
		if (baseNames == null || baseNames.Length == 0)
		{
			writer.WriteLine($"public partial class {className}");
		}
		else
		{
			var inheritFrom = string.Join(", ", baseNames);
			writer.WriteLine($"public partial class {className} : {inheritFrom}");
		}
	}

	public void WriteInterfaceDeclaration(string className, params string[] baseNames)
	{
		if (baseNames == null || baseNames.Length == 0)
		{
			writer.WriteLine($"public partial interface {className}");
		}
		else
		{
			var inheritFrom = string.Join(", ", baseNames);
			writer.WriteLine($"public partial interface {className} : {inheritFrom}");
		}
	}

	public void WriteIfBlock(string expr, params string[] statements)
	{
		WriteLine($"if ({expr}) {{");
		IndentMore();

		foreach (var stm in statements)
			WriteLine(stm);

		CloseBrace();
	}

	public void WriteConstString(string propertyName, string value)
	{
		var escaped = value.Replace("\"", "\\\"");
		WriteLine($"public const string {propertyName} = \"{escaped}\";");
	}

	public void WriteDocumentation(string? summary)
	{
		if (summary == null)
			return;

		var humanReadable = GetHumanReadableText(summary);
		if (humanReadable == null)
			return;

		WriteLine("/// <summary>");

		foreach (var line in humanReadable)
			WriteLine($"/// {line}");

		WriteLine("/// </summary>");
	}

	private static string[] GetHumanReadableText(string summary)
	{
		var doc = new HtmlDocument();
		doc.LoadHtml(summary);

		var sb = new StringBuilder();
		GetHumanReadableText(sb, doc.DocumentNode);

		// trim newlines at the end
		// break long lines on each . (only when followed by a space)
		return sb.ToString().Trim().Replace(". ", ".\n").Split('\n');
	}

	private static void GetHumanReadableText(StringBuilder sb, HtmlNode node)
	{
		if (node is HtmlTextNode textNode)
		{
			sb.Append(WebUtility.HtmlDecode(textNode.InnerText.Trim()));
			sb.Append(' ');
			return;
		}

		if (node is HtmlCommentNode)
		{
			return;
		}

		if (node.Name == "p")
		{
			sb.Append('\n');
		}
		else if (node.Name == "code")
		{
			sb.Append(WebUtility.HtmlDecode(node.InnerText.Trim()));
			sb.Append(' ');
			return;
		}
		else if (node.Name == "br")
		{
			sb.Append('\n');
			return;
		}

		foreach (var child in node.ChildNodes)
		{
			GetHumanReadableText(sb, child);
		}
	}
}
