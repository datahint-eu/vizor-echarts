using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace Vizor.ECharts.Tests.TestFixtures;

internal static class SnapshotHelper
{
    private static readonly JsonSerializerOptions NormalizeOptions = new()
    {
        WriteIndented = true
    };

    public static void AssertJsonSnapshot(
        object actual,
        string testClassName,
        string testMethodName,
        JsonSerializerOptions serializerOptions,
        bool skipNormalization = false,
        [CallerFilePath] string filePath = "")
    {
        string actualJson = JsonSerializer.Serialize(actual, serializerOptions);
        string normalizedActual = skipNormalization ? actualJson : NormalizeJson(actualJson);

        string snapshotDir = Path.Combine(
            Path.GetDirectoryName(filePath)!,
            "__snapshots__",
            testClassName);
        Directory.CreateDirectory(snapshotDir);

        string snapshotPath = Path.Combine(snapshotDir, $"{testMethodName}.json");
        bool shouldUpdate = Environment.GetEnvironmentVariable("UPDATE_SNAPSHOTS") == "true";

        if (!File.Exists(snapshotPath) || shouldUpdate)
        {
            File.WriteAllText(snapshotPath, normalizedActual, Encoding.UTF8);
            if (shouldUpdate)
            {
                Assert.Inconclusive("Snapshot updated.");
            }
            return;
        }

        string expected = File.ReadAllText(snapshotPath);
        Assert.AreEqual(expected, normalizedActual, "Snapshot mismatch");
    }

    private static string NormalizeJson(string json)
    {
        using var doc = JsonDocument.Parse(json);
        return JsonSerializer.Serialize(doc.RootElement, NormalizeOptions);
    }
}
