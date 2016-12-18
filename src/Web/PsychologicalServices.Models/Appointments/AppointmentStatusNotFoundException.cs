using System;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentStatusNotFoundException : Exception
    {
        private const string MessageFormat = "Appointment status {0} was not found";

        public AppointmentStatusNotFoundException(int appointmentStatusId)
            : base(string.Format(MessageFormat, appointmentStatusId))
        {
        }
    }
}
