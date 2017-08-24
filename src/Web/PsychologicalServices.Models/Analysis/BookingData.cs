using System;

namespace PsychologicalServices.Models.Analysis
{
    public class BookingData
    {
        public int AssessmentId { get; set; }

        public int ReferralSourceId { get; set; }

        public string ReferralSource { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public bool IsPsychological { get; set; }

        public bool IsLargeFile { get; set; }
    }
}
