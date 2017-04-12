using System;
using System.IO;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class FileWriter : IFileWriter
    {
        public void WriteText(string text, string path)
        {
            File.WriteAllText(path, text);
        }

        public void WriteBytes(byte[] bytes, string path)
        {
            File.WriteAllBytes(path, bytes);
        }
    }
}
