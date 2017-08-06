using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychologistScheduleModel
    {
        private List<DateTime> _days = null;

        public User Psychologist { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public string DisplayTimezoneId { get; set; }

        public ITimezoneService TimezoneService { get; set; }

        public IEnumerable<PsychologistScheduleWeek> Weeks
        {
            get
            {
                var calendar = System.Globalization.CultureInfo.CurrentCulture.Calendar;

                return Days
                    .Select(day => new
                    {
                        Week = calendar.GetWeekOfYear(day, System.Globalization.CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday),
                        Day = day
                    })
                    .GroupBy(keySelector => keySelector.Week)
                    .Select(grouping =>
                        new PsychologistScheduleWeek
                        {
                            Days =
                            grouping.Where(item =>
                                item.Day.DayOfWeek >= DayOfWeek.Monday &&
                                item.Day.DayOfWeek <= DayOfWeek.Friday
                            )
                            .Select(item => item.Day)
                        }
                    );
            }
        }

        public IEnumerable<DateTime> Days
        {
            get
            {
                if (null == _days)
                {
                    _days = new List<DateTime>();

                    var day = FromDate;

                    while (day <= ToDate)
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
