using GeoJsonSanitizer;
using System.Text.Json.Nodes;

if (args.Length != 1)
{
	Console.WriteLine("Usage: GeoJsonSanitizer <inputFilePath>");
	return -1;
}

string inputFilePath = args[0];
if (!File.Exists(inputFilePath))
{
	Console.WriteLine("ERROR: Input file does not exist.");
	return -1;
}

try
{
	string jsonContent = File.ReadAllText(inputFilePath);
	var root = JsonNode.Parse(jsonContent);

	Helper.RemoveProperties(root);

	string modifiedJson = root.ToJsonString();
	File.WriteAllText(inputFilePath + ".new", modifiedJson);

	Console.WriteLine("Properties removed successfully.");
	return 0;
}
catch (Exception ex)
{
	Console.WriteLine("ERROR: " + ex.Message);
	return -1;
}