using System.Text.Json;
using System.IO;

namespace WinFormsApp2;

public static class JSONHelper
{
    public static void SaveToFile<T>(string filePath, T data)
    {
        var json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(filePath, json);
    }

    public static T LoadFromFile<T>(string filePath)
    {
        if (!File.Exists(filePath))
            return default;

        var json = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(json);
    }
}