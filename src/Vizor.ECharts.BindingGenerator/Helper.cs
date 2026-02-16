using System.Text;
using System.Text.Json;

namespace Vizor.ECharts.BindingGenerator;

internal static class Helper
{
    public static string ToClassName(this string input)
    {
        string[] words = input.Split(new char[] { '-', '_', ' ' }, StringSplitOptions.RemoveEmptyEntries);
        var sb = new StringBuilder();

        foreach (string word in words)
        {
            sb.Append(char.ToUpper(word[0]));
            if (word.Length > 1)
                sb.Append(word[1..]);
        }

        return sb.ToString();
    }

    /// <summary>
    /// Singularize a plural property name for use as a type name in array items.
    /// For example: "links" -> "link", "levels" -> "level", "items" -> "item"
    /// Special cases: "series" stays "series" (singular and plural are the same)
    /// </summary>
    public static string Singularize(this string input)
    {
        if (string.IsNullOrEmpty(input))
            return input;

        // Special cases where singular and plural are the same
        if (input.Equals("series", StringComparison.OrdinalIgnoreCase))
            return input;

        // Common plural forms
        if (input.EndsWith("ies", StringComparison.OrdinalIgnoreCase))
            return input[..^3] + "y";
        if (input.EndsWith("ves", StringComparison.OrdinalIgnoreCase))
            return input[..^3] + "f";
        if (input.EndsWith("xes", StringComparison.OrdinalIgnoreCase) || 
            input.EndsWith("zes", StringComparison.OrdinalIgnoreCase) ||
            input.EndsWith("ches", StringComparison.OrdinalIgnoreCase) ||
            input.EndsWith("shes", StringComparison.OrdinalIgnoreCase))
            return input[..^2];
        if (input.EndsWith("es", StringComparison.OrdinalIgnoreCase))
            return input[..^2];
        if (input.EndsWith("s", StringComparison.OrdinalIgnoreCase) && !input.EndsWith("ss", StringComparison.OrdinalIgnoreCase))
            return input[..^1];

        return input;
    }

    public static List<string> ParsePropertyTypes(JsonElement value)
    {
        List<string> types = new();

        if (value.ValueKind == JsonValueKind.Array)
        {
            foreach (var child in value.EnumerateArray())
            {
                if (child.ValueKind != JsonValueKind.String)
                    throw new ArgumentException($"JSON type array element must be of type string: '{value.ValueKind}'");

                var str = child.GetString();
                if (!string.IsNullOrEmpty(str))
                    types.Add(str.ToLower());
            }
        }
        else if (value.ValueKind == JsonValueKind.String)
        {
            var str = value.GetString();
            if (!string.IsNullOrEmpty(str))
                types.Add(str.ToLower());
        }
        else
        {
            throw new ArgumentException($"JSON type element must be of type string or array: '{value.ValueKind}'");
        }

        return types;
    }
}
