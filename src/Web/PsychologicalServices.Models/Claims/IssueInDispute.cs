using System;

namespace PsychologicalServices.Models.Claims
{
    public class IssueInDispute
    {
        public int IssueInDisputeId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public decimal AdditionalFee { get; set; }

        public bool IsNew()
        {
            return IssueInDisputeId == 0;
        }
    }
}
