using System;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentProtocolResponseValue
    {
        public int AppointmentProtocolResponseValueId { get; set; }

        public string Value { get; set; }

        public bool IsActive { get; set; }
    }
}
