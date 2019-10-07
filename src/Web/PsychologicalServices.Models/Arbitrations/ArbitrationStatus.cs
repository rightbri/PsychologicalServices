using System;

namespace PsychologicalServices.Models.Arbitrations
{
    public class ArbitrationStatus
    {
        public int ArbitrationStatusId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool ShowOnCalendar { get; set; }

        public bool ShowOnSchedule { get; set; }
    }
}
