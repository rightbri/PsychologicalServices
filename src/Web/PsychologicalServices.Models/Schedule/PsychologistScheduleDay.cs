using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool IsEmpty
        {
            get
            {
                return !(
                    Appointments.Any() ||
                    ArbitrationsStarting.Any() ||
                    ArbitrationsDateGiven.Any() ||
                    CalendarNotes.Any() ||
                    UnavailableUsers.Any()
                );
            }
        }
    }
}
