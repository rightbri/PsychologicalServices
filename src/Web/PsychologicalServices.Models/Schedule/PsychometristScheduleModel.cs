using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychometristScheduleModel
    {
        public User User { get; set; }

        public string DisplayTimezoneId { get; set; }

        public ITimezoneService TimezoneService { get; set; }
    }
}
