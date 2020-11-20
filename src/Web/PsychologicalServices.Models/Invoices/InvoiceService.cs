using log4net;
using PsychologicalServices.Models.Appointments;
using PsychologicalServices.Models.Assessments;
using PsychologicalServices.Models.Claims;
using PsychologicalServices.Models.Common;
using PsychologicalServices.Models.Common.Utility;
using PsychologicalServices.Models.Referrals;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PsychologicalServices.Models.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IDate _date = null;
        private readonly IAppointmentRepository _appointmentRepository = null;
        private readonly IAssessmentRepository _assessmentRepository = null;
        private readonly IClaimRepository _claimRepository = null;
        private readonly IReferralRepository _referralRepository = null;
        private readonly IInvoiceRepository _invoiceRepository = null;
        private readonly IInvoiceValidator _invoiceValidator = null;
        private readonly IInvoiceConfigurationValidator _invoiceConfigurationValidator = null;
        private readonly ILog _log = null;
        private readonly IInvoiceSender _invoiceSender = null;
        private readonly IInvoiceSendModelFactory _invoiceSendModelFactory = null;
        private readonly IInvoiceGenerator _invoiceGenerator = null;

        public InvoiceService(
            IDate date,
            IAppointmentRepository appointmentRepository,
            IAssessmentRepository assessmentRepository,
            IClaimRepository claimRepository,
            IReferralRepository referralRepository,
            IInvoiceRepository invoiceRepository,
            IInvoiceValidator invoiceValidator,
            IInvoiceConfigurationValidator invoiceConfigurationValidator,
            ILog log,
            IInvoiceSender invoiceSender,
            IInvoiceSendModelFactory invoiceSendModelFactory,
            IInvoiceGenerator invoiceGenerator
        )
        {
            _date = date;
            _appointmentRepository = appointmentRepository;
            _assessmentRepository = assessmentRepository;
            _claimRepository = claimRepository;
            _referralRepository = referralRepository;
            _invoiceRepository = invoiceRepository;
            _invoiceValidator = invoiceValidator;
            _invoiceConfigurationValidator = invoiceConfigurationValidator;
            _log = log;
            _invoiceSender = invoiceSender;
            _invoiceSendModelFactory = invoiceSendModelFactory;
            _invoiceGenerator = invoiceGenerator;
        }
        
        public Invoice GetInvoice(int id)
        {
            var invoice = _invoiceRepository.GetInvoice(id);

            return invoice;
        }

        public Invoice CreatePsychologistInvoice(int appointmentId)
        {
            var invoice = _invoiceGenerator.CreatePsychologistInvoice(appointmentId);

            return invoice;
        }

        public Invoice CreatePsychometristInvoice(PsychometristInvoiceCreationParameters parameters)
        {
            var invoice = _invoiceGenerator.CreatePsychometristInvoice(parameters);

            return invoice;
        }

        public Invoice CreateArbitrationInvoice(ArbitrationInvoiceCreationParameters parameters)
        {
            var invoice = _invoiceGenerator.CreateArbitrationInvoice(parameters);

            return invoice;
        }

        public Invoice CreateRawTestDataInvoice(RawTestDataInvoiceCreationParameters parameters)
        {
            var invoice = _invoiceGenerator.CreateRawTestDataInvoice(parameters);

            return invoice;
        }

        public Invoice CreateConsultingInvoice(ConsultingInvoiceCreationParameters parameters)
        {
            var invoice = _invoiceGenerator.CreateConsultingInvoice(parameters);

            return invoice;
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
            var invoiceLineGroups = _invoiceGenerator.GetInvoiceLineGroups(invoice);

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

        public IEnumerable<InvoiceableArbitrationData> GetInvoiceableArbitrationData(InvoiceableArbitrationDataSearchCriteria criteria)
        {
            var data = _invoiceRepository.GetInvoiceableArbitrationData(criteria);

            return data;
        }

        public IEnumerable<InvoiceableRawTestDataData> GetInvoiceableRawTestDataData(InvoiceableRawTestDataSearchCriteria criteria)
        {
            var data = _invoiceRepository.GetInvoiceableRawTestData(criteria);

            return data;
        }

        public IEnumerable<InvoiceableConsultingAgreementData> GetInvoiceableConsultingAgreementData(InvoiceableConsultingAgreementSearchCriteria criteria)
        {
            var now = _date.UtcNow;

            if (
                criteria.Month < 1 ||
                criteria.Month > 12 ||
                criteria.Year < now.Year - 1 ||
                criteria.Year > now.Year ||
                (criteria.Year == now.Year && criteria.Month > now.Month)
            )
            {
                return Enumerable.Empty<InvoiceableConsultingAgreementData>();
            }

            return _invoiceRepository.GetInvoiceableConsultingAgreementData(criteria);
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
                    var total = _invoiceGenerator.GetInvoiceTotal(invoice);

                    invoice.Total = total;

                    if (invoice.InvoiceStatus.SaveDocument)
                    {
                        invoice.InvoiceDate = _date.UtcNow;
                    }

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

        public InvoiceSendResult SendInvoiceDocument(InvoiceSendParameters parameters)
        {
            if (null == parameters)
            {
                throw new ArgumentNullException("parameters");
            }

            var invoice = _invoiceRepository.GetInvoiceForDocument(parameters.InvoiceDocumentId);

            if (null == invoice)
            {
                return InvoiceSendResult.Error("Invoice not found", InvoiceSendErrorType.InvoiceNotFound);
            }

            if (!invoice.InvoiceType.CanSend)
            {
                return InvoiceSendResult.Error("Invoices of this type cannot be sent", InvoiceSendErrorType.InvoiceTypeCannotBeSent);
            }

            var invoiceDocument = _invoiceRepository.GetInvoiceDocument(parameters.InvoiceDocumentId);

            var hasInvoiceDocument = null != invoiceDocument &&
                !string.IsNullOrWhiteSpace(invoiceDocument.FileName) &&
                null != invoiceDocument.Content;

            if (!hasInvoiceDocument)
            {
                return InvoiceSendResult.Error("Invoice document not found", InvoiceSendErrorType.InvoiceDocumentNotFound);
            }

            var model = _invoiceSendModelFactory.GetInvoiceSendModel(invoice, invoiceDocument);

            if (null == model)
            {
                return InvoiceSendResult.Error("Sending invoices of this type is not yet supported", InvoiceSendErrorType.InvoiceSendModelNotImplemented);
            }

            var result = _invoiceSender.SendInvoiceDocument(model);

            return result;
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
