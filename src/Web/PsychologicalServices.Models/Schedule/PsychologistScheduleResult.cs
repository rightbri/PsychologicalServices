using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychologistScheduleResult
    {
        public User Psychologist { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public byte[] Content { get; set; }
    }
}
