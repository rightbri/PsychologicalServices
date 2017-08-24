using System;

namespace PsychologicalServices.Models.Analysis
{
    public class CancellationData
    {
        public int AssessmentId { get; set; }

        public int ReferralSourceId { get; set; }

        public string ReferralSource { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public int AppointmentCount { get; set; }

        public int BillableCount { get; set; }

        public int CanceledCount { get; set; }
    }
}
