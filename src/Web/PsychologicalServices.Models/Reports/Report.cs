using PsychologicalServices.Models.Claims;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Reports
{
    public class Report
    {
        public int ReportId { get; set; }

        public ReportType ReportType { get; set; }

        public int AssessmentId { get; set; }

        public bool IsAdditional { get; set; }

        public IEnumerable<IssueInDispute> IssuesInDispute { get; set; }
    }
}
