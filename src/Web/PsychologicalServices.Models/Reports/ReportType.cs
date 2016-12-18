using System;

namespace PsychologicalServices.Models.Reports
{
    public class ReportType
    {
        public int ReportTypeId { get; set; }

        public string Name { get; set; }

        public int NumberOfReports { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return ReportTypeId == 0;
        }
    }
}
