using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Arbitrations;
using PsychologicalServices.Models.CalendarNotes;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychologistScheduleModel
    {
        private List<DateTimeOffset> _days = null;

        public User Psychologist { get; set; }

        public DateTimeOffset FromDate { get; set; }

        public DateTimeOffset ToDate { get; set; }

        public IEnumerable<Appointment> Appointments { get; set; }

        public IEnumerable<Arbitration> Arbitrations { get; set; }

        public IEnumerable<CalendarNote> CalendarNotes { get; set; }

        public IEnumerable<User> UsersWithUnavailability { get; set; }

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
                        Week = calendar.GetWeekOfYear(day.Date, System.Globalization.CalendarWeekRule.FirstFullWeek, DayOfWeek.Sunday),
                        Day = day
                    })
                    .GroupBy(keySelector => keySelector.Week)
                    .Select(grouping => new PsychologistScheduleWeek
                        {
                            Days =
                                grouping.Where(item =>
                                    item.Day.DayOfWeek >= DayOfWeek.Monday &&
                                    item.Day.DayOfWeek <= DayOfWeek.Friday
                                )
                                .Select(item => GetPsychologistScheduleDay(item.Day)),
                        })
                    .Where(week => week.Days.Any(day => !day.IsEmpty));
            }
        }

        public IEnumerable<DateTimeOffset> Days
        {
            get
            {
                if (null == _days)
                {
                    _days = new List<DateTimeOffset>();
                    
                    var day = FromDate.StartOfDay(DisplayTimezoneId);

                    while (day <= ToDate)
                    {
                        _days.Add(day);

                        day = day.AddDays(1);
                    }
                }

                return _days;
            }
        }

        public PsychologistScheduleDay GetPsychologistScheduleDay(DateTimeOffset day)
        {
            var appointments = Appointments
                                    .Where(app =>
                                        app.AppointmentTime.IsWithin(day.StartOfDay(DisplayTimezoneId), day.EndOfDay(DisplayTimezoneId)) &&
                                        app.Assessment.AssessmentType.ShowOnSchedule
                                    );

            var arbitrationsStarting = Arbitrations.Where(arbitration => arbitration.StartDate.IsWithin(day.StartOfDay(DisplayTimezoneId), day.EndOfDay(DisplayTimezoneId)));

            var arbitrationsDateGiven = Arbitrations.Where(arbitration => arbitration.AvailableDate.HasValue && arbitration.AvailableDate.Value.IsWithin(day.StartOfDay(DisplayTimezoneId), day.EndOfDay(DisplayTimezoneId)));

            var calendarNotes = CalendarNotes.Where(calendarNote => calendarNote.AppliesToDay(day));

            var unavailableUsers = UsersWithUnavailability.Where(user => user.Unavailability.Any(unavailability => unavailability.StartDate.IsWithin(day.StartOfDay(DisplayTimezoneId), day.EndOfDay(DisplayTimezoneId))));

            return new PsychologistScheduleDay
            {
                Day = day,
                Appointments = appointments.OrderBy(appointment => appointment.AppointmentTime),
                ArbitrationsStarting = arbitrationsStarting.OrderBy(arbitration => arbitration.StartDate),
                ArbitrationsDateGiven = arbitrationsDateGiven.OrderBy(arbitration => arbitration.AvailableDate),
                CalendarNotes = calendarNotes.OrderBy(calendarNote => calendarNote.FromDate).ThenBy(calendarNote => calendarNote.ToDate),
                UnavailableUsers = unavailableUsers.OrderBy(user => user.FirstName),
            };
        }
    }
}
