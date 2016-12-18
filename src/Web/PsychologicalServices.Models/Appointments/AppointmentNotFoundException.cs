using System;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentNotFoundException : Exception
    {
        private const string MessageFormat = "Appointment {0} was not found";

        public AppointmentNotFoundException(int appointmentId)
            : base(string.Format(MessageFormat, appointmentId))
        {
        }
    }
}
