using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Schedule
{
    public class WeekScheduleModel
    {
        private List<DateTime> _days = null;

        public Company Company { get; set; }

        public DateTime WeekStart { get; set; }

        public DateTime WeekEnd { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public string DisplayTimezoneId { get; set; }

        public ITimezoneService TimezoneService { get; set; }

        public IEnumerable<DateTime> Days
        {
            get
            {
                if (null == _days)
                {
                    _days = new List<DateTime>();

                    var day = WeekStart;

                    while (day <= WeekEnd)
                    {
                        _days.Add(day);

                        day = day.AddDays(1);
                    }
                }

                return _days;
            }
        }
    }
}
