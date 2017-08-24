using System;

namespace PsychologicalServices.Models.Analysis
{
    public class CompletionData
    {
        public int AssessmentId { get; set; }

        public DateTimeOffset AppointmentTime { get; set; }

        public int Year { get; set; }

        public int Month { get; set; }

        public string Psychometrist { get; set; }

        public int IncompleteCount { get; set; }

        public int CompleteCount { get; set; }
	
        public bool HasTranslator { get; set; }

        public bool HasReader { get; set; }

        public bool HasPsychiatrist { get; set; }

        public bool IsFemaleClaimant { get; set; }
    }
}
