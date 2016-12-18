using System;

namespace PsychologicalServices.Models.Common.Utility
{
    public class Now : INow
    {
        public DateTime DateTimeNow
        {
            get { return DateTime.Now; }
        }
    }
}
