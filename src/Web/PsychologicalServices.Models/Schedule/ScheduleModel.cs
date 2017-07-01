using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.Schedule
{
    public class ScheduleModel
    {
        public User User { get; set; }

        public string DisplayTimezoneId { get; set; }
    }
}
