using System;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public interface IFileWriter
    {
        void WriteText(string text, string path);

        void WriteBytes(byte[] bytes, string path);
    }
}
