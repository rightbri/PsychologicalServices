using System;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychologistScheduleParameters
    {
        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int PsychologistId { get; set; }
    }
}
