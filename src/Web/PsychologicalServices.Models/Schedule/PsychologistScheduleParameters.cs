using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychologistScheduleParameters
    {
        public DateTimeOffset FromDate { get; set; }

        public DateTimeOffset ToDate { get; set; }

        public int PsychologistId { get; set; }

        public IEnumerable<int> AppointmentStatusIds { get; set; }
    }
}
