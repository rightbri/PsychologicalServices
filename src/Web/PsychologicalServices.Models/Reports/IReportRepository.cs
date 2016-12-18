using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Reports
{
    public interface IReportRepository
    {
        ReportStatus GetReportStatus(int id);

        ReportType GetReportType(int id);

        IEnumerable<ReportStatus> GetReportStatuses(bool? isActive = true);

        IEnumerable<ReportType> GetAssessmentTypeReportTypes(int assessmentTypeId);

        IEnumerable<ReportType> GetReportTypes(bool? isActive = true);

        int SaveReportStatus(ReportStatus reportStatus);

        int SaveReportType(ReportType reportType);
    }
}
