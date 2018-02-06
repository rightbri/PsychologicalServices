using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Contacts;
using PsychologicalServices.Models.Notes;
using System;

namespace PsychologicalServices.Models.Arbitrations
{
    public class Arbitration
    {
        public int ArbitrationId { get; set; }

        public Claimant Claimant { get; set; }

        public string Title { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? AvailableDate { get; set; }

        public DateTimeOffset? NotifiedDate { get; set; }

        public DateTimeOffset? LetterOfUnderstandingSentDate { get; set; }

        public Contact DefenseLawyer { get; set; }

        public string DefenseFileNumber { get; set; }

        public Contact PlaintiffLawyer { get; set; }

        public Note Note { get; set; }
    }
}
