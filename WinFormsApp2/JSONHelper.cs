using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace WinFormsApp2
{
    public static class JSONHelper
    {
        public static void SaveToFile<T>(string filePath, T data)
        {
            try
            {
                // Serializam datele in format JSON si le scriem in fisier

                var json = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving to file: {ex.Message}");
            }
        }

        public static T LoadFromFile<T>(string filePath)
        {
            try
            {
                // Daca fisierul nu exista, returnam valoarea default

                if (!File.Exists(filePath))
                    return default;

                // Citim datele din fisier si le deserializam

                var json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading from file: {ex.Message}");
                return default;
            }
        }
    }
}
