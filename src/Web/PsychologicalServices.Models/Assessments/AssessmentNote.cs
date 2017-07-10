using PsychologicalServices.Models.Notes;
using System;

namespace PsychologicalServices.Models.Assessments
{
    public class AssessmentNote
    {
        public Note Note { get; set; }

        public bool ShowOnCalendar { get; set; }
    }
}
