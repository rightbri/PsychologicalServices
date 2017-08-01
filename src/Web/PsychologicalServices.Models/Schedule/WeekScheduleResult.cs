using PsychologicalServices.Models.Companies;
using System;

namespace PsychologicalServices.Models.Schedule
{
    public class WeekScheduleResult
    {
        public Company Company { get; set; }

        public DateTime WeekStart { get; set; }

        public DateTime WeekEnd { get; set; }

        public byte[] Content { get; set; }
    }
}
