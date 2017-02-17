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
        private readonly IDate _now = null;
        private readonly IClaimValidator _claimValidator = null;
        private readonly IAppointmentValidator _appointmentValidator = null;
        private readonly IEmailAddressValidator _emailAddressValidator = null;
        private readonly IMedRehabValidator _medRehabValidator = null;

        public AssessmentValidator(
            IAssessmentRepository assessmentRepository,
            IReferralRepository referralRepository,
            IReportRepository reportRepository,
            IUserRepository userRepository,
            ICompanyRepository companyRepository,
            IDate now,
            IClaimValidator claimValidator,
            IAppointmentValidator appointmentValidator,
            IEmailAddressValidator emailAddressValidator,
            IMedRehabValidator medRehabValidator
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
            _emailAddressValidator = emailAddressValidator;
            _medRehabValidator = medRehabValidator;
        }

        public IValidationResult Validate(Assessment item)
        {
            var result = new ValidationResult
            {
                ValidationErrors = new List<IValidationError>(),
            };

            if (null == item.AssessmentType)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "AssessmentTypeId", Message = "Please select an assessment type" }
                );
            }
            else
            {
                var assessmentType = _assessmentRepository.GetAssessmentType(item.AssessmentType.AssessmentTypeId);

                if (null == assessmentType)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "AssessmentTypeId", Message = "Invalid assessment type" }
                    );
                }
                else if (!assessmentType.IsActive)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "AssessmentTypeId", Message = "The selected assessment type is not active." }
                    );
                }
            }
            
            if (null == item.ReferralType)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "ReferralTypeId", Message = "Please select a referral type" }
                );
            }
            else
            {
                var referralType = _referralRepository.GetReferralType(item.ReferralType.ReferralTypeId);

                if (null == referralType)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ReferralTypeId", Message = "Invalid referral type" }
                    );
                }
                else if (!referralType.IsActive)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ReferralTypeId", Message = "The selected referral type is not active." }
                    );
                }
                else
                {
                    if (null != item.IssuesInDispute)
                    {
                        result.ValidationErrors.AddRange(
                            item.IssuesInDispute
                                .Where(issueInDispute => !referralType.IssuesInDispute.Any(referralTypeIssuesInDispute => referralTypeIssuesInDispute.IssueInDisputeId == issueInDispute.IssueInDisputeId))
                                .Select(issueInDispute => new ValidationError { PropertyName = "IssuesInDispute", Message = string.Format("{0} is not a valid issue in dispute for referral type {1}", issueInDispute.Name, referralType.Name) })
                        );
                    }
                }
            }
            
            if (null == item.ReferralSource)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "ReferralSourceId", Message = "Please select a referral source" }
                );
            }
            else
            {
                var referralSource = _referralRepository.GetReferralSource(item.ReferralSource.ReferralSourceId);

                if (null == referralSource)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ReferralSourceId", Message = "Invalid referral source" }
                    );
                }
                else if (!referralSource.IsActive)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ReferralSourceId", Message = "The selected referral source is not active." }
                    );
                }
            }
            
            if (null == item.ReportStatus)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "ReportStatusId", Message = "Please select a report status" }
                );
            }
            else
            {
                var reportStatus = _reportRepository.GetReportStatus(item.ReportStatus.ReportStatusId);

                if (null == reportStatus)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ReportStatusId", Message = "Invalid report status" }
                    );
                }
                else if (!reportStatus.IsActive)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ReportStatusId", Message = "The selected report status is not active." }
                    );
                }
            }
            
            if (null != item.DocListWriter)
            {
                var docListWriters = _userRepository.GetUsers(new UserSearchCriteria
                {
                    UserId = item.DocListWriter.UserId,
                    RightId = (int)StaticRights.WriteDocList,
                    CompanyId = item.Company.CompanyId,
                });

                if (!docListWriters.Any())
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "DocListWriterId", Message = "Invalid doc list writer" }
                    );
                }
                else if (!docListWriters.First().IsActive)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "DocListWriterId", Message = "The selected doc list writer is not active." }
                    );
                }
            }
            
            if (null != item.NotesWriter)
            {
                var notesWriters = _userRepository.GetUsers(new UserSearchCriteria
                {
                    UserId = item.NotesWriter.UserId,
                    RightId = (int)StaticRights.WriteNotes,
                    CompanyId = item.Company.CompanyId,
                });

                if (!notesWriters.Any())
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "NotesWriterId", Message = "Invalid notes writer" }
                    );
                }
                else if (!notesWriters.First().IsActive)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "NotesWriterId", Message = "The selected notes writer is not active." }
                    );
                }
            }
            
            if (item.MedicalFileReceivedDate.HasValue)
            {
                var arbitraryMinimumDate = new DateTime(2015, 1, 1);
                if (item.MedicalFileReceivedDate < arbitraryMinimumDate)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "MedicalFileReceivedDate", Message = string.Format("The medical file received date cannot be before {0}.", arbitraryMinimumDate.ToShortDateString()) }
                    );
                }

                if (item.MedicalFileReceivedDate > _now.Now)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "MedicalFileReceivedDate", Message = "The medical file received date cannot be in the future." }
                    );
                }
            }
            
            if (item.FileSize.HasValue)
            {
                if (item.FileSize < 0)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "FileSize", Message = "The file size cannot be less than zero." }
                    );
                }
            }
            
            if (null == item.Company)
            {
                result.ValidationErrors.Add(
                    new ValidationError { PropertyName = "CompanyId", Message = "Please select a company" }
                );
            }
            else
            {
                var company = _companyRepository.GetCompany(item.Company.CompanyId);

                if (null == company)
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "CompanyId", Message = "Invalid company" }
                    );
                }
            }
            
            if (!string.IsNullOrEmpty(item.ReferralSourceContactEmail))
            {
                if (!_emailAddressValidator.IsValid(item.ReferralSourceContactEmail))
                {
                    result.ValidationErrors.Add(
                        new ValidationError { PropertyName = "ReferralSourceContactEmail", Message = string.Format("'{0}' is not a valid email address", item.ReferralSourceContactEmail) }
                    );
                }
            }

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

            if (null != item.MedRehabs)
            {
                foreach (var medRehab in item.MedRehabs)
                {
                    result.ValidationErrors.AddRange(
                        _medRehabValidator.Validate(medRehab).ValidationErrors
                    );
                }
            }

            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
