using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;

namespace PsychologicalServices.Models.Reports
{
    public interface IReportService
    {
        ReportStatus GetReportStatus(int id);

        ReportType GetReportType(int id);

        IEnumerable<ReportStatus> GetReportStatuses(bool? isActive = true);

        IEnumerable<ReportType> GetAssessmentTypeReportTypes(int assessmentTypeId);

        IEnumerable<ReportType> GetReportTypes(bool? isActive = true);

        SaveResult<ReportStatus> SaveReportStatus(ReportStatus reportStatus);

        SaveResult<ReportType> SaveReportType(ReportType reportType);
    }
}
