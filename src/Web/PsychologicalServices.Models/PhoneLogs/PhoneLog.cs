using PsychologicalServices.Models.Notes;
using PsychologicalServices.Models.Users;
using System;

namespace PsychologicalServices.Models.PhoneLogs
{
    public class PhoneLog
    {
        public int PhoneLogId { get; set; }

        public DateTimeOffset CallTime { get; set; }

        public string CompanyName { get; set; }

        public string CallerName { get; set; }

        public string ClaimantFirstName { get; set; }

        public string ClaimantLastName { get; set; }

        public Note Note { get; set; }

        public DateTimeOffset CreateDate { get; set; }

        public User CreateUser { get; set; }

        public DateTimeOffset UpdateDate { get; set; }

        public User UpdateUser { get; set; }

        public bool IsNew()
        {
            return PhoneLogId == 0;
        }
    }
}
