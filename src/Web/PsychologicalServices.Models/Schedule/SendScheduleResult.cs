using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.Schedule
{
    public class SendScheduleResult
    {
        public User User { get; set; }

        public bool Success { get; set; }

        public bool IsError { get; set; }

        public string ErrorDetails { get; set; }
    }
}
