using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public interface IDate
    {
        DateTime Today { get; }
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
