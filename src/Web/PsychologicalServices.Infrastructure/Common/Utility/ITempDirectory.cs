using System;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public interface ITempDirectory : IDisposable
    {
        string FullPath { get; }
    }
}
