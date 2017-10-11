using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Contacts;
using System;

namespace PsychologicalServices.Models.Arbitrations
{
    public class Arbitration
    {
        public int ArbitrationId { get; set; }

        public Assessment Assessment { get; set; }

        public string Title { get; set; }

        public DateTimeOffset StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? AvailableDate { get; set; }

        public Contact DefenseLawyer { get; set; }

        public string DefenseFileNumber { get; set; }
    }
}
