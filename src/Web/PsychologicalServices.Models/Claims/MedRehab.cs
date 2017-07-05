using PsychologicalServices.Models.Assessments;
using System;

namespace PsychologicalServices.Models.Claims
{
    public class MedRehab
    {
        public int MedRehabId { get; set; }

        public DateTime Date { get; set; }

        public int Amount { get; set; }

        public string Description { get; set; }

        public bool Deleted { get; set; }

        public int AssessmentId { get; set; }
    }
}
