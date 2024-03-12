using System.Linq;
using System.Text.Json.Nodes;

namespace GeoJsonSanitizer;

internal class Helper
{
	internal static void RemoveProperties(JsonNode? node)
	{
		if (node == null)
			return;

		if (node is JsonObject obj)
		{
			obj.Remove("ID_0");
			obj.Remove("NAME_0");
			obj.Remove("ID_1");
			obj.Remove("NAME_1");
			obj.Remove("ID_2");
			obj.Remove("NAME_2");
			obj.Remove("ID_3");
			obj.Remove("NAME_3");
			obj.Remove("ID_4");
			obj.Remove("NAME_4");
			obj.Remove("VARNAME_4");

			obj.Remove("ISO");
			obj.Remove("ENGTYPE_4");
			obj.Remove("TYPE_4");

			obj.Remove("NAME_2 - New");
			obj.Remove("NAME_3 - NEW");
			obj.Remove("NAME_4_NEW");

			foreach (var pair in obj)
			{
				RemoveProperties(pair.Value);
			}
		}
		else if (node is JsonArray array)
		{
			foreach (var item in array)
			{
				RemoveProperties(item);
			}
		}
	}
}
