using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychologistScheduleWeek
    {
        public IEnumerable<PsychologistScheduleDay> Days { get; set; }
    }
}
