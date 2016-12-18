using System;

namespace PsychologicalServices.Models.Claims
{
    public class IssueInDispute
    {
        public int IssueInDisputeId { get; set; }

        public string Name { get; set; }

        public string Instructions { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return IssueInDisputeId == 0;
        }
    }
}
