using System;

namespace PsychologicalServices.Models.Reports
{
    public class Report
    {
        public int ReportId { get; set; }

        public ReportType ReportType { get; set; }

        public int AssessmentId { get; set; }
    }
}
