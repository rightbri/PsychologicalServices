using System;

namespace PsychologicalServices.Models.Analysis
{
    public class ArbitrationData
    {
        public int AssessmentId { get; set; }

        public int ArbitrationId { get; set; }

        public int ReferralSourceId { get; set; }

        public string ReferralSource { get; set; }

        public int? IssueInDisputeId { get; set; }

        public string IssueInDispute { get; set; }

        public int? LawyerId { get; set; }

        public string Lawyer { get; set; }
    }
}
