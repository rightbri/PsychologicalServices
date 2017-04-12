using System;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public interface IFileReader
    {
        byte[] ReadBytes(string path);
    }
}
