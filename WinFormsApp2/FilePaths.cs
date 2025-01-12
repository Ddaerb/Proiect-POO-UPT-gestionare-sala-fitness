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
        public static readonly string JSONFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\JSONFiles");

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
