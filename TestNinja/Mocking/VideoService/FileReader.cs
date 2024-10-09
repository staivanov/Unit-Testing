using Newtonsoft.Json;
using System.IO;

namespace TestNinja.Mocking
{
    public class FileReader : IFileReader
    {
        public FileReader()
        {
        }

        public string Read(string path)
        {
            return File.ReadAllText(path);
        }
    }
}
