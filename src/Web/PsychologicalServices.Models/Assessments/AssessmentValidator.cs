using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Common.Validation;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Reports;
using PsychologicalServices.Models.Rights;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Assessments
{
    public class AssessmentValidator : IAssessmentValidator
    {
        private readonly IAssessmentRepository _assessmentRepository = null;
        private readonly IReferralRepository _referralRepository = null;
        private readonly IReportRepository _reportRepository = null;
        private readonly IUserRepository _userRepository = null;
        private readonly ICompanyRepository _companyRepository = null;
        private readonly INow _now = null;
        private readonly IClaimValidator _claimValidator = null;
        private readonly IAppointmentValidator _appointmentValidator = null;

        public AssessmentValidator(
            IAssessmentRepository assessmentRepository,
            IReferralRepository referralRepository,
            IReportRepository reportRepository,
            IUserRepository userRepository,
            ICompanyRepository companyRepository,
            INow now,
            IClaimValidator claimValidator,
            IAppointmentValidator appointmentValidator
        )
        {
            _assessmentRepository = assessmentRepository;
            _referralRepository = referralRepository;
            _reportRepository = reportRepository;
            _userRepository = userRepository;
            _companyRepository = companyRepository;
            _now = now;
            _claimValidator = claimValidator;
            _appointmentValidator = appointmentValidator;
        }

        public IValidationResult Validate(Assessment item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            var assessmentType = _assessmentRepository.GetAssessmentType(item.AssessmentTypeId);

            if (null == assessmentType)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "AssessmentTypeId", Message = "Invalid assessment type" }
                );
            }
            else if (!assessmentType.IsActive)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "AssessmentTypeId", Message = "The selected assessment type is not active." }
                );
            }

            var referralType = _referralRepository.GetReferralType(item.ReferralTypeId);

            if (null == referralType)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "ReferralTypeId", Message = "Invalid referral type" }
                );
            }
            else if (!referralType.IsActive)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "ReferralTypeId", Message = "The selected referral type is not active." }
                );
            }
            else
            {
                if (null != item.IssuesInDispute)
                {
                    result.ValidationErrors.AddRange(
                        item.IssuesInDispute
                            .Where(issueInDispute => !referralType.IssuesInDispute.Any(referralTypeIssuesInDispute => referralTypeIssuesInDispute.IssueInDisputeId == issueInDispute.IssueInDisputeId))
                            .Select(issueInDispute => new ValidationError { Property = "IssuesInDispute", Message = string.Format("{0} is not a valid issue in dispute for referral type {1}", issueInDispute.Name, referralType.Name) })
                    );
                }
            }

            var referralSource = _referralRepository.GetReferralSource(item.ReferralSourceId);

            if (null == referralSource)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "ReferralSourceId", Message = "Invalid referral source" }
                );
            }
            else if (!referralSource.IsActive)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "ReferralSourceId", Message = "The selected referral source is not active." }
                );
            }

            var reportStatus = _reportRepository.GetReportStatus(item.ReportStatusId);

            if (null == reportStatus)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "ReportStatusId", Message = "Invalid report status" }
                );
            }
            else if (!reportStatus.IsActive)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "ReportStatusId", Message = "The selected report status is not active." }
                );
            }

            var docListWriters = _userRepository.GetUsers(new UserSearchCriteria
            {
                UserId = item.DocListWriterId,
                RightId = (int) StaticRights.WriteDocList,
                CompanyId = item.CompanyId,
            });

            if (!docListWriters.Any())
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "DocListWriterId", Message = "Invalid doc list writer" }
                );
            }
            else if (!docListWriters.First().IsActive)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "DocListWriterId", Message = "The selected doc list writer is not active." }
                );
            }

            var notesWriters = _userRepository.GetUsers(new UserSearchCriteria
            {
                UserId = item.NotesWriterId,
                RightId = (int)StaticRights.WriteNotes,
                CompanyId = item.CompanyId,
            });

            if (!notesWriters.Any())
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "NotesWriterId", Message = "Invalid notes writer" }
                );
            }
            else if (!notesWriters.First().IsActive)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "NotesWriterId", Message = "The selected notes writer is not active." }
                );
            }

            var arbitraryMinimumDate = new DateTime(2015, 1, 1);
            if (item.MedicalFileReceivedDate < arbitraryMinimumDate)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "MedicalFileReceivedDate", Message = string.Format("The medical file received date cannot be before {0}.", arbitraryMinimumDate.ToShortDateString()) }
                );
            }

            if (item.MedicalFileReceivedDate > _now.DateTimeNow)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "MedicalFileReceivedDate", Message = "The medical file received date cannot be in the future." }
                );
            }

            if (item.FileSize < 0)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "FileSize", Message = "The file size cannot be less than zero." }
                );
            }

            var company = _companyRepository.GetCompany(item.CompanyId);

            if (null == company)
            {
                result.ValidationErrors.Add(
                    new ValidationError { Property = "CompanyId", Message = "Invalid company" }
                );
            }

            //public string ReferralSourceContactEmail { get; set; }

            if (null != item.Claims)
            {
                foreach (var claim in item.Claims)
                {
                    result.ValidationErrors.AddRange(
                        _claimValidator.Validate(claim).ValidationErrors
                    );
                }
            }
            
            if (null != item.Appointments)
            {
                foreach (var appointment in item.Appointments)
                {
                    result.ValidationErrors.AddRange(
                        _appointmentValidator.Validate(appointment).ValidationErrors
                    );
                }
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
