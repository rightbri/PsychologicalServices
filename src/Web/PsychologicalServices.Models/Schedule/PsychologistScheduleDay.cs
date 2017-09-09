using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Schedule
{
    public class PsychologistScheduleDay
    {
        public DateTimeOffset Day { get; set; }

        public IEnumerable<Appointments.Appointment> Appointments { get; set; }

        public IEnumerable<Arbitrations.Arbitration> ArbitrationsStarting { get; set; }

        public IEnumerable<Arbitrations.Arbitration> ArbitrationsDateGiven { get; set; }

        public IEnumerable<CalendarNotes.CalendarNote> CalendarNotes { get; set; }

        public IEnumerable<Users.User> UnavailableUsers { get; set; }
    }
}
