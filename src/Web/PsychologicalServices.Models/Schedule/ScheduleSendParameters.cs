using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Schedule
{
    public class ScheduleSendParameters
    {
        public ScheduleSearchCriteria Criteria { get; set; }

        public IEnumerable<string> Recipients { get; set; }

        public IEnumerable<string> CourtesyCopy { get; set; }

        public IEnumerable<string> BlindCourtesyCopy { get; set; }
    }
}
