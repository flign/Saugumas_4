using System;
using System.IO;

namespace Saugumas_4
{
    class FileManager
    {
        static FileManager()
        {
            string path = Naming.Directory;
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        public void CreateFile(string path)
        {
            if (File.Exists(path))
                throw new Exception("Toks vardas jau egzistuoja");

            File.Create(path);
        }

        public void WriteAFile(string path, string data)
        {
            File.WriteAllText(path, data);
        }

        public string[] ReadFile(string path)
        {
            if (!File.Exists(path))
                throw new Exception("Toks failas/vardas neegzistuoja");

            string[] lines = File.ReadAllLines(path);
            return lines;
        }
    }
}
