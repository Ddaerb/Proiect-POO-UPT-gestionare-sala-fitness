using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinFormsApp2
{
    public static class FilePaths
    {
        // Folderul in care se vor salva fisierele JSON
        public static readonly string JSONFolder = Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory,
            "..\\..\\..\\JSONFiles");


        // Metoda care returneaza calea completa a unui fisier JSON
        public static string GetFilePath(string fileName)
        {
            if (!Directory.Exists(JSONFolder))
            {
                Directory.CreateDirectory(JSONFolder);
            }
            return Path.Combine(JSONFolder, fileName);
        }
    }
}
