using System;
using System.Linq;
using PsychologicalServices.Models.Common.Validation;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Appointments;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceConfigurationValidator : IInvoiceConfigurationValidator
    {
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IAssessmentRepository _assessmentRepository = null;
        private readonly IClaimRepository _claimRepository = null;
        private readonly IReferralRepository _referralRepository = null;

        public InvoiceConfigurationValidator(
            IAppointmentRepository appointmentRepository,
            IAssessmentRepository assessmentRepository,
            IClaimRepository claimRepository,
            IReferralRepository referralRepository
        )
        {
            _appointmentRepository = appointmentRepository;
            _assessmentRepository = assessmentRepository;
            _claimRepository = claimRepository;
            _referralRepository = referralRepository;
        }

        public IValidationResult Validate(InvoiceConfiguration item)
        {
            var result = new ValidationResult();

            var appointmentSequences = _appointmentRepository.GetAppointmentSequences();

            var appointmentStatuses = _appointmentRepository.GetAppointmentStatuses();

            var assessmentTypes = _assessmentRepository.GetAssessmentTypes();

            var referralSources = _referralRepository.GetReferralSources(new ReferralSourceSearchCriteria());
            
            if (null != item.AppointmentStatusInvoiceRates)
            {
                result.ValidationErrors.AddRange(
                    item.AppointmentStatusInvoiceRates
                        .Where(asir => asir.InvoiceRate < 0)
                        .Select(asir =>
                            new ValidationError { PropertyName = "AppointmentStatusInvoiceRates", Message = $"Appointment status invoice rate cannot be less than zero: referral source '{asir.ReferralSource.Name}, appointment status '{asir.AppointmentStatus.Name}, appointment sequence '{asir.AppointmentSequence.Name}'", }
                        )
                );

                result.ValidationErrors.AddRange(
                    item.AppointmentStatusInvoiceRates
                        .Where(asir => !referralSources.Any(rs => rs.ReferralSourceId == asir.ReferralSource.ReferralSourceId))
                        .Select(asir =>
                            new ValidationError { PropertyName = "AppointmentStatusInvoiceRates", Message = $"Invalid referral source {asir.ReferralSource.Name}", }
                        )
                );

                result.ValidationErrors.AddRange(
                    item.AppointmentStatusInvoiceRates
                        .Where(asir => !appointmentStatuses.Any(apps => apps.AppointmentStatusId == asir.AppointmentStatus.AppointmentStatusId))
                        .Select(asir =>
                            new ValidationError { PropertyName = "AppointmentStatusInvoiceRates", Message = $"Invalid appointment status {asir.AppointmentStatus.Name}", }
                        )
                );

                result.ValidationErrors.AddRange(
                    item.AppointmentStatusInvoiceRates
                        .Where(asir => !appointmentSequences.Any(apps => apps.AppointmentSequenceId == asir.AppointmentSequence.AppointmentSequenceId))
                        .Select(asir =>
                            new ValidationError { PropertyName = "AppointmentStatusInvoiceRates", Message = $"Invalid appointment sequence {asir.AppointmentSequence.Name}", }
                        )
                );
            }

            if (null != item.ReferralSourceInvoiceConfigurations)
            {
                result.ValidationErrors.AddRange(
                    item.ReferralSourceInvoiceConfigurations
                        .Where(rsic => rsic.CompletionFee < 0)
                        .Select(rsic =>
                            new ValidationError { PropertyName = "ReferralSourceInvoiceConfigurations", Message = $"Completion fee cannot be less than zero: referral source '{rsic.ReferralSource.Name}'" }
                        )
                );

                result.ValidationErrors.AddRange(
                    item.ReferralSourceInvoiceConfigurations
                        .Where(rsic => rsic.ExtraReportFee < 0)
                        .Select(rsic =>
                            new ValidationError { PropertyName = "ReferralSourceInvoiceConfigurations", Message = $"Extra report fee cannot be less than zero: referral source '{rsic.ReferralSource.Name}'" }
                        )
                );

                result.ValidationErrors.AddRange(
                    item.ReferralSourceInvoiceConfigurations
                        .Where(rsic => rsic.LargeFileFee < 0)
                        .Select(rsic =>
                            new ValidationError { PropertyName = "ReferralSourceInvoiceConfigurations", Message = $"Large file fee cannot be less than zero: referral source '{rsic.ReferralSource.Name}'" }
                        )
                );

                result.ValidationErrors.AddRange(
                    item.ReferralSourceInvoiceConfigurations
                        .Where(rsic => rsic.LargeFileSize < 0)
                        .Select(rsic =>
                            new ValidationError { PropertyName = "ReferralSourceInvoiceConfigurations", Message = $"Large file size cannot be less than zero: referral source '{rsic.ReferralSource.Name}'" }
                        )
                );
                
                result.ValidationErrors.AddRange(
                    item.ReferralSourceInvoiceConfigurations
                        .Where(rsic => !referralSources.Any(rs => rs.ReferralSourceId == rsic.ReferralSource.ReferralSourceId))
                        .Select(rsic =>
                            new ValidationError { PropertyName = "ReferralSourceInvoiceConfigurations", Message = $"Invalid referral source {rsic.ReferralSource.Name}", }
                        )
                );
            }

            if (null != item.AssessmentTypeInvoiceAmounts)
            {
                result.ValidationErrors.AddRange(
                    item.AssessmentTypeInvoiceAmounts
                        .Where(atia => atia.SingleReportInvoiceAmount < 0)
                        .Select(atia =>
                            new ValidationError { PropertyName = "AssessmentTypeInvoiceAmounts", Message = $"Single report invoice amount cannot be less than zero: referral source '{atia.ReferralSource.Name}', assessment type '{atia.AssessmentType.Name}'" }
                        )
                );

                result.ValidationErrors.AddRange(
                    item.AssessmentTypeInvoiceAmounts
                        .Where(atia => atia.ComboReportInvoiceAmount < 0)
                        .Select(atia =>
                            new ValidationError { PropertyName = "AssessmentTypeInvoiceAmounts", Message = $"Combo report invoice amount cannot be less than zero: referral source '{atia.ReferralSource.Name}', assessment type '{atia.AssessmentType.Name}'" }
                        )
                );
                
                result.ValidationErrors.AddRange(
                    item.AssessmentTypeInvoiceAmounts
                        .Where(atia => !assessmentTypes.Any(at => at.AssessmentTypeId == atia.AssessmentType.AssessmentTypeId))
                        .Select(atia =>
                            new ValidationError { PropertyName = "AssessmentTypeInvoiceAmounts", Message = $"Invalid assessment type {atia.AssessmentType.Name}", }
                        )
                );

                result.ValidationErrors.AddRange(
                    item.AssessmentTypeInvoiceAmounts
                        .Where(atia => !referralSources.Any(rs => rs.ReferralSourceId == atia.ReferralSource.ReferralSourceId))
                        .Select(atia =>
                            new ValidationError { PropertyName = "AssessmentTypeInvoiceAmounts", Message = $"Invalid referral source {atia.ReferralSource.Name}", }
                        )
                );
            }
            
            if (null != item.IssueInDisputeInvoiceAmounts)
            {
                result.ValidationErrors.AddRange(
                    item.IssueInDisputeInvoiceAmounts
                        .Where(idia => idia.InvoiceAmount < 0)
                        .Select(idia =>
                            new ValidationError { PropertyName = "IssueInDisputeInvoiceAmounts", Message = $"Invoice amount for issue in dispute {idia.IssueInDispute.Name} cannot be less than zero", }
                        )
                );
                
                var issuesInDispute = _claimRepository.GetIssuesInDispute();

                result.ValidationErrors.AddRange(
                    item.IssueInDisputeInvoiceAmounts
                        .Where(idia => !issuesInDispute.Any(id => id.IssueInDisputeId == idia.IssueInDispute.IssueInDisputeId))
                        .Select(idia =>
                            new ValidationError { PropertyName = "IssueInDisputeInvoiceAmounts", Message = $"Invalid issue in dispute {idia.IssueInDispute.Name}", }
                        )
                );
            }

            if (null != item.PsychometristInvoiceAmounts)
            {
                result.ValidationErrors.AddRange(
                    item.PsychometristInvoiceAmounts
                        .Where(pia => pia.InvoiceAmount < 0)
                        .Select(pia =>
                            new ValidationError { PropertyName = "PsychometristInvoiceAmounts", Message = $"Psychometrist invoice amount cannot be less than zero: assessment type '{pia.AssessmentType.Name}', appointment status '{pia.AppointmentStatus.Name}', appointment sequence '{pia.AppointmentSequence.Name}'" }
                        )
                );
                
                result.ValidationErrors.AddRange(
                    item.PsychometristInvoiceAmounts
                        .Where(pia => !assessmentTypes.Any(at => at.AssessmentTypeId == pia.AssessmentType.AssessmentTypeId))
                        .Select(pia =>
                            new ValidationError { PropertyName = "PsychometristInvoiceAmounts", Message = $"Invalid assessment type {pia.AssessmentType.Name}", }
                        )
                );
                
                result.ValidationErrors.AddRange(
                    item.PsychometristInvoiceAmounts
                        .Where(pia => !appointmentStatuses.Any(apps => apps.AppointmentStatusId == pia.AppointmentStatus.AppointmentStatusId))
                        .Select(pia =>
                            new ValidationError { PropertyName = "PsychometristInvoiceAmounts", Message = $"Invalid appointment status {pia.AppointmentStatus.Name}", }
                        )
                );
                
                result.ValidationErrors.AddRange(
                    item.PsychometristInvoiceAmounts
                        .Where(pia => !appointmentSequences.Any(apps => apps.AppointmentSequenceId == pia.AppointmentSequence.AppointmentSequenceId))
                        .Select(pia =>
                            new ValidationError { PropertyName = "PsychometristInvoiceAmounts", Message = $"Invalid appointment sequence {pia.AppointmentSequence.Name}", }
                        )
                );
            }
            
            result.IsValid = !result.ValidationErrors.Any();

            return result;
        }
    }
}
