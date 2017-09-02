using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychologistScheduleWeek
    {
        public IEnumerable<DateTimeOffset> Days { get; set; }
    }
}
