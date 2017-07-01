using log4net;
using PsychologicalServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PsychologicalServices.Models.Reports
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository = null;
        private readonly IReportStatusValidator _reportStatusValidator = null;
        private readonly IReportTypeValidator _reportTypeValidator = null;
        private readonly ILog _log = null;

        public ReportService(
            IReportRepository reportRepository,
            IReportStatusValidator reportStatusValidator,
            IReportTypeValidator reportTypeValidator,
            ILog log
        )
        {
            _reportRepository = reportRepository;
            _reportStatusValidator = reportStatusValidator;
            _reportTypeValidator = reportTypeValidator;
            _log = log;
        }

        public ReportStatus GetReportStatus(int id)
        {
            var reportStatus = _reportRepository.GetReportStatus(id);

            return reportStatus;
        }

        public ReportType GetReportType(int id)
        {
            var reportType = _reportRepository.GetReportType(id);

            return reportType;
        }

        public IEnumerable<ReportStatus> GetReportStatuses(bool? isActive = true)
        {
            var reportStatuses = _reportRepository.GetReportStatuses(isActive);

            return reportStatuses;
        }

        public IEnumerable<ReportType> GetAssessmentTypeReportTypes(int assessmentTypeId)
        {
            var reportTypes = _reportRepository.GetAssessmentTypeReportTypes(assessmentTypeId);

            return reportTypes;
        }

        public IEnumerable<ReportType> GetReportTypes(bool? isActive = true)
        {
            var reportTypes = _reportRepository.GetReportTypes(isActive);

            return reportTypes;
        }

        public SaveResult<ReportStatus> SaveReportStatus(ReportStatus reportStatus)
        {
            var result = new SaveResult<ReportStatus>();

            try
            {
                var validation = _reportStatusValidator.Validate(reportStatus);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _reportRepository.SaveReportStatus(reportStatus);

                    result.Item = _reportRepository.GetReportStatus(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveReportStatus", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public SaveResult<ReportType> SaveReportType(ReportType reportType)
        {
            var result = new SaveResult<ReportType>();

            try
            {
                var validation = _reportTypeValidator.Validate(reportType);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var id = _reportRepository.SaveReportType(reportType);

                    result.Item = _reportRepository.GetReportType(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveReportType", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }
    }
}
