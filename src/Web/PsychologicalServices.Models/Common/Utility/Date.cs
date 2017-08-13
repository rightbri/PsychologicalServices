using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public class Date : IDate
    {
        public DateTime Today
        {
            get { return DateTime.Today; }
        }

        public DateTimeOffset UtcNow
        {
            get { return DateTimeOffset.UtcNow; }
        }
    }
}
