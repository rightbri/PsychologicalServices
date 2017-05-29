using System;

namespace PsychologicalServices.Infrastructure.Common.Utility
{
    public interface ITempDirectoryFactory
    {
        ITempDirectory Create();
    }
}
