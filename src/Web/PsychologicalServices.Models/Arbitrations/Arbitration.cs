using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Contacts;
using PsychologicalServices.Models.Notes;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Arbitrations
{
    public class Arbitration
    {
        public int ArbitrationId { get; set; }

        public Claimant Claimant { get; set; }

        public IEnumerable<Claim> Claims { get; set; }

        public string Title { get; set; }

        public DateTimeOffset? StartDate { get; set; }

        public DateTimeOffset? EndDate { get; set; }

        public DateTimeOffset? AvailableDate { get; set; }

        public DateTimeOffset? NotifiedDate { get; set; }

        public DateTimeOffset? LetterOfUnderstandingSentDate { get; set; }

        public Contact DefenseLawyer { get; set; }

        public string DefenseFileNumber { get; set; }

        public Contact PlaintiffLawyer { get; set; }

        public Contact BillToContact { get; set; }

        public Note Note { get; set; }

        public User Psychologist { get; set; }

        public ArbitrationStatus ArbitrationStatus { get; set; }

        public bool IsNew()
        {
            return ArbitrationId == 0;
        }
    }
}
