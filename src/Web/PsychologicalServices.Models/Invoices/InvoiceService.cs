using log4net;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Companies;
using PsychologicalServices.Models.Referrals;
using PsychologicalServices.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IAssessmentRepository _assessmentRepository = null;
        private readonly IClaimRepository _claimRepository = null;
        private readonly ICompanyRepository _companyRepository = null;
        private readonly IReferralRepository _referralRepository = null;
        private readonly IUserService _userService = null;
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IInvoiceValidator _invoiceValidator = null;
        private readonly IInvoiceConfigurationValidator _invoiceConfigurationValidator = null;
        private readonly IPsychologistInvoiceGenerator _psychologistInvoiceGenerator = null;
        private readonly IPsychometristInvoiceGenerator _psychometristInvoiceGenerator = null;
        private readonly IDate _date = null;
        private readonly ILog _log = null;
        private readonly ITimezoneService _timezoneService = null;
        private readonly IMailService _mailService = null;

        public InvoiceService(
            IAppointmentRepository appointmentRepository,
            IAssessmentRepository assessmentRepository,
            IClaimRepository claimRepository,
            ICompanyRepository companyRepository,
            IReferralRepository referralRepository,
            IUserService userService,
            IInvoiceRepository invoiceRepository,
            IInvoiceValidator invoiceValidator,
            IInvoiceConfigurationValidator invoiceConfigurationValidator,
            IPsychologistInvoiceGenerator psychologistInvoiceGenerator,
            IPsychometristInvoiceGenerator psychometristInvoiceGenerator,
            IDate date,
            ILog log,
            ITimezoneService timezoneService,
            IMailService mailService
        )
        {
            _appointmentRepository = appointmentRepository;
            _assessmentRepository = assessmentRepository;
            _claimRepository = claimRepository;
            _companyRepository = companyRepository;
            _referralRepository = referralRepository;
            _userService = userService;
            _invoiceRepository = invoiceRepository;
            _psychologistInvoiceGenerator = psychologistInvoiceGenerator;
            _psychometristInvoiceGenerator = psychometristInvoiceGenerator;
            _invoiceValidator = invoiceValidator;
            _invoiceConfigurationValidator = invoiceConfigurationValidator;
            _date = date;
            _log = log;
            _timezoneService = timezoneService;
            _mailService = mailService;
        }
        
        public Invoice GetInvoice(int id)
        {
            var invoice = _invoiceRepository.GetInvoice(id);

            return invoice;
        }

        public Invoice CreatePsychologistInvoice(int appointmentId)
        {
            var appointment = _appointmentRepository.GetAppointmentForPsychologistInvoice(appointmentId);

            var invoice = _psychologistInvoiceGenerator.CreateInvoice(appointment);

            var invoiceId = _invoiceRepository.SaveInvoice(invoice);

            return _invoiceRepository.GetInvoice(invoiceId);
        }
        
        public Invoice CreatePsychometristInvoice(PsychometristInvoiceCreationParameters parameters)
        {
            var user = _userService.GetUserById(parameters.PsychometristId);

            var company = _companyRepository.GetCompany(parameters.CompanyId);
            
            var invoiceDate = new DateTimeOffset(parameters.Year, parameters.Month, 1, 0, 0, 0, _timezoneService.GetTimeZoneInfo(company.Timezone).BaseUtcOffset).EndOfMonth(company.Timezone);

            var invoice = _psychometristInvoiceGenerator.CreateInvoice(user, invoiceDate);

            var invoiceId = _invoiceRepository.SaveInvoice(invoice);

            return _invoiceRepository.GetInvoice(invoiceId);
        }

        public InvoiceDocument GetInvoiceDocument(int invoiceDocumentId)
        {
            var invoiceDocument = _invoiceRepository.GetInvoiceDocument(invoiceDocumentId);

            return invoiceDocument;
        }
        
        public InvoiceConfiguration GetInvoiceConfiguration(int companyId)
        {
            var configuration = _invoiceRepository.GetInvoiceConfiguration(companyId);

            var updatedConfiguration = FillInvoiceConfiguration(configuration);

            return updatedConfiguration;
        }

        public IEnumerable<InvoiceLineGroup> GetInvoiceLineGroups(Invoice invoice)
        {
            IEnumerable<InvoiceLineGroup> invoiceLineGroups = null;

            if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychologist)
            {
                invoiceLineGroups = _psychologistInvoiceGenerator.GetInvoiceLineGroups(invoice);
            }
            else if (invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychometrist)
            {
                invoiceLineGroups = _psychometristInvoiceGenerator.GetInvoiceLineGroups(invoice);
            }
            else
            {
                throw new ArgumentOutOfRangeException("invoice", $"Invoice type {invoice.InvoiceType.InvoiceTypeId} is not supported");
            }

            return invoiceLineGroups;
        }
        
        public IEnumerable<InvoiceStatus> GetInvoiceStatuses(bool? isActive = true)
        {
            var invoiceStatuses = _invoiceRepository.GetInvoiceStatuses(isActive);

            return invoiceStatuses;
        }

        public IEnumerable<InvoiceType> GetInvoiceTypes(bool? isActive = true)
        {
            var invoiceTypes = _invoiceRepository.GetInvoiceTypes(isActive);

            return invoiceTypes;
        }

        public IEnumerable<InvoiceDocument> GetInvoiceDocuments(int invoiceId)
        {
            var invoiceDocuments = _invoiceRepository.GetInvoiceDocuments(invoiceId);

            return invoiceDocuments;
        }

        public IEnumerable<Invoice> GetInvoices(InvoiceSearchCriteria criteria)
        {
            var invoices = _invoiceRepository.GetInvoices(criteria);

            return invoices;
        }
        
        public IEnumerable<InvoiceableAppointmentData> GetInvoiceableAppointmentData(InvoiceableAppointmentDataSearchCriteria criteria)
        {
            var data = _invoiceRepository.GetInvoiceableAppointmentData(criteria);

            return data;
        }

        public SaveResult<Invoice> SaveInvoice(Invoice invoice)
        {
            var result = new SaveResult<Invoice>();

            try
            {
                var validation = _invoiceValidator.Validate(invoice);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var total = 0;

                    switch (invoice.InvoiceType.InvoiceTypeId)
                    {
                        case InvoiceType.Psychometrist:
                            total = _psychometristInvoiceGenerator.GetInvoiceTotal(invoice);
                            break;
                        case InvoiceType.Psychologist:
                            total = _psychologistInvoiceGenerator.GetInvoiceTotal(invoice);
                            break;
                        default:
                            break;
                    }

                    invoice.Total = total;

                    var id = _invoiceRepository.SaveInvoice(invoice);

                    result.Item = _invoiceRepository.GetInvoice(id);
                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveInvoice", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public SaveResult<InvoiceConfiguration> SaveInvoiceConfiguration(InvoiceConfiguration invoiceConfiguration)
        {
            var result = new SaveResult<InvoiceConfiguration>();

            try
            {
                var validation = _invoiceConfigurationValidator.Validate(invoiceConfiguration);

                result.ValidationResult = validation;

                if (result.ValidationResult.IsValid)
                {
                    var companyId = _invoiceRepository.SaveInvoiceConfiguration(invoiceConfiguration);

                    result.Item = _invoiceRepository.GetInvoiceConfiguration(companyId);

                    result.IsSaved = true;
                }
            }
            catch (Exception ex)
            {
                _log.Error("SaveInvoiceConfiguration", ex);
                result.IsError = true;
                result.ErrorDetails = ex.Message;
            }

            return result;
        }

        public PsychologistInvoiceSendResult SendPsychologistInvoiceDocument(PsychologistInvoiceSendParameters parameters)
        {
            var result = new PsychologistInvoiceSendResult();

            var model = GetPsychologistInvoiceSendModel(parameters.InvoiceDocumentId);

            if (model.IsValid)
            {
                var from = model.CompanyEmail;
                var to = model.InvoicesContactEmail;
                var subject = "Invoice";
                var body = $"Please see the attached invoice regarding the services for {model.ClaimantName}.";

                var message = new MailMessage(from, to, subject, body);

                message.CC.Add(model.PsychologistEmail);

                message.Attachments.Add(
                    new Attachment(new MemoryStream(model.Document.Content), model.Document.FileName)
                );

                var mailResult = _mailService.Send(message);
                
                if (!string.IsNullOrWhiteSpace(mailResult.ErrorDetails))
                {
                    result.Errors.Add(mailResult.ErrorDetails);
                }

                var logId = _invoiceRepository.LogInvoiceDocumentSent(model.Document.InvoiceDocumentId, model.InvoicesContactEmail);

                result.SendLogs = _invoiceRepository.GetInvoiceDocumentSendLogs(model.Document.InvoiceDocumentId);

                result.Success = mailResult.MailSent && !mailResult.IsError;
            }
            else
            {
                result.Errors.AddRange(model.Errors);
            }
            
            return result;
        }

        private PsychologistInvoiceSendModel GetPsychologistInvoiceSendModel(int invoiceDocumentId)
        {
            var model = new PsychologistInvoiceSendModel();

            var errors = new List<string>();

            InvoiceDocument document = null;
            Invoice invoice = null;
            Appointment appointment = null;
            Claims.Claimant claimant = null;

            document = _invoiceRepository.GetInvoiceDocument(invoiceDocumentId);

            var hasDocument = null != document;

            if (!hasDocument)
            {
                errors.Add("The selected invoice document does not exist");
            }
            else
            {
                model.Document = document;

                invoice = _invoiceRepository.GetInvoiceForDocument(invoiceDocumentId);
            }

            var hasInvoice = hasDocument && null != invoice;
            var hasPsychologistInvoice = hasInvoice && null != invoice.InvoiceType && invoice.InvoiceType.InvoiceTypeId == InvoiceType.Psychologist;

            if (!hasPsychologistInvoice)
            {
                errors.Add("The selected invoice document is not from a psychologist invoice");
            }

            var hasAppointments = hasPsychologistInvoice &&
                (null != invoice.LineGroups && invoice.LineGroups.Any(lineGroup => null != lineGroup.Appointment));
                
            if (hasAppointments)
            {
                appointment = invoice.LineGroups.First(lineGroup => null != lineGroup.Appointment).Appointment;
            }
            else
            {
                errors.Add("The selected invoice has no appointment");
            }

            var hasAssessment = hasAppointments && null != appointment && null != appointment.Assessment;

            var hasReferralSource = hasAssessment && null != appointment.Assessment.ReferralSource;

            var hasInvoiceContactEmail = hasReferralSource &&
                (null != appointment.Assessment.ReferralSource && !string.IsNullOrWhiteSpace(appointment.Assessment.ReferralSource.InvoicesContactEmail));

            if (hasInvoiceContactEmail)
            {
                model.InvoicesContactEmail = appointment.Assessment.ReferralSource.InvoicesContactEmail;
            }
            else
            {
                errors.Add("The referral source has no invoices contact email address");
            }

            var hasClaims = hasAssessment && null != appointment.Assessment.Claims && appointment.Assessment.Claims.Any();

            if (!hasClaims)
            {
                errors.Add("The related assessment has no claim/claimant");
            }
            else
            {
                claimant = appointment.Assessment.Claims.First().Claimant;
            }

            var hasClaimant = null != claimant;

            if (hasClaimant)
            {
                model.ClaimantName = $"{claimant.FirstName} {claimant.LastName}";
            }

            var hasCompanyEmail = hasAssessment && null != appointment.Assessment.Company && !string.IsNullOrWhiteSpace(appointment.Assessment.Company.Email);

            if (hasCompanyEmail)
            {
                model.CompanyEmail = appointment.Assessment.Company.Email;
            }
            else
            {
                errors.Add("The related assessment has no company email");
            }

            var hasPsychologistEmail = hasAppointments && null != appointment.Psychologist && !string.IsNullOrWhiteSpace(appointment.Psychologist.Email);

            if (hasPsychologistEmail)
            {
                model.PsychologistEmail = appointment.Psychologist.Email;
            }
            else
            {
                errors.Add("The psychologist has no email");
            }

            model.Errors = errors;

            return model;
        }

        private InvoiceConfiguration FillInvoiceConfiguration(InvoiceConfiguration configuration)
        {
            var appointmentStatuses = _appointmentRepository.GetAppointmentStatuses();
            var appointmentSequences = _appointmentRepository.GetAppointmentSequences();
            var assessmentTypes = _assessmentRepository.GetAssessmentTypes();
            var issuesInDispute = _claimRepository.GetIssuesInDispute();
            var referralSources = _referralRepository.GetReferralSources(new ReferralSourceSearchCriteria { IsActive = true });

            //add missing appointment status invoice rates with default values
            var appointmentStatusInvoiceRates = new List<AppointmentStatusInvoiceRate>(
                configuration.AppointmentStatusInvoiceRates
            ).Union(
                (from rs in referralSources
                 from appst in appointmentStatuses
                 from appsq in appointmentSequences
                 where appst.CanInvoice &&
                 (
                    (appsq.AppointmentSequenceId == AppointmentSequence.First) ||
                    (appsq.AppointmentSequenceId == AppointmentSequence.Subsequent && appst.AppointmentStatusId != AppointmentStatus.Complete) ||
                    (appsq.AppointmentSequenceId == AppointmentSequence.Last && appst.AppointmentStatusId == AppointmentStatus.Complete)
                 )
                 select new { ReferralSource = rs, AppointmentStatus = appst, AppointmentSequence = appsq }
                )
                .Where(apir =>
                    !configuration.AppointmentStatusInvoiceRates.Any(appointmentStatusInvoiceRate =>
                        appointmentStatusInvoiceRate.ReferralSource.ReferralSourceId == apir.ReferralSource.ReferralSourceId &&
                        appointmentStatusInvoiceRate.AppointmentStatus.AppointmentStatusId == apir.AppointmentStatus.AppointmentStatusId &&
                        appointmentStatusInvoiceRate.AppointmentSequence.AppointmentSequenceId == apir.AppointmentSequence.AppointmentSequenceId
                    )
                )
                .Select(apir =>
                    new AppointmentStatusInvoiceRate
                    {
                        ReferralSource = apir.ReferralSource,
                        AppointmentStatus = apir.AppointmentStatus,
                        AppointmentSequence = apir.AppointmentSequence,
                        ApplyCompletionFee = InvoiceDefaults.ApplyCompletionFee,
                        ApplyExtraReportFees = InvoiceDefaults.ApplyExtraReportFees,
                        ApplyIssueInDisputeFees = InvoiceDefaults.ApplyIssueInDisputeFees,
                        ApplyLargeFileFee = InvoiceDefaults.ApplyLargeFileFee,
                        ApplyTravelFee = InvoiceDefaults.ApplyTravelFee,
                        InvoiceRate = InvoiceDefaults.InvoiceRate,
                    })
            );

            //add missing assessment type invoice amounts with default values
            var assessmentTypeInvoiceAmounts = new List<AssessmentTypeInvoiceAmount>(
                configuration.AssessmentTypeInvoiceAmounts
            ).Union(
                (from rs in referralSources
                 from at in assessmentTypes
                 select new { ReferralSource = rs, AssessmentType = at }
                )
                .Where(rsat =>
                    !configuration.AssessmentTypeInvoiceAmounts.Any(assessmentTypeInvoiceAmount =>
                        assessmentTypeInvoiceAmount.ReferralSource.ReferralSourceId == rsat.ReferralSource.ReferralSourceId &&
                        assessmentTypeInvoiceAmount.AssessmentType.AssessmentTypeId == rsat.AssessmentType.AssessmentTypeId
                    )
                )
                .Select(rsat =>
                    new AssessmentTypeInvoiceAmount
                    {
                        ReferralSource = rsat.ReferralSource,
                        AssessmentType = rsat.AssessmentType,
                        SingleReportInvoiceAmount = InvoiceDefaults.SingleReportInvoiceAmount,
                        ComboReportInvoiceAmount = InvoiceDefaults.ComboReportInvoiceAmount,
                    })
            );

            //add missing issue in dispute invoice amounts with default values
            var issueInDisputeInvoiceAmounts = new List<IssueInDisputeInvoiceAmount>(
                configuration.IssueInDisputeInvoiceAmounts
            ).Union(
                issuesInDispute.Where(issueInDispute =>
                    !configuration.IssueInDisputeInvoiceAmounts.Any(issueInDisputeInvoiceAmount =>
                        issueInDisputeInvoiceAmount.IssueInDispute.IssueInDisputeId == issueInDispute.IssueInDisputeId
                    )
                )
                .Select(issueInDispute =>
                    new IssueInDisputeInvoiceAmount
                    {
                        IssueInDispute = issueInDispute,
                        InvoiceAmount = InvoiceDefaults.IssueInDisputeInvoiceAmount,
                    })
            );

            //add missing psychometrist invoice amounts with default values
            var psychometristInvoiceAmounts = new List<PsychometristInvoiceAmount>(
                configuration.PsychometristInvoiceAmounts
            ).Union(
                (from at in assessmentTypes
                 from appst in appointmentStatuses
                 from appsq in appointmentSequences
                 where appst.CanInvoice &&
                 (
                    (appsq.AppointmentSequenceId == AppointmentSequence.First) ||
                    (appsq.AppointmentSequenceId == AppointmentSequence.Subsequent && appst.AppointmentStatusId != AppointmentStatus.Complete) ||
                    (appsq.AppointmentSequenceId == AppointmentSequence.Last && appst.AppointmentStatusId == AppointmentStatus.Complete)
                 )
                 select new { AssessmentType = at, AppointmentStatus = appst, AppointmentSequence = appsq }
                )
                .Where(pia =>
                    !configuration.PsychometristInvoiceAmounts.Any(psychometristInvoiceAmount =>
                        psychometristInvoiceAmount.AssessmentType.AssessmentTypeId == pia.AssessmentType.AssessmentTypeId &&
                        psychometristInvoiceAmount.AppointmentStatus.AppointmentStatusId == pia.AppointmentStatus.AppointmentStatusId &&
                        psychometristInvoiceAmount.AppointmentSequence.AppointmentSequenceId == pia.AppointmentSequence.AppointmentSequenceId
                    )
                )
                .Select(pia =>
                    new PsychometristInvoiceAmount
                    {
                        AssessmentType = pia.AssessmentType,
                        AppointmentStatus = pia.AppointmentStatus,
                        AppointmentSequence = pia.AppointmentSequence,
                        InvoiceAmount = InvoiceDefaults.PsychometristInvoiceAmount,
                    })
            );
            
            //add missing referral source configurations with default values
            var referralSourceInvoiceConfigurations = new List<ReferralSourceInvoiceConfiguration>(
                configuration.ReferralSourceInvoiceConfigurations
            ).Union(
                referralSources.Where(referralSource =>
                    !configuration.ReferralSourceInvoiceConfigurations.Any(referralSourceInvoiceConfiguration =>
                        referralSourceInvoiceConfiguration.ReferralSource.ReferralSourceId == referralSource.ReferralSourceId
                    )
                )
                .Select(referralSource =>
                    new ReferralSourceInvoiceConfiguration
                    {
                        ReferralSource = referralSource,
                        CompletionFee = InvoiceDefaults.CompletionFee,
                        ExtraReportFee = InvoiceDefaults.ExtraReportFee,
                        LargeFileFee = InvoiceDefaults.LargeFileFee,
                        LargeFileSize = InvoiceDefaults.LargeFileSize,
                    })
            );

            var newConfiguration = new InvoiceConfiguration
            {
                CompanyId = configuration.CompanyId,
                AssessmentTypeInvoiceAmounts = assessmentTypeInvoiceAmounts,
                AppointmentStatusInvoiceRates = appointmentStatusInvoiceRates,
                IssueInDisputeInvoiceAmounts = issueInDisputeInvoiceAmounts,
                PsychometristInvoiceAmounts = psychometristInvoiceAmounts,
                ReferralSourceInvoiceConfigurations = referralSourceInvoiceConfigurations,
            };
            
            return newConfiguration;
        }
    }
}
