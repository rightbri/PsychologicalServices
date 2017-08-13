using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public interface IDate
    {
        DateTime Today { get; }

        DateTimeOffset UtcNow { get; }
    }
}
