using System;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentSequence
    {
        public const int First = 1;
        public const int Subsequent = 2;

        public int AppointmentSequenceId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
