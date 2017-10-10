using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Appointments
{
    public class AppointmentSequence
    {
        public const int First = 1;
        public const int Subsequent = 2;
        public const int Last = 3;

        private static IDictionary<int, string> _names = new Dictionary<int, string>()
        {
            { First, "First" },
            { Subsequent, "Subsequent" },
            { Last, "Last" },
        };
        
        public int AppointmentSequenceId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public static string GetName(int appointmentSequenceId)
        {
            if (!_names.ContainsKey(appointmentSequenceId))
            {
                throw new ArgumentOutOfRangeException("appointmentSequenceId");
            }

            return _names[appointmentSequenceId];
        }
    }
}
