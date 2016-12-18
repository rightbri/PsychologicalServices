using System;

namespace PsychologicalServices.Models.Reports
{
    public class ReportStatus
    {
        public int ReportStatusId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }

        public bool IsNew()
        {
            return ReportStatusId == 0;
        }
    }
}
