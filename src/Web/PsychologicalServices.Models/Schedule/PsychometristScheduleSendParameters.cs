using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychometristScheduleSendParameters
    {
        public PsychometristScheduleSearchCriteria Criteria { get; set; }

        public IEnumerable<string> Recipients { get; set; }

        public IEnumerable<string> CourtesyCopy { get; set; }

        public IEnumerable<string> BlindCourtesyCopy { get; set; }
    }
}
