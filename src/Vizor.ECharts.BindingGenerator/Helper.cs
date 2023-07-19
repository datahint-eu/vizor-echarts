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
