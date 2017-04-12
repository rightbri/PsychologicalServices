using System;
using System.IO;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public class FileReader : IFileReader
    {
        public byte[] ReadBytes(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}
